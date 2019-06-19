#ifndef _SETTINGS_h
#define _SETTINGS_h

#include "Sensors/Temperature.h"

class Settings {
public:
	///<summary>Constructor</summary>
	Settings();

	///<summyry>Destructor</summary>
	~Settings();

	void TemperatureUnit(Temperature::TemperatureUnitEnum aValue);
	Temperature::TemperatureUnitEnum TemperatureUnit();

private:
	Temperature::TemperatureUnitEnum _TemperatureUnit = Temperature::C;
};
#endif