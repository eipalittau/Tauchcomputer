#ifndef _SENSOR_h
#define _SENSOR_h

#include "Clock.h"
#include "Temperature.h"

class Sensor {
public:
	Sensor();
  ~Sensor();
  
  void GetData();
};
#endif
