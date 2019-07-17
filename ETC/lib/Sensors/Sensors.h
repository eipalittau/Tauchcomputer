#ifndef _SENSORS_h
#define _SENSORS_h

#include "I2C.h"
#include "Wire.h"
#include "SensorData.h"

class Sensors {
public:
	Sensors();
	~Sensors();

	void StartMesurement();
	SensorData GetData();

private:
	void Sensors::Pressure_CreateCrc();
	uint32_t Pressure_ReadData(uint8_t aRegister);
	uint8_t Sensors::Pressure_CheckCrc(unsigned int n_prom[]);
	
	SensorData* mSensorData;	
	I2C mClock;
	I2C mPressure;
	OneWire mTemperature;
	//PressureData* mPressureData;
	uint32_t mNextAction;
	bool _IsCrcOk;
};
#endif
