# The goal of this exercise is to convert a string to a new string
# where each character in the new string is "(" if that character
# appears only once in the original string, or ")" if that character
# appears more than once in the original string. Ignore capitalization
# when determining if a character is a duplicate.

# "din"      =>  "((("
# "recede"   =>  "()()()"
# "Success"  =>  ")())())"
# "(( @"     =>  "))(("
import unittest


def duplicate_encode(word):
    # todo: refactor to only iterate once

    word = word.lower()
    duplicate_characters = ''

    for i, character in enumerate(word):
        if character in word[i+1:]:
            duplicate_characters += character

    result = ''
    for character in word:
        if character in duplicate_characters:
            result += ')'
        else:
            result += '('

    return result


class TestDuplicate(unittest.TestCase):
    def test_duplicate_encode(self):
        self.assertEqual(duplicate_encode("din"), "(((")
        self.assertEqual(duplicate_encode("recede"), "()()()")
        self.assertEqual(duplicate_encode("Success"), ")())())")
        self.assertEqual(duplicate_encode("(( @"), "))((")


if __name__ == "__main__":
    unittest.main()

