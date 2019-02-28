import time
import AD7490
from pipes import Pipe

#CAl value


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
    #data[7]
    #data[10]

    # Set the value of the third joints
    data[2] = getScaledChannel(2)
    #data[5]
    #data[8]
    #data[11]

    # Set the value of the thim joints
    #data[12]
    #data[13]
    
    pipe.write(data)
    time.sleep(1/60)

    
    