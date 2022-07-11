# last_digit(4, 1)                # returns 4 (4**1)
# last_digit(4, 2)                # returns 6 (4**2)
# last_digit(9, 7)                # returns 9  etc...
# last_digit(10, 10 ** 10)        # returns 0
# last_digit(2 ** 200, 2 ** 300)  # returns 6

# 0 - 0
# 1 - 1
# 2 - 2486
# 3 - 3971
# 4 - 46
# 5 - 5
# 6 - 6
# 7 - 7931
# 8 - 8426
# 9 - 91


MULTI_PATTERN = {
    2: (2, 4, 8, 6),
    3: (3, 9, 7, 1),
    4: (4, 6),
    7: (7, 9, 3, 1),
    8: (8, 4, 2, 6),
    9: (9, 1),
}

SINGLE_PATTERN = {
    0: 0,
    1: 1,
    5: 5,
    6: 6,
}


def last_digit(base, exponent):
    base = base % 10 if base >= 10 else base

    if not exponent: return 1
    if exponent == 1: return base

    # base has a repeating pattern, that is the same number
    if base in SINGLE_PATTERN.values(): return SINGLE_PATTERN.get(base)

    # base has a repeating pattern, that is not a single number
    key = MULTI_PATTERN.get(base)
    i = exponent if len(key) >= exponent else exponent % len(key)
    # print(f"{base=}", f"{exponent=}")
    return key[i - 1]

