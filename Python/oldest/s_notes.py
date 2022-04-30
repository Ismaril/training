# sys module - used here for return of bytes per request
import sys

# timeit module - used here for speed per nr of iterations
import timeit

# math module - extra mathematical operations

import random

# pathlib module - for working with folders
from pathlib import Path

# Random test 1 ##############################################################################################

from future.types import range

print("# Random test 1")
first = 10
last = 5
message1 = f"{first - last}"
print(sys.getsizeof(message1), "bytes")

first = 10
last = 5
message2 = first - last
print(sys.getsizeof(message2), "bytes")
print("*" * 100)

# Difference in bytes & speed ################################################################################
print("# Difference in bytes & speed")
score_player = 10
score_program = 8
print(f"Your score: {str(score_player)}\nProgram score: {str(score_program)}")
print(sys.getsizeof(f"Your score: {str(score_player)}\nProgram score: {str(score_program)}"), "bytes")
print(timeit.timeit(stmt=f"{str(score_player)}", number=1000), "seconds")
print("")
print("Your score: " + str(score_player) + "\nProgram score: " + str(score_program))
print(sys.getsizeof("Your score: " + str(score_player) + "\nProgram score: " + str(score_program)), "bytes")
print(timeit.timeit(stmt=str(score_player), number=1000), "seconds")
print("*" * 100)

# search in lists etc ########################################################################################
print("# search in lists etc")
string_a = ["pig", "pong", "hof", "dog", "wiz", "jiz"]
string_b = "This is my text"
print(string_a)
print(string_b)

# search index position by inserting exact item, possible to insert also range in which to look for
print(string_a.index("hof", 0, len(string_a)))

# search by index, to find item use NUMBER
print(string_a[0])

# search index position by .find (seems working only for string?)
print(string_b.find("T"))
print(string_b.index("T"))
print("*" * 100)

