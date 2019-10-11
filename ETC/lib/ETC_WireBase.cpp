#include "ETC_WireBase.h"

ETC_WireBase::ETC_WireBase(uint8_t aAddress) {
  mAddress = aAddress;
}
  
ETC_WireBase::~ETC_WireBase() {}

uint8_t ETC_WireBase::Write(uint8_t aByte) {
  Wire.beginTransmission(mAddress);
  Wire.write(aByte);
  return Wire.endTransmission();
}

uint8_t ETC_WireBase::Request(uint8_t aByte, int aCount) {
  uint8_t lResult = Write(aByte);
  
  if (lResult == 0) {
    if (Wire.requestFrom(mAddress, aCount) == aCount) {
      return 0;
    } else {
      return 5;
    }
  } else {
    return lResult;
  }
}
