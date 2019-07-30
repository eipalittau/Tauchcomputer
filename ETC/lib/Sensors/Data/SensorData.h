#ifndef _SENSORDATA_h
#define _SENSORDATA_h

#include "Essentials.h"

class SensorData {
public:
	SensorData();
	~SensorData();

	DateTimeData* DateTime();
	void Temperature(float aValue);
	float Temperature();
	void Pressure(float aValue);
	float Pressure();

class DateTimeData {
public:
	unsigned char Second();
	void Second(unsigned char aValue);
	unsigned char Minute();
	void Minute(unsigned char aValue);
	unsigned char Hour();
	void Hour(unsigned char aValue);
	unsigned char Day();
	void Day(unsigned char aValue);
	unsigned char Month();
	void Month(unsigned char aValue);
	unsigned short int Year();
	void Year(unsigned short int aValue);
	unsigned char Weekday();
	void Weekday(unsigned char aValue);

private:
	DateTimeData();
	~DateTimeData();
};

Private:
	DateTimeData* _DateTime = new DateTimeData();
	float _Temperature = FLOAT_MIN;
	float _Pressure = FLOAT_MIN;
};
#endif
