#ifndef _WIREBASE_h
#define _WIREBASE_h

#include <OneWire.h>
#include "Constants.h"
#include <assert.h>

class WireBase {
protected:
	///<summary>Constructor</summary>
	///<param name="aPinNumber">Nummer des angeschlossenen Pin's.</param>
	///<param name="aDeviceAdressSize">Grösse des Arrays.</param>
	WireBase(unsigned char aPinNumber, unsigned char aDeviceAdressSize);

	///<summyry>Destructor</summary>
	~WireBase();

	///<summary>Weisst den Sensor zur Datenerfassung an.</summary>
	///<param name="aCommand">Anzusprechendes Sensor-Register</param>
	void StartMesurement(unsigned char aCommand);

	///<summary>Liest die gesammelten Daten des Sensors.</summary>
	///<param name="aCommand">Anzusprechendes Sensor-Register.</param>
	///<param name="aData">Array, in welchen die Daten geschrieben werden.</param>
	///<returns</returns>
	unsigned char GetData(unsigned char aCommand, unsigned short aData[]);

private:
	bool SendCommand(unsigned char aValue);

	OneWire* m1Wire;
	uint8_t* mDeviceAddress;
};
#endif
