n = int(input())  # Number of elements which make up the association table.
q = int(input())  # Number Q of file names to be analyzed.
mimes = []
exts = []
for i in range(n):
    # ext: file extension
    # mt: MIME type.
    ext, mt = input().split()
    mimes.append( (ext.lower(), mt) )
    exts.append(ext.lower())

for i in range(q):
    fname = input()
    try:
        name, ex = fname.rsplit('.', 1)
        ex = ex.lower()
    except:
        print('UNKNOWN')
        continue
    try:
        if ex not in exts:
            print('UNKNOWN')
        else:
            for i in range( len(mimes) ):
                if ex and mimes[i][0] == ex:
                    print(mimes[i][1])
                    break
    except:
        print('UNKNOWN')
        continue
