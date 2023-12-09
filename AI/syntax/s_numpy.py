import time

# import matplotlib.pyplot as plt
import numpy as np

from Python.utilities.separate_text_stdout import SeparateText

separator = SeparateText()

print(f"{np.__version__ = }")

# NUMPY
# btw is installed automatically with matplotlib or pandas... numpy will be installed automatically
# functions/operations on numpy arrays usually operate on each item
# some methods require you to insert in the parameter filed a tuple
# use np.array.copy to make sure changes are done only were you want them

# Rules for working with arrays
# 1. check the shapes
# 2. mathematical operations (+, -, *, etc) apply on each element
# 3. reduction operations (mean, std, prod, etc) apply to the whole array, unless axis specified
# 4. missing values propagate unless explicitly ignored

# basic operations
array_1 = np.array([[1, 2, 3],
                    [4, 5, 6]])
print(array_1)
print(f"{array_1.shape = }")
print(f"{array_1.dtype = }")
print(f"{array_1.ndim = }")  # 0 scalar, 1 vector, 2 matrix, 3+ tensor
print(f"{array_1.size = }")  # total number of elements
print(
    f"{array_1.itemsize = }")  # number of bytes per each item (dtype is int32 meaning 32 bits per each item, meaning 4 bytes per each item)

print(separator.separator())

print(array_1[0])  # access first element
array_1[0] = 10  # change all items of the first row to this number
print(array_1)

print(separator.separator())

array_2 = np.array([1, 2, 3])
array_2_b = np.array([0, 2, 10])
scaler_1 = np.array(5)
print(f"{np.sqrt(array_2) = }")  # square root of each item
print("before:", array_2)
print("add arrays:", array_2 + array_2_b)  # add array and array
print("multiply by scaler:", array_2 * scaler_1)  # add array and array
print("multiply arrays:", array_2 * array_2_b)  # multiply array and array
print(f"{np.nan=}")

print(separator.separator())

# dot product
array_2 = np.array([1, 2, 3])
array_3 = np.array([4, 5, 6])
print(f"{array_2.dot(array_3) = }")  # dot product
print(f"{array_2@array_3 = }")  # dot product using '@' (new syntax)

print(separator.separator())

# compare the speed between list and np array
array_speed_test = np.random.randn(1_000_000)
list_speed_test = list(np.random.randn(1_000_000))

start = time.perf_counter()
array_speed_test * np.array(2)
end = time.perf_counter()
print("numpy", f"{end - start:.6f}", "seconds")

start = time.perf_counter()
_ = (item * 2 for item in list_speed_test)
end = time.perf_counter()
print("generator", f"{end - start:.6f}", "seconds")

start = time.perf_counter()
__ = [item * 2 for item in list_speed_test]
end = time.perf_counter()
print("list", f"{end - start:.6f}", "seconds")

print(separator.separator())

# types of data based on number of dimensions
scalar = np.array(1)
print(f"{scalar.shape = }")
print(f"{scalar.ndim = }")

vector = np.array([1, 2, 3])
print(f"{vector.shape = }")
print(f"{vector.ndim = }")

matrix = np.array([[1, 2, 3],
                   [4, 5, 6],
                   [7, 8, 9]])
print(f"{matrix.shape = }")
print(f"{matrix.ndim = }")

tensor = np.array([[[1, 2, 3],
                    [4, 5, 6]],

                   [[7, 8, 9],
                    [10, 11, 12]]])
print(f"{tensor.shape = }")
print(f"{tensor.ndim = }")

print(separator.separator())

# access elements from a numpy array
print(f"{tensor[0][0][2] = }")  # this is the same as below
print(f"{tensor[0, 0, 2] = }")  # this is the same as above

print(separator.separator())

# indexing, slicing, boolean indexing numpy arrays
print(f"{tensor[:, 0]}")  # get all the rows (in this example) on the first index
print(f"{tensor[:, :, -1]}")  # access all elements that are on the last index of each row
print(
    f"{tensor[..., -1]}")  # ellipsis "..." can skip repetitive colons ':, :,' Output is the same as above.

