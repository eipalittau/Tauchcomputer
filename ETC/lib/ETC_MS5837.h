#ifndef _ETC_MS5837_H
#define _ETC_MS5837_H

#include "ETC_WireBase.h"
#include <Arduino.h>

typedef struct MS5837StructDef {
  float Temperature;
  int Pressure;
} MS5837Struct;

class ETC_MS5837: private ETC_WireBase {
public:
  ETC_MS5837();
  ~ETC_MS5837();

  bool Init();
  MS5837Struct GetData();
  
private:
  uint16_t C[8];  
  
  uint32_t ReadData(uint8_t aByte);
  uint8_t  CheckSum(uint16_t n_prom[]);
};
#endif
