from Python.utilities import separate_text_stdout

sep = separate_rows_in_training_files.SeparateText()

# empty set:
set_0 = set()
# set_0 = {} this would actually be a dictionary

set_1 = {1, 2, 3}

set_3 = set([1, 2, 3])
print(set_3, "set_3")
set_4 = set("Hello")
print(set_4, "set_4")
set_5 = {1, "hello", (1, 2), True}  # sets or lists cannot be in set (only immutable elements)
print(set_5, "set_5")

# print(set_1[0]) set does not support indexing
# accessing exact elements in set is probably not done in practise, because in that case list or tuple
# could be used

set_1.add(4)
print(set_1, "-add")

set_1.clear()
print(set_1, "-clear")

print(sep.separator())

# make a copy
set2 = {1, 2}
print(set2 is set2.copy())
print(set2 is set(set2))

print(sep.separator())

x = {"apple", "banana", "cherry"}
y = {"google", "microsoft", "apple"}
print(x.difference(y),
      "-difference")  # this is same as diff_update, but difference returns a new set

xx = {"apple", "banana", "cherry"}
yy = {"google", "microsoft", "apple"}
xx.difference_update(yy)
print(xx, "-difference update")

fruits = {"apple", "banana", "cherry"}
fruits.discard("banana")
fruits.discard("x")  # will not return an error if not found
print(fruits, "-discard")

xxx = {"apple", "banana", "cherry"}
yyy = {"google", "microsoft", "apple"}
zzz = {"apple"}
print(xxx.intersection(yyy, zzz),
      "-intersection")  # return only the same for both all
# ↑ this is same as intersection_update, but intersection returns a new set

a = {"apple", "banana", "cherry"}
b = {"google", "microsoft", "apple"}
c = {"apple"}
a.intersection_update(b, c)
print(a, "-intersection_update")

aa = {"apple", "banana", "cherry"}
bb = {"google", "microsoft", "facebook"}
print(aa.isdisjoint(bb),
      "-isdisjoint")  # True if non of the elements is the same

x = {"a", "b", "c"}
y = {"f", "e", "d", "c", "b", "a"}
print(x.issubset(y), "-issubset")
print(y.issuperset(x), "-issuperset")

fruits = {"apple", "banana", "cherry"}
print(fruits.pop(), "-pop")  # remove a random item

fruits = {"apple", "banana", "cherry"}
fruits.remove("apple")  # will return an error if not found
print(fruits, "-remove")

x = {"apple", "banana", "cherry"}
y = {"google", "microsoft", "apple"}
print(x.symmetric_difference(y),
      "-symetric_difference")  # return all from both sets that are not the same
# just the same as above (returns a new set)

x = {"apple", "banana", "cherry"}
y = {"google", "microsoft", "apple"}
x.symmetric_difference_update(y)
print(x,
      "-symetric_difference_update")  # return all items from both sets that are not the same

x = {"apple", "banana", "cherry"}
y = {"google", "microsoft", "apple"}
print(x.union(y, {1, 2, 3}), "-union")  # combine all

print(sep.separator())

setos_1 = {item for item in range(5)}
print(setos_1)

setos_2 = set()
for item in range(5):
    setos_2.add(item)
print(setos_2)

print(sep.separator())

# operators like & - | ^
set_6 = {1, 2, 3}
set_7 = {1, 2, 3, 4, 5, 6}
print(set_7 - set_6)  # only nums in left set
print(set_7 | set_6)  # nums in left or right or both
print(set_7 & set_6)  # nums in both
print(set_7 ^ set_6)  # letters in left or right but not both
print(sep.separator())

# comprehension
a = {x for x in 'abracadabra' if x not in 'abc'}
print(a)
