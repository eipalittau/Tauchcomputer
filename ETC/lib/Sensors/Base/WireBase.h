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
	WireBase(uint8_t aPinNumber, uint8_t aDeviceAdressSize);

	///<summyry>Destructor</summary>
	~WireBase();

	///<summary>Weisst den Sensor zur Datenerfassung an.</summary>
	///<param name="aCommand">Anzusprechendes Sensor-Register</param>
	void StartMesurement(uint8_t aCommand);

	///<summary>Liest die gesammelten Daten des Sensors.</summary>
	///<param name="aCommand">Anzusprechendes Sensor-Register.</param>
	///<param name="aData">Array, in welchen die Daten geschrieben werden.</param>
	///<returns</returns>
	unsigned char GetData(uint8_t aCommand, uint16_t aData[]);

private:
	bool SendCommand(uint8_t aValue);

	OneWire* m1Wire;
	uint8_t* mDeviceAddress;
};
#endif
