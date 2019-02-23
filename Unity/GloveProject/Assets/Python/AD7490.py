import time
import Adafruit_GPIO as GPIO
import Adafruit_GPIO.FT232H as FT232H
import struct


class adc():
    def __init__(self):
        # Temporarily disable FTDI serial drivers.
        FT232H.use_FT232H()
        # Find the first FT232H device.
        ft232h = FT232H.FT232H()
        # Create a SPI interface from the FT232H using pin 8 (C0) as chip select.
        # Use a clock speed of 3mhz, SPI mode 0, and most significant bit first.
        self.spi = FT232H.SPI(
            ft232h, cs=8, max_speed_hz=3000000, mode=0, bitorder=FT232H.MSBFIRST)

        #Initialize ADC after  power up by sending ones for two cycles.
        self.spi.write([0xff, 0xff])
        self.spi.write([0xff, 0xff])

        print("init complete")



    def readAll(self):
        return self.read(16)

    def read(self, channels):
        values = range(channels)
        for x in values:
            values[x] = self.readChannel(x)
        
        return values

    def readChannel(self, channel):
        # data = 0b1000001100010000 #Basic data word, sets power functions to normal, goes to address 0, range is 2x
        byte1 = 0b10000011 | (channel << 2)
        byte2 = 0b00010000

        self.spi.write([byte1, byte2])

        ret = self.spi.read(2)
        response = struct.unpack('>H', ret)[0] & 4095

        return response
