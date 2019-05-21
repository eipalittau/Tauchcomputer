#include "DateTimeData.h"

DateTimeData::DateTimeData() {}

DateTimeData::~DateTimeData() {}

int DateTimeData::Second() {
	return _Second;
}
void DateTimeData::Second(int aValue) {
	_Second = Constrain60(aValue);
}

int DateTimeData::Minute() {
	return _Minute;
}
void DateTimeData::Minute(int aValue) {
	_Minute = Constrain60(aValue);
}

int DateTimeData::Hour() {
	return _Hour;
}
void DateTimeData::Hour(int aValue) {
	_Hour = Constrain24(aValue);
}

int DateTimeData::Day() {
	return _Day;
}
void DateTimeData::Day(int aValue) {
	_Day = Constrain31(aValue);
}

int DateTimeData::Month() {
	return _Month;
}
void DateTimeData::Month(int aValue) {
	_Month = Constrain12(aValue);
}

int DateTimeData::Year() {
	return _Year;
}
void DateTimeData::Year(int aValue) {
	_Year = aValue;
}

int DateTimeData::Weekday() {
	return _Weekday;
}
void DateTimeData::Weekday(int aValue) {
	_Weekday = Constrain7(aValue);
}

int DateTimeData::Constrain60(int aNumber) {
	return Essentials::Constrain(0, 60, aNumber);
}

int DateTimeData::Constrain31(int aNumber) {
	return Essentials::Constrain(1, 31, aNumber);
}

int DateTimeData::Constrain24(int aNumber) {
	return Essentials::Constrain(0, 24, aNumber);
}

int DateTimeData::Constrain12(int aNumber) {
	return Essentials::Constrain(1, 12, aNumber);
}

int DateTimeData::Constrain7(int aNumber) {
	return Essentials::Constrain(1, 7, aNumber);
}
