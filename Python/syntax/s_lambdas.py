from Python.utilities.separate_text_stdout import SeparateText

sep = SeparateText()

# LAMBDAS
# - are used when the function is used only once
# - used as a argument to higher order function like (sorted, map, filter, reduce, etc...)


# lambda arguments: expression

# lambda and def below are the same
from functools import reduce

add10 = lambda x: x + 10
print(add10(5))
print(sep.separator())


def add10_(x):
    return x + 10


print(add10_(5))
print(sep.separator())

# multiple variables
multiply = lambda num_1, num_2: num_1 * num_2
print(multiply(2, 4))
print(sep.separator())

full_name = lambda first, last: f'Full name: {first.title()} {last.title()}'
print(full_name('guido', 'van rossum'))
print(sep.separator())

# with sorted method
points_2D = [(1, 2),
             (15, 1),
             (5, -1),
             (10, 4)]
points_2D_sorted = sorted(points_2D)  # sorted based on the first element
points_2D_sorted_ = sorted(points_2D, key=lambda x: x[1])  # sorted based on the second element
points_2D_sorted_sum = sorted(points_2D, key=lambda x: x[0] + x[1])  # sorted based on the second element

print(points_2D)
print(points_2D_sorted)
print(points_2D_sorted_)
print(points_2D_sorted_sum)
print(sep.separator())

# with map function
a = [1, 2, 3, 4, 5]
b = map(lambda x: x * 2, a)
print(list(b))
print(sep.separator())

# with filter function
a = [1, 2, 3, 4, 5, 6]
b = filter(lambda x: x % 2 == 0, a)
print(list(b))
print(sep.separator())

# with reduce function
a = [1, 2, 3, 4, 5, 6]
b = reduce(lambda x, y: x + y, a)
print(b)
print(sep.separator())

# define lambda and pass immediately behind it some arguments
print((lambda x, y: x + y)(8, 2))
print(sep.separator())

# pass a function inside
high_ord_func = lambda x, func: x + func(x)
print(high_ord_func(2, lambda x: x * x))  # here lambda x is placed at a position of parameter func above
print(sep.separator())

# arguments
print((lambda x, *args, y=0, z=0: x + sum(args) + y + z)(1, 2, 4, y=2, z=3))
print(sep.separator())


# make a function and return function
def make_incrementor(n):
    return lambda x: x + n


f = make_incrementor(42)

print(f(0))
print(f(1))
