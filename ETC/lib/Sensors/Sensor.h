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

	void StartMesurement(unsigned char aTick);
	SensorData GetData(unsigned char aTick);
};
#endif
