#ifndef _CALCULATION_h
#define _CALCULATION_h

#include "Essentials.h"
#include <math.h>

class Calculation {
public:
	Calculation();
	~Calculation();

	float Pressure(unsigned short aDepth);
	unsigned short Depth(float aPressure);
	float PartialPressure(unsigned char aGasProportion, float aTotalPressur);
	float EAD(unsigned char aO2Proportion, unsigned char aHe2Proportion, unsigned short aDepth);
	float EAD(unsigned char aN2Proportion, unsigned short aDepth);
	float END(unsigned char aO2Proportion, unsigned char aN2Proportion, float aTotalPressur);
	float PPO2(unsigned char aO2Proportion, unsigned short aDepth);
	float MOD(unsigned char aO2Proportion, unsigned char aMaxPPO2);
	float BestMix(unsigned char aMaxPPO2, unsigned short aDepth);
	float BestMix(unsigned char aMaxPPO2, float aTotalPressur);
	unsigned short OTU(unsigned short aDuration, float aPPO2);
	unsigned short MaxOTU(unsigned char aDay);

private:
	bool IsBetween100(unsigned char aValue);
	bool IsBetween7(unsigned char aValue);
};
#endif