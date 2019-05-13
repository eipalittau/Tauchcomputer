#include "Clock.h"

//Constructor / Destructor
Clock::Clock() {}

Clock::~Clock() {}

//Public
void Clock::SetData(struct DataStruct aData) {
  
}

void Clock::GetData(struct DataStruct *aData) {
  int lTimestamp[7];
  
  if (I2CBase.GetData(0x68, 0x00, lTimestamp) == 0) {  
    aData->Second = lTimestamp[0];
    aData->Minute = lTimestamp[1];
    aData->Hour = lTimestamp[2];
    aData->Day = lTimestamp[4];
    aData->Month = lTimestamp[5];
    aData->Year = lTimestamp[6] + 2000;
    aData->Weekday = lTimestamp[3];
  }
}
