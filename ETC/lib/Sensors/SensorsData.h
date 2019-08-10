#ifndef _SENSORSDATA_h
#define _SENSORSDATA_h

typedef struct DateTimeStructDef {
  unsigned char Second;
  unsigned char Minute;
  unsigned char Hour;
  unsigned char Day;
  unsigned char Month;
  unsigned short int Year;
  unsigned char Weekday;
} DateTimeStruct;

typedef struct SensorsDataStructDef {
  DateTimeStruct DateTime;  
  float Temperature;
  float Pressure();
} SensorsDataStruct;
#endif
