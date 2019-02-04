import time
import os
import sys

values = 254

path = "/tmp/glove"
    
pipein = open(path, 'r')

while 1:
    line = pipein.readline()[:-1]
    print(line)