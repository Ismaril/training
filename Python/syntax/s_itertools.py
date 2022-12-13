import itertools
from itertools import product, permutations, combinations, combinations_with_replacement, accumulate, groupby
from itertools import count, cycle, repeat
from Python.utilities.separate_text_stdout import SeparateText

separator = SeparateText()

# collection of tools for handling iterators

# check what is inside
print(dir(itertools))
print(separator.separator())

# product
# combine all items from first sequence with all items from second one
a = [1, 2]
b = [3, 4]
product_ = product(a, b)
print(list(product_))  # have to convert it to list to see it

# - repeat (parameter)
# (see the system of the print to understand it)
a = [1, 2]
b = [3]
product_ = product(a, b, repeat=2)
print(list(product_))

print(separator.separator())

# permutations
# - return all possible permutations from a given sequence - it is the same as method combinations, but
#   permutations returns also switched elements. Example (1, 2) and (2, 1)
a = [1, 2, 3]
print(list(permutations(a)))
print(list(permutations(iterable=a, r=2)))  # specify length of each permutation

print(separator.separator())

# combinations
# - return all possible combinations (returned elements in the tuple will not repeat
#   and the same number will not be in the same tuple)
a = [1, 2, 3]
print(list(combinations(iterable=a, r=2)))

print(separator.separator())

# combinations_with_replacement
# - same like combinations method but the same number can be also in combination with itself
a = [1, 2, 3]
print(list(combinations_with_replacement(iterable=a, r=2)))

print(separator.separator())

# accumulate
# - sums together next element in original list with former sum of the current item in accumulate list
# [1,   2,   3,   4]
# [1, 1+2, 3+3, 6+4]
a = [1, 2, 3, 4]
print(a)
print(list(accumulate(a)))

# - we can for example use also multiplication (same system as above but with multiplication)
import operator

a = [1, 2, 3, 4]
print(a)
print(list(accumulate(iterable=a, func=operator.mul)))

# - we can also use max, to return for the rest of the list only the max value if the items at the same index
#     in original list are smaller
a = [1, 2, 5, 3, 4]
print(a)
print(list(accumulate(iterable=a, func=max)))

print(separator.separator())


# groupby
# - will group by to (True) list items that match the condition in a function. Those items that done will be
#   returned in other list (False list)
def smaller_than_three(x):
    return x < 3


a = [1, 2, 3, 4]
group_obj = groupby(iterable=a, key=lambda x: x < 3)  # can use lambda or function above
for key, value in group_obj:
    print(key, list(value))

# - can also group a dictionaries ! seems that it does not group it completely? 🤔 = seprated to multiple rows?
person = [{"name": "Tim", "age": 20},
          {"name": "Kim", "age": 36},
          {"name": "Bim", "age": 40},
          {"name": "Pim", "age": 5}]

group_obj = groupby(iterable=person, key=lambda x: x["age"] <= 20)
for key, value in group_obj:
    print(key, list(value))

print(separator.separator())

# count
# - loop from given number to infinity
for i in itertools.count(4):
    print(i)
    if i == 10:
        break

print(separator.separator())

# cycle
# loop infinitely in the loop
a = [1, 2, 3]
"""for i in cycle(a):
    print(i)"""

print(separator.separator())

# repeat
# repeat the loop infinitely (or specify number of iterations) with the same object
for i in repeat(object=a, times=6):
    print(i)