# - boolean index
boolean_index = matrix % 2 == 0
print(boolean_index, "return each item based on: matrix % 2 == 0")
print(matrix[boolean_index], "return all numbers that matched the condition (True only)")
print(matrix[matrix % 2 == 0])  # this is the same as above, but shorter code

#   -> condition for each item, if not met replace with specified num
#   - where finds COORDINATES of each met position
print(np.where(matrix % 2 == 0, matrix, -1).flatten())

# - fancy indexing
#   -> filter indexes in np.array based on inputed list in square brackets
filter_key = [1, 2, 3]
array_4 = np.array([1, 2, 3, 4, 5, 6, 7])
print(f"{array_4[filter_key] = }")  # filter numbers on indexes 1, 2 and 3

even = np.where(array_4 % 2 == 0)
print(f"{array_4[even] = }")

print(separator.separator())

# another operations on numpy array
array_4 = np.array([[1, 2], [3, 4]])
print(f"{matrix.transpose()}", "transpose")
# print(f"{matrix.T = }")  # same as transpose
print(f"{np.linalg.inv(array_4)}", "inverse")  # calculate a inverse
print(f"{np.linalg.det(array_4)}", "determinant")  # calculate a determinant

diagonal = np.diag(array_4)
print(f"{diagonal}", "diagonal")  # return all items in diagonal line
print(np.diag(diagonal), "one hot encode")  # return diagonal, with rest of zeroes

print(separator.separator())

# change dimensions
array_5 = np.arange(1, 7)
print(array_5)
print(f"{array_5.shape = }")
reshaped_array_5 = array_5.reshape((2, 3))  # reshape
print(f"{reshaped_array_5 = }")
print(f"{reshaped_array_5.shape = }")

# - add new axis based on index position in square brackets
print(array_5[:, np.newaxis])
print(array_5[np.newaxis, :])

print(separator.separator())

# concatenate arrays
concatenate = np.concatenate((matrix, np.array([[10, 11, 12]])),
                             axis=0)  # axis None flattens the array
print(f"{concatenate = }")

concatenate = np.concatenate((matrix, np.array([[10, 11, 12]]).transpose()), axis=1)
print(f"{concatenate}")

print(f"{np.hstack((vector, np.array([-1, 8, -20]))) = }")  # stack horizontally
print(f"{np.vstack((vector, np.array([-1, 8, -20]))) = }")  # stack vertically

print(separator.separator())

# broadcasting
# - allows np to work with arrays of different shape when performing arithmetic operations
# - (in my words - it really only means that arithmetic operation will be done for each element in the array)
print(array_4)
print(array_4 + np.array([10, 10]))

print(separator.separator())

# functions and axis
array_6 = np.array([[7, 8, 9, 10, 11, 12, 13], [17, 18, 19, 20, 21, 22, 23]])
print(f"{array_6.sum(axis=None) = }")  # default sum (None), sum all items in the array
print(f"{array_6.sum(axis=1) = }")  # sum all rows
print(f"{array_6.sum(axis=0) = }")  # sum all columns

print(f"{array_6.mean(axis=None) = }")  # default sum (None), mean of items
print(f"{array_6.mean(axis=1) = }")  # mean of all rows
print(f"{array_6.mean(axis=0) = }")  # mean of all columns

print(f"{array_6.std() = }")  # standard deviation
print(f"{np.min(array_6) = }")  # minimum of all items
print(f"{np.max(array_6) = }")  # maximum of all items

print(separator.separator())

# different datatypes
# - shown some examples
array_1 = np.array(array_1, dtype=np.float64)
print(f"{array_1.dtype = }")

array_1 = np.array(array_1, dtype=np.int16)
print(f"{array_1.dtype = }")

print(separator.separator())

# generate/create arrays
zeroes = np.zeros((3, 6), dtype=np.float64, )
print(zeroes)

ones = np.ones((3, 6))
print(ones)

full = np.full((3, 6), -66)  # generate a array based on specified number
print(full)

