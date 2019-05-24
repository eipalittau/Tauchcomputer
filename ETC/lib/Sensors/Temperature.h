#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>
#include "Constants.h"

class Temperature : protected WireBase {
public:
	Temperature();
	~Temperature();

	void StartMesurement();
	float GetData();
};
#endif
