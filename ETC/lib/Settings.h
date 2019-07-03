#ifndef _SETTINGS_h
#define _SETTINGS_h

class Settings {
public:
	///<summary>Constructor</summary>
	Settings();

	///<summyry>Destructor</summary>
	~Settings();

	enum TemperatureUnitEnum { C, F, K };

	void TemperatureUnit(TemperatureUnitEnum aValue);
	TemperatureUnitEnum TemperatureUnit();

private:
	TemperatureUnitEnum _TemperatureUnit = C;
};
#endif
