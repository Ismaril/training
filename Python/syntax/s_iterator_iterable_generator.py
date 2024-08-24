import sys
import time

from Utilities.console_line_separator.separate_text_stdout import SeparateText

sep = SeparateText()

# ITERATORS and ITERABLES

# iterable = it can be looped over
# iterable is only when it can call __iter__
# iterable is any object that we can iterate through, like list, dictionary, file etc...
# we can check if the object can be iterated through vid dir() function -> __iter__ must be included in

nums = [1, 2, 3]
print(dir(nums))
print("1" * 20)

# iterator only works when it can call __next__ from object it is iterating through
# iterator is an object which remembers where it is during operation
# iterators get their next value with __next__
# meaning if we want to check whether the object is an iterator, then in dir() result __next__ must be in
iter_nums = iter(nums)  # same like if we wrote nums.__iter__()
print(iter_nums)
print(dir(iter_nums))

print(next(iter_nums))
print(next(iter_nums))
print("2" * 20)

# code below is what for loop actually does (at least acc to video on YT)
iter_nums_2 = iter(nums)
while True:
    try:
        item = next(iter_nums_2)
        print(item)
    except StopIteration:
        break

print(sep.separator())


# we can create an object that is both iterator and iterable
class MyRange:
    def __init__(self, start, end):
        self.value = start
        self.end = end

    def __iter__(self):
        return self

    def __next__(self):
        if self.value >= self.end:
            raise StopIteration
        else:
            current = self.value
            self.value += 1
            return current


nums_1 = MyRange(1, 10)
nums_2 = MyRange(1, 10)

for num in nums_1:
    print(num)

print("3" * 20)
print(next(nums_2))
print(next(nums_2))
print("4" * 20)

print(sep.separator())


# GENERATORS
# generators are iterators as well
# They do not necessarily speed up the code compared to the lists etc...,
#   but they save a lot of memory
# __iter__ and __next__ are crated automatically here
def my_range(start, end):
    current = start
    while current < end:
        yield current
        current += 1


nums_3 = my_range(1, 10)
print(next(nums_3))
print(next(nums_3))
print(next(nums_3))
print(next(nums_3))
print("5" * 20)

nums_4 = my_range(1, 10)
for num in nums_4:
    print(num)

print(sep.separator())

# Iterators/Generators are useful when when we want to save memory and do not care about data before and after
# current yielded result
# Lists, tuples, dictionaries, sets and even strings are all iterable objects. They are iterable containers
# which you can get an iterator from.

# Iterator
# An object that enables a programmer to to traverse a container, particularly list without having
# to store everything it is iterating through in memory.

# Generators
# Basically the same as iterators, but was introduced as a new syntax. It is not as "tedious to work with 'em"

# Basic for loop stores everything in memory, which could not be efficient when dealing with huge data
x = [1, 2, 3]

for element in x:
    print(element)

# We can see that range() which does not have to store every item is much smaller (bytes). Also it is
# due to yielding one item at a time, when it comes to loops.
print(sys.getsizeof([1, 2, 3]), "Bytes")
print(sys.getsizeof(range(1, 4)), "Bytes")

# map is also generator, meaning values are outputted once someone call them
y = map(lambda a: a ** 2, x)
for square in y:
    print(square)

print(sep.separator())

z = map(lambda a: a ** 3, x)
# with using 2x below next() we called 2 elements. If we for example used another next() or created some loop,
# it would continue where it left. Meaning "27" would be  x list -> z map -> 27.
print(next(z))
print(next(z))

print(sep.separator())


# this is my take how is probably range function build
def range_(start, end):
    current = start
    while current != end:
        yield current
        current += 1


for number in range_(0, 8):
    print(number)

print(sep.separator())

# generator comprehension
xxx = (num for num in range(5, 10))

print(next(xxx))
print("pause")
for numba in xxx:
    print(numba)

# difference between iterator and iterable
some_tuple = (1, 2, 3)
print(type(some_tuple))

some_iterator = iter(some_tuple)
print(type(some_iterator))

# Use generators for big iterables - here parentheses are actually generator and list is not
my_list_1 = [i for i in range(1_000_000)]
my_list_2 = (i for i in range(1_000_000))
print(sys.getsizeof(my_list_1), "Bytes")
print(sys.getsizeof(my_list_2), "Bytes")
print(sep.separator())


def my_generator():
    yield 1
    yield 2
    yield 3


g = my_generator()
print(g)

for num in g:
    print(num)
print(sep.separator())

number = 10_000_000
start = time.perf_counter()


def firstn(n):
    nums = []
    num = 0
    while num < n:
        nums.append(num)
        num += 1
    return nums


print(sum(firstn(n=number)))
print(sys.getsizeof(firstn(number)), "bytes")
end = time.perf_counter()
print("cas normal", f"{end - start:.10f}")
print(sep.separator())

start_g = time.perf_counter()


def generator_firstn(n):
    num = 0
    while num < n:
        yield num
        num += 1


print(sum(generator_firstn(n=number)))
print(sys.getsizeof(generator_firstn(number)), "bytes")
end_g = time.perf_counter()
print("cas genera", f"{end_g - start_g:.10f}")
print(sep.separator())


# ! While you can create a generator and iterate over it later, the most
#   efficient way is to have full generator pipeline
# Below you can see that generator just calls previous generator and therefore
#   the file which we read does not have to be whole in memory, becasue
#   it actually processes one row at a time in the complete pipeline saving a lot
#   of memory.

"""def perfrom_some_operations_on_file():
    with open("some_file.txt") as file:
        nums = (row.partition('#')[0].rstrip() for row in file)
        nums = (row for row in nums if row)
        ...
        nums = (max(0., x) for x in nums)
        s = sum(nums)"""