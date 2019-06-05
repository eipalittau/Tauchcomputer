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
	bool ReadTemperature();
  uint8_t ccr4();
  void read();
  void calculate();
};

#endif
