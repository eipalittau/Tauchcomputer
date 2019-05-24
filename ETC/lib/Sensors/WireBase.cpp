#include "WireBase.h"

OneWire m1Wire;

//Constructor / Destructor
WireBase::WireBase(unsigned char aPinNumber) {
  m1Wire(aPinNumber);
}

WireBase::~WireBase() {}

//Protected
void WireBase::StartMesurement(unsigned char aCommand) {
	SendCommand(aValue);
}

unsigned char WireBase::GetData(unsigned char aCommand, unsigned char aData[]) {
  unsigned long lStart = millis();

  while (m1Wire->read_bit() != 1 && millis() - lStart < Constants.TIMEOUT) {
    delay(2)
  }

  if (SendCommand(aCommand)) {
    unsigned short lSize = sizeof(aData) / sizeof(unsigned char);
    
    for (unsigned char lI = 0; lI < lSize; lI++) {
      aData[i] = m1Wire->read();
    }
    
    return 0;
  }

	return 1;
}
	
	
//Private
bool WireBase::SendCommand(unsigned char aValue) {
	if (m1Wire->reset() == 0) {
		return false;
	}
	
	m1Wire->select(deviceAddress);
	m1Wire->write(aValue);
	
	return true;
}
