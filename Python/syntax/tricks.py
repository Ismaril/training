import sys
import time
from Python.utilities import separate_text_stdout

sep = separate_rows_in_training_files.SeparateText()

# You can extend the list with +=

s = []
for _ in range(2):
    s += [1, 2]
print(1, s)

print(sep.separator())


# parameter in function hovno is able to store changes.
# See that it is possible to increment it below.
def hovno(shit):
    for _ in range(shit):
        shit += 1
    return shit


print(2, hovno(3))

print(sep.separator())

# Zip can be used only one iterable and zip it to it self with *argument.
# First elements from nested items.
arr = [[1, 2, 3],
       [4, 5, 6],
       [7, 8, 9]]
print(arr)
a = list(zip(*arr))
print(a)
print(list(zip(arr, arr)))

print(sep.separator())

# Sort dictionaries based on what I want
data = [{"name": "John", "age": 35},
        {"name": "Alen", "age": 16},
        {"name": "Dix", "age": 100}]
sorted_data = sorted(data, key=lambda x: x["age"], reverse=True)
print(sorted_data)

print(sep.separator())

# Use generators for big iterables.
# Here parentheses are actually generator and list is not
my_list_1 = [i for i in range(1_000_000)]
my_list_2 = (i for i in range(1_000_000))
print(sys.getsizeof(my_list_1), "Bytes")
print(sys.getsizeof(my_list_2), "Bytes")

print(sep.separator())

# Concatenate two lists
my_list_3 = ["AA", "BB"]
my_list_4 = ["CC", "DD"]
my_list_3.extend(my_list_4)  # extends already existing list
print(my_list_3 + my_list_4)
print([*my_list_3, *my_list_4])
print(my_list_3)

print(sep.separator())

# Can concatenate also separate containers
# take into consideration shallow and deep programing here ↓
# (Change in source will change it also in output)
my_tuple_1 = ("CC", "DD")
print([*my_list_3,
       *my_tuple_1])  # returns a list even though it was extended by tuple

print(sep.separator())

# Walrus operator - can assign a variable during execution - if len > 10 assign "n" to len(a)
a = range(11)
if (n := len(a)) > 10:
    print(f"List is too long ({n} elements, expected <= 10)")

print(sep.separator())


# Checking against True, False, None (should not use == operator)
def equality(x):
    if x is True:
        pass
    if x is False:
        pass
    if x is None:
        pass


# Measure time with time.perf_counter() not time.time()
def measure_time():
    start = time.perf_counter()
    end = time.perf_counter()
    print(end - start)


# another boolean operators
print((10 > 5) & (10 == 8))
print((10 > 5) | (10 == 8))
print(sep.separator())

# chained conditionals
print(6 > 3 == 3 in (3, 2))
print(sep.separator())

# returns first true variable?
string1, string2, string3 = '', 'Trondheim', 'Hammer'
non_null = string1 or string2 or string3
print(non_null)
print(sep.separator())



