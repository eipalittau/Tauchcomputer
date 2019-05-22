#include "I2CBase.h"

const unsigned char TIMEOUT = 100;

unsigned char mI2CAdress;
unsigned char mRegister;

//Constructor / Destructor
I2CBase::I2CBase(unsigned char aI2CAdress, unsigned char aRegister) {
	mI2CAdress = aI2CAdress;
	mRegister = aRegister;
}

I2CBase::~I2CBase() {}

//Protected
void I2CBase::SetData(unsigned char aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);
	int lI;

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	for (lI = 0; lI < lSize; lI++) {
		Wire.write(Dec2Bcd(aData[lI]));
	}
	Wire.endTransmission();
}

// 0 = alles OK
// 1 = Keine Daten
signed char I2CBase::GetData(unsigned char aData[]) {
	unsigned short int lSize = sizeof(aData) / sizeof(unsigned char);
	unsigned short int lI;

	if (HasData(lSize)) {
		for (lI = 0; lI < lSize; lI++) {
			aData[lI] = Bcd2Dec(Wire.read());
		}

		return 0;
	}
	else {
		return 1;
	}
}

//Private
bool I2CBase::HasData(unsigned short int aSize) {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	Wire.endTransmission();

	unsigned long lStart = millis();

	while (millis() - lStart < TIMEOUT) {
		if (Wire.requestFrom(mI2CAdress, aSize) == aSize) {
			return true;
		}

		delay(2);
	}

	return false;
}

unsigned char I2CBase::Dec2Bcd(unsigned char aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Bcd2Dec(unsigned char aValue) {
	return (aValue / 160) + (aValue % 16);
}