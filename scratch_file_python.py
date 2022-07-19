"""nr = 100
res = [[np.sin(0+i)] for i in range(nr)]
res2 = [[np.cos(2+i)] for i in range(nr)]
plt.scatter(res, res2)
plt.show()"""

#
# def increment(current_counter):
#     return current_counter + 1
#
#
# class obj:
#     def __init__(self):
#         self.counter = 0
#
#     def increment(self):
#         self.counter += 1
#         return self.counter
#
#
# print(increment(1))
#
# ojb_ = obj()
#
# print(ojb_.increment(), ojb_.increment(), ojb_.increment())
#
#
# data = {"sloup1": "A",
#         "sloup2": (1, 2)}
#
# print(data["sloup2"][0])

import requests
from io import BytesIO  # buffer for reading data in bytes
from PIL import Image
import matplotlib.pyplot as plt

address = "https://www.imdb.com/name/nm0000246/?ref_=nv_sr_srsg_0"
r = requests.get(address)

img = Image.open(BytesIO(r.content))
plt.style.use("default")
plt.figure(figsize=(16, 9))
plt.imshow(img)
plt.show()









