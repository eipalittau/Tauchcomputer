#ifndef _TEMPERATURE_h
#define _TEMPERATURE_h

#include <OneWire.h>
#include "WireBase.h"
#include "Constants.h"
#include "/Projekte/ETC/ETC/lib/Settings.h"

class Temperature : protected WireBase {
public:
	Temperature();
	~Temperature();

	enum TemperatureUnitEnum { C, F, K };

	void StartMesurement();
	float GetData();
};
#endif
