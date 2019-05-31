#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>
#include "WireBase.h"
#include "Constants.h"

class Temperature : protected WireBase {
public:
	Temperature();
	~Temperature();

	enum UnitMesurmentTemperature { C, F, K };

	void StartMesurement();
	float GetData(UnitMesurmentTemperature aUnitMesurment = C);
};
#endif
