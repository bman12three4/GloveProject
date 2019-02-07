import time
import Adafruit_GPIO as GPIO
import Adafruit_GPIO.FT232H as FT232H
 
class AD7490():
    def __init__(self):
        # Temporarily disable FTDI serial drivers.
        self.FT232H.use_FT232H()
        # Find the first FT232H device.
        self.ft232h = FT232H.FT232H()
        # Create a SPI interface from the FT232H using pin 8 (C0) as chip select.
        # Use a clock speed of 3mhz, SPI mode 3, and most significant bit first.
        self.spi = FT232H.SPI(ft232h, cs=8, max_speed_hz=3000000, mode=3, bitorder=FT232H.MSBFIRST)
    
    def read(self):
        #tbd, probably a loop of readChannel()

    def readChannel(self, channel):
        #data = 0b1000001100110000 #Basic data word, sets power functions to normal, goes to address 0
        byte1 = 0b10000011 | channel << 2
        byte2 = 0b00110000 

        self.spi.write(byte1)           #Write the first byte (read nothing)
        data1 = self.spi.write(byte2)   #Write the second byte (read the first response byte)
        data2 = self.spi.read()         #Read the second response byte

        print(data1)                    #Print first byte (TESTING)
        print(data2)                    #Print second byte (TESTING)

        return [data1, data2]           #Return both bytes

    

