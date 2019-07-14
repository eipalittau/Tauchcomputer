#include "SensorData.h"

//Constructor / Destructor
SensorData::SensorData() {}

SensorData::~SensorData() {}

void SensorData::DateTime(DateTimeData* aValue) {
	_DateTime = aValue;
}
DateTimeData* SensorData::DateTime() {
	return _DateTime;
}

void SensorData::Temperature(float aValue) {
	_Temperature = aValue;
}
float SensorData::Temperature() {
	return _Temperature;
}

void SensorData::Pressure(float aValue) {
	_Pressure = aValue;
}
float SensorData::Pressure() {
	return _Pressure;
}
