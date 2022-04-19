# Decorators

# There are 2 types:
# Class decorators and function decorators

# Decorator allows to add functionality to already existing function

# Decorator is a function that takes another function as an argument and extends
# the behavior of this function without explicitly modifying it

# Functions in python are first class objects = they:
# - defined inside another function
# - passed as an argument into another function
# - returned from another function

def start_end_decorator(some_func):
    def wrapper():
        print("Start")
        some_func()
        print("End")

    return wrapper


@start_end_decorator  # this would do the same as "XXX" line below
def print_name():
    print("Alex")


# print_name = start_end_decorator(print_name) XXX
print_name()

##############################################################################################################
