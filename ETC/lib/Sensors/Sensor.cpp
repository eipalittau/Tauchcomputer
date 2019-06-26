#include "Sensor.h"

Clock mClock;
Temperature mTemperature;
Pressure mPressure;

//Constructor / Destructor
Sensor::Sensor() {
	mData = new SensorData();
}

Sensor::~Sensor() {
	delete mData;
}

//Public
void Sensor::StartMesurement(uint8_t aTick) {
	mClock.StartMesurement();
	
	if (aTick % Constants::INTERVALL_5 == 0) {
		mTemperature.StartMesurement();
	}

	mNextAction = millis() + 20;
}

SensorData Sensor::GetData(uint8_t aTick) {
	while mNextAction > millis() {}

	mData.DateTime = mClock.GetData();
	mData.Pressure = mPressure.GetData();

	if (aTick % Constants::INTERVALL_5 == 0) {
		float lData = mTemperature.GetData();
		
		switch (Settings::TemperatureUnit()) {
		case F:
			mData.Temperature = lData * 0.0140625 + 32;
			break;

		case K:
			mData.Temperature = lData * 0.0078125 + 273.15;
			break;

		case C:
		default:
			mData.Temperature = lData * 0.0078125;
			break;
		}
	}

	return mData;
}
