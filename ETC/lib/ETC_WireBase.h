#ifndef _ETC_WireBase_H
#define _ETC_WireBase_H

#include <Wire.h>

class ETC_WireBase {
public:
  ETC_WireBase(uint8_t aAddress);
  ~ETC_WireBase();

protected:
  uint8_t Write(uint8_t aByte) ;
  uint8_t Request(uint8_t aByte, int aCount);

private:
  uint8_t mAddress;
};
#endif
