# Write a function that takes a string of braces, and determines if the order of the braces is valid.
#   It should return true if the string is valid, and false if it's invalid.
#
# This Kata is similar to the Valid Parentheses Kata, but introduces new characters: brackets [], and curly
#   braces {}. Thanks to @arnedag for the idea!
#
# All input strings will be nonempty, and will only consist of parentheses, brackets and curly braces: ()[]{}.
#
# What is considered Valid?
# A string of braces is considered valid if all braces are matched with the correct brace.
#
# Examples:
# "(){}[]"   =>  True
# "([{}])"   =>  True
# "(}"       =>  False
# "[(])"     =>  False
# "[({})](]" =>  False

KEYS = {")": "(", "]": "[", "}": "{"}


def valid_braces(string):
    string_copy = list(string)
    string += " "
    i = 0
    while True:
        if not string_copy:
            return True
        elif i == len(string) - 1:
            return False

        for j, char in enumerate(string_copy[:-1]):
            if char == KEYS.get(string_copy[1 + j]):
                del string_copy[j:j + 2]
                break
            else:
                continue
        i += 1
