#ifndef __i2cbase_h_
  #define __i2cbase_h_
  
  #include <Arduino.h>
  #include <Wire.h>
  #include "config.h"

  #define TIMEOUT 100

  void GetData(uint8_t aAdress, uint8_t aRegister, int aBytes);
#endif
