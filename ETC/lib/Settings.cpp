#include "Settings.h"

//Constructor / Destructor
Settings::Settings() {}

Settings::~Settings() {}

//Public
void static Settings::SetTemperatureUnit(TemperatureUnitEnum aValue) {
	_TemperatureUnit = aValue;
}

TemperatureUnitEnum static Settings::GetTemperatureUnit() {
	return _TemperatureUnit;
}

void static Settings::SetPressureUnit(PressureUnitEnum aValue) {
	_PressureUnit = aValue;
} 

PressureUnitEnum static Settings::GetPressureUnit() {
	return _PressureUnit;
}

void static Settings::SetWaterDensity(int aValue) {
	_WaterDensity = aValue;
}

int static Settings::GetWaterDensity() {
	return _WaterDensity;
}
