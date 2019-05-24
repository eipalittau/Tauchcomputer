#include "Temperature.h"

//Constructor / Destructor
Temperature::Temperature() : WireBase(2) {}

Temperature::~Temperature() {}

//Public
void Temperature::StartMesurement() {
	WireBase::StartMesurement(0x44);
}

float Temperature::GetData() {
	signed short lData[9]
		
	if (WireBase::GetData(0xBE, lData) = 0) {
		return (float) ((lData[1] << 11) | (lData[0] << 3)) * 0.0078125;
	} else {
		return numeric_limits<float>::min();
	}
}
