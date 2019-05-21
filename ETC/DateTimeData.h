#ifndef _DATETIMEDATA_h
#define _DATETIMEDATA_h

#include <Math.h>

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

	private:
		int _Second = 0;
		int _Minute = 0;
		int _Hour = 0;
		int _Day = 1;
		int _Month = 1;
		int _Year = 0;
		int _Weekday = 0;

		int Constrain60(int aNumber);
		int Constrain31(int aNumber);
		int Constrain24(int aNumber);
		int Constrain12(int aNumber);
		int Constrain7(int aNumber);
#endif
