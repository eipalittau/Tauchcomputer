#ifndef _WIREBASE_h
#define _WIREBASE_h

#include <OneWire.h>
#include "Constants.h"

class WireBase {
protected:
	WireBase(unsigned char aPinNumber);
	~WireBase();
	
	void StartMesurement(unsigned char aCommand);
  unsigned char GetData(unsigned char aCommand, unsigned char aData[]);
	
//Private
  bool SendCommand(unsigned char aValue);
};
#endif
