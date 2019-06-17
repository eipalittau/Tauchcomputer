#ifndef _PRESSUREDATA_h
#define _PRESSUREDATA_h

class PressureData {
public:
	PressureData();
	~PressureData();

  int64_t Sensitivity();
  int64_t Offset();
  int64_t TCS();
  int64_t TCO();
  uint32_t ReferenceTemperature();
  int64_t TCT();
  
private:
  int64_t _Sensitivity;
  int64_t _Offset;
  int64_t _TCS;
  int64_t _TCO;
  uint32_t _ReferenceTemperature;
  int64_t _TCT;
};
#endif
