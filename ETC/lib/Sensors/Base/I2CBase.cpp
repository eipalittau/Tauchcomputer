#include "I2CBase.h"

unsigned char mI2CAdress;
unsigned char mRegister;

//Constructor / Destructor
I2CBase::I2CBase(unsigned char aI2CAdress, unsigned char aRegister) {
	mI2CAdress = aI2CAdress;
	mRegister = aRegister;
}

I2CBase::~I2CBase() {}

//Protected
void I2CBase::StartMeasurement() {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	Wire.endTransmission();
}

void I2CBase::SetData(unsigned char aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);
	int lI;

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	for (lI = 0; lI < lSize; lI++) {
		Wire.write(aData[lI]);
	}
	Wire.endTransmission();
}

// 0 = alles OK
// 1 = Keine Daten
unsigned char I2CBase::GetData(unsigned char aData[]) {
	unsigned short lSize = sizeof(aData) / sizeof(unsigned char);
	unsigned long lStart = millis();

	while (millis() - lStart < Constants.TIMEOUT) {
		if (Wire.requestFrom(mI2CAdress, lSize) == lSize) {
			for (unsigned short lI = 0; lI < lSize; lI++) {
				aData[lI] = Hex2Dec(Wire.read());
			}
			
			return 0;
		}

		delay(2);
	}
	
	return 1;
}

//Private
unsigned char I2CBase::Dec2Hex(unsigned char aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Hex2Dec(unsigned char aValue) {
	return (aValue / 160) + (aValue % 16);
}
