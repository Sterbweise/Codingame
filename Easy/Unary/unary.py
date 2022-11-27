import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

message = input()
binary = ''

for i in range(len(message)):
    charInbinary = str(bin(ord(message[i])))[2:]
    
    charInbinary = charInbinary.zfill(7)
    
    binary += charInbinary

output = ""
reset = None
for i in binary:
    if i == "1" :
        if reset != 1:
            if reset == None:
                output += "0 0"
            else:
                output += " 0 0"
            reset = 1
        else:
            output += "0"
    else:
        if reset != 0:
            if reset == None:
                output += "00 0"
            else:
                output += " 00 0"
            reset = 0
        else:
            output += "0"

print(output)
