# You are given an array (which will have a length of at least 3,
# but could be very large) containing integers. The array is either
# entirely comprised of odd integers or entirely comprised of even
# integers except for a single integer N. Write a method that takes
# the array as an argument and returns this "outlier" N.

# [2, 4, 0, 100, 4, 11, 2602, 36]
# Should return: 11 (the only odd number)
#
# [160, 3, 1719, 19, 11, 13, -21]
# Should return: 160 (the only even number)


def find_outlier(integers):

    # check if container contains mainly even or odd
    container_is_even = 0
    for number in integers[:3]:
        if number % 2 == 0:
            container_is_even += 1
        else:
            container_is_even -= 1

    for number in integers:
        if container_is_even > 0:
            pre_result = number % 2
            if pre_result: return number
        elif container_is_even < 0:
            pre_result = number % 2
            if not pre_result: return number


print(find_outlier([160, 3, 1719, 19, 11, 13, -21]))

