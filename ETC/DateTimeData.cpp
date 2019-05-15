#include "DateTimeData.h"

DateTimeData::DateTimeData() {}

DateTimeData::~DateTimeData() {}

int DateTimeData::Second() {
	return _Second;
}
void DateTimeData::Second(int aValue) {
	_Second = IsBetween60(aValue);
}

int DateTimeData::Minute() {
	return _Minute;
}
void DateTimeData::Minute(int aValue) {
	_Minute = IsBetween60(aValue);
}

int DateTimeData::Hour() {
	return _Hour;
}
void DateTimeData::Hour(int aValue) {
	_Hour = IsBetween24(aValue);
}

int DateTimeData::Day() {
	return _Day;
}
void DateTimeData::Day(int aValue) {
	_Day = IsBetween31(aValue);
}

int DateTimeData::Month() {
	return _Month;
}
void DateTimeData::Month(int aValue) {
	_Month = IsBetween12(aValue);
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
	_Weekday = IsBetween7(aValue);
}

int DateTimeData::IsBetween60(int aNumber) {
	return Math::IsBetween(0, 60, aNumber);
}

int DateTimeData::IsBetween31(int aNumber) {
	return Math::IsBetween(1, 31, aNumber);
}

int DateTimeData::IsBetween24(int aNumber) {
	return Math::IsBetween(0, 24, aNumber);
}

int DateTimeData::IsBetween12(int aNumber) {
	return Math::IsBetween(1, 12, aNumber);
}

int DateTimeData::IsBetween7(int aNumber) {
	return Math::IsBetween(1, 7, aNumber);
}