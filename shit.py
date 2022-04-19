import numpy as np


def spiralize(size):
    # create a matrix of all 0
    matrix = [[0 for _ in range(size)] for _ in range(size)]

    offset_x_right = -1
    offset_x_left = 0
    offset_y = 0
    i = 0
    round_one = True
    rotation_complete = False
    rotations = 0

    while i != size:
        # specified zeroes will be replaced by ones
        for j, num in enumerate(matrix[offset_y][offset_x_left:offset_x_right]):
            matrix[offset_y][offset_x_left + j] = 1

        i += 1
        rotations += 1

        # set the offset_x_left +2 in total for the rest of the remaining 3 sides
        if rotation_complete:
            rotation_complete = False
            offset_x_left += 1

        # set the offset for the 4th side
        if rotations == 3:
            if round_one:  # exception for the first round of rotations
                offset_x_right -= 1
            else:  # remaining rounds
                offset_x_right -= 2

        # set the new offsets once all 4 rotations have been completed
        elif rotations == 4:
            rotation_complete = True
            round_one = False
            offset_x_left += 1
            offset_y += 2
            rotations = 0

        # rotate the matrix by 90 degrees
        matrix = np.rot90(matrix)

    # rotate the matrix till top left corner has specified starting position
    while not all(matrix[0]) or matrix[1][0]:
        matrix = np.rot90(matrix)

    return matrix


print(spiralize(20))
