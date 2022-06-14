# This time we want to write calculations using functions and get the results.
#
# Let's have a look at some examples:
# seven(times(five())) # must return 35
# four(plus(nine())) # must return 13
# eight(minus(three())) # must return 5
# six(divided_by(two())) # must return 3
#
# There must be a function for each number from 0 ("zero") to 9 ("nine")
# There must be a function for each of the following mathematical operations: plus, minus, times, divided_by
# Each calculation consist of exactly one operation and two numbers
# The most outer function represents the left operand, the most inner function represents the right operand
# Division should be integer division. For example, this should return 2, not 2.666666...:

def zero(arg=None): return 0 if not arg else int(eval(f"0 {arg}"))
def one(arg=None): return 1 if not arg else int(eval(f"1 {arg}"))
def two(arg=None): return 2 if not arg else int(eval(f"2 {arg}"))
def three(arg=None): return 3 if not arg else int(eval(f"3 {arg}"))
def four(arg=None): return 4 if not arg else int(eval(f"4 {arg}"))
def five(arg=None): return 5 if not arg else int(eval(f"5 {arg}"))
def six(arg=None): return 6 if not arg else int(eval(f"6 {arg}"))
def seven(arg=None): return 7 if not arg else int(eval(f"7 {arg}"))
def eight(arg=None): return 8 if not arg else int(eval(f"8 {arg}"))
def nine(arg=None): return 9 if not arg else int(eval(f"9 {arg}"))
def plus(number): return f"+ {number}"
def minus(number): return f"- {number}"
def times(number): return f"* {number}"
def divided_by(number): return f"/ {number}"
