from Python.utilities.separate_text_stdout import SeparateText

sep = SeparateText()

# FUNCTIONS
# default argument/parameter is evaluated at the point of function, and is kept
#   in that function no mather how many times you call that function. If you
#   want that parameter to change each time you call the function, you
#   must implement it inside the function.
i = 5


def f(arg=i):
    print(arg)


i = 6
f()

print(sep.separator())


# change parameters in function
# taken from official python docs, but I feel like it is not good practise to
#   have mutable parameter in function
def f(a, L=[]):
    L.append(a)
    return L


print(f(1))  # [1]
print(f(2))  # [1, 2]
print(f(3))  # [1, 2, 3]
print(sep.separator())


# how args and kwargs work in function
def cheese_shop(kind, *arguments, **keywords):
    print("-- Do you have any", kind, "?")
    print("-- I'm sorry, we're all out of", kind)
    for arg in arguments:
        print(arg)
    print("-" * 40)
    for kw in keywords:
        print(kw, ":", keywords[kw])


def combined_example(pos_only, *standard, **kwd_only):
    print(pos_only, standard, kwd_only, sep="\n")


combined_example(1,
                 'a', 'b', 'c', 'd',
                 kwrd1=100,
                 kwrd2=200)
print(sep.separator())

# just for your info about some other argument definition (but I have never seen it so far)
# / and *
# def f(pos1, pos2, /, pos_or_kwd, *, kwd1, kwd2):
#     -----------    ----------     ----------


# you can have functions inside functions
def parent_funct():
    def child_funct():
        return "this is child function 1"
    return f"This is parent function and {child_funct()}"

print(parent_funct())