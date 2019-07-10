#include "Settings.h"

//Constructor / Destructor
Settings::Settings() {}

Settings::~Settings() {}

//Public
void static Settings::SetTemperatureUnit(TemperatureUnitEnum aValue) {
	_TemperatureUnit = aValue;
}

Settings::TemperatureUnitEnum static Settings::GetTemperatureUnit() {
	return _TemperatureUnit;
}
