#include "Sensor.h"

Sensor::Sensor() {}
Sensor::~Sensor() {}

boolean Sensor::Init(float aSeawaterPercentage = 0) {
  if (!mPressure.init()) {
    return false;
  } else {
    SensorDataStruct lData;
    
    mPressure.setModel(MS5837::MS5837_30BA);
    mPressure.setFluidDensity(997 + (int)(aSeawaterPercentage * 10));

    lData = GetData();
    
    return true;
  }
}

SensorDataStruct Sensor::GetData() {
  SensorDataStruct lData;

  lData.Pressure = 0;
  lData.Temperature = 0;
  
  for (uint8_t lI = 0; lI < 3; lI++ ) {
    mPressure.read();

    lData.Pressure = lData.Pressure + mPressure.pressure();
    lData.Temperature = lData.Temperature + mPressure.temperature();
  }
  lData.Pressure = lData.Pressure / 3;
  lData.Temperature = int ((lData.Temperature / 3) * 10);
  lData.Temperature = lData.Temperature / 10;
  
  return lData;
}