# floor division and mod #####################################################################################
print("# mod and floor division")
print(11 // 2)
print(11 % 2)
print("*" * 100)

# Nested for loop with printed x and y as coordinates ########################################################
print("# Nested for loop with printed x and y as coordinates ")

list_1 = []
for x in range(3):
    for y in range(3):
        for z in range(3):
            list_1.append([x, y, z])
print(list_1)

for x in range(3):
    for y in range(3):
        for z in range(3):
            print(f"({x}, {y}, {z})")
print("*" * 100)

# Prints F on multiple lines, coded by me:
numbers = [5, 2, 5, 2, 2]
for index in numbers:
    x = ""
    for number in range(index):
        x = x + "x"
    print(x)
print()

# Prints F on multiple lines, shorter code:
numbers = [5, 2, 5, 2, 2]
for index in numbers:
    print("x" * index)
print("*" * 100)

# Sorting and reversing ######################################################################################
print("# Sorting and reversing ")
list_2 = [1, 35, 88, 0.5, 2, 63, 100, 354]
print(list_2)
list_2.sort()
print(list_2)
list_2.reverse()
print(list_2)
print("*" * 100)

# Remove doubled items #######################################################################################
print("# Remove doubled items")
list_3 = [3, 56, 3, 17, 11, 11, 36, 55, 20, 20, 1, 1, 2, 2]
list_3.sort()
print(list_3)
index_p = 0
removed_items = []
for nr in list_3:
    if nr in list_3[index_p + 1:]:
        list_3.remove(nr)
        removed_items.append(nr)
        index_p += 1
    else:
        index_p += 1
print(list_3)
print(f"Removed doubled items: {removed_items}")
print("*" * 100)

# Tuples #####################################################################################################
print("# Tuples")
my_tuple = (1, 2, 3)
print(type(my_tuple))

a, b, c = my_tuple
print(a, b, c)
print("*" * 100)

# Dictionary #################################################################################################
print("# Dictionary")
my_dict = {
    "1": "one",
    "2": "two",
    "3": "three",
}
# delete "" if you want to try out this program (returns assigned number)
"""
my_input = input("Phone: ")
output = ""
for l in my_input:
    output += my_dict.get(l) + " "
print(output)
"""
print("*" * 100)

# Emoji converter ############################################################################################
print("# Emoji converter")
"""
input_my = input("> ")
words = input_my.split(" ")
emojis = {
    ":D": "😁",
    ":(": "☹",
}
output = ""
for item in words:
    output = output + emojis.get(item, item) + " "
print(output)
"""
print("*" * 100)

# Emoji converter -> Create reusable function ################################################################
print("# Emoji converter -> Reusable function")

"""
def emoji_converter(input_my):
    words = input_my.split(" ")
    emojis = {
        ":D": "😁",
        ":(": "☹",
    }
    output = ""
    for item in words:
        output = output + emojis.get(item, item) + " "
    return output


input_my = input("> ")
emoji_converter(input_my)
print(output)
"""
print("*" * 100)

# Key word arguments #########################################################################################
# useful when order of arguments needs to be changed, or can be used to improve readability
# If using keyword arguments (in red below) in function together with standard (positional arguments, key word
# arg haveto go last, = after positional arguments.
print("# Key word arguments")


def greeting(first_name, second_name):
    print(f"Greeting {first_name} {second_name}")


greeting(second_name="Vajrova", first_name="Morena")
print("*" * 100)

# Classes ####################################################################################################
print("# Classes")


class Point:
    @staticmethod
    def move():
        print("move")

    @staticmethod
    def draw():
        print("draw")


point1 = Point()
point1.x = 10
point1.y = 20
print(point1.x)

point2 = Point()
point2.x = 30
point2.y = 40
print(point2.x)
print("*" * 100)

# This is exactly the same as above but good practise:
print("# Good practise class")


class Point:

    def __init__(self, x, y):
        self.x = x
        self.y = y


point1 = Point(10, 20)
print(point1.x)
print("*" * 100)

# Some example:
print("# Some class example")


class Person:
    def __init__(self, name):
        self.name = name

    def talk(self):
        print(f"Hi, I am {self.name}")


tom_bro = Person("Tom Bro")
tom_bro.talk()

bob = Person("Bob")
bob.talk()
print("*" * 100)

# Inheritance ################################################################################################
# Inheritance is a mechanism for reusing code
print("# Inheritance")


class Mammal:
    def walk(self):
        print(f"{self.name} walks")


class Dog(Mammal):
    def __init__(self, name):
        self.name = name


class Cat(Mammal):
    def __init__(self, name):
        self.name = name


dog1 = Dog("Barik")
dog1.walk()

cat1 = Cat("Busty")
cat1.walk()
print("*" * 100)

# Modules ####################################################################################################
print("# Modules")
from oldest import s_utilities

print(s_utilities.kg_to_lbs(100))
print(s_utilities.find_max_num([30, 25, 63]))
print("*" * 100)

# Difference when def under class ############################################################################
print("# Difference when def under class")


# 2 same functions with one difference when under class (self has to be added)
# 1


class Dice:
    @staticmethod
    def roll():
        x = random.randint(1, 6)
        y = random.randint(1, 6)
        return x, y


print(Dice().roll())


# 2


def roll_it():
    a = random.randint(1, 6)
    b = random.randint(1, 6)
    return a, b


print(roll_it())
print("*" * 100)

# Working with folders #######################################################################################
# Imported pathlib
print("# Working with folders")

# Path can be either relative (starting from current folder) or absolute (starting from C:-> ...)
# Here it's relative starting from file in current project
path1 = Path("../mini projects/hangman.py")
print(Path.is_file(path1))

# .glob for searching all files in folders.
# "*" sign for all, "*.*" for files "*.xls" for exact files
path2 = Path()
for file in path2.glob("*.py"):
    print(file)
print("*" * 100)

# Encoding ###################################################################################################
print("# Encoding")
a = "a"
b = "b"
c = "c"

var_string1 = "alphabet is key"
var_string2 = "string"
var_string3 = "Čenda sére sračky"

result1 = var_string2.encode("cp037", "strict")
result2 = result1.decode("cp037", "strict")

for x in var_string3, result1, result2:
    print(x)
print("*" * 100)

# General ####################################################################################################
print("# General")

# * hvězdička
my_tuple = (0, 1, 2, 3, 4)
i1, *i2, i3 = my_tuple
print(i1)  # 0
print(i2)  # [1, 2, 3]
print(i3)  # 4
