# Memoization is used to speed up computing times of a function or whatever
#   object by remembering the values that were inputted to that function /
#   object and remebering the result of that computation.

# This mean that we can have some function that accepts some parameters
#   checks if the parameters were ever used and if yes it returns from some
#   data container the result that it computed sometime in the past

import time
from Utilities.console_line_separator.separate_text_stdout import SeparateText

sep = SeparateText()

expensive_funct_cache = {}


def expensive_funct(number):
    if number in expensive_funct_cache:
        return expensive_funct_cache[number]

    print(f"Computing {number}")
    time.sleep(1)
    result = number * number
    expensive_funct_cache[number] = result
    return result


# we would expect here, that the final result should be 4 second, but since
#     we check the data in cache we can drastically reduce the time. In this
#     case we can save 2secs.
start = time.perf_counter()
res = expensive_funct(2)
print(f"Result is: {res}", sep.separator(), sep='\n')
res = expensive_funct(10)
print(f"Result is: {res}", sep.separator(), sep='\n')
res = expensive_funct(2)
print(f"Result is: {res}", sep.separator(), sep='\n')
res = expensive_funct(10)
print(f"Result is: {res}", sep.separator(), sep='\n')

end = time.perf_counter()
print("Total time: ", end - start)
