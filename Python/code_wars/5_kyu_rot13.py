# ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in
#   the alphabet. ROT13 is an example of the Caesar cipher.
#
# Create a function that takes a string and returns the string ciphered with Rot13. If there are numbers or
#   special characters included in the string, they should be returned as they are. Only letters from the
#   latin/english alphabet should be shifted, like in the original Rot13 "implementation".
#
# Please note that using encode is considered cheating.


OFFSET = 13
UPPER_MIN = 65
UPPER_MAX = 90
LOWER_MIN = 97
LOWER_MAX = 122


def rot13(message):
    result = ""
    letter: str

    for letter in message:
        ord_letter = ord(letter)

        if letter.isupper():
            if ord_letter + OFFSET > UPPER_MAX:
                result += (chr((ord_letter + OFFSET - UPPER_MAX - 1) + UPPER_MIN))
            else:
                result += (chr(ord_letter + OFFSET))

        elif letter.islower():
            if ord_letter + OFFSET > LOWER_MAX:
                result += (chr((ord_letter + OFFSET - LOWER_MAX - 1) + LOWER_MIN))
            else:
                result += (chr(ord_letter + OFFSET))

        else:
            result += letter

    return result
