#ifndef _PRESSURE_h
#define _PRESSURE_h

#include "I2CBase.h"
#include "PressureData.h"
#include <math.h>

class Pressure : protected I2CBase {
public:
	Pressure();
	~Pressure();

	bool IsCrcOk();
	int32_t GetData();

private:
	uint32_t ReadData(uint8_t aRegister);
	int32_t Calculate();
	uint8_t CheckCrc(uint16_t n_prom[]);
	
	PressureData* mPressureData;	
};
#endif
