# The rgb function is incomplete. Complete it so that passing in RGB decimal values will result in a
#   hexadecimal representation being returned. Valid decimal values for RGB are 0 - 255. Any values that
#   fall out of that range must be rounded to the closest valid value.
#
# Note: Your answer should always be 6 characters long, the shorthand with 3 will not work here.
#
# The following are examples of expected output values:
# rgb(255, 255, 255) # returns FFFFFF
# rgb(255, 255, 300) # returns FFFFFF
# rgb(0,0,0) # returns 000000
# rgb(148, 0, 211) # returns 9400D3


def rgb(r, g, b):
    all_three = list()
    for item in (r, g, b):
        if item > 255:
            all_three.append(255)
        elif item < 0:
            all_three.append(0)
        else:
            all_three.append(item)
    r, g, b = all_three
    pre_res = f"{hex(r)},{hex(g)},{hex(b)}".upper().replace("0X", "").split(",")

    return "".join([f"0{item}" if len(item) == 1 else item for item in pre_res])
