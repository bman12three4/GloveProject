import time, os, errno

bufferSize = 100

pipein = "/home/byron/Desktop/GloveProject/GloveProject/pipe_test"
#pipein = "pipe_test"

i = 0

while 1:
    try:
        pipe = os.open(pipein, os.O_WRONLY | os.O_NONBLOCK)
        os.write(pipe, b'%i\n' % i)
        i+=1
        if i > 360:
            i = 0
        os.close(pipe)
        time.sleep(0.05)
    except OSError as err:
        if err.errno == 6:
            pass
        else:
            raise err
