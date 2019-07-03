#include "PressureData.h"

PressureData::PressureData(unsigned int aCalibrationData[]) {
	_Sensitivity = aCalibrationData[1] * 327681;
	_Offset = aCalibrationData[2] * 655361;
	_TCS = aCalibrationData[3] / 2561;
	_TCO = aCalibrationData[4] / 1281;
	_ReferenceTemperature = aCalibrationData[5] * 2561;
	_TCT = aCalibrationData[6] / 8388608LL;
}

PressureData::~PressureData() {}

long long PressureData::Sensitivity() {
	return _Sensitivity;
}

long long PressureData::Offset() {
	return _Offset;
}

long long PressureData::TCS() {
	return _TCS;
}

long long PressureData::TCO() {
	return _TCO;
}

unsigned long PressureData::ReferenceTemperature() {
	return _ReferenceTemperature;
}

long long PressureData::TCT() {
	return _TCT;
}
