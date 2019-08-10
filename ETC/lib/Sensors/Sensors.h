#ifndef _SENSORS_H
#define _SENSORS_H

#include <OneWire.h>
#include <DallasTemperature.h>
#include <Wire.h>
#include "MS5837.h"
#include "SensorData.h"

class Sensors {
public:
  Sensors();
  ~Sensors();

private:
  SensorData GetData();
  
  MS5837 mPressure;
  SensorData mSensorData;
};
#endif
