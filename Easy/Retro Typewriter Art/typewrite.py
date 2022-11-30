import re

t = input().split(' ')
number = "123456789"
character = "~!@#$%^&*()_+-=qwertyuiop[]{}|\\asdfghjkl;\':zxcvbnm<>,.?/"
message = ""
for i in t:
    try:
        i = i.replace('sp', ' ')
        i = i.replace('bS', '\\')
        i = i.replace('sQ', '\'')
        i = i.replace('nl', '\n')
    except:
        continue

    if (any(char in number for char in i) and any(char in character for char in i)):
        sep = re.split('(\d+)', i)
        message += int(sep[1])*sep[2]

    elif any(char in number for char in i):
        p_char = i[len(i)-1]
        m_char = int(i[0:len(i)-1])
        message += m_char*p_char

    else:
        message += i
print(message)