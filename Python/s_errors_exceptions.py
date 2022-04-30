"""
Syntax error
a = 10)

Type error
a = 10 + "5"

Name error - assigning value which is not defined yet
b = c

Value error
d = [1, 2, 3]
d.remove(4)

Index error (list index out of range)
d[4]

Key error
my_dict = {"name": "Pet"}
my_dict["age"]

"""

# Raise
x = 5
if x < 0:
    raise Exception("Number should be positive")

# Assert (checks if statement is True)
y = 5
assert y > 0, "Number should be positive"

# Try Except
try:
    f = 5 / 1
    # b = c
except ZeroDivisionError as e:  # Runs if exception
    print(e)
except NameError as e:  # Runs if exception
    print(e)
else:  # Runs if no exception
    print("Everything ok")
finally:  # Runs always
    print("Cleaning operation")


# Create a custom Exception
class ValueTooHigh(Exception):
    pass


if 100 > 1:
    raise ValueTooHigh("Value too high")
