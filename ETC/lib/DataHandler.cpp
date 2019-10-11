#include "DataHandler.h"

DataHandler::DataHandler() {}
DataHandler::~DataHandler() {}

bool DataHandler::Init() {
  if (mPressure.Init()) {
    return true;
  }
}

DiveDataStruct DataHandler::DiveData() {
  MS5837Struct lPressureData = mPressure.GetData();

  return lData;
}
