#include "SensorData.h"

//Constructor / Destructor
SensorData::SensorData() {}

SensorData::~SensorData() {}

DateTimeData* _DateTime = NULL;
void SensorData::DateTime(DateTimeData* aValue) {
	_DateTime = aValue;
}
DateTimeData* SensorData::DateTime() {
	return _DateTime;
}

float _Temperature = FLOAT_MIN;
void SensorData::Temperature(float aValue) {
	_Temperature = aValue;
}
float SensorData::Temperature() {
	return _Temperature;
}

float _Pressure = FLOAT_MIN;
void SensorData::Pressure(float aValue) {
	_Pressure = aValue;
}
float SensorData::Pressure() {
	return _Pressure;
}
