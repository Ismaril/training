from Python.utilities.separate_text_stdout import SeparateText

separator = SeparateText()


def http_error(status):
    match status:
        case 400:
            return "Bad request"
        case 404:
            return "Not found"
        case 418:
            return "I'm a teapot"
        case _:  # _ if no other cases are matched
            return "Something's wrong with the internet"


print(http_error(999))
print(separator.separator())


def funct_(x):
    match x:
        case 401 | 403 | 404:
            return "Not allowed"


print(funct_(401))
print(separator.separator())


def funct_2(point: tuple):
    match point:
        case (0, 0):
            return "Origin"
        case (0, y):
            return f"Y={y}"
        case (x, 0):
            return f"X={x}"
        case (x, y):
            return f"X={x}, Y={y}"
        case _:
            raise ValueError("Not a point")


print(funct_2((5, 5)))
print(separator.separator())


class Point:
    x: int
    y: int


instance_ = Point()
instance_.x = 5
instance_.y = 5


def where_is(point):
    match point:
        case Point(x=0, y=0):
            return "Origin"
        case Point(x=0, y=y):
            return f"Y={y}"
        case Point(x=x, y=0):
            return f"X={x}"
        case Point():
            return "Somewhere else"
        case _:
            return "Not a point"


print(where_is(instance_))
print(separator.separator())


def numba_check(point):
    match point:
        case point if point > 1:
            return f"Yes yes"
        case _:
            return "Not met condition"


print(numba_check(0))
