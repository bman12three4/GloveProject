import time, os, errno

class Pipe():

    PATH = "/tmp/glove"

    def write(self, dList):
        data = b''
        for position in range(len(dList)):
            data += b'%i,' % (dList[position])
        data += b'\n'

        try:
            pipe = os.open(self.PATH, os.O_WRONLY | os.O_NONBLOCK)
            os.write(pipe, data)
            os.close(pipe)
            time.sleep(0.05)
        except OSError as err:
            if err.errno == 6:
                pass
            else:
                raise err

