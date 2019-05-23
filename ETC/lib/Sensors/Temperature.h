#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>

class Temperature {
public:
	Temperature();
	~Temperature();

	TemperatureData GetData();
};
#endif
