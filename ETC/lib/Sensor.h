#ifndef _SENSOR_H
#define _SENSOR_H

#include <MS5837.h>
#include <Wire.h>
#include "SensorData.h"

class Sensor {
public:
  Sensor();
  ~Sensor();

  boolean Init(float aSeawaterPercentage = 0);
  SensorDataStruct GetData();
  
private:  
  MS5837 mPressure;
};
#endif
