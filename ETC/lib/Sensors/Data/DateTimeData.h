#ifndef _DATETIMEDATA_h
#define _DATETIMEDATA_h

#include "Essentials.h"

class DateTimeData {
public:
	DateTimeData();
	~DateTimeData();

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
};
#endif