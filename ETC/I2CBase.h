#ifndef _I2CBASE_h
#define _I2CBASE_h

#include <Arduino.h>
#include <Wire.h>


class I2CBase {
	public:
		I2CBase(int aAdress, int aRegister);
		~I2CBase();

		void SetData(int aData[]);
		int  GetData(int *aData[]);

	private:
		const int TIMEOUT = 100;

		int mAdress;
		int mRegister;

		bool HasData(int aBytes);
		int  Dec2Bcd(int aValue);
		int  Bcd2Dec(int aValue);
};
#endif