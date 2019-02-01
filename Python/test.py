import time, os, sys

pipein = open('pipe_test', 'r')

line = pipein.readline()[:-1]

print(line)
