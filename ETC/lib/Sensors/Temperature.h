#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>
#include "WireBase.h"
#include "Constants.h"
#include <float.h>

class Temperature : protected WireBase {
public:
	Temperature();
	~Temperature();

	void StartMesurement();
	float GetData(UnitMesurmentTemperature aUnitMesurment = C);
};
#endif
