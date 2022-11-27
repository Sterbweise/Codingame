import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

n = int(input())  # the number of temperatures to analyse
t = []*n
for i in input().split():
    # t: a temperature expressed as an integer ranging from -273 to 5526
    t.append(int(i))

# Write an answer using print
if n > 0 :
    if (abs(t[t.index(min(t, key = abs))]) in t):
        print(t[t.index(abs(t[t.index(min(t, key = abs))]))])
    else:
        print(t[t.index(min(t, key = abs))])
else:
    print(0)