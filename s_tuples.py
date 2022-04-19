# TUPLES - ordered, immutable, allows duplicates
import sys
import timeit

not_tuple = ("a")
one_element_a = ("a",)
my_tuple_1 = "a", "b", "c", "d", "e"  # parentheses can be excluded, but is it good practise?
my_tuple_2 = ("f", "g", "h", "i", "j")
my_tuple_3 = tuple(("a", "a", "a", "b", "c"))
age, town, color = (25, "York", "white")  # can assign to variables
first_index, *middle_indexes, last_index = my_tuple_1

# tuple methods
print(my_tuple_3.count("a"))
print(my_tuple_3.index("a"))  # first occurrence

# types
print(type(not_tuple))
print(type(one_element_a))

# tuples can be concatenated
print(my_tuple_1 + my_tuple_2)

# can be used to create tuple with number of elements we are multiplying
print(one_element_a * 10)

# len
print(len(my_tuple_2))

# can be iterated through
for item in my_tuple_1:
    print(item)

# working with indexes possible
print(my_tuple_2[::-1])
print(my_tuple_2[1:5])

# min max can be used also
print(min((24, 63, 100)))

print(first_index, middle_indexes, last_index, sep=", ")

# compare the sizes
some_list = [1, 2, 3, 4, 5, 6]
some_tuple = (1, 2, 3, 4, 5, 6)
print(sys.getsizeof(some_list), "bytes")
print(sys.getsizeof(some_tuple), "bytes")

# compare the speed
print(timeit.timeit(stmt=str(some_list), number=1_000_000), "seconds")
print(timeit.timeit(stmt=str(some_tuple), number=1_000_000), "seconds")
