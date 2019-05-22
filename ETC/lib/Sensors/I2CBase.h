#ifndef _I2CBASE_h
#define _I2CBASE_h

#include <Arduino.h>
#include <Wire.h>

class I2CBase {
public:
	I2CBase(unsigned char mI2CAdress, unsigned char aRegister);
	~I2CBase();

	void SetData(unsigned char aData[]);
	signed char GetData(unsigned char aData[]);
	unsigned char Dec2Hex(unsigned char aValue);
	unsigned char Hex2Dec(unsigned char aValue);

private:
	bool HasData(unsigned short int aSize);
};
#endif