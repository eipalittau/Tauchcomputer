#ifndef _SENSORS_H
#define _SENSORS_H

#include <OneWire.h>
#include <DallasTemperature.h>
#include <Wire.h>
#include "MS5837.h"
#include "SensorsData.h"

class Sensors {
public:
  Sensors();
  ~Sensors();

private:
  SensorsData GetData();
  
  MS5837 mPressure;
  SensorsData mSensorData;
};
#endif
