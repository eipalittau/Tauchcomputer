#include "Sensors.h"

const uint8_t CLOCK_ARRAYSIZE = 7;
const uint8_t PRESS_ARRAYSIZE = 2;
const uint8_t TEMPE_ARRAYSIZE = 9;
const uint8_t CALIB_ARRAYSIZE = 7;

#pragma region Constructor / Destructor
Sensors::Sensors() {
	mSensorData = new SensorData();

	Wire.begin();

	mClock = new I2C(0x68);
	mPressure = new I2C(0x76);
	mTemperature = new Wire(2, 8);
	
	Sensors::Pressure_CreateCrc();
}

Sensors::~Sensors() {
	delete mClock;
	delete mPressure;
	delete mTemperature;
	delete mPressureData;
}
#pragma endregion

#pragma region Public
void Sensors::StartMesurement() {
	assert(!_IsCrcOk);
	
	uint8_t lClickSize = CLOCK_ARRAYSIZE;

	mClock.StartMesurement(0x00, lClockSize);
	mTemperature.StartMesurement(0x44);
}

SensorData Sensors::GetData() {
	assert(!_IsCrcOk);
	
	uint8_t lClockData[CLOCK_ARRAYSIZE];
	uint8_t lTemperatureData[TEMPE_ARRAYSIZE];

	if (mClock.GetData(lClockData) >= CLOCK_ARRAYSIZE) {
		mSensorData.DateTime.Second(lClockData[0]);
		mSensorData.DateTime.Minute(lClockData[1]);
		mSensorData.DateTime.Hour(lClockData[2]);
		mSensorData.DateTime.Weekday(lClockData[3]);
		mSensorData.DateTime.Day(lClockData[4]);
		mSensorData.DateTime.Month(lClockData[5]);
		mSensorData.DateTime.Year(lClockData[6] + 2000);
	}
	
	while(mNextAction > millis()) {}

	long lDeltaTemp = Sensors::Pressure_ReadData(0x5A) - mPressureData->ReferenceTemperature();
	long long lSensitivity = mPressureData->Sensitivity + mPressureData->TCS  * lDeltaTemp;
	long long lOffset = mPressureData->Offset + mPressureData->TCO  * lDeltaTemp;
	long lSensitivity2;
	long lOffset2;
	long lTemperature = 2000l + lDeltaTemp * mPressureData->TCT;

	if (lTemperature < 2000) {
		long lTemperature2 = pow(lTemperature - 2000, 2);

		lOffset2 = 3 * lTemperature2 / 2;
		lSensitivity2 = 5 * lTemperature2 / 8;

		if (lTemperature < -1500) {
			long lTemperature3 = pow(lTemperature + 1500l, 2);

			lOffset2 += 7 * lTemperature3;
			lSensitivity2 += 4 * lTemperature3;
		}

		lTemperature -= 3 * pow(lDeltaTemp, 2) / 8589934592LL;
	} else {
		long lTemperature2 = pow(lTemperature - 2000, 2);

		lTemperature -= 2 * pow(lDeltaTemp, 2) / 137438953472LL;
		lOffset2 = lTemperature2 / 16;
		lSensitivity2 = 0;
	}

	mSensorData.Pressure = (Sensors::Pressure_ReadData(0x4A) * (lSensitivity - lSensitivity2) / 2097152l - (lOffset - lOffset2)) / 8192l;
	
	if (Wire.GetData(0xBE, lTemperatureData) == 0) {
		mSensorData.Temperature = (float)((lTemperatureData[1] << 11) | (lTemperatureData[0] << 3));
	}
}
#pragma endregion

#pragma region Private
void Sensors::Pressure_CreateCrc() {
	uint8_t lPressureSize = PRESS_ARRAYSIZE;
	uint8_t lPressureData[PRESS_ARRAYSIZE];
	uint16_t lCalibrationData[CALIB_ARRAYSIZE];

	mPressure.RequestRegister(0x1E); //Reset
	delay(10);

	for (uint8_t lI = 0; lI < CALIB_ARRAYSIZE; lI++) {
		if (mPressure.StartMesurement(0xA0 + (lI * 2), lPressureSize) == 0) { //Read EPROM
			if (lPressureSize == PRESS_ARRAYSIZE && mPressure.GetData(lPressureData) == PRESS_ARRAYSIZE) {
				lCalibrationData[lI] = (lPressureData[0] << 8) | lPressureData[1];
			}
		}
	}
	mNextAction = millis() + 20;
	
	_IsCrcOk = Sensors::Pressure_CheckCrc(lCalibrationData) == (lCalibrationData[0] >> 12);
	if (_IsCrcOk) {
		mPressureData = new PressureData(lCalibrationData);
	}
}

uint32_t Sensors::Pressure_ReadData(uint8_t aRegister) {
	uint8_t lSize = 3;

	if (mPressure.RequestRegister(aRegister) == 0) {
		delay(20);

		if (mPressure.StartMesurement(0x00, lSize) == 0) {
			uint8_t lData[lSize];

			mPressure.GetData(lData);
			
			unsigned long lResult = lData[0];
			lResult = (lResult << 8) | lData[1];
			lResult = (lResult << 8) | lData[2];
			
			mDate.Temperature = lResult;
		}
	}
}

uint8_t Sensors::Pressure_CheckCrc(unsigned int n_prom[]) {
	unsigned int n_rem = 0;

	n_prom[0] = (n_prom[0] & 0x0FFF);
	n_prom[7] = 0;

	for (unsigned char lI = 0; lI < 16; lI++) {
		if (lI % 2 == 1) {
			n_rem ^= (unsigned int)((n_prom[lI >> 1]) & 0x00FF);
		} else {
			n_rem ^= (unsigned int)(n_prom[lI >> 1] >> 8);
		}

		for (uint8_t n_bit = 8; n_bit > 0; n_bit--) {
			if (n_rem & 0x8000) {
				n_rem = (n_rem << 1) ^ 0x3000;
			} else {
				n_rem = (n_rem << 1);
			}
		}
	}

	n_rem = ((n_rem >> 12) & 0x000F);

	return n_rem ^ 0x00;
}
#pragma endregion
