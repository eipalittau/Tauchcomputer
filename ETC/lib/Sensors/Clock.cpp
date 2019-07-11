#include "Clock.h"

const unsigned char ARRAYSIZE = 7;

#pragma region Constructor / Destructor
Clock::Clock() {
	I2C mClock = new I2C(0x68, true);
}

Clock::~Clock() {}
#pragma endregion

#pragma region Public
void Clock::StartMesurement() {
	uint8_t lSize = ARRAYSIZE;

	mClock.StartMesurement(0x00, lSize);
}

DateTimeData Clock::GetData() {
	unsigned char lData[ARRAYSIZE];
	DateTimeData lResult;

	if (I2CBase::GetData(lData) >= 7) {
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
