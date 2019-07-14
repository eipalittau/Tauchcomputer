#include "Sensors.h"

const unsigned char CLOCK_ARRAYSIZE = 7;

#pragma region Constructor / Destructor
Sensors::Sensors() {
	Wire.begin();

	mClock = new I2C(0x68);
	mPressure = new I2C();
}

Sensors::~Sensors() {}
#pragma endregion

#pragma region Public
void Sensors::StartMesurement() {
	uint8_t lSize = CLOCK_ARRAYSIZE;

	mClock.StartMesurement(0x00, lSize);
}

DateTimeData Sensors::GetData() {
	uint8_t lData[ARRAYSIZE];
	DateTimeData lResult;

	if (mClock.GetData(lData) >= CLOCK_ARRAYSIZE) {
		lResult.Second(lData[0]);
		lResult.Minute(lData[1]);
		lResult.Hour(lData[2]);
		lResult.Weekday(lData[3]);
		lResult.Day(lData[4]);
		lResult.Month(lData[5]);
		lResult.Year(lData[6] + 2000);
	}
	
	return lResult;
}
#pragma endregion
