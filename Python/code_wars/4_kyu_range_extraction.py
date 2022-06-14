# A format for expressing an ordered list of integers is to use a comma separated list of either
#
# - individual integers
# - or a range of integers denoted by the starting integer separated from the end integer in the range by a
#       dash, '-'. The range includes all integers in the interval including both endpoints. It is not
#       considered a range unless it spans at least 3 numbers. For example "12,13,15-17"
#
# Complete the solution so that it takes a list of integers in increasing order and returns a correctly
#   formatted string in the range format.
#
# Example:
# solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20])
# returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"


def solution(iterable):
    iterable.extend([98, 99])
    result = ""
    for number in iterable[:-2]:
        zero_pos = iterable[iterable.index(number)]
        plus_one_pos = iterable[iterable.index(number) + 1]
        plus_two_pos = iterable[iterable.index(number) + 2]
        minus_one_pos = iterable[iterable.index(number) - 1]
        minus_two_pos = iterable[iterable.index(number) - 2]

        three_elements_back = True if abs(minus_two_pos - minus_one_pos) == 1 and abs(
            minus_one_pos - zero_pos) == 1 \
            else False
        dif_front_2 = abs(number - plus_two_pos)
        dif_front = abs(number - plus_one_pos)
        dif_back = abs(number - minus_one_pos)

        # print(dif_back, number, dif_front, dif_front_2, end="\n")

        if dif_back != 1 and dif_front == 1:
            if dif_front_2 == 2:
                result += f"{number}"
            elif dif_front_2 != 2:
                result += f"{number},"
        elif dif_back == 1 and dif_front == 1:
            pass
        elif dif_back == 1 and dif_front != 1 and three_elements_back:
            result += f"-{number},"
        else:
            result += f"{number},"

    return result[:-1] if result[-1] == "," else result
