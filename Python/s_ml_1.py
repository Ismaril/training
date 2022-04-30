
import pandas as pd

import numpy as np
music_data = pd.read_excel("C:/Users/lazni/Downloads/music.xlsx")

X = music_data.drop(columns=["genre"])
print(X)



