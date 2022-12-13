from Python.utilities import separate_text_stdout

sep = separate_rows_in_training_files.SeparateText()

my_dict_1 = {"a": 100, "b": 200}
my_dict_2 = dict(c=300, d=400)
my_dict_13 = {(1,
               2): 4}  # also possible to use a tuple as a key (because it is immutable)

# empty dictionary
my_dict_3 = {}

# dictionary with integer keys
my_dict_4 = {1: 'apple', 2: 'ball', 3: "gun"}

# dictionary with mixed keys
my_dict_5 = {'name': 'John', 1: [2, 4, 3]}

# using dict()
my_dict_6 = dict({1: 'apple', 2: 'ball'})

# from sequence having each item as a pair
my_dict_7 = dict([(1, 'apple'), (2, 'ball')])

print(my_dict_1, my_dict_2, my_dict_3, my_dict_4, my_dict_5, my_dict_6,
      my_dict_7, sep="\n")

print(sep.separator())

# get values
print(my_dict_1["a"])  # returns its pair value
print(my_dict_1.get("x"),
      "-get")  # returns its pair value, "none" if no value found
print(my_dict_1.get("BBB", "value does not exist"),
      "-get")  # second argument returns if value does not exist

car = dict(brand="Ford", model="Mustang", year=1964)
print(car.items(),
      "-items")  # converts a dict to list with tuples for each key value pair
print(car.keys(), "-keys")
print(car.values(), "-values")

dict_my = dict(a=dict(c=3), b=2)
print(dict_my["a"]["c"])  # []["c"] C here is actually key of nested dict

print(sep.separator())

# add values / change values
my_dict_1["a"] = 999
print(my_dict_1["a"])  # changed to 999 above

my_dict_1["x"] = "xxx"
print(my_dict_1.get("x"))

keys = ("key_1", "key_2", "key_3")
values = (1, 2, 3)
print(dict.fromkeys(keys, values), "-fromkeys")  # dictionary with the specified keys and the specified value.

my_dict_11 = dict(name="Tom", age=25)
print(my_dict_11.setdefault("name", 185), my_dict_11, "-setdefault")  # returns value based on specified key
# from the dict. If the key does not exist, insert it together with specified key

update_1 = dict(foot=10, ass=100)
my_dict_11.update(update_1)
print(my_dict_11, "-update")

dictionary1 = dict(x=10, y=20)
dictionary2 = dict(z=30, za=40)
print(dictionary1 | dictionary2, "-| sign for merging dicts")

print(sep.separator())

# delete values
del my_dict_1  # completely deletes this object
print(car)
del car["brand"]
print(car, "-del")

print(my_dict_2.pop("c"), my_dict_2,
      "-pop")  # removes item, and returns a value

print(my_dict_4.popitem(), my_dict_4,
      "-popitem")  # removes item, and returns item. Only last element,
# no parameters can be filled

my_dict_2.clear()
print(my_dict_2, "-clear")

print(sep.separator())

# copies of dict
my_dict_8 = {"99": 99}
print(my_dict_8 is my_dict_8)

my_dict_9 = dict(my_dict_8)
print(my_dict_8 is my_dict_9)

my_dict_10 = my_dict_8.copy()
print(my_dict_10 is my_dict_9)

print(sep.separator())

# comprehensions and looping
# How to do it -> {key: value for variable in iterable}
print({num: num * num for num in range(1, 11)})
print({num: num * num for num in range(1, 11) if num % 2 == 0})
print({num: num * num if num % 2 == 0 else num % 2 == 1 for num in range(1, 11)})

my_dict_12 = {}
keys = ["name", "age", "ass", "eye"]
values = ["Pig", 37, True, True]
for i, item in enumerate(keys):
    my_dict_12[keys[i]] = values[i]
print(my_dict_12)

original_dict = {'jack': 38, 'michael': 48, 'guido': 57, 'john': 33}
new_dict = {k: v for (k, v) in original_dict.items() if v % 2 != 0 if v < 40}  # two if statements
print(new_dict)

original_dict = {'jack': 38, 'michael': 48, 'guido': 57, 'john': 33}
new_dict_1 = {k: ('old' if v > 40 else 'young') for (k, v) in original_dict.items()}
print(new_dict_1)

# nested dict comprehension
print({k1: {k2: k1 * k2 for k2 in range(1, 6)} for k1 in range(2, 5)})

# this normal for_loop will input the same result
dictionary = dict()
for k1 in range(1, 3):
    dictionary[k1] = dict()
    for k2 in range(2, 4):
        dictionary[k1][k2] = k1 * k2
print(dictionary)

# some example of basic for loop
result = {}
for number in range(4):
    result[number] = number * number * number
print(result)
