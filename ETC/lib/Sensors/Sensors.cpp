#include "Sensors.h"

Sensors::Sensors() {
  Wire.begin();

  while (!mPressure.init()) {
    Serial.println("NOK");
    delay(5000);
  }

  mPressure.setModel(MS5837::MS5837_30BA);
  mPressure.setFluidDensity(997); // kg/m^3 (freshwater, 1029 for seawater)
  Serial.println("Init");
}

Sensors::~Sensors() {}

SensorsData Sensors::GetData() {
  mPressure.read();

  mSensorData.Pressure(mPressure.pressure());
  mSensorData.Temperature(mPressure.temperature());
  mSensorData.Depth(mPressure.depth());
  mSensorData.Altitude(mPressure.altitude());

  return mSensorData;
}
