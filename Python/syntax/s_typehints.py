from typing import Tuple, TypeVar, List, Any, NamedTuple
from collections.abc import Sequence


# Ellipsis (three dots) ...
#  - used as slicing operator in numpy
#  - used in in type hinting
#       - used for functions or classes that are not implemented yet
#       - should be the same as pass

# Basic example of typing & function documentation
def greeting(name: str) -> str:
    """Pass your name, and let the function greet you"""
    return f"Hello {name}"


print(greeting("Tom"))

# TYPE ALIASES #############################################
# example 1 ------------------------------------------------
Vector = list[float]


def scale(scalar: float, vector: Vector) -> Vector:
    return [scalar * num for num in vector]


print(scale(2.0, [2.5, 4.36, 5.2]))

# example 2 ------------------------------------------------


ConnectionOptions = dict[str, str]
Address = tuple[str, int]
Server = tuple[Address, ConnectionOptions]


def broadcast_message(message: str, servers: Sequence[Server]) -> None:
    ...


# The static type checker will treat the previous type signature as
# being exactly equivalent to this one.
def broadcast_message_(
        message: str,
        servers: Sequence[tuple[tuple[str, int], dict[str, str]]]
) -> None:
    ...


##################################################
def hovno(param: str | float) -> str:
    return str(param)


x = hovno(2.00)
print(x)

# ------------------------------------------------
z = str("g")


def fn_1(name: str = z) -> str: return name  # if no string inserted, returns name = g


def fn_2(name: str) -> str: return name


print(fn_1())
print(fn_2("prdel"))
print(fn_2(1))


# ------------------------------------------------


def f_0() -> Tuple[str, int, bool, Any]:
    return "1", 20, False, 10


print(f_0())


def f_1() -> Tuple[int, ...]:  # ellipsis allows here unspecified number of elements
    return 10, 20, 30, 40, 50, 60


print(f_1())


def f_2() -> Any:
    return ["1", "ef", 20, 30]


print(f_2())

listos = List[float]


def f_3() -> listos: return [2.3, 54.5, 62.5]


print(f_3())


def append_pi(lst: List[float]) -> None:  # can append to the inserted list without returning anyhting
    lst += [3.14]


my_list = [1, 3, 5]  # type: List[int]

append_pi(my_list)
print(my_list)


def longest(first, second):
    return first if len(first) >= len(second) else second


class MyStr(str):
    ...


result = longest(MyStr('a'), MyStr('abc'))
print(result)


def is_str(val: str | float):  # | means that both types are possible
    # "isinstance" type guard
    if isinstance(val, str):
        # Type of ``val`` is narrowed to ``str``
        ...
    else:
        # Else, type of ``val`` is narrowed to ``float``.
        return "float"


print(is_str(2.5))

