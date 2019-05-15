#ifndef I2CBASE_H
  #define I2CBASE_H
  
  #include <Arduino.h>
  #include <Wire.h>
  #include "config.h"
  
  #define TIMEOUT 100

class I2CBase {
public:
  I2CBase(int aAdress, int aRegister);
  ~I2CBase();

  void I2CBase::SetData(int aData[]);
  int  I2CBase::GetData(int *aData[]);
  
private:
  int mAdress;
  int mRegister;
  
  bool I2CBase::HasData(int aBytes);
  int  I2CBase::Dec2Bcd(int aValue);
  int  I2CBase::Dec2Bcd(int aValue);
};
#endif
