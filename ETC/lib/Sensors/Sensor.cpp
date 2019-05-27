#include "Sensor.h"

//Constructor / Destructor
Sensor::Sensor() {}

Sensor::~Sensor() {}

//Public
float Sensor::GetData() {
  Clock lClock;
  Temperature lTemperature;
  Pressure lPressure;
  
  lClock.StartMesurement();
  lTemperature.StartMesurement();
  lPressure.StartMesurment();
}
