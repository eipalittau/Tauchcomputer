#include "SensorData.h"

//Constructor / Destructor
SensorData::SensorData() {}

SensorData::~SensorData() {}

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

void SensorData::DateTimeData::Minute() {
	_Minute = aValue;
} 
