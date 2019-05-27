#include "I2CBase.h"

unsigned char mI2CAdress;
unsigned char mRegister;
unsigned char mDataSize;

//Constructor / Destructor
I2CBase::I2CBase(unsigned char aI2CAdress, unsigned char aRegister, unsigned char aDataSize) {
	mI2CAdress = aI2CAdress;
	mRegister = aRegister;
	mDataSize = aDataSize;
}

I2CBase::~I2CBase() {}

//Protected
void I2CBase::StartMeasurement() {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	Wire.endTransmission();

	Wire.requestFrom(mI2CAdress, mDataSize);
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

unsigned char I2CBase::GetData() {
	unsigned char *lData = new unsigned char[mDataSize];
	
	for (int lI = 0; lI < mDataSize; lI++) {
		if (Wire.available()) {
			lData[lI] = Hex2Dec(Wire.read());
		} else {
			break;
		}
	}
		
	return "";
}

//Private
unsigned char I2CBase::Dec2Hex(unsigned char aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Hex2Dec(unsigned char aValue) {
	return (aValue / 160) + (aValue % 16);
}
