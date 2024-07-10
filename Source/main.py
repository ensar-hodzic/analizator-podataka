import pandas as pd

file=open("path.txt", "r")
path = file.read()
file.close()

df = pd.read_csv(path[:len(path)-1])

newfile = open("names.txt","w")
for col in df.columns:
    newfile.write(col+",")
newfile.close()
