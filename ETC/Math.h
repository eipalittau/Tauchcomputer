#ifndef _MATH_h
#define _MATH_h

class Math {
	public:
		static int IsBetween(int aLower, int aUpper, int aNumber);
		static bool Constrain(int aLower, int aUpper, int aNumber);
	
	private:
		Math();
		~Math();
};
#endif
