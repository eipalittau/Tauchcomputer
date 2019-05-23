#include "Temperature.h"

const unsigned char TIMEOUT = 100;

OneWire m1Wire(2);

//Constructor / Destructor
Temperature::Temperature() {}

Temperature::~Temperature() {}

//Public
float Temperature::GetData() {
	ScratchPad lScratchPad;

	if (SendCommand(0x44)) {
		unsigned long lStart = millis();

		while (m1Wire->read_bit() != 1 && millis() - lStart < Constants.TIMEOUT) {
			delay(2)
		}
		
		if (SendCommand(0xBE)) {
			for (unsigned char lI = 0; lI < 9; lI++) {
				lScratchPad[i] = m1Wire->read();
			}

			return (float) ((((signed short)lScratchPad[1]) << 11) | (((signed short)lScratchPad[0]) << 3)) * 0.0078125;
		}
	}

	return numeric_limits<float>::min();
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