#ifndef _SENSOR_h
#define _SENSOR_h

#include "Clock.h"
#include "Temperature.h"
#include "Pressure.h"
#include "SensorData.h"

class Sensor {
public:
	Sensor();
	~Sensor();

	void StartMesurement(uint8_t aTick);
	SensorData GetData(uint8_t aTick);

private:
};
#endif
