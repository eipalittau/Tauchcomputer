#ifndef _SENSORDATA_h
#define _SENSORDATA_h

typedef struct DateTimeStructDef {
	unsigned char Second;
	unsigned char Minute;
	unsigned char Hour;
	unsigned char Day;
	unsigned char Month;
	unsigned short int Year;
	unsigned char Weekday;
} DateTimeStruct;

typedef struct SensorStructDef {
	DateTimeStruct DateTime;	
	float Temperature;
	float Pressure();
} SensorStruct;

#endif
