import time
#from AD7490 import AD7490
from pipes import Pipe


#adc = AD7490()
pipe = Pipe()


while (True):
    data = [15, 15, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    pipe.write(data)
    
    