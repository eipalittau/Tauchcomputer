#ifndef _CLOCK_h
#define _CLOCK_h

#include "I2CBase.h"
#include "DateTimeData.h"

class Clock : public I2CBase {
public:
	Clock();
	~Clock();

	void SetData(DateTimeData aData);
	DateTimeData GetData();
};
#endif