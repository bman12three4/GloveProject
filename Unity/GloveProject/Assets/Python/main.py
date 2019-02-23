import time
import AD7490
from pipes import Pipe


#adc = AD7490()
pipe = Pipe()

data = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

adc = AD7490.adc()

while (True):
    #data[0] = (adc.readChannel(3)*360/4095)
    #pipe.write(data)

    adc.read(12)
    time.sleep(1/60)

    
    