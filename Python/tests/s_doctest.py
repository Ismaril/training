import doctest
# Module doctest -- a framework for running examples in docstrings.

def average(values):
    """Computes the arithmetic mean of a list of numbers.

    >>> print(average([20, 30, 70]))
    40.0
    """
    return sum(values) / len(values)


def sum_(*args):
    """Sum all numbers together.

    >>> print(sum((10, 20, 30, 40)))
    100
    """

    return sum(args)


doctest.testmod()  # automatically validate the embedded tests
