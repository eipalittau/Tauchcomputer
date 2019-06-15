#include "Pressure.h"

//#define MS5837_ADDR               0x76  
//#define MS5837_RESET              0x1E
//#define MS5837_ADC_READ           0x00
//#define MS5837_PROM_READ          0xA0
//#define MS5837_CONVERT_D1_8192    0x4A
//#define MS5837_CONVERT_D2_8192    0x5A

uint32_t D1, D2;
int32_t P;
unsigned long mNextAction;
unsigned long mNextCrcCheck;
unsigned char _IntervallCrcCheck;
bool _IsCrcOk;

//Constructor / Destructor
Pressure::Pressure(unsigned char aCheckCrcIntervall) : I2CBase(0x76) {
	I2CBase::RequestRegister(0x1E); //Reset
	mNextAction = millis() + 10;
	
	_IntervallCrcCheck = aIntervallCrcCheck;
	
	if (aIntervallCrcCheck == 0) {
		_IsCrcOk = false
	} else {
		Pressure::Wait4Action();
		
		if (Pressure::ReadTemperature()) {
			mNextAction = millis() + 10;
			Pressure::CheckCrc();
		} else {
			_IsCrcOk = false;
		}
	}
}

Pressure::~Pressure() {
	delete mNextAction;
	delete mNetxtCrcCheck;
	delete _IntervallCrcCheck;
	delete _IsCrcOk;
}

//Public
void CheckCrc() {
	_IsCrcOk = Pressure::crc4(C) == (C[0] >> 12);
	mNextCrcCheck = millis() + (_CheckCrcIntervall * 1000);
} 

bool Pressure::IsCrcOk() {
	return _IsCrcOk;
} 

float Pressure::GetData() {
	Pressure::Wait4Action();

	if (Pressure::ReadTemperature()) {
		mNextAction = millis() + 10;

		if (mNextCrcCheck <= millis() {
			Pressure::CheckCrc();
		}
		Pressure::Wait4Action();

		D1 = Pressure::ReadPressure(0x4A);
		D2 = Pressure::ReadPressure(0x5A);

		Pressure::Calculate();
	} else {
		_IsCrcOk = false;
		return FLOAT_MIN;
	}
}

void Pressure::ReadTemperature() {
	const unsigned char ARRAYSIZE = 2;

	unsigned char lSize = ARRAYSIZE;
	unsigned char lData[ARRAYSIZE];

	for (unsigned char lI = 0; lI < 7; lI++) {
		if (I2CBase::StartMesurement(0xA0 + (lI * 2), lSize) == 0) {
			if (lSize == ARRAYSIZE && I2CBase::GetData(lData) == ARRAYSIZE) {
				C[i] = (lData[0] << 8) | lData[1];
			}
		}
	}
}

uint32_t Pressure::ReadPressure(unsigned char aRegister) {
	unsigned char lSize = 3;
	uint32_t lResult = 0;

	if (I2CBase::RequestRegister(aRegister) == 0) {
		delay(20);

		if (I2CBase::StartMesurement(0x00, lSize) == 0) {
			I2CBase::GetData(aData[]);
				lResult = aData[0];
				lResult = (lResult << 8) | aData[1];
				lResult = (lResult << 8) | aData[2];
		}
	}

	return lResult;
}

void Wait4Action() {
	while mNextAction > millis() {}
}

void Pressure::Calculate() {
	int32_t dT = 0;
	int64_t SENS = 0;
	int64_t OFF = 0;
	int32_t SENSi = 0;
	int32_t OFFi = 0;
	int32_t Ti = 0;
	int64_t OFF2 = 0;
	int64_t SENS2 = 0;

	// Terms called
	dT = D2 - uint32_t(C[5]) * 256l;
	SENS = int64_t(C[1]) * 32768l + (int64_t(C[3])*dT) / 256l;
	OFF = int64_t(C[2]) * 65536l + (int64_t(C[4])*dT) / 128l;
	P = (D1*SENS / (2097152l) - OFF) / (8192l);

	// Temp conversion
	TEMP = 2000l + int64_t(dT)*C[6] / 8388608LL;

	//Second order compensation

	if ((TEMP / 100) < 20) {         //Low temp
		Ti = (3 * int64_t(dT)*int64_t(dT)) / (8589934592LL);
		OFFi = (3 * (TEMP - 2000)*(TEMP - 2000)) / 2;
		SENSi = (5 * (TEMP - 2000)*(TEMP - 2000)) / 8;
		if ((TEMP / 100) < -15) {    //Very low temp
			OFFi = OFFi + 7 * (TEMP + 1500l)*(TEMP + 1500l);
			SENSi = SENSi + 4 * (TEMP + 1500l)*(TEMP + 1500l);
		}
	} else if ((TEMP / 100) >= 20) {    //High temp
		Ti = 2 * (dT*dT) / (137438953472LL);
		OFFi = (1 * (TEMP - 2000)*(TEMP - 2000)) / 16;
		SENSi = 0;
	}

	OFF2 = OFF - OFFi;           //Calculate pressure and temp second order
	SENS2 = SENS - SENSi;

	TEMP = (TEMP - Ti);

	P = (((D1*SENS2) / 2097152l - OFF2) / 8192l);
}


uint8_t Pressure::crc4(uint16_t n_prom[]) {
	uint16_t n_rem = 0;

	n_prom[0] = (n_prom[0] & 0x0FFF);
	n_prom[7] = 0;

	for (uint8_t i = 0; i < 16; i++) {
		if (i % 2 == 1) {
			n_rem ^= (uint16_t)((n_prom[i >> 1]) & 0x00FF);
		}
		else {
			n_rem ^= (uint16_t)(n_prom[i >> 1] >> 8);
		}

		for (uint8_t n_bit = 8; n_bit > 0; n_bit--) {
			if (n_rem & 0x8000) {
				n_rem = (n_rem << 1) ^ 0x3000;
			}
			else {
				n_rem = (n_rem << 1);
			}
		}
	}

	n_rem = ((n_rem >> 12) & 0x000F);

	return n_rem ^ 0x00;
}
