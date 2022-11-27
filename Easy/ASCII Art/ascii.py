import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

l = int(input()) # Largeur
h = int(input()) # Hauteur
t = input().upper() #Met en majuscule
words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?"
for i in range(h):
    row = input()
    output_line = ""
    for j in t:
        get_index = (words.find(j)+1)
        if get_index == 0:
            get_index = len(words)
        fin_lettre = get_index*l
        debut_lettre = fin_lettre-l
        output_line += row[debut_lettre: fin_lettre]
    print(output_line)
