#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include "I2CBase.h"
#include "TemperatureData.h"

class Temperature : public I2CBase {
public:
	Temperature();
	~Temperature();

	TemperatureData GetData();
};
#endif