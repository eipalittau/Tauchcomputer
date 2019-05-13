#ifndef __i2cbase_h_
  #define __i2cbase_h_
  
  #include <Arduino.h>
  #include <Wire.h>
  #include "config.h"
  
  #define TIMEOUT 100
#endif

class I2CBase {
public:
  I2CBase();
  ~I2CBase();

  int I2CBase::GetData(int aAdress, int aRegister, int *aData[]);
  int I2CBase::SetData(int aAdress, int aRegister, int aData[]);
  
private:
  bool I2CBase::HasData(int aAdress, int aRegister, int aBytes);
  int  I2CBase::Dec2Bcd(int aValue);
  int  I2CBase::Dec2Bcd(int aValue);
};
