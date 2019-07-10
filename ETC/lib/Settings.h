#ifndef _SETTINGS_h
#define _SETTINGS_h

class Settings {
public:
	enum TemperatureUnitEnum { C, F, K };

	void static SetTemperatureUnit(TemperatureUnitEnum aValue);
	TemperatureUnitEnum static GetTemperatureUnit();

private:
	///<summary>Constructor</summary>
	Settings();

	///<summyry>Destructor</summary>
	~Settings();

	TemperatureUnitEnum _TemperatureUnit = C;
};
#endif
