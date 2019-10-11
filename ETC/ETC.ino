#include <Wire.h>
#include "DataCollector.h"
#include "SettingsData.h"

DataCollector mDiveData;
unsigned long mLastMillis = 0;
DiveDataStruct mData;

void setup() {
  Serial.begin(9600);
  Wire.begin();
  
  if (mDiveData.Init()) {
    Serial.println("Sensoren initialisiert");
  } else {
    Serial.println("Sensoren NOK");
  }
}

void loop() {
  DiveDataStruct lData;
    
  if (mLastMillis <= millis()) {
    mLastMillis = millis() + 1000;
    
    lData = mDiveData.GetData();

    Serial.print("Millis: ");
    Serial.println(millis());

    Serial.print("Druck: ");
    Serial.print(lData.Pressure);
    Serial.print(" mbar / ");
    
    Serial.print("Temperatur: ");
    Serial.print(lData.Temperature);
    Serial.print(" °C / ");
    
    Serial.print("Zeit: ");
    Serial.print(lData.Clock.Day, DEC);
    Serial.print(".");
    Serial.print(lData.Clock.Month, DEC);
    Serial.print(".");
    Serial.print(lData.Clock.Year, DEC);
    Serial.print(" ");
    Serial.print(lData.Clock.Hour, DEC);
    Serial.print(":");
    Serial.print(lData.Clock.Minute, DEC);
    Serial.print(":");
    Serial.println(lData.Clock.Second, DEC);
  }
}
