# Snail Sort
# Given an n x n array, return the array elements arranged from outermost elements to the middle element,
#     traveling clockwise.
#
# array = [[1,2,3],
#          [4,5,6],
#          [7,8,9]]
# snail(array) #=> [1,2,3,6,9,8,7,4,5]
#
# For better understanding, please follow the numbers of the next array consecutively:
# array = [[1,2,3],
#          [8,9,4],
#          [7,6,5]]
# snail(array) #=> [1,2,3,4,5,6,7,8,9]

def snail(source):
    array_1d = [item for sublist in source for item in sublist]
    from_top = 0
    from_left = 0
    from_right = 0
    from_bottom = 0
    row = len(source[0])
    column = len(source)
    result = []

    while len(result) < len(array_1d):
        # RIGHT
        result.extend(source[0 + from_top][from_left + 0: row - from_right])

        # DOWN
        for item in source[1 + from_top: column - 1 - from_bottom]:
            result.append(item[-1 - from_left])

        # LEFT
        result.extend(reversed(source[-1 - from_bottom][from_left + 0: row - from_right]))

        # UP
        for item in reversed(source[1 + from_top: column - 1 - from_bottom]):
            result.append(item[0 + from_right])

        from_top += 1
        from_left += 1
        from_right += 1
        from_bottom += 1

    return result[:len(array_1d)]
