import sys
import math

#### ENIGMA ENCRYPTION / DECRYPTION MACHINE ####
### DATA FOR MACHINE ###
rotor = ['']*3
default = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
operation = input()
jump = int(input())
for i in range(3):
    rotor[i] = input()
message = input()

### FUNCTIONS ###
def ENCODE(message, jump, rotor):
    encoded_message = ['']*len(message)
    ## DEFAULT SECTION ##
    for i in range(len(message)):
        encoded_message[i] = default[(default.index(message[i])) - ((len(default) - ((i + jump)%len(default))))]
    
    ## ROTOR SECTION ##
    for i in range(len(rotor)):
        sequence = rotor[i]
        for j in range (0, len(message), 1):
            encoded_message[j] = sequence[(default.index(encoded_message[j]))]

    return ''.join(encoded_message)

def DECODE(message, jump, rotor):
    decoded_message = ['']*len(message)
    ## ROTOR SECTION ##
    for i in range(len(rotor)-1,0,-1):
        sequence = rotor[i]
        for j in range (0, len(message), 1):
            if i == len(rotor) - 1:
                decoded_message[j] = default[(sequence.index(message[j]))]
            else:
                decoded_message[j] = default[(sequence.index(decoded_message[j]))]
    
    ## DEFAULT SECTION ##
    for i in range(len(message)):
        decoded_message[i] = default[(rotor[0].index(decoded_message[i])) - (jump + i)%len(default)]

    return ''.join(decoded_message)

if operation == "ENCODE":
    print(ENCODE(message, jump, rotor))
else:
    print(DECODE(message, jump, rotor))
    