import time
import AD7490
from pipes import Pipe

#CAl value


pipe = Pipe()

data = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

adc = AD7490.adc()

while (True):
    # Set the first joints to all be the same angle
    data[0] = (adc.readChannel(1)*(360*.7)/(4095) -126)
    data[3] = (adc.readChannel(1)*(360*.7)/(4095) -126)
    data[6] = (adc.readChannel(1)*(360*.7)/(4095) -126)
    data[9] = (adc.readChannel(1)*(360*.7)/(4095) -126)

    # Set the value of the second joints
    data[1] = (adc.readChannel(0)*(360*.7)/(4095) -126)
    #data[4]
    #data[10]
    #data[7]

    # Set the value of the third joints
    #data[2]
    #data[5]
    #data[11]
    #data[8]

    # Set the value of the thim joints
    #data[12]
    #data[13]
    
    pipe.write(data)
    time.sleep(1/60)

    
    