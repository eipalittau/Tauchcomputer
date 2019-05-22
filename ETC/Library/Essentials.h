#ifndef _ESSENTIALS_H
#define _ESSENTIALS_H

#include <math.h>

class Essentials {
	public:
		static bool IsBetween(int aLower, int aUpper, int aNumber);
		static int Constrain(int aLower, int aUpper, int aNumber);

	private:
		Essentials();
		~Essentials();
};
#endif