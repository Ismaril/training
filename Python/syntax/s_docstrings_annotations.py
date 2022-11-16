def my_function():
    """
    First line which is summary of the function, followed by blank line.

    More detailed description in this paragraph.
    Evey sentence must begin with capital letter and end with dot.
    """
    pass


print(my_function.__doc__)


def f(ham: str, eggs: str = 'eggs') -> str:
    print("Annotations:", f.__annotations__)
    print("Arguments:", ham, eggs)
    return ham + ' and ' + eggs


print(f("Ham"))
