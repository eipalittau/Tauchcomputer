#include "SensorData.h"
#include "Sensors.h"

Sensors mSensors;
SensorStruct mSensorData;

void setup() {
    
}

void loop() {
    mSensors.StartMesurement();
    mSensors.GetData(&mSensorData);
    
    
}
