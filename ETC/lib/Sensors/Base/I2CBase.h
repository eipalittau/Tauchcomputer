#ifndef _I2CBASE_h
#define _I2CBASE_h

#include <Arduino.h>
#include <Wire.h>
#include "Constants.h"

class I2CBase {
protected:
	I2CBase(unsigned char aI2CAdress, unsigned char aRegister);
	~I2CBase();
	
	void StartMeasurement();
	void SetData(unsigned char aData[]);
	void I2CBase::GetData(unsigned char aData[]);

private:
	unsigned char Dec2Hex(unsigned char aValue);
	unsigned char Hex2Dec(unsigned char aValue);
};
#endif
