# A coloured triangle is created from a row of colours, each of which is red, green or blue.
# Successive rows, each containing one fewer colour than the last, are generated by considering the two
#   touching colours in the previous row. If these colours are identical, the same colour is used in the new
#   row. If they are different, the missing colour is used in the new row. This is continued until the final
#   row, with only a single colour, is generated.
#
# Colour here:        G G        B G        R G        B R
# Becomes colour:      G          R          B          G
#
# With a bigger example:
# R R G B R G B B
#  R B R G B R B
#   G G B R G G
#    G R G B G
#     B B R R
#      B G R
#       R B
#        G


KEY = dict({4: 2, 5: 1, 2: 1, 3: 3, 6: 3})
KEY_2 = dict({1: "R", 2: "B", 3: "G"})


def change(n):
    return 1 if n == "R" else 2 if n == "B" else 3


def triangle(row):
    row = tuple(map(change, tuple(row)))
    while len(row) != 1:
        row = [KEY.get(x + row[i + 1]) for i, x in enumerate(row[:-1])]
    return KEY_2.get(row[0])
