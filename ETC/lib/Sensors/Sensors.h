#ifndef _SENSORS_h
#define _SENSORS_h

#include "I2C.h"
#include <OneWire.h>
#include "SensorData.h"

class Sensors {
public:
	Sensors();
	~Sensors();

	void StartMesurement();
	void SetData(SensorData aData);
	SensorData GetData();

private:
	SensorData* mSensorData;
	
	I2C mClock;
	I2C mPressure;
	OneWire mTemperature;


	//PressureData* mPressureData;
	uint32_t mNextAction;
	bool _IsCrcOk;
};
#endif
