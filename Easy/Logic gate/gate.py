import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

n = int(input())
m = int(input())
signal = dict()
print("----- Debug Message -----\n --- Input Value ---", file=sys.stderr, flush=True)
for i in range(n):
    input_name, input_signal = input().split()
    signal[input_name] = input_name
    signal[input_name] = {'signal' :input_signal}
    print(f"{input_name} {input_signal}", file=sys.stderr, flush=True)

print("\n--- Output Value ---", file=sys.stderr, flush=True)

for i in range(m):
    output_name, _type, input_name_1, input_name_2 = input().split()
    output_signal = output_name + " "
    if _type == "AND" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] == signal[input_name_2]['signal'][s]:
                output_signal += signal[input_name_1]['signal'][s]
            else:
                output_signal += "_"
    elif _type == "OR" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] == "-" or signal[input_name_2]['signal'][s] == "-":
                output_signal += "-"
            else:
                output_signal += "_"
    elif _type == "XOR" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] != signal[input_name_2]['signal'][s]:
                output_signal += "-"
            else:
                output_signal += "_"
    elif _type == "NAND" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] == signal[input_name_2]['signal'][s]:
                if signal[input_name_1]['signal'][s] == '-':
                    output_signal += "_"
                else:
                    output_signal += "-"
            else:
                output_signal += "-"

    elif _type == "NOR" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] == "-" or signal[input_name_2]['signal'][s] == "-":
                    output_signal += "_"
            else:
                output_signal += "-"

    elif _type == "NXOR" :
        for s in range(len(signal[input_name_1]['signal'])):
            if signal[input_name_1]['signal'][s] != signal[input_name_2]['signal'][s]:
                    output_signal += "_"
            else:
                output_signal += "-"
    print(output_signal)
