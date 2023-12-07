import time

from Python.utilities.separate_text_stdout import SeparateText
from Python.syntax.s_logging import my_logger
from functools import wraps

sep = SeparateText()


# Decorators

# There are 2 types:
# Class decorators and function decorators

# DECORATOR ALLOWS TO ADD FUNCTIONALITY TO ALREADY EXISTING FUNCTION

# Decorator is a function that takes another function as an argument and
# extends the behavior of this function without explicitly modifying it

# Functions in python are first class objects = they:
# - defined inside another function
# - passed as an argument into another function
# - returned from another function

# For info, basically the original function will be equal do wrapper function
#   when the original function is decorated.

def decorator_function(original_function):
    def wrapper_function():
        print("Here you can modify the code of DECORATOR FUNCTION "
              "without touching the code in decorated function.")
        return original_function()

    return wrapper_function  # we return a function here


# this block does the same as the block below
def display():
    print('display function ran')
display = decorator_function(display)
display()


# this block does the same as the block above.
@decorator_function
def display():
    print('display function ran')
display()

print(sep.separator())


###############################################################################
# the same thing, but we want to give parameters to original function
# explanation:
#   Since we specified parameters in display function, it means that once we
#   apply decorator, the wrapper function will also need those parameters,
#   because otherwise it would not be able to pass those parameters into
#   original function within decorator_function.

def decorator_function(original_function):
    def wrapper_function(*args, **kwargs):
        print("Here you can modify the code of DECORATOR FUNCTION "
              "without touching the code in decorated function.")
        return original_function(*args, **kwargs)

    return wrapper_function  # we return a function here


@decorator_function
def display(argument1, argument2):
    print(f'Display function ran with {argument1} and {argument2}.')


display('hello', 'bye')

print(sep.separator())


###############################################################################
# do the same as above, but with a class


class DecoratorClass:
    def __init__(self, original_function):
        self.original_function = original_function

    # call allows us to call the instance of a class as a function
    # example:
    #   e = DecoratorClass(original_function=some_function)
    #   e(some_parameters)
    def __call__(self, *args, **kwargs):
        print("Here you can modify the code of DECORATOR CLASS "
              "without touching the code in decorated function.")
        return self.original_function(*args, **kwargs)


@DecoratorClass
def display(argument1, argument2):
    print(f'Display function ran with {argument1} and {argument2}.')


display('hello', 'bye')

print(sep.separator())


###############################################################################
# practical examples:
# 1. used often logging - example is in s_logging.py
# 2. used often as performance measuring


def my_timer(original_function):
    from time import perf_counter

    # wraps allows us to preserve the name of original function. (Here
    # 'some_function_'). Without @wraps, the '__name__' method would return
    #  name 'wrapper'
    @wraps(original_function)
    def wrapper():
        start = perf_counter()
        result = original_function()
        end = perf_counter()
        print(f"Function ran in {end - start:.8f}")
        return result

    return wrapper


@my_timer
def some_function_():
    return [n for n in range(100)]


print(some_function_.__name__)
print(some_function_())

print(sep.separator())


###############################################################################
# it is also possible to stack multiple decorators together
# order of decorators above function also plays role!

# After the first decorator my_timer is applied on print_function, the print
#   function now becomes wrapper function of my_timer that is going to be
#   passed to my_logger. This means that the __name__ of the most original
#   print function will not be kept. To fix this we must use wraps from
#   functools -> @wraps(name_of_original_funct) above every declared wrapper.

@my_logger
@my_timer
def print_function():
    time.sleep(0.3)
    return f"hello from print_function"

# above implementation actually does this:
# print_function = my_logger(my_timer(print_function))


print(print_function())

