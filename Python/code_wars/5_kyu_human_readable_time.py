# Write a function, which takes a non-negative integer (seconds) as input and returns the time in a
#   human-readable format (HH:MM:SS)
#
# HH = hours, padded to 2 digits, range: 00 - 99
# MM = minutes, padded to 2 digits, range: 00 - 59
# SS = seconds, padded to 2 digits, range: 00 - 59
# The maximum time never exceeds 359999 (99:59:59)
#
# You can find some examples in the test fixtures.


def make_readable(seconds: int):
    mins_secs = divmod(seconds, 60)
    hrs_mins = divmod(mins_secs[0], 60)
    seconds = mins_secs[1]
    minutes = hrs_mins[1]
    hours = hrs_mins[0]
    result = ""

    for digit in hours, minutes, seconds:
        result += f"0{digit}:" if digit < 10 else f"{digit}:"

    return result[:-1]
