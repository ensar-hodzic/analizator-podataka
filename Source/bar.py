import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

file=open("path.txt", "r")
path = file.read()
file.close()

file=open("settings.txt", "r")
rsettings = file.read()
file.close()

data = pd.read_csv(path[:len(path)-1])

file=open("selected.txt", "r")
rcolumns = file.read()
file.close()

columns = list(rcolumns.split('\n'))

settings = list(rsettings.split('\n'))


COLOR = settings[0]
plt.rcParams['text.color'] = COLOR
plt.rcParams['axes.labelcolor'] = COLOR
plt.rcParams['xtick.color'] = COLOR
plt.rcParams['ytick.color'] = COLOR
f= plt.figure(figsize=(10, 7))
f.set_facecolor(settings[2])
ax = plt.axes()
ax.set_facecolor(settings[1])
sns.barplot(x=columns[0],y=columns[1],data=data, palette=settings[6])
if settings[3]!='':
    plt.xlabel(settings[3])
plt.xticks(rotation=int(settings[7]))
if settings[4]!='':
    plt.ylabel(settings[4])
if settings[5]!='':
    plt.title(settings[5], fontweight="bold")
plt.show()
