#ifdef _PRESSURE_h
#define _PRESSURE_h

#include "Base/I2CBase.h"
#include "Data/PressureData.h"
#include <math.h>
#include <assert.h>

class Pressure : protected I2CBase {
public:
	Pressure();
	~Pressure();

	bool IsCrcOk();
	long GetData();

private:
	unsigned long ReadData(unsigned char aRegister);
	unsigned char CheckCrc(unsigned int n_prom[]);

	bool _IsCrcOk = false;
	unsigned long mNextAction = 0;
	PressureData* mPressureData;
};
#endif
