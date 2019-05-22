#include "Temperature.h"

//Constructor / Destructor
Temperature::Temperature() : I2CBase(104, 17) {}

Temperature::~Temperature() {}

//Public
TemperatureData Temperature::GetData() {
	unsigned char lTemperature[2];
	TemperatureData lResult;

	if (I2CBase::GetData(lTemperature) == 0) {
		
	}
}