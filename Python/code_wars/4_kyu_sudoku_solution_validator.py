# Sudoku Background
# Sudoku is a game played on a 9x9 grid. The goal of the game is to fill all cells of the grid with digits
#   from 1 to 9, so that each column, each row, and each of the nine 3x3 sub-grids (also known as blocks)
#   contain all of the digits from 1 to 9.
# (More info at: http://en.wikipedia.org/wiki/Sudoku)
#
# Sudoku Solution Validator
# Write a function validSolution/ValidateSolution/valid_solution() that accepts a 2D array representing a
#   Sudoku board, and returns true if it is a valid solution, or false otherwise. The cells of the sudoku
#   board may also contain 0's, which will represent empty cells. Boards containing one or more zeroes are
#   considered to be invalid solutions.
#
# The board is always 9 cells by 9 cells, and every cell only contains integers from 0 to 9.
#
# validSolution([
#   [5, 3, 4, 6, 7, 8, 9, 1, 2],
#   [6, 7, 2, 1, 9, 5, 3, 4, 8],
#   [1, 9, 8, 3, 4, 2, 5, 6, 7],
#   [8, 5, 9, 7, 6, 1, 4, 2, 3],
#   [4, 2, 6, 8, 5, 3, 7, 9, 1],
#   [7, 1, 3, 9, 2, 4, 8, 5, 6],
#   [9, 6, 1, 5, 3, 7, 2, 8, 4],
#   [2, 8, 7, 4, 1, 9, 6, 3, 5],
#   [3, 4, 5, 2, 8, 6, 1, 7, 9]
# ]); // => true
#
# validSolution([
#   [5, 3, 4, 6, 7, 8, 9, 1, 2],
#   [6, 7, 2, 1, 9, 0, 3, 4, 8],
#   [1, 0, 0, 3, 4, 2, 5, 6, 0],
#   [8, 5, 9, 7, 6, 1, 0, 2, 0],
#   [4, 2, 6, 8, 5, 3, 7, 9, 1],
#   [7, 1, 3, 9, 2, 4, 8, 5, 6],
#   [9, 0, 1, 5, 3, 7, 2, 1, 4],
#   [2, 8, 7, 4, 1, 9, 6, 3, 5],
#   [3, 0, 0, 4, 8, 1, 1, 7, 9]
# ]); // => false

import numpy as np


def valid_solution(board):
    board_transposed = list(np.transpose(board.copy()))
    internal_box = []
    portion = []
    start = 0
    end = 3
    i = 0

    # create an array of internal 3x3 boxes - (9 rectangles)
    while True:
        for j, item in enumerate(board[i]):
            portion.extend(board[i][start:end])
            if j in [2, 5, 8]:
                internal_box.append(portion)
                portion = []
            if i == 8:
                i = -1
                start += 3
                end += 3
            i += 1
        if len(internal_box) == 9:
            break

    # check original board
    for array in board:
        if list(range(1, 10)) != sorted(array) or sum(array) != 45:
            return False

    # check original board transposed
    for array in board_transposed:
        if list(range(1, 10)) != sorted(array) or sum(array) != 45:
            return False

    # check 9 internal rectangles
    for array in internal_box:
        if list(range(1, 10)) != sorted(array) or sum(array) != 45:
            return False

    return True
