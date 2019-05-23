#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>
#include "Constants.h"

class Temperature {
public:
	Temperature();
	~Temperature();

	float GetData();

private:
	bool SendCommand(unsigned char aValue);
};
#endif