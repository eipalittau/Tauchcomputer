#include "Math.h"

Math::Math() {}

Math::~Math() {}

bool Math::IsBetween(int aLower, int aUpper, int aNumber) {
	return aNumber >= aLower && aNumber <= aUpper;
}

int Math::Constrain(int aLower, int aUpper, int aNumber) {
	return min(aUpper, max(aLower, aNumber));
}
