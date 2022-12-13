from Python.utilities import separate_text_stdout

sep = separate_rows_in_training_files.SeparateText()

print([0, 0, 0])
print([0] * 3)  # create a list with multiplication
print(list(0 for _ in range(3)))
print(list(range(3)))
greeting = list("Helloworld")
print(greeting)
greeting[2:5] = []  # remove elements from list
print(greeting)

print(sep.separator())

list_1 = [1, 2, 3]
list_2 = [1, 2, 3]
first, second, third = list_1
_, *all_middles, _ = list_1
_, _, *all_remaining = list_1

# return copies of original list
list_x = list_1.copy()
list_y = list(list_1)
list_z = list_1[:]

print(list_1 + list_2, "+")

list_1.append(list_2)
print(list_1, "-append")

list_1.clear()
print(list_1, "-clear")

list_3 = list_2.copy()
print(list_3, "-copy")

list_4 = [1, 4, 2, 9, 7, 8, 9, 3, 1, "B"]
print(list_4.count(9), "-count")  # how many times is the element in

list_4.extend(list_2)
print(list_4, "-extend")

print(list_4.index("B"), "-index")

list_4.insert(0, "Z")
print(list_4, "-insert")

print(list_4.pop(0), list_4)  # removes and returns an index

list_4.remove(9)
print(list_4, "-remove")  # removes first occurence

list_2.reverse()
print(list_2, "-reverse")

print(sep.separator())


# A function that returns the 'year' value:
def my_func(e):
    return e['year']


cars = [
    {'car': 'Ford', 'year': 2005},
    {'car': 'Mitsubishi', 'year': 2000},
    {'car': 'BMW', 'year': 2019},
    {'car': 'VW', 'year': 2011}
]

cars.sort(key=my_func, reverse=True)
print(cars)

print(sep.separator())


# A function that returns the length of the value:
def my_func_2(e):
    return len(e)


cars = ['Ford', 'Mitsubishi', 'BMW', 'VW']

cars.sort(reverse=True, key=my_func_2)
print(cars)

print(sep.separator())

# comprehensions
print([_ for _ in range(10)])
print([number for number in range(10) if not number % 2])
print([number if not number % 2 else "X" for number in range(10)])
print([number for list_ in range(3) for number in [["a", "b", "c"]]])
print(sep.separator())

# boolean comparison
print([1, 2, 3, 4] > [1, 2])
print([1, 2, 3, 4] == [1, 2])
