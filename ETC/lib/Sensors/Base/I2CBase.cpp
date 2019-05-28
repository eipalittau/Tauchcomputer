#include "I2CBase.h"

#pragma region Variable declaration
unsigned char mI2CAdress;
unsigned char mRegister;
static boolean mInitWire = true;
#pragma endregion

#pragma region Constructor / Destructor
I2CBase::I2CBase(unsigned char aI2CAdress, unsigned char aRegister) {
	mI2CAdress = aI2CAdress;
	mRegister = aRegister;

	if (mInitWire) {
		mInitWire = false;
		Wire.begin();
	}
}

I2CBase::~I2CBase() {}
#pragma endregion

#pragma region Protected
char I2CBase::StartMesurement(unsigned char &aDataSize) {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);

	char lResult = Wire.endTransmission();

	if (lResult == 0) {
		aDataSize = Wire.requestFrom(mI2CAdress, aDataSize, true);
		return 0;
	} else {
		aDataSize = 0;
		return lResult;
	}
}

void I2CBase::SetData(unsigned char aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);

	for (int lI = 0; lI < lSize; lI++) {
		Wire.write(aData[lI]);
	}
	Wire.endTransmission();
}

int I2CBase::GetData(unsigned char aData[]) {
	int lSize = int (fmin(sizeof(aData) / sizeof(unsigned char), Wire.available()));

	for (int lI = 0; lI < lSize; lI++) {
		aData[lI] = Hex2Dec(Wire.read());
	}

	return lSize;
}
#pragma endregion

#pragma region Privat
unsigned char I2CBase::Dec2Hex(unsigned char aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Hex2Dec(unsigned char aValue) {
	return (aValue / 160) + (aValue % 16);
}
#pragma endregion
