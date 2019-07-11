#ifndef _CLOCK_h
#define _CLOCK_h

#include "I2C.h"
#include "DateTimeData.h"

class Clock {
public:
	Clock();
	~Clock();

	void StartMesurement();
	void SetData(DateTimeData aData);
	DateTimeData GetData();
};
#endif
