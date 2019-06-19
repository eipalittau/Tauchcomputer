#include "I2CBase.h"

static bool mInitWire = true;

#pragma region Constructor / Destructor
I2CBase::I2CBase(uint8_t aI2CAdress) {
	mI2CAdress = aI2CAdress;

	if (mInitWire) {
		mInitWire = false;
		Wire.begin();
	}
}

I2CBase::~I2CBase() {}
#pragma endregion

#pragma region Protected
char I2CBase::RequestRegister(uint8_t aRegister) {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(aRegister);

	return Wire.endTransmission();
}

char I2CBase::StartMesurement(uint8_t aRegister, uint8_t &aDataSize) {
	int8_t lResult = RequestRegister(aRegister);

	if (lResult == 0) {
		aDataSize = Wire.requestFrom(mI2CAdress, aDataSize);
	} else {
		aDataSize = 0;
	}

	return lResult;
}

void I2CBase::SetData(uint8_t aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);

	for (int lI = 0; lI < lSize; lI++) {
		Wire.write(aData[lI]);
	}
	Wire.endTransmission();
}

int I2CBase::GetData(uint8_t aData[]) {
	unsigned long lStart = millis();

	while (!Wire.available() && millis() - lStart < TIMEOUT) {
		delay(2);
	}

	int lSize = int(fmin(sizeof(aData) / sizeof(unsigned char), Wire.available()));

	for (int lI = 0; lI < lSize; lI++) {
		aData[lI] = Hex2Dec(Wire.read());
	}

	return lSize;
}
#pragma endregion

#pragma region Privat
unsigned char I2CBase::Dec2Hex(uint8_t aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Hex2Dec(uint8_t aValue) {
	return (aValue / 160) + (aValue % 16);
}
#pragma endregion