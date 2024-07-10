import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

file=open("path.txt", "r")
path = file.read()
file.close()

file=open("settings.txt", "r")
rsettings = file.read()
file.close()

file=open("selected.txt", "r")
rcolumns = file.read()
file.close()

columns = list(rcolumns.split('\n'))

settings = list(rsettings.split('\n'))
data = pd.read_csv(path[:len(path)-1])
xdata = data.groupby(columns[0])[columns[1]].sum()
COLOR = settings[0]
plt.rcParams['text.color'] = COLOR
plt.rcParams['axes.labelcolor'] = COLOR
plt.rcParams['xtick.color'] = COLOR
plt.rcParams['ytick.color'] = COLOR
f= plt.figure(figsize=(10, 7))
f.set_facecolor(settings[2])
ax = plt.axes()
ax.set_facecolor(settings[1])
plt.pie(x=xdata, labels=list(dict.fromkeys(data[columns[0]])), autopct="%.2f%%")
if settings[5]!='':
    plt.title(settings[5], fontweight="bold")
plt.show()
