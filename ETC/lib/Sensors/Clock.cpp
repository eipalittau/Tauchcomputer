#include "Sensors.h"

const uint8_t CLOCK_ARRAYSIZE = 7;
const uint8_t PRESS_ARRAYSIZE = 2;
const uint8_t CALIB_ARRAYSIZE = 7;

#pragma region Constructor / Destructor
Sensors::Sensors() {
	Wire.begin();

	mClock = new I2C(0x68);
	mPressure = new I2C(0x76);
	mTemperature = new Wire(2, 8);

	mData = new SensorData();

	uint8_t lSize = PRESS_ARRAYSIZE;
	uint8_t lData[PRESS_ARRAYSIZE];
	uint16_t lCalibrationData[CALIB_ARRAYSIZE];

	_IsCrcOk = false;

	mPressure.RequestRegister(0x1E); //Reset
	delay(10);

	for (uint8_t lI = 0; lI < CALIB_ARRAYSIZE; lI++) {
		if (I2CBase::StartMesurement(0xA0 + (lI * 2), lSize) == 0) { //Read PROM
			if (lSize == PRESS_ARRAYSIZE && I2CBase::GetData(lData) == PRESS_ARRAYSIZE) {
				lCalibrationData[lI] = (lData[0] << 8) | lData[1];
			}
		}
	}

	_IsCrcOk = Pressure::CheckCrc(lCalibrationData) == (lCalibrationData[0] >> 12);

	if (_IsCrcOk) {
		mPressureData = new PressureData(lCalibrationData);
	}
	else {
		mPressureData = NULL;
	}

}

Sensors::~Sensors() {}
#pragma endregion

#pragma region Public
void Sensors::StartMesurement() {
	uint8_t lSize = CLOCK_ARRAYSIZE;

	mClock.StartMesurement(0x00, lSize);
}

SensorData Sensors::GetData() {
	uint8_t lData[CLOCK_ARRAYSIZE];

	if (mClock.GetData(lData) >= CLOCK_ARRAYSIZE) {
		mData.DateTime.Second(lData[0]);
		mData.DateTime.Minute(lData[1]);
		mData.DateTime.Hour(lData[2]);
		mData.DateTime.Weekday(lData[3]);
		mData.DateTime.Day(lData[4]);
		mDate.DateTime.Month(lData[5]);
		mDate.DateTime.Year(lData[6] + 2000);
	}
}
#pragma endregion
