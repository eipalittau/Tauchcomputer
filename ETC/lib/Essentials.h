#ifndef _ESSENTIALS_H
#define _ESSENTIALS_H

#include <math.h>

class Essentials {
public:
	static bool IsBetween(int16_t aLower, int16_t aUpper, int16_t aNumber);
	static int16_t Constrain(int16_t aLower, int16_t aUpper, int16_t aNumber);

private:
	Essentials();
	~Essentials();
};
#endif
