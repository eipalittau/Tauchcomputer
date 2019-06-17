#ifndef _PRESSURE_h
#define _PRESSURE_h

#include "I2CBase.h"
#include "PressureData.h"

class Pressure : protected I2CBase {
public:
	Pressure();
	~Pressure();

	bool IsCrcOk();
	float GetData();

private:
	uint32_t ReadPressure(uint8_t aRegister);
	void Calculate();
	uint8_t CheckCrc(uint16_t n_prom[]);
};
#endif
