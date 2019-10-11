#include "ETC_MS5837.h"

ETC_MS5837::ETC_MS5837(): ETC_WireBase(0x76) {}
ETC_MS5837::~ETC_MS5837() {}

bool ETC_MS5837::Init() {
  if (Write(0x1E) == 0) {
    delay(10);

    for (uint8_t lI = 0; lI < 7; lI++ ) {
      if (Request(0xA0 + lI * 2, 2) == 0) {
        C[lI] = (Wire.read() << 8) | Wire.read();
      }
    }
  
    return (CheckSum(C) == (C[0] >> 12));
  } else {
    return false;
  }
}

MS5837Struct ETC_MS5837::GetData() {
  MS5837Struct lData;
  uint32_t lDPressure = ReadData(0x4A);
  uint32_t lDTemperature = ReadData(0x5A);
  int32_t SENSi = 0;
  int32_t OFFi = 0;
  int32_t Ti = 0;
  
  // Terms called
  int32_t dT = lDTemperature - uint32_t(C[5]) * 256l;
  int64_t SENS = int64_t(C[1]) * 32768l + (int64_t(C[3]) * dT) / 256l;
  int64_t OFF = int64_t(C[2]) * 65536l + (int64_t(C[4]) * dT) / 128l;
  int32_t P = (lDPressure * SENS / (2097152l) - OFF) / (8192l);
  
  // Temp conversion
  int32_t TEMP = 2000l + int64_t(dT) * C[6] / 8388608LL;
  
  //Second order compensation
  if (TEMP < 2000) {
    Ti = (3 * int64_t(dT) * int64_t(dT)) / (8589934592LL);
    OFFi = (3 * (TEMP-2000) * (TEMP-2000)) / 2;
    SENSi = (5 * (TEMP-2000) * (TEMP-2000)) / 8;
    if (TEMP < -1500){
      OFFi = OFFi + 7 * (TEMP + 1500l) * (TEMP + 1500l);
      SENSi = SENSi + 4 * (TEMP + 1500l) * (TEMP + 1500l);
    }
  } else {
    Ti = 2 * (dT * dT) / (137438953472LL);
    OFFi = (1 * (TEMP - 2000) * (TEMP - 2000)) / 16;
    SENSi = 0;
  }

  TEMP = int((TEMP - Ti) / 10);
  P = (((lDPressure * (SENS - SENSi)) / 2097152l - (OFF - OFFi)) / 8192l);
  
  lData.Temperature = TEMP / 10;
  lData.Pressure = int(P / 10);
  
  return lData;
}

uint32_t ETC_MS5837::ReadData(uint8_t aByte) {
  uint32_t lResult = 0;
  
  if (Write(aByte) == 0) {
    delay(20);

    if (Request(0x00, 3) == 0) {
      lResult = Wire.read();
      lResult = (lResult << 8) | Wire.read();
      lResult = (lResult << 8) | Wire.read();
    }
  }

  return lResult;
}

uint8_t ETC_MS5837::CheckSum(uint16_t n_prom[]) {
  uint16_t n_rem = 0;

  n_prom[0] = ((n_prom[0]) & 0x0FFF);
  n_prom[7] = 0;

  for ( uint8_t i = 0 ; i < 16; i++ ) {
    if ( i%2 == 1 ) {
      n_rem ^= (uint16_t)((n_prom[i>>1]) & 0x00FF);
    } else {
      n_rem ^= (uint16_t)(n_prom[i>>1] >> 8);
    }
    for ( uint8_t n_bit = 8 ; n_bit > 0 ; n_bit-- ) {
      if ( n_rem & 0x8000 ) {
        n_rem = (n_rem << 1) ^ 0x3000;
      } else {
        n_rem = (n_rem << 1);
      }
    }
  }
  
  n_rem = ((n_rem >> 12) & 0x000F);

  return n_rem ^ 0x00;
}
