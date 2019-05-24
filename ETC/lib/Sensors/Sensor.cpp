#include "Sensor.h"

//Constructor / Destructor
Sensor::Sensor() {}

Sensor::~Sensor() {}

//Public
float Sensor::GetData() {
  Clock lClock;
  Temperature lTemperature;
  
  lClock.StartMesurement();
  lTemperature.StartMesurement();
}
