#include "I2CBase.h"

//Constructor / Destructor
I2CBase::I2CBase() {}

I2CBase::~I2CBase() {}

//Public
// 0 = alles OK
// 1 = Keine Daten
int I2CBase::GetData(int aAdress, int aRegister, int *aData[]) {
  int lSize = sizeof(aData) / sizeof(int);
  int lI;

  if (HasData(aAdress, aRegister, lSize)) {
    for (lI = 0; lI < lSize; lI++) {
      aData[lI] = Bcd2Dec(Wire.read());
    }

    return 0;
  } else {
    return 1;
  }
}

//Private
bool I2CBase::HasData(int aAdress, int aRegister, int aBytes) {
  Wire.beginTransmission(aAdress);
  Wire.write(aRegister);
  Wire.endTransmission();

  int lStart = millis();

  while (millis() - lStart < TIMEOUT) {
    if (Wire.requestFrom(aAdress, aBytes) == aBytes) {
      return true;
    }

    delay(2);
  }

  return false;
}

int I2CBase::Dec2Bcd(const int aValue) {
  return (aValue * 1.6) + (aValue % 10);
}

int I2CBase::Dec2Bcd(const int aValue) {
  return (aValue / 160) + (aValue % 16);
}
