#include "Clock.h"

//Constructor / Destructor
Clock::Clock() {
  mBase = new I2CBase(0x68, 0x00);
}

Clock::~Clock() {}

//Public
void Clock::SetData(struct DataStruct aData) {
  int lTimestamp[7] = {aData->Second, aData->Minute, aData->Hour, aData->Weekday, aData->Day, aData->Month, aData->Year};
  
  lTimestamp[6] -= 2000;
  
  mBase.SetData(lTimestamp);
}

void Clock::GetData(struct DataStruct *aData) {
  int lTimestamp[7];
  
  if (mBase.GetData(lTimestamp) == 0) {  
    aData->Second = lTimestamp[0];
    aData->Minute = lTimestamp[1];
    aData->Hour = lTimestamp[2];
    aData->Weekday = lTimestamp[3];
    aData->Day = lTimestamp[4];
    aData->Month = lTimestamp[5];
    aData->Year = lTimestamp[6] + 2000;
  }
}
