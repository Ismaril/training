# The marketing team is spending way too much time typing in hashtags.
# Let's help them with our own Hashtag Generator!
#
# Here's the deal:
#
# It must start with a hashtag (#).
# All words must have their first letter capitalized.
# If the final result is longer than 140 chars it must return false.
# If the input or the result is an empty string it must return false.

# " Hello there thanks for trying my Kata"  =>  "#HelloThereThanksForTryingMyKata"
# "    Hello     World   "                  =>  "#HelloWorld"
# ""                                        =>  false

import unittest


def generate_hashtag(input_: str) -> str | bool:
    if not input_:
        return False
    titled = input_.lower().title()
    joined = ''.join(titled.split())
    with_hashtag = f"#{joined}"
    if len(with_hashtag) > 140: return False
    return with_hashtag


class TestHashtags(unittest.TestCase):
    def test_generate_hashtag(self):
        self.assertEqual("#", generate_hashtag("some instagram talk")[0])
        self.assertEqual("#SomeInstagramTalk",
                         generate_hashtag("some instagram talk"))
        self.assertEqual(False, generate_hashtag("a" * 140))
        self.assertEqual(False, generate_hashtag(""))


if __name__ == "__main__":
    unittest.main()
