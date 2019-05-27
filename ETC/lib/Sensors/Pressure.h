#ifndef _PRESSURE_h
#define _PRESSURE_h

#include "I2CBase.h"

class Pressure : protected I2CBase {
public:
	Pressure();
	~Pressure();

	void StartMesurement();
	float GetData();
};
#endif
