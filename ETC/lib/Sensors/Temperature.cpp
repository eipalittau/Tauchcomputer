#include "Temperature.h"

OneWire m1Wire(2);
ScratchPad mScratchPad;

//Constructor / Destructor
Temperature::Temperature() {}

Temperature::~Temperature() {}

//Public
float Temperature::GetData() {
	const int lDelayInMS = 94;
	
	if (SendCommand(0x44)) {
		unsigned long now = millis();
		
		while (m1Wire->read_bit() != 1 && millis() - lDelayInMS < now) {
			delay(lDelayInMS)
		}
		
		ReadScratchPad();
		
		signed short lTemperature = (((signed short) mScratchPad[1]) << 11) | (((signed short) mScratchPad[0]) << 3);

		return (float) lTemperature * 0.0078125;
	}
}
	
	
//Private
bool Temperature::SendCommand(unsigned char aValue) {
	if (m1Wire->reset() == 0) {
		return false;
	}
	
	m1Wire->select(deviceAddress);
	m1Wire->write(aValue);
	
	return true;
}

bool Temperature::ReadScratchPad() {
	if (SendCommand(0xBE)) {
		// byte 0: temperature LSB
		// byte 1: temperature MSB
		// byte 2: high alarm temp
		// byte 3: low alarm temp
		// byte 4: DS18S20: store for crc
		//         DS18B20 & DS1822: configuration register
		// byte 5: internal use & crc
		// byte 6: DS18S20: COUNT_REMAIN
		//         DS18B20 & DS1822: store for crc
		// byte 7: DS18S20: COUNT_PER_C
		//         DS18B20 & DS1822: store for crc
		// byte 8: SCRATCHPAD_CRC
		for (unsigned char lI = 0; lI < 9; lI++) {
			mScratchPad[i] = m1Wire->read();
		}

		return m1Wire->reset() == 1;
	} else {
		return false;
	}
}
