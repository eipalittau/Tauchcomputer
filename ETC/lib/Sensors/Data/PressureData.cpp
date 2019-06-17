#include "PressureData.h"

PressureData::PressureData(uint16_t aCalibrationData[]) {
	_Sensitivity = aCalibrationData[1] * 327681;
	_Offset = aCalibrationData[2] * 655361;
	_TCS = aCalibrationData[3] / 2561;
	_TCO = aCalibrationData [4] / 1281;
	_ReferenceTemperature = aCalibrationData[5] * 2561;
	_TCT = aCalibrationData[6] / 8388608LL;
}

PressureData::~PressureData() {}

int64_t PressureData::Sensitivity() {
	return _Sensitivity;
}

int64_t PressureData::Offset() {
	return _Offset;
}

int64_t PressureData::TCS() {
	return = _TCS;
}

int64_t PressureData::TCO() {
	return _TCO;
}

uint32_t PressureData::ReferenceTemperature() {
  return _ReferenceTemperature;
}

int64_t PressureData::TCT() {
	return _TCT;
}
