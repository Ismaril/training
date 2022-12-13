from builtins import BaseExceptionGroup, ExceptionGroup

# Syntax error
# a = 10)
#
# Type error
# a = 10 + "5"
#
# Name error - assigning value which is not defined yet
# b = c
#
# Value error
# d = [1, 2, 3]
# d.remove(4)
#
# Index error (list index out of range)
# d[4]
#
# Key error
# my_dict = {"name": "Pet"}
# my_dict["age"]


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


class SalaryNotInRangeError(Exception):
    """Exception raised for errors in the input salary.

    Attributes:
        salary -- input salary which caused the error
        message -- explanation of the error
    """

    def __init__(self, salary, message="Salary is not in (5000, 15000) range"):
        self.salary = salary
        self.message = message
        super().__init__(self.message)

    def __str__(self):
        return f'{self.salary} -> {self.message}'


salary = 10000
if not 5000 < salary < 15000:
    raise SalaryNotInRangeError(salary)

if 1 > 1:
    raise ValueTooHigh("Value too high")

# have multiple exceptions in one line
try:
    print()
    # print(1/0)
    # print([1, 2][3])
except (ZeroDivisionError, IndexError) as err:
    print('Exception:', err)

# if you want to check whether the exception was raised and you don't want to
# handle it use raise
"""
try:
    f = open('myfile.txt')
    s = f.readline()
    i = int(s.strip())
except Exception as err:
    raise  # with raise you get also error msg in red text from python
"""

# chaining exceptions - this will let you know that:
# 'The above exception was the direct cause of the following exception'
# instead of
# 'During handling of the above exception, another exception occurred'
#  No I have not found other reason yet.
# raise XXX from exception
"""
try:
    raise ConnectionError
except ConnectionError as exc:
    raise RuntimeError('Failed to open database') from exc
"""


# for concurrency/parallel running code it makes sense to include
# ExceptionGroup
def function_that_causes_exceptions():
    excs = [OSError('ERROR 1'), SystemError('ERROR 2')]
    raise BaseExceptionGroup('there were problems', excs)

# function_that_causes_exceptions()

# You can also append exceptions so that you can use them for exception group
# later
# excs = []
# for test in tests:
#     try:
#         test.run()
#     except Exception as e:
#         excs.append(e)
#
# if excs:
#    raise ExceptionGroup("Test Failures", excs)

# Python docs support to add a note to exception but it does not work here
# def f():
#     raise OSError('operation failed')
#
# excs = []
# for i in range(3):
#     try:
#         f()
#     except Exception as e:
#         e.add_note(f'Happened in Iteration {i+1}')
#         excs.append(e)
#
# raise ExceptionGroup('We have some problems', excs)
