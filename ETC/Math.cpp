#include "Math.h"

Math::Math() {}

Math::~Math() {}

int Math::IsBetween(int aLower, int aUpper, int aNumber) {
	return min(aUpper, max(aLower, aNumber));
}