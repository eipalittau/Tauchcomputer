#include "Pressure.h"

//Constructor / Destructor
Pressure::Pressure() : I2CBase(0x76) { //I2C-Adress
	const uint8_t ARRAYSIZE = 2;
	
	uint8_t lSize = ARRAYSIZE;
	uint8_t lData[ARRAYSIZE];
	uint16_t lCalibrationData[7];
	
	_IsCrcOk = false;

	I2CBase::RequestRegister(0x1E); //Reset
	delay(10);
	
	for (unsigned char lI = 0; lI < 7; lI++) {
		if (I2CBase::StartMesurement(0xA0 + (lI * 2), lSize) == 0) { //Read PROM
			if (lSize == ARRAYSIZE && I2CBase::GetData(lData) == ARRAYSIZE) {
				lCalibrationData[i] = (lData[0] << 8) | lData[1];
			}
		}
	}
	
	_IsCrcOk = Pressure::CheckCrc(lCalibrationData) == (lCalibrationData[0] >> 12);
		
	if (_IsCrcOk) {
		mPressureData = new PressureData(lCalibrationData);			
	} else {
		mPressureData = null;
	}
}

Pressure::~Pressure() {
	delete mNextAction;
	delete mPressureData;
	delete _IsCrcOk;
}

//Public
bool Pressure::IsCrcOk() {
	return _IsCrcOk;
} 

int32_t Pressure::GetData() {
	assert(mPressureData != NULL);
	assert(_IsCrcOk)

	while mNextAction > millis() {}

	int32_t lDeltaTemp = Pressure::ReadData(0x5A) - mPressureData.ReferenceTemperature();
	int64_t lSensitivity = mPressureData.Sensitivity + mPressureData.TCS  * lDeltaTemp;
	int64_t lOffset = mPressureData.Offset + mPressureData.TCO  * lDeltaTemp;
	int32_t lSensitivity2;
	int32_t lOffset2;
	int32_t lTemperature = 2000l + lDeltaTemp * mPressureData.TCT;

	if (lTemperature < 2000) {
		int32_t lTemperature2 = pow(lTemperature - 2000, 2);
		
		lOffset2 = 3 * lTemperature2 / 2;
		lSensitivity2 = 5 * lTemperature2 / 8;
		
		if (lTemperature < -1500) {
			int32_t lTemperature3 = pow(lTemperature + 1500l, 2);

			lOffset2 += 7 * lTemperature3;
			lSensitivity2 += 4 * lTemperature3;
		}
		
		lTemperature -= 3 * pow(lDeltaTemp, 2) / 8589934592LL;
	} else {
		int32_t lTemperature2 = pow(lTemperature - 2000, 2);
	
		lTemperature -= 2 * pow(lDeltaTemp, 2) / 137438953472LL;
		lOffset2 = lTemperature2 / 16;
		lSensitivity2 = 0;
	}

	return (Pressure::ReadData(0x4A) * (lSensitivity - lSensitivity2) / 2097152l - (lOffset - lOffset2)) / 8192l;
}

//Private
uint32_t Pressure::ReadData(uint8_t aRegister) {
	uint8_t lSize = 3;
	uint32_t lResult = 0;

	if (I2CBase::RequestRegister(aRegister) == 0) {
		delay(20);

		if (I2CBase::StartMesurement(0x00, lSize) == 0) {
			I2CBase::GetData(aData[]);
				lResult = aData[0];
				lResult = (lResult << 8) | aData[1];
				lResult = (lResult << 8) | aData[2];
		}
	}

	return lResult;
}

uint8_t Pressure::CheckCrc(uint16_t n_prom[]) {
	uint16_t n_rem = 0;

	n_prom[0] = (n_prom[0] & 0x0FFF);
	n_prom[7] = 0;

	for (uint8_t lI = 0; lI < 16; lI++) {
		if (lI % 2 == 1) {
			n_rem ^= (uint16_t)((n_prom[i >> 1]) & 0x00FF);
		} else {
			n_rem ^= (uint16_t)(n_prom[i >> 1] >> 8);
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