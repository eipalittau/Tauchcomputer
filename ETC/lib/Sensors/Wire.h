#ifndef _WIRE_h
#define _WIRE_h

#include <OneWire.h>
#include "Constants.h"
#include <assert.h>

class Wire {
public:
	///<summary>Constructor</summary>
	///<param name="aPinNumber">Nummer des angeschlossenen Pin's.</param>
	///<param name="aDeviceAdressSize">Grösse des Arrays.</param>
	Wire(unsigned char aPinNumber, unsigned char aDeviceAdressSize);

	///<summyry>Destructor</summary>
	~Wire();

	///<summary>Liest die gesammelten Daten des Sensors.</summary>
	///<param name="aCommand">Anzusprechendes Sensor-Register.</param>
	///<param name="aData">Array, in welchen die Daten geschrieben werden.</param>
	///<returns</returns>
	unsigned char GetData(unsigned char aCommand, uint16_t aData[]);

private:
	bool SendCommand(unsigned char aValue);

	OneWire* m1Wire;
	uint8_t* mDeviceAddress;
};
#endif
