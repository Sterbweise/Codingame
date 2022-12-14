import math

def distance (lon, lat, _lon, _lat):
    x = (_lon - lon)*math.cos((lon+lat)/2)
    y = (_lat - lat)
    return math.sqrt(x**2 + y**2)*6371

lon = float(input().replace(',','.'))*math.pi/180
lat = float(input().replace(',','.'))*math.pi/180
n = int(input())
result = {'distance': 0, 'name': None}

for i in range(n):
    defib = input().split(';')
    _name, _lon, _lat = defib[1], float(defib[4].replace(',','.'))*math.pi/180, float(defib[5].replace(',','.'))*math.pi/180
    dist = distance(lon, lat, _lon, _lat)
    if i == 0:
        result['distance'], result['name'] = dist, _name
    elif dist <= result['distance']:
        result['distance'], result['name'] = dist, _name

print(result['name'])
