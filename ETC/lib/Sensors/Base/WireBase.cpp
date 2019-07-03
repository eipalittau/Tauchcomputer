#include "WireBase.h"

#pragma region Constructor / Destructor
WireBase::WireBase(uint8_t aPinNumber, const uint8_t aDeviceAdressSize) {
	assert(aPinNumber < 0 || aPinNumber > 13);

	m1Wire = new OneWire(aPinNumber);
	mDeviceAddress = new uint8_t[aDeviceAdressSize]();

	while (m1Wire->search(mDeviceAddress)) {
		if (m1Wire->crc8(mDeviceAddress, aDeviceAdressSize - 1) == mDeviceAddress[aDeviceAdressSize - 1]) {
			break;
		}
	}
}

WireBase::~WireBase() {
	assert(m1Wire == NULL);

	delete m1Wire;
}
#pragma endregion

#pragma region Protected
void WireBase::StartMesurement(uint8_t aCommand) {
	SendCommand(aCommand);
}

unsigned char WireBase::GetData(uint8_t aCommand, uint16_t aData[]) {
	uint32_t lStart = millis();

	while (m1Wire->read_bit() != 1 && millis() - lStart < TIMEOUT) {
		delay(2);
	}

	if (SendCommand(aCommand)) {
		uint16_t lSize = sizeof(aData) / sizeof(unsigned char);

		for (uint8_t lI = 0; lI < lSize; lI++) {
			aData[lI] = m1Wire->read();
		}

		return 0;
	}

	return 1;
}
#pragma endregion

#pragma region Private
bool WireBase::SendCommand(uint8_t aValue) {
	if (m1Wire->reset() == 0) {
		return false;
	}

	m1Wire->select(mDeviceAddress);
	m1Wire->write(aValue);

	return true;
}
#pragma endregion
