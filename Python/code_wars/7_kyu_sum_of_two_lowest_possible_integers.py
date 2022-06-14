# For example, when an array is passed like [19, 5, 42, 2, 77], the output should be 7.


def sum_two_smallest_numbers(numbers):
    return min(numbers) + sorted(numbers)[1]
