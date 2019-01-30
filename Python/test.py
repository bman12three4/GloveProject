
## FROM ADAFRUIT EXAMPLE
import Adafruit_GPIO.FT232H as FT232H
 
# Temporarily disable FTDI serial drivers.
FT232H.use_FT232H()
 
# Find the first FT232H device.
ft232h = FT232H.FT232H()
 
# Create a SPI interface from the FT232H using pin 8 (C0) as chip select.
# Use a clock speed of 3mhz, SPI mode 3, and most significant bit first.
spi = FT232H.SPI(ft232h, cs=8, max_speed_hz=3000000, mode=3, bitorder=FT232H.MSBFIRST

## END ADAFRUIT EXAMPLE