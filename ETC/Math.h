#ifndef _MATH_h
#define _MATH_h

class Math {
	public:
		static bool IsBetween(int aLower, int aUpper, int aNumber);
		static int Constrain(int aLower, int aUpper, int aNumber);
	
	private:
		Math();
		~Math();
};
#endif
