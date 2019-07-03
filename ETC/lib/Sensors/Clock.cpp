#include "Clock.h"

const uint8_t ARRAYSIZE = 7;

#pragma region Constructor / Destructor
Clock::Clock() : I2CBase(0x68) {}

Clock::~Clock() {}
#pragma endregion

#pragma region Public
void Clock::StartMesurement() {
	uint8_t lSize = ARRAYSIZE;

	I2CBase::StartMesurement(0x00, lSize);
}

void Clock::SetData(DateTimeData aData) {
	uint8_t lTimestamp[ARRAYSIZE] = { aData.Second(), aData.Minute(), aData.Hour(), aData.Weekday(), aData.Day(), aData.Month(), aData.Year() - 2000 };

	I2CBase::SetData(lTimestamp);
}

DateTimeData Clock::GetData() {
	uint8_t lData[ARRAYSIZE];
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
