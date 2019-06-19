#ifndef _SENSOR_h
#define _SENSOR_h

#include "Clock.h"
#include "Temperature.h"
#include "Pressure.h"
#include "SensorData.h"

class Sensor {
public:
	static void StartMesurement(uint8_t aTick);
	static SensorData GetData(uint8_t aTick);

private:
	Sensor();
	~Sensor();

	SensorData* mData;
	uint32_t mNextAction;
};
#endif