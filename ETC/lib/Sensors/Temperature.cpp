#include "Temperature.h"

//Constructor / Destructor
Temperature::Temperature() : WireBase(2, 8) {}

Temperature::~Temperature() {}

//Public
void Temperature::StartMesurement() {
	WireBase::StartMesurement(0x44);
}

float Temperature::GetData() {
	unsigned char lData[9];

	if (WireBase::GetData(0xBE, lData) == 0) {
		return (float)((lData[1] << 11) | (lData[0] << 3));
	}
	else {
		return FLOAT_MIN;
	}
}
