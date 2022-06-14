# Build Tower
# Build a pyramid tower given a positive integer number of floors. A tower block is represented with "*"

# And a tower with 6 floors looks like this:
# [
#   "     *     ",
#   "    ***    ",
#   "   *****   ",
#   "  *******  ",
#   " ********* ",
#   "***********"
# ]


def tower_builder(n_floors):
    stars_raw = [(f"*" + ("**" * x)).center(2 * n_floors - 1, " ") for x in range(n_floors)]
    return stars_raw


[print(_) for _ in tower_builder(20)]
