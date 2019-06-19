#include "Sensor.h"

Clock mClock;
Temperature mTemperature;
Pressure mPressure;

const unsigned char INTERVALL_5 = 5;

//Constructor / Destructor
Sensor::Sensor() {}

Sensor::~Sensor() {}

//Public
void Sensor::StartMesurement(uint8_t aTick) {
	mClock.StartMesurement();
	
	if (aTick % INTERVALL_5 == 0) {
		mTemperature.StartMesurement();
	}
}

SensorData Sensor::GetData(uint8_t aTick) {
	SensorData lData;

	lData.DateTime = mClock.GetData();
	lData.Pressure = mPressure.GetData();

	if (aTick % INTERVALL_5 == 0) {
		lData.Temperature = mTemperature.GetData();
	}

	return lData;
}
