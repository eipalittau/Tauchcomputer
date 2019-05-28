#ifndef _I2CBASE_h
#define _I2CBASE_h

#include <Arduino.h>
#include <Wire.h>
#include "Constants.h"

class I2CBase {
protected:
	///<summary>Constructor</summary>
	///<param name="aI2CAdress">I2C Bus-Addresse</param>
	///<param name="aRegister">Anzusprechendes Sensor-Register</param>
	I2CBase(unsigned char aI2CAdress, unsigned char aRegister);

	///<summyry>Destructor</summary>
	~I2CBase();

	///<summary>Weisst den Sensor zur Datenerfassung an.</summary>
	///<param name="aDataSize">Anzahl Bytes die erwartet werden.</param>
	///<returns>0 = Successful send.
	///1 = Send buffer too large for the twi buffer.
	///2 = Address was sent and a NACK received. This is an issue, and the master should send a STOP condition.
	///3: Data was sent and a NACK received. This means the slave has no more to send. The master can send a STOP condition, or a repeated START.
	///4: Another twi error took place (eg, the master lost bus arbitration).</returns>
	char StartMesurement(unsigned char &aDataSize);

	void SetData(unsigned char aData[]);

	///<summary>Liest die gesammelten Daten des Sensors.</summary>
	///<param name="aData">Array, in welchen die Daten geschrieben werden.</param>
	///<returns>Wieviele Bytes gelesen wurden.</returns>
	int GetData(unsigned char aData[]);

private:
	///<summary>Konvertiert den übergebenen dezimalen Wert in einen Hexadezimalen.</summary>
	unsigned char Dec2Hex(unsigned char aValue);

	///<summary>Konvertiert den übergebenen hexadezimalen Wert in einen Dezimalen.</summary>
	unsigned char Hex2Dec(unsigned char aValue);
};
#endif
