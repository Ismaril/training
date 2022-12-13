from collections import Counter, namedtuple, OrderedDict, defaultdict, deque
from Python.utilities.separate_text_stdout import SeparateText
separator = SeparateText()

# Counter, namedtuple, OrderedDict, defaultdict, deque
# Used as handy alternative for basic container datatypes like lists, dicts etc...

# Counter
# - count the number of elements in the container
a = "aaaabbbbccc"
my_counter = Counter(a)
print(1, Counter(a))
print(2, Counter(a).most_common())
print(3, Counter(a).most_common()[0][1])
print(4, Counter(a).keys())
print(5, Counter(a).values())
print(6, list(my_counter.elements()))

# - you can subtract two counters from each other
inventory = Counter(dogs=23, cats=14, pythons=7)
adopted = Counter(dogs=2, cats=5, pythons=1)
inventory.subtract(adopted)
print(inventory)

# - or you can update the counter
inventory.update({"dogs": 20, "cats": -5})
print(inventory)

print(separator.separator())

# Namedtuple (improves readability)
# - allows you to create tuple subclasses with named fields
Point = namedtuple("Point", "parameter_1, parameter_2")
point_instance = Point(24, 30)
print(point_instance.parameter_1)
print(point_instance.parameter_2)


# - example how it improves readability
def custom_divmod(x, y):
    DivMod = namedtuple("DivMod", "quotient remainder")
    return DivMod(*divmod(x, y))


result = custom_divmod(12, 5)
print("custom divmod:", result)
print(f"{result.quotient = }")
print(f"{result.remainder = }")


print(separator.separator())

# defaultdict
# - set a value to return if a key is not found in the dict
d = defaultdict(int)  # here it is set that it will return a base value of int which is 0
d["a"] = 1
d["b"] = 2
d["c"] = 3
print(d["d"])

# - can be also done with regular dict.setdefault()
d2 = {"a": 1}
print(d2.get("c", 99))  # return 99 if b not in dict
d2.setdefault("b", 88)  # return 99 if b not in dict
print(d2["b"])
print(d2) # now it will also return dict with "b": 88 because set default updates it

# OrderedDict
# - can be used in older versions of python, where dicts were not ordered
# Three main reason why to use ordered dict
# - to clearly communicate to the reader that order of this dict matters
# - can use methods like .move_to_end(), popitem() ...
# - equality check - two ordered dicts wit same items but in different order will be unequal
print(separator.separator())

# deque (double-ended queue)
# - means double ended que
# - used to add or remove elements from both ends
# - supports indexing - deque[int] to find a item but deque does not support slicing... [:]

deque_ = deque(maxlen=3)  # it will keep max length of deque 3 items. Newly appended
# items will push out the old ones

deque_.append(1)
deque_.append(2)
deque_.append(3)
print(deque_)

print(separator.separator())

# - append to the left side
deque_.appendleft(4)
print(deque_)

print(separator.separator())

# - pop (return and remove last element)
deque_.pop()
print(deque_)
# - popleft (return and remove last element)
deque_.popleft()
print(deque_)

print(separator.separator())

# - extend the deque from left side
deque_.extendleft([4, 5, 6])  # last in will be at the first position etc.
print(deque_)

print(separator.separator())

# - rotate
deque_.rotate(2)  # this will shift all elements by 2 to the right
print(deque_)
deque_.rotate(-4)  # rotate back 2 positions plus another 2 more to the left
print(deque_)
