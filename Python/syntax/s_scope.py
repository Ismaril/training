import s_oop_source

# LEGB
# Local, Enclosing, Global, Build-in

# While using keyword "global" makes sense in some situations, it does not make sense to overuse it
# System of LEGB is following: Starting from the most inner function, python looks for object in it's
#       local scope. If nothing found there it continues to Enclosing scope (function above current one)
#       (class variables without self are also Enclosing??). If nothing found there it the continues to
#       global scope. If nothing found in previous scopes, the last one to look in is build in functions.


# Global scope: The names that you define in this scope are available to all your code.
# Local scope: The names that you define in this scope are only available or visible to the code within the scope.

x = "global x"


def test_():
    # global makes x available in lower level. It means it can create a new object in global & local scope
    # or it can change the object in global & local scope
    global x
    x = "local y"
    print(x)


test_()
print(x)

print("-" * 50)

# MY TAKE ON THE SCOPES ######################################


# With class
a = min([1])  # build in - function "min()"
b = 2  # global


class TestTest:
    c = 3  # local to TestTest. Enclosing?? to methods below?
    d = None  # local to TestTest. Enclosing?? to methods below?

    @classmethod
    def function_1(cls):
        cls.d = 4
        return f"{cls.d=}"

    @staticmethod
    def function_2():
        e = 5  # local to function 2
        return f"{e=}"

    @staticmethod
    def function_3():
        return f"{b=}"

    @staticmethod
    def function_4():
        return min([6])


print(f"{a=}")  # build-ins
print(f"{b=}")  # global
print(TestTest.c)  # local to TestTest
print(TestTest.function_1())  # taken from local of TestTest (Enclosing??)
print(TestTest.function_2())  # taken from local of function_2
print(TestTest.function_3())  # taken from global scope (seems that Class.method can look into global scope)
print(TestTest.function_4())  # taken from build ins

print("-" * 50)
############################################################

# With functions only
j = min([10])
k = 20


def func_1():
    global k
    k = 20.0
    L = 30

    def func_2():
        j = 30
        return j  # returns j from local scope

    def func_3():
        nonlocal L  # "nonlocal" will preserve L in enclosed scope. Local scope can freely change L without
        # affecting original L
        L *= 100
        return L

    def func_4():
        return k  # returns k from global scope because it did not find it in niether local(func4)
        # nor enclosed(func1)

    def func_5():
        return min([60])  # calls to build_ins because in was found in no scope except the most outer one
        # which is build ins

    print(k)
    print(L)
    print(func_2())
    print(func_3())
    print(func_4())
    print(func_5())


print(j)
func_1()

############################################################
print(s_oop_source.__dict__.keys())  # check what functions or stuff is inside some module
print(dir())  # check what object holds global scope
