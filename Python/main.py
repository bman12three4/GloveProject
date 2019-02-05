import time
#from AD7490 import AD7490
from pipes import Pipe


#adc = AD7490()
pipe = Pipe()

data = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]


while (True):
    pipe.write(data)

    if data[0] < 30:
         data[0]+=1

    if data[1] < 30:
        data[1] +=1

    if data[2] < 30:
        data[2] +=1

    if data[12] < 30:
        data[12] +=1

    if data[13] > -30:
        data[13] -= 1


    
    