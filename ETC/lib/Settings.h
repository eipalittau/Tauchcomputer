#ifndef _SETTINGS_h
#define _SETTINGS_h

class Settings {
public:
	enum TemperatureUnitEnum { C, F, K };
	enum PressureUnitEnum { mBar, hPa };

	void static SetTemperatureUnit(TemperatureUnitEnum aValue);
	TemperatureUnitEnum static GetTemperatureUnit();

	void static SetPressureUnit(PressureUnitEnum aValue);
	PressureUnitEnum static GetPressureUnit();

	void static SetWaterDensity(int aValue);
	int static GetWaterDensity();
private:
	///<summary>Constructor</summary>
	Settings();

	///<summyry>Destructor</summary>
	~Settings();

	TemperatureUnitEnum _TemperatureUnit = C;
	PressureUnitEnum _PessureUnit = mBar;
	int _WaterDensity;
};
#endif
