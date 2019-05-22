#include "Calculation.h"

Calculation::Calculation() {}

Calculation::~Calculation() {}

float Calculation::Pressure(unsigned short aDepth) {
	return aDepth / (float)10 + 1;
}

unsigned short Calculation::Depth(float aPressure) {
	return (aPressure - 1) * 10;
}

float Calculation::PartialPressure(unsigned char aGasProportion, float aTotalPressur) {
	if (!IsBetween100(aGasProportion)) {
		return -1;
	}

	return aGasProportion / aTotalPressur;
}

float Calculation::EAD(unsigned char aO2Proportion, unsigned char aHe2Proportion, unsigned short aDepth) {
	return EAD(100 - (aO2Proportion + aHe2Proportion), aDepth);
}

float Calculation::EAD(unsigned char aN2Proportion, unsigned short aDepth) {
	if (!IsBetween100(aN2Proportion)) {
		return -1;
	}

	return ((aDepth + 10) * aN2Proportion / 78.09) - 10;
}

float Calculation::END(unsigned char aO2Proportion, unsigned char aN2Proportion, float aTotalPressur) {
	unsigned char lGasProportion = aO2Proportion + aN2Proportion;

	if (!IsBetween100(lGasProportion)) {
		return -1;
	}

	return aTotalPressur * lGasProportion;
}

float Calculation::PPO2(unsigned char aO2Proportion, unsigned short aDepth) {
	return Pressure(aDepth) * aO2Proportion;
}

float Calculation::MOD(unsigned char aO2Proportion, unsigned char aMaxPPO2) {
	return aMaxPPO2 * 10 / aO2Proportion - 10;
}

float Calculation::BestMix(unsigned char aMaxPPO2, unsigned short aDepth) {
	return aMaxPPO2 / Pressure(aDepth);
}

float Calculation::BestMix(unsigned char aMaxPPO2, float aTotalPressur) {
	return aMaxPPO2 / aTotalPressur;
}

unsigned short Calculation::OTU(unsigned short aDuration, float aPPO2) {
	return aDuration * pow((aPPO2 - 0.5) * 2, 5.0 / 6.0);
}

unsigned short Calculation::MaxOTU(unsigned char aDay) {
	if (!IsBetween7(aDay)) {
		return -1;
	}

	unsigned short lOTU[] = { 850, 700, 620, 525, 460, 420, 380 };

	return lOTU[aDay];
}

bool Calculation::IsBetween100(unsigned char aValue) {
	return Essentials::IsBetween(1, 100, aValue);
}

bool Calculation::IsBetween7(unsigned char aValue) {
	return Essentials::IsBetween(1, 7, aValue);
}