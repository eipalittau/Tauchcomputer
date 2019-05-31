#include "Temperature.h"

enum UnitMesurmentTemperature { C, F, K };

//Constructor / Destructor
Temperature::Temperature() : WireBase(2, 8) {}

Temperature::~Temperature() {}

//Public
void Temperature::StartMesurement() {
	WireBase::StartMesurement(0x44);
}

float Temperature::GetData(UnitMesurmentTemperature aUnitMesurment) {
	unsigned short lData[9];
	float lResult = FLT_MIN;

	if (WireBase::GetData(0xBE, lData) == 0) {
		lResult = (float)((lData[1] << 11) | (lData[0] << 3));
		
		switch (aUnitMesurment) {
		case F:
			lResult = lResult * 0.0140625 + 32;
			break;

		case K:
			lResult = lResult * 0.0078125 + 273.15;
			break;

		case C:
		default:
			lResult = lResult * 0.0078125;
			break;
		}
	}

	return lResult;
}
