import time

writeFile = open("adc.txt", "a")
readFile = open("adc.txt", "r")

values = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]


writeFile.truncate(0)
for x in range(16):
    writeFile.write(str((values[x])))
    writeFile.write("\n")
    writeFile.flush()

print("Beginning Loop")

while (True):
    lines = readFile.readlines()
    writeFile.truncate(0)
    for x in range(16):
        writeFile.write(str((values[x])))
        writeFile.write('\n')
        writeFile.flush()

        if (values[x] > 359):
            values[x] = 0
        #print("Update Complete")
    
    