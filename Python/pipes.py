import time, os, errno

class Pipe():

    #Location of the pipe
    PATH = "/tmp/glove"

    
    #The write funcion writes the values in the array to the pipe with commas delimiting.

    def write(self, dList):
        data = b''                                  #create the binary string
        for position in range(len(dList)):          #for each value in the array
            data += b'%i,' % (dList[position])      #Add that value and a comma to the binary string
        data += b'\n'                               #At the end of the loop add a newline.

        try:                                        #Open up the pipe in write only, nonblocking mode 
            pipe = os.open(self.PATH, os.O_WRONLY | os.O_NONBLOCK) 
            os.write(pipe, data)                    #write the data to the pipe
            os.close(pipe)                          #close the pipe
            time.sleep(0.05)                        #sleep for 1/20 seconds. decrease this for faster refresh rate
        except OSError as err:
            if err.errno == 6:
                pass
            else:
                raise err

