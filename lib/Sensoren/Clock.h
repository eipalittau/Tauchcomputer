#ifndef CLOCK_H
  #define CLOCK_H
  
  #include <I2CBase.h>

class Clock: private I2CBase {
public:
  struct DataStruct {
    int Second;
    int Minute;
    int Hour;
    int Day;
    int Month;
    int Year;
    String Weekday;
  };
  
  Clock():I2CBase(int aAdress, int aRegister);
  ~Clock();
  
  void Clock::SetData(struct DataStruct aData);
  void Clock::GetData(struct DataStruct *aData);
};
#endif
