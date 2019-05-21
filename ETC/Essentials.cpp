#include "Essentials.h"

Essentials::Essentials() {}

Essentials::~Essentials() {}

bool Essentials::IsBetween(int aLower, int aUpper, int aNumber) {
	return aNumber >= aLower && aNumber <= aUpper;
}

int Essentials::Constrain(int aLower, int aUpper, int aNumber) {
	return min(aUpper, max(aLower, aNumber));
}
