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

private:
	bool HasData(unsigned short int aSize);
	unsigned char Dec2Bcd(unsigned char aValue);
	unsigned char Bcd2Dec(unsigned char aValue);
};
#endif