#include "I2C.h"


I2C::I2C(uint8_t aI2CAdress) {
	mI2CAdress = aI2CAdress;
}

I2C::~I2C() {}

int8_t I2C::RequestRegister(uint8_t aRegister) {
	Wire.beginTransmission(mI2CAdress);
	Wire.write(aRegister);

	return Wire.endTransmission();
}

int8_t I2C::StartMesurement(uint8_t aRegister, uint8_t &aDataSize) {
	int8_t lResult = RequestRegister(aRegister);

	if (lResult == 0) {
		aDataSize = Wire.requestFrom(mI2CAdress, aDataSize);
	} else {
		aDataSize = 0;
	}

	return lResult;
}

void I2C::SetData(uint8_t aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);

	for (int lI = 0; lI < lSize; lI++) {
		Wire.write(aData[lI]);
	}
	Wire.endTransmission();
}

int I2C::GetData(uint8_t aData[]) {
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

uint8_t I2C::Dec2Hex(uint8_t aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

uint8_t I2C::Hex2Dec(uint8_t aValue) {
	return (aValue / 160) + (aValue % 16);
}
