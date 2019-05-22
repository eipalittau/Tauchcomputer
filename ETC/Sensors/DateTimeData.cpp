#include "DateTimeData.h"

DateTimeData::DateTimeData() {}

DateTimeData::~DateTimeData() {}

int _Second = 0;
int DateTimeData::Second() {
	return _Second;
}
void DateTimeData::Second(int aValue) {
	_Second = Essentials::Constrain(1, 60, aValue);
}

int _Minute = 0;
int DateTimeData::Minute() {
	return _Minute;
}
void DateTimeData::Minute(int aValue) {
	_Minute = Essentials::Constrain(1, 60, aValue);
}

int _Hour = 0;
int DateTimeData::Hour() {
	return _Hour;
}
void DateTimeData::Hour(int aValue) {
	_Hour = Essentials::Constrain(1, 24, aValue);
}

int _Day = 1;
int DateTimeData::Day() {
	return _Day;
}
void DateTimeData::Day(int aValue) {
	_Day = Essentials::Constrain(1, 31, aValue);
}

int _Month = 1;
int DateTimeData::Month() {
	return _Month;
}
void DateTimeData::Month(int aValue) {
	_Month = Essentials::Constrain(1, 12, aValue);
}

int _Year = 0;
int DateTimeData::Year() {
	return _Year;
}
void DateTimeData::Year(int aValue) {
	_Year = aValue;
}

int _Weekday = 0;
int DateTimeData::Weekday() {
	return _Weekday;
}
void DateTimeData::Weekday(int aValue) {
	_Weekday = Essentials::Constrain(1, 7, aValue);
}