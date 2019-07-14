#ifndef _SENSORS_h
#define _SENSORS_h

#include "I2C.h"
#include "Wire.h"
#include "SensorData.h"

class Sensors {
public:
	Sensors();
	~Sensors();

	void StartMesurement();
	void SetData(SensorData aData);
	SensorData GetData();

private:
	I2C mClock;
	I2C mPressure;
	Wire mTemperature;

	SensorData* mData;

	bool _IsCrcOk;
};
#endif
