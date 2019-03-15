import time
import AD7490
from pipes import Pipe


pipe = Pipe()

data = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

adc = AD7490.adc()

def getScaledChannel(channel):
    return (adc.readChannel(channel)*(360*.7)/(4095) -126)


while (True):
    # Set the first joints to all be the same angle
    data[0] = getScaledChannel(1)
    data[3] = getScaledChannel(1)
    data[6] = getScaledChannel(1)
    data[9] = getScaledChannel(1)

    # Set the value of the second joints
    data[1] = getScaledChannel(0)
    data[4] = getScaledChannel(3)
    data[7] = getScaledChannel(7)
    data[10] = getScaledChannel(4)

    # Set the value of the third joints
    data[2] = getScaledChannel(2)
    data[5] = getScaledChannel(5)
    data[8] = getScaledChannel(8)
    data[11] = getScaledChannel(6)

    # Set the value of the thumb joints
    data[12] = getScaledChannel(9)
    data[13] = getScaledChannel(10)
    
    pipe.write(data)
    time.sleep(1/60)

    
    