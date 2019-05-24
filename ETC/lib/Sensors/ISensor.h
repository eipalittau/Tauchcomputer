#ifndef _ISENSOR_h
#define _ISENSOR_h

class ISensor {
protected:
	ISensor();
   
public:
	virtual ~ISensor();
	
	virtual void StartMeasurement() = 0;
	virtual void SetData(unsigned char aData[]) = 0;
	virtual unsigned char GetData(unsigned char aData[]) = 0;
};
#endif
