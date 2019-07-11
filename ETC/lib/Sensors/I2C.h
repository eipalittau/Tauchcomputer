#ifndef _I2C_h
#define _I2C_h

#include <Arduino.h>
#include <Wire.h>
#include "Constants.h"

class I2C {
public:
	///<summary>Constructor</summary>
	///<param name="aI2CAdress">I2C Bus-Addresse</param>
	I2C(uint8_t aI2CAdress);

	///<summary>Constructor</summary>
	///<param name="aI2CAdress">I2C Bus-Addresse</param>
	///<param name="aInitWire">Soll die Wire-Klasse initialisiert werden?</param>
	I2C(uint8_t aI2CAdress, bool aInitWire);

	///<summyry>Destructor</summary>
	~I2C();

	///<summary>Ruft ein Resgister an.</summary>
	///<param name="aRegister">Anzusprechendes Sensor-Register</param>
	///<returns>0 = Successful send.
	///1 = Send buffer too large for the twi buffer.
	///2 = Address was sent and a NACK received. This is an issue, and the master should send a STOP condition.
	///3 = Data was sent and a NACK received. This means the slave has no more to send. The master can send a STOP condition, or a repeated START.
	///4 = Another twi error took place (eg, the master lost bus arbitration).</returns>
	int8_t RequestRegister(uint8_t aRegister);

	///<summary>Weisst den Sensor zur Datenerfassung an.</summary>
	///<param name="aRegister">Anzusprechendes Sensor-Register</param>
	///<param name="aDataSize">Anzahl Bytes die erwartet werden.</param>
	///<returns>0 = Successful send.
	///1 = Send buffer too large for the twi buffer.
	///2 = Address was sent and a NACK received. This is an issue, and the master should send a STOP condition.
	///3 = Data was sent and a NACK received. This means the slave has no more to send. The master can send a STOP condition, or a repeated START.
	///4 = Another twi error took place (eg, the master lost bus arbitration).</returns>
	int8_t StartMesurement(uint8_t aRegister, uint8_t &aDataSize);

	void SetData(uint8_t aData[]);

	///<summary>Liest die gesammelten Daten des Sensors.</summary>
	///<param name="aData">Array, in welchen die Daten geschrieben werden.</param>
	///<returns>Wieviele Bytes gelesen wurden.</returns>
	int GetData(uint8_t aData[]);

private:
	///<summary>Konvertiert den übergebenen dezimalen Wert in einen Hexadezimalen.</summary>
	uint8_t Dec2Hex(uint8_t aValue);

	///<summary>Konvertiert den übergebenen hexadezimalen Wert in einen Dezimalen.</summary>
	uint8_t Hex2Dec(uint8_t aValue);

	uint8_t mI2CAdress;
};
#endif
