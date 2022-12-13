import sys
from Python.utilities import separate_text_stdout


def some_funct():
    pass


def bigger_than_2(number):
    return number > 2


class SomeClass:
    hovno = 1
    prdel = "Ass"


class SubClass(SomeClass):
    pass


some_instance = SomeClass()
some_number = 500
some_list = [1, 2, 3, 4, 5]

sep = separate_text_stdout.SeparateText()

print(abs(-5), "-abs")
print(all([True, True]), "-all")
print(ascii("pepík"), "-ascii")
print(bin(7), "-bin")
print(bytearray("řřř", encoding="UTF-8"), "-bytearray")  # bytearray object can be modified
print(bytearray("aaa", encoding="UTF-8"), "-bytearray")
print(bytearray([5]), "-bytearray")

print(sep.separator())

print(bytes("řřř", encoding="UTF-8"), "-bytes")
print(bytes("aaa", encoding="UTF-8"), "-bytearray")
print(bytes([5]), "-bytes")  # bytes object cannot be modified
print(callable(some_funct), "-callable")
print(chr(90), "-chr")
exec(compile(source='print(55)', filename='test', mode='eval', flags=0, dont_inherit=0, optimize=-1))
print(complex(real=12, imag=2.5), "-complex")  # imaginary is optional
print(complex("12+2.5j"), "-complex")

print(sep.separator())

print(delattr(SomeClass, "hovno"), "-delattr")
print(dict(shit="x", dig="digos"), "-dict")
print(dir(), "-dir")
print(divmod(10, 2), "-divmod")
print(list(enumerate(iterable=["x", "y", "z"], start=5)), "-list(enumareate)")

print(sep.separator())

print(eval("1+2", None, None), "-eval")  # eval(source, globals, locals)
exec("print([x for x in range(11)])", None, None)  # exec(object, globals, locals)
print(list(filter(bigger_than_2, [5, 18, 1])), "-list(filter)")
print(float(59))
print(str("For only {price:.2f} dollars!").format(price=20), "str.fromat()")

print(sep.separator())

print("{x:.8f}".format(x=float(1e-6)), "str.fromat()")
print(format(123, "b"), "-format")
print(frozenset(["a", "b", "c"]), "-frozenset")
print(getattr(some_instance, "prdel"), "-getattr")
print(getattr(some_instance, "hovno", "hovno je smazane"), "-getattr")  # last argument is optional

print(sep.separator())

print(globals())
print(hasattr(some_instance, "prdel"), "-hasattr")
print(hash(1563), hash(10.250), hash("Prdel"), "-hash()")  # Only immutable objects can be passed in.
#   serves as a dictionary
print("help()", "executes the build in help system")
print(hex(263), "-hex")

print(sep.separator())

print(id(some_instance), "-id")
print("input()", "awaits input from user")
print(int("10000101", 2), "-int")
print(isinstance(some_number, int), "-isinstance")
print(issubclass(SubClass, SomeClass), "-subclass")

print(sep.separator())

print(iter(some_list), "-iter")  # second argument (sentinel) can be assigned when the first par is callable
print(len(some_list), "-len")
print(list("Hello"), "-list")
print(locals())
print(list(map(lambda x: x ** 3, some_list)), "list(-map)")

print(sep.separator())

print(max(some_list), "-max")
print(memoryview(bytes(1)), "-memoryview(-bytes())")
print(min(some_list), "-min")
print(next(iter(some_list), "return this if iterator depleted"), "-next")  # second argument if iter depleted
print(object(), "-object")  # returns an empty object

print(sep.separator())

print(oct(869), "-oct")  # converts an integer into an octal string
# print(open()) opens a file
print(ord("?"), "-ord")
print(pow(base=4, exp=2, mod=5), "-pow")  # (4 * 4) % 5)
print(list(range(0, 50, 4)), "-range")
print("object1", "object2", sep="separator", end="\n", file=sys.stdout, flush=False)  # this is default

print(sep.separator())

print(repr(SomeClass), "-repr")
print(reversed([10, 20, 30]), "-reversed")
print(round(number=1.5575637, ndigits=3), "-round")
print(set("a"), "-set")
print(setattr(SomeClass, "sracka", "smrdi"), "-setattr")
print(some_list, some_list[slice(0, 5, 2)], "list_[-slice]")

print(sep.separator())

print(sorted(some_list, reverse=True), "-sorted")  # sorted(iterable, key=optional function, reverse)
# print(staticmethod())
print(str(20 + 20), "-str")
b = bytes('pythööön', encoding='utf-8')
print(str(b, encoding='ascii', errors='ignore'))
print(sum([0.1, 0.2, 0.3, 0.4], 5), "-sum")  # adds second argument to the whole some
# print(super().__init__(), "-super")

print(sep.separator())

print(tuple(["a", "b"]), "-tuple")
print(type(1))  # here have to fill in other arguments - has to be checked cause it aint clear
print(vars(SomeClass), "-vars")  # dictionary containing all local variables
print(list(zip([91, 92, 93, 94], [101, 102, 103], [111, 112, 113])), "list(-zip)")
