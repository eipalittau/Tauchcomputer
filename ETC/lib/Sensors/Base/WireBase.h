#ifndef _WIREBASE_h
#define _WIREBASE_h

#include <OneWire.h>
#include "Constants.h"
#include <assert.h>

class WireBase {
protected:
	WireBase(unsigned char aPinNumber, unsigned char aDeviceAdressSize);
	~WireBase();

	void StartMesurement(unsigned char aCommand);
	unsigned char GetData(unsigned char aCommand, unsigned short aData[]);

	//Private
	bool SendCommand(unsigned char aValue);
};
#endif
