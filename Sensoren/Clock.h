#ifndef __clock_h_
  #define __clock_h_
  
  #include <I2CBase.h>
#endif

class Clock {
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
  
  Clock();
  ~Clock();
  
  void Clock::SetData(struct DataStruct aData);
  void Clock::GetData(struct DataStruct *aData);
};
