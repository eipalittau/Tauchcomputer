#include "Settings.h"

//Constructor / Destructor
Settings::Settings() {}
	
Settings::~Settings() {}

//Public
void Settings::TemperatureUnit(Temperature::TemperatureUnitEnum aValue) {
	_TemperatureUnit = aValue;
}

Temperature::TemperatureUnitEnum Settings::TemperatureUnit() {
	return _TemperatureUnit;
}