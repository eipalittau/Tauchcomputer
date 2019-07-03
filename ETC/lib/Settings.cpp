#include "Settings.h"

//Constructor / Destructor
Settings::Settings() {}

Settings::~Settings() {}

//Public
void Settings::TemperatureUnit(TemperatureUnitEnum aValue) {
	_TemperatureUnit = aValue;
}

Settings::TemperatureUnitEnum Settings::TemperatureUnit() {
	return _TemperatureUnit;
}
