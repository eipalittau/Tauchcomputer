#include "Sensors.h"

const unsigned char ARRAYSIZE = 7;

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
	uint8_t lSize = ARRAYSIZE;

	mClock.StartMesurement(0x00, lSize);
}

DateTimeData Sensors::GetData() {
	unsigned char lData[ARRAYSIZE];
	DateTimeData lResult;

	if (mClock.GetData(lData) >= 7) {
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
