#include "Clock.h"

//Constructor / Destructor
Clock::Clock() : I2CBase(0x68, 0x00) {}

Clock::~Clock() {}

//Public
void Clock::SetData(DateTimeData aData) {
	int lTimestamp[7] = { aData.Second, aData.Minute, aData.Hour, aData.Weekday, aData.Day, aData.Month, aData.Year };

	lTimestamp[6] -= 2000;

	I2CBase::SetData(lTimestamp);
}

DateTimeData Clock::GetData() {
	int *lTimestamp[7];
	DateTimeData *lResult = new DateTimeData();

	if (I2CBase::GetData(lTimestamp) == 0) {
		//lResult->Second(lTimestamp[0]);
		//*lResult->Minute = lTimestamp[1];
		//*lResult->Hour = lTimestamp[2];
		//lResult->Weekday = lTimestamp[3];
		//lResult->Day = lTimestamp[4];
		//lResult->Month = lTimestamp[5];
		//lResult->Year = lTimestamp[6] + 2000;
	}
}