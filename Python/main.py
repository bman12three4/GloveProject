import time
from AD7490 import AD7490

#def...

print("Hello, World!")

adc = AD7490()

writeFile = open("adc.txt", "a")
readFile = open("adc.txt", "r")


writeFile.truncate(0)
for x in range(16):
    writeFile.write(adc.readChannel(x))

while (True):
    lines = readFile.readlines()
    if (lines[16] == "G"):
        writeFile.truncate(0)
        for x in range(16):
            writeFile.write(adc.readChannel(x))
    
    