eye = np.eye(6)  # generate a square matrix with diagonal 1
print(eye)

arange = np.arange(start=10, stop=20, step=2, dtype=np.float32)
print(arange)

linspace = np.linspace(start=10, stop=20,
                       num=3)  # returns evenly spaced range based on specified "num" param
print(linspace)

print(separator.separator())

# generate random arrays
random_arr = np.random.random((3, 2))  # generate random values between 0 and 1
print(f"{random_arr = }")

randn = np.random.randn(1000)  # generate an array
"""plt.hist(x=randn, bins=50)"""
# plt.show()
print(f"{randn.mean() = }", f"{randn.var()}")  # mean should be close to 0, variance close to 1

randint = np.random.randint(low=2, high=20, size=(2, 2, 8), dtype=np.int32)
print(f"{randint = }")

choice = np.random.choice(a=10, size=7)
print(f"{choice = }")

choice = np.random.choice(a=[2, 3, 5, 13, 1], size=7)
print(f"{choice = }")

# mathematics / linear algebra
array_1 = [[1, 2], [3, 4]]
eigenvalues, eigenvectors = np.linalg.eig(array_1)
print(f"{eigenvalues=}")
print(f"{eigenvectors=}")  # column vector!

print(f"{np.sum(array_1)=}")  # sum all together
print(f"{np.prod(array_1)=}")  # product of array
print(f"{np.min(array_1)=}")  # min of array
print(f"{np.max(array_1)=}")  # max of array
print(f"{np.argmin(array_1)=}")  # return index where the smallest value is
print(f"{np.argmax(array_1)=}")  # return index where the biggest value is
print(f"{np.ptp(array_1)=}")  # ?

# statistics
print(f"{np.mean(array_1)=}")
print(f"{np.std(array_1)=}")  # standard deviation
print(f"{np.var(array_1)=}")  # variance

# truth testing
print(f"{np.all(array_1)=}")
print(f"{np.any(array_1)=}")

print(separator.separator(), "*" * 50)

# compare two arrays if they are equal
print(f"{np.allclose(np.array([2.0000001, 1]), np.array([2.0, 1.0]))=}")

print(separator.separator())

# load csv file
load_csv = np.loadtxt("../files/some_numbers.csv", skiprows=1, delimiter=",", dtype=object)
print(load_csv)

print(separator.separator())

# working with axes
# check photos arrays broadcasting.jpg, axes.jpg
ones1 = np.ones((5, 3))
ones2 = np.ones(
    (3,))  # can be used even if it has not the same dimension because numpy will prepend one
#   dimension to match the other array

print(ones1)
print(ones2)
result = ones1 + ones2
print(result, end="\n" * 2)

array_7 = np.arange(24).reshape((2, 3, 4))
print(array_7)
print(f"{array_7.shape=}")
print(f"{array_7.ndim=}")
print(np.sum(array_7,
             axis=0))  # axis 0 sums each element on the same pos of two biggest sections here
print(np.sum(array_7, axis=1))  # axis 1 sums individual columns into separate numbers
print(np.sum(array_7, axis=2))  # axis 2 sums individual rows into separate numbers

print(separator.separator())

# crete 2D array with 1D arrays using MESHGRID
# - this function creates a grid of x any coordinates based on 2 inputted arrays
x = np.linspace(0, 1000, 100)
y = np.linspace(0, 1000, 100)

xv, yv = np.meshgrid(y, x)

zv = xv + yv
# plt.contourf(zv)
# plt.show()

print(separator.separator())

# np.c_
# this function is used to concatenate two arrays and make at least 2D array
# below example concatenates two 1D arrays into 2D array
print(np.c_[
          [1, 2, 3],
          [4, 5, 6]
      ])

# concatenate into 2D array with 3 columns
print(np.c_[
          [1, 2, 3],
          [4, 5, 6],
          [7, 8, 9]
      ])

# concatenate into one item array
print(np.c_[
          [[1, 2, 3]],
          0,
          0,
          [[4, 5, 6]]
      ])

print(separator.separator())

