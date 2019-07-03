#include "Essentials.h"

Essentials::Essentials() {}

Essentials::~Essentials() {}

bool Essentials::IsBetween(int16_t aLower, int16_t aUpper, int16_t aNumber) {
	return aNumber >= aLower && aNumber <= aUpper;
}

int16_t Essentials::Constrain(int16_t aLower, int16_t aUpper, int16_t aNumber) {
	return fmin(aUpper, fmax(aLower, aNumber));
}
