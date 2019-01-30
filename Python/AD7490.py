import time
import Adafruit_GPIO as GPIO
import Adafruit_GPIO.FT232H as FT232H
 
class AD7490(object):
    def __init__(self):
        # Temporarily disable FTDI serial drivers.
        self.FT232H.use_FT232H()
        # Find the first FT232H device.
        self.ft232h = FT232H.FT232H()
        # Create a SPI interface from the FT232H using pin 8 (C0) as chip select.
        # Use a clock speed of 3mhz, SPI mode 3, and most significant bit first.
        self.spi = FT232H.SPI(ft232h, cs=8, max_speed_hz=3000000, mode=3, bitorder=FT232H.MSBFIRST
        self.spi.write()
    

