#ifndef _DATAHANDLER_H
#define _DATAHANDLER_H

#include "ETC_MS5837.h"

class DataHandler {
public:
  DataHandler();
  ~DataHandler();

  bool Init();
  DiveDataStruct GetData();
  
private:
  ETC_MS5837 mPressure;
};
#endif
