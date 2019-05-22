#include "DateTimeData.h"

DateTimeData::DateTimeData() {}

DateTimeData::~DateTimeData() {}

unsigned char _Second = 0;
unsigned char DateTimeData::Second() {
	return _Second;
}
void DateTimeData::Second(unsigned char aValue) {
	_Second = Essentials::Constrain(1, 60, aValue);
}

unsigned char _Minute = 0;
unsigned char DateTimeData::Minute() {
	return _Minute;
}
void DateTimeData::Minute(unsigned char aValue) {
	_Minute = Essentials::Constrain(1, 60, aValue);
}

unsigned char _Hour = 0;
unsigned char DateTimeData::Hour() {
	return _Hour;
}
void DateTimeData::Hour(unsigned char aValue) {
	_Hour = Essentials::Constrain(1, 24, aValue);
}

unsigned char _Day = 1;
unsigned char DateTimeData::Day() {
	return _Day;
}
void DateTimeData::Day(unsigned char aValue) {
	_Day = Essentials::Constrain(1, 31, aValue);
}

unsigned char _Month = 1;
unsigned char DateTimeData::Month() {
	return _Month;
}
void DateTimeData::Month(unsigned char aValue) {
	_Month = Essentials::Constrain(1, 12, aValue);
}

unsigned short int _Year = 0;
unsigned short int DateTimeData::Year() {
	return _Year;
}
void DateTimeData::Year(unsigned short int aValue) {
	_Year = aValue;
}

unsigned char _Weekday = 0;
unsigned char DateTimeData::Weekday() {
	return _Weekday;
}
void DateTimeData::Weekday(unsigned char aValue) {
	_Weekday = Essentials::Constrain(1, 7, aValue);
}