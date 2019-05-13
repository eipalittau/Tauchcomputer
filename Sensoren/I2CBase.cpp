#include "I2CBase.h"

//Constructor / Destructor
I2CBase::I2CBase(int aAdress, int aRegister) {
  mAdress = aAdress;
  mRegister = aRegister;
}

I2CBase::~I2CBase() {}

//Public
void I2CBase::SetData(int aData[]) {
  int lSize = sizeof(aData) / sizeof(int);
  int lI;
  
  Wire.beginTransmission(mAdress);
  Wire.write(mREgister);
  for (lI = 0; lI < lSize; lI++) {
    Wire.Write(Dec2Bcd(aData[lI]));
  }
  Wire.endTransmission();
}

// 0 = alles OK
// 1 = Keine Daten
int I2CBase::GetData(int *aData[]) {
  int lSize = sizeof(aData) / sizeof(int);
  int lI;

  if (HasData(lSize)) {
    for (lI = 0; lI < lSize; lI++) {
      aData[lI] = Bcd2Dec(Wire.read());
    }

    return 0;
  } else {
    return 1;
  }
}

//Private
bool I2CBase::HasData(int aBytes) {
  Wire.beginTransmission(mAdress);
  Wire.write(mRegister);
  Wire.endTransmission();

  int lStart = millis();

  while (millis() - lStart < TIMEOUT) {
    if (Wire.requestFrom(mAdress, aBytes) == aBytes) {
      return true;
    }

    delay(2);
  }

  return false;
}

int I2CBase::Dec2Bcd(int aValue) {
  return (aValue * 1.6) + (aValue % 10);
}

int I2CBase::Dec2Bcd(int aValue) {
  return (aValue / 160) + (aValue % 16);
}
