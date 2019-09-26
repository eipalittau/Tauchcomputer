#include "Sensor.h"

Sensor mPressure;
unsigned long mLastMillis = 0;

void setup() {
  Serial.begin(9600);

  Wire.begin();

  mPressure.Init();
}

void loop() {
  SensorDataStruct lData;

  if (mLastMillis <= millis()) {
    mLastMillis = millis() + 5000;
    
    lData = mPressure.GetData();
    
    Serial.print("Druck: "); 
    Serial.print(lData.Pressure); 
    Serial.println(" mbar");
    
    Serial.print("Temperatur: "); 
    Serial.print(lData.Temperature); 
    Serial.println(" °C");
  }
}
