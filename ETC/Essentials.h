
#ifndef _ESSENTIALS_h
#define _ESSENTIALS_h

class Essentials {
	public:
		static bool IsBetween(int aLower, int aUpper, int aNumber);
		static int  Constrain(int aLower, int aUpper, int aNumber);
	
	private:
		Essentials();
		~Essentials();
};
#endif
