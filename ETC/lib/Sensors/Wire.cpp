#include "Wire.h"

#pragma region Constructor / Destructor
Wire::Wire(uint8_t aPinNumber, const uint8_t aDeviceAdressSize) {
	assert(aPinNumber < 0 || aPinNumber > 13);

	m1Wire = new OneWire(aPinNumber);
	mDeviceAddress = new uint8_t[aDeviceAdressSize]();

	while (m1Wire->search(mDeviceAddress)) {
		if (m1Wire->crc8(mDeviceAddress, aDeviceAdressSize - 1) == mDeviceAddress[aDeviceAdressSize - 1]) {
			break;
		}
	}
}

Wire::~Wire() {
	assert(m1Wire == NULL);

	delete m1Wire;
}
#pragma endregion

#pragma region Protected
void Wire::StartMesurement(unsigned char aCommand) {
	SendCommand(aCommand);
}

unsigned char WireBase::GetData(unsigned char aCommand, uint16_t aData[]) {
	uint32_t lStart = millis();

	while (m1Wire->read_bit() != 1 && millis() - lStart < TIMEOUT) {
		delay(2);
	}

	if (SendCommand(aCommand)) {
		uint16_t lSize = sizeof(aData) / sizeof(unsigned char);

		for (unsigned char lI = 0; lI < lSize; lI++) {
			aData[lI] = m1Wire->read();
		}

		return 0;
	}

	return 1;
}
#pragma endregion

#pragma region Private
bool Wire::SendCommand(uint8_t aValue) {
	if (m1Wire->reset() == 0) {
		return false;
	}

	m1Wire->select(mDeviceAddress);
	m1Wire->write(aValue);

	return true;
}
#pragma endregion
