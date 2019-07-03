#ifndef _PRESSURE_h
#define _PRESSURE_h

#include "I2CBase.h"

class Pressure : protected I2CBase {
public:
	Pressure();
	~Pressure();

	bool StartMesurement();
	float GetData();

private:
	unsigned int C[8];
	unsigned long D1, D2;
	long P;


	bool ReadTemperature();
	unsigned long ReadPressure(unsigned char aRegister);
	unsigned char crc4(unsigned int n_prom[]);
	void Calculate();
};
#endif
