import time
import os
import sys

values = 254

if not os.path.exists('pipe_test'):
    os.mkfifo('pipe_test')

pipeout = os.open('pipe_test', os.O_WRONLY)
while True :
    os.write(pipeout, values)
    
    