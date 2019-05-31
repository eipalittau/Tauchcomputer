#include "Sensor.h"

Clock mClock;
Temperature mTemperature;
Pressure mPressure;

const unsigned char INTERVALL_5 = 5;

//Constructor / Destructor
Sensor::Sensor() {}

Sensor::~Sensor() {}

//Public
void Sensor::StartMesurement(unsigned char aTick) {
	mClock.StartMesurement();
	mPressure.StartMesurement();

	if (aTick % INTERVALL_5 == 0) {
		mTemperature.StartMesurement();
	}
}

SensorData Sensor::GetData(unsigned char aTick) {
	SensorData lData;

	lData.DateTime = mClock.GetData();
	lData.Pressure = mPressure.GetData();

	if (aTick % INTERVALL_5 == 0) {
		lData.Temperature = mTemperature.GetData(Temperature::C);
	}

	return lData;
}
