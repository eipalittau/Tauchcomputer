#ifndef _DATETIMEDATA_h
#define _DATETIMEDATA_h

#include "Essentials.h"

class DateTimeData {
public:
	DateTimeData();
	~DateTimeData();

	int Second();
	void Second(int aValue);
	int Minute();
	void Minute(int aValue);
	int Hour();
	void Hour(int aValue);
	int Day();
	void Day(int aValue);
	int Month();
	void Month(int aValue);
	int Year();
	void Year(int aValue);
	int Weekday();
	void Weekday(int aValue);
};
#endif