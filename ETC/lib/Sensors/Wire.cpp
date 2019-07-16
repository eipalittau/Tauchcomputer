m1Wire = new OneWire(aPinNumber);
	mDeviceAddress = new uint8_t[aDeviceAdressSize]();

	while (m1Wire->search(mDeviceAddress)) {
		if (m1Wire->crc8(mDeviceAddress, aDeviceAdressSize - 1) == mDeviceAddress[aDeviceAdressSize - 1]) {
			break;
		}
	}
