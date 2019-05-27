#include "Clock.h"

const unsigned char ARRAYSIZE = 7;

//Constructor / Destructor
Clock::Clock() : I2CBase(104, 0) {}

Clock::~Clock() {}

//Public
void Clock::StartMesurement() {
	I2CBase::StartMesurement();
}

void Clock::SetData(DateTimeData aData) {
	unsigned char lTimestamp[ARRAYSIZE] = { aData.Second(), aData.Minute(), aData.Hour(), aData.Weekday(), aData.Day(), aData.Month(), aData.Year() - 2000 };

	I2CBase::SetData(lTimestamp);
}

DateTimeData Clock::GetData() {
	unsigned char lData[ARRAYSIZE];
	DateTimeData lResult;

	if (I2CBase::GetData(lData) == 0) {
		lResult.Second(lData[0]);
		lResult.Minute(lData[1]);
		lResult.Hour(lData[2]);
		lResult.Weekday(lData[3]);
		lResult.Day(lData[4]);
		lResult.Month(lData[5]);
		lResult.Year(lData[6] + 2000);
	}
}
