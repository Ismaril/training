
# Write a function named first_non_repeating_letter that takes a string input, and returns the first character
#   that is not repeated anywhere in the string.
#
# For example, if given the input 'stress', the function should return 't', since the letter t only occurs
#   once in the string, and occurs first in the string.
#
# As an added challenge, upper- and lowercase letters are considered the same character, but the function
#   should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'.
#
# If a string contains all repeating characters, it should return an empty string ("") or None -- see sample
#   tests.


def first_non_repeating_letter(string):
    if not string:
        return ""
    else:
        lower_ = string.lower()
        for i, letter in enumerate(string):
            sliced_ = lower_[0:i] + lower_[i + 1:len(string)]

            if letter.lower() not in sliced_:
                return letter
            elif letter.lower() in sliced_:
                if i == len(string) - 1:
                    return ""
                continue
