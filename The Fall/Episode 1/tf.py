import sys
import math
import numpy as np


# Initialisation Type of path
Type = {
  0 : {
    "path": ["None"]
  },
    1 : {
    "path": ["TOP-BOT", "LEFT-BOT", "RIGHT-BOT"]
  },
    2 : {
    "path": ["LEFT-RIGHT", "RIGHT-LEFT"]
  },
    3 : {
    "path": ["TOP-BOT"]
  },
    4 : {
    "path": ["TOP-LEFT", "RIGHT-BOT"]
  },
    5 : {
    "path": ["LEFT-BOT", "TOP-RIGHT"]
  },
    6 : {
    "path": ["RIGHT-LEFT", "LEFT-RIGHT"]
  },
    7 : {
    "path": ["TOP-BOT", "RIGHT-BOT"]
  },
    8 : {
    "path": ["RIGHT-BOT", "LEFT-BOT"]
  },
    9 : {
    "path": ["LEFT-BOT", "TOP-BOT"]
  },
    10 : {
    "path": ["TOP-LEFT"]
  },
    11 : {
    "path": ["TOP-RIGHT"]
  },
    12 : {
    "path": ["RIGHT-BOT"]
  },
    13 : {
    "path": ["LEFT-BOT"]
  },
}

# w: number of columns.
# h: number of rows.
w, h = [int(i) for i in input().split()]
array = np.arange(w*h).reshape(h,w)
for i in range(h):
     line = input().split()
     for j in range(w):
      array[i][j] = line[j]
ex = int(input())

# game loop
while True:
    inputs = input().split()
    xi = int(inputs[0])
    yi = int(inputs[1])
    pos = inputs[2]
    out = ""
    path = Type[array[yi][xi]]['path']
    if f"{pos}-" in ' '.join(path):
        for j in range (len(path)):
            if f"{pos}-" in path[j]:
                out = path[j].split('-')[1]

    if out == "BOT": yi+=1
    if out == "RIGHT": xi+=1
    if out == "LEFT": xi-=1
    print(f"{xi} {yi}")
