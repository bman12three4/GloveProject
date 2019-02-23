import Adafruit_GPIO.FT232H as FT232H
import struct

# Temporarily disable FTDI serial drivers.
FT232H.use_FT232H()

# Find the first FT232H device.
ft232h = FT232H.FT232H()

# Create a SPI interface from the FT232H using pin 8 (C0) as chip select.
# Use a clock speed of 3mhz, SPI mode 0, and most significant bit first.
spi = FT232H.SPI(ft232h, cs=8, max_speed_hz=3000000,
                 mode=0, bitorder=FT232H.MSBFIRST)

# Write three bytes (0x01, 0x02, 0x03) out using the SPI protocol.

spi.write([0xff, 0xff])
spi.write([0xff, 0xff])

while True:
    spi.write([0b10000011, 0b00010000])
    ret = spi.read(2) #This returns something like 00001101 11010110 00001010
    response = struct.unpack('>H', ret)[0]
    print(response)
