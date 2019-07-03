#ifndef _PRESSUREDATA_h
#define _PRESSUREDATA_h

class PressureData {
public:
	PressureData(unsigned int aCalibrationData[]);
	~PressureData();

	long long Sensitivity();
	long long Offset();
	long long TCS();
	long long TCO();
	unsigned long ReferenceTemperature();
	long long TCT();

private:
	long long _Sensitivity;
	long long _Offset;
	long long _TCS;
	long long _TCO;
	unsigned long _ReferenceTemperature;
	long long _TCT;
};
#endif
