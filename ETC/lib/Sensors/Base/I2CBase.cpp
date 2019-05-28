#include "I2CBase.h"

unsigned char mI2CAdress;
unsigned char mRegister;
static boolean mInitWire = true;

//Constructor / Destructor
I2CBase::I2CBase(unsigned char aI2CAdress, unsigned char aRegister) {
	mI2CAdress = aI2CAdress;
	mRegister = aRegister;
	
	if (mInitWire) {
		mInitWire = false;
		Wire.begin();
	}
	
	Wire.onReceive(OnReceiveData);
}

I2CBase::~I2CBase() {}

//Protected
//0: Successful send.
//1: Send buffer too large for the twi buffer. This should not happen, as the TWI buffer length set in twi.h is equivalent to the send buffer length set in Wire.h.
//2: Address was sent and a NACK received. This is an issue, and the master should send a STOP condition.
//3: Data was sent and a NACK received. This means the slave has no more to send. The master can send a STOP condition, or a repeated START.
//4: Another twi error took place (eg, the master lost bus arbitration).
char I2CBase::StartMeasurement(unsigned char aDataSize) {
	char lResult;
	
	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	lResult = Wire.endTransmission();
	
	if (lResult == 0) {
		Wire.requestFrom(mI2CAdress, aDataSize, true);
	} else {
		return lResult;
	}
}

void I2CBase::SetData(unsigned char aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);

	Wire.beginTransmission(mI2CAdress);
	Wire.write(mRegister);
	
	for (int lI = 0; lI < lSize; lI++) {
		Wire.write(aData[lI]);
	}
	Wire.endTransmission();
}

unsigned char I2CBase::GetData(unsigned char aData[]) {
	int lSize = sizeof(aData) / sizeof(unsigned char);
	
	for (int lI = 0; lI < lSize; lI++) {
		if (Wire.available()) {
			aData.[lI] = Hex2Dec(Wire.read());
		} else {
			return 1;
		}
	}

return 0;
}

//Private
unsigned char I2CBase::Dec2Hex(unsigned char aValue) {
	return (aValue * 1.6) + (aValue % 10);
}

unsigned char I2CBase::Hex2Dec(unsigned char aValue) {
	return (aValue / 160) + (aValue % 16);
}
