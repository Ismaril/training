import re
from utilities.separate_rows_in_training_files import SeparateCode

separator = SeparateCode()
# FYI r"some_text" means that the text will be read as "raw", meaning characters like \n \t etc won't be incl.

# OVERVIEW
"""                                     Example:
1) Methods to search for mathces
2) Methods on a match object
3) Metacharacters                       $
4) Special sequences                    \B
5) Sets                                 [a-z]
6) Quantifier                           \d{4}
7) Conditions                           (Mr|Mrs|Ms)
8) Grouping                             (..) (..)  .match(2)
9) Modification                         
"""

# METACHARACTERS
"""
[]	A set of characters	"[a-m]"
\	Signals a special sequence (can also be used to escape special characters)	"\d"
.	Any character (except newline character)	"he..o"
^	Starts with	"^hello"
$	Ends with	"planet$"
*	Zero or more occurrences	"he.*o"
+	One or more occurrences	"he.+o"
?	Zero or one occurrences	"he.?o"
{}	Exactly the specified number of occurrences	"he.{2}o"
|	Either or "falls|stays"
()	Capture and group
"""

# SPECIAL SEQUENCES
"""
\A	Returns a match if the specified characters are at the beginning of the string
    - "\AThe"	
\b	Returns a match where the specified characters are at the beginning or at the end of a word
    (the "r" in the beginning is making sure that the string is being treated as a "raw string")
    - r"\bain"
    - r"ain\b"
\B	Returns a match where the specified characters are present, but NOT at the beginning (or at the end) of a 
    word (the "r" in the beginning is making sure that the string is being treated as a "raw string")
    - r"\Bain"
    - r"ain\B"	
\d	Returns a match where the string contains digits (numbers from 0-9)
    - "\d"	
\D	Returns a match where the string DOES NOT contain digits
    - "\D"	
\s	Returns a match where the string contains a white space character
    - "\s"	
\S	Returns a match where the string DOES NOT contain a white space character
    - "\S"	
\w	Returns a match where the string contains any word characters (characters from a to Z, digits from 0-9, 
    and the underscore _ character)	
    - "\w"	
\W	Returns a match where the string DOES NOT contain any word characters
    - "\W"	
\Z	Returns a match if the specified characters are at the end of the string
    - "Spain\Z"
"""

# SETS
# - A set is a set of characters inside a pair of square brackets [] with a special meaning:
"""
[arn]	Returns a match where one of the specified characters (a, r, or n) are present	
[a-n]	Returns a match for any lower case character, alphabetically between a and n	
[^arn]	Returns a match for any character EXCEPT a, r, and n	
[0123]	Returns a match where any of the specified digits (0, 1, 2, or 3) are present	
[0-9]	Returns a match for any digit between 0 and 9	
[0-5][0-9]	Returns a match for any two-digit numbers from 00 and 59	
[a-zA-Z]	Returns a match for any character alphabetically between a and z, lower case OR upper case	
[+]	In sets, +, *, ., |, (), $,{} has no special meaning, so [+] means: return a match for any + character 
    in the string
"""

# COMPILATION FLAGS
"""
ASCII, A - Makes several escapes like \w, \b, \s and \d match only on ASCII characters 
DOTALL, S - Make . match any character, including newlines
IGNORECASE, I - Do case-insensitive matches
LOCALE, L - Do a locale aware match ???
MULTILINE, M - Multiline matching, affecting ^ and $
VERBOSE, X (for 'extended') - Enable verbose REs, which can be organzied more cleanly ???

"""
# findall()
# - The list contains the matches in the order they are found.
# - If no matches are found, an empty list is returned:
txt = "The rain in Spain"
print(re.findall(pattern="ai", string=txt))
print(re.findall("prd", txt))

print(separator.separator())

# search()
# - function searches the string for a match, and returns a Match object if there is a match.
# - If there is more than one match, only the first occurrence of the match will be returned:
txt = "some yo"
print("The first white-space character is located in position:", re.search("\s", txt).start())
print(re.search(pattern="Spain", string=txt))

print(separator.separator())

# finditer()
# - returns all Iterator/Match object
txt = "The rain in Spain"
res = re.finditer("ai", txt)
print([re for re in res])

print(separator.separator())

# split()
# - function returns a list where the string has been split at each match:
txt = "The rain in Spain"
print(re.split(pattern="\s", string=txt, maxsplit=2))

print(separator.separator())

# match()
# - returns the position only if the string starts with specified str
txt = "The rain in Spain"
print(f"{re.match('The', txt)}")

print(separator.separator())

# sub()
# - function replaces the matches with the text of your choice:
txt = "The rain in Spain"
print(re.sub(pattern="\s", repl="X", string=txt, count=2))

print(separator.separator())

# Match Object
# - A Match Object is an object containing information about the search and the result.
"""
.span() returns a tuple containing the start-, and end positions of the match.
.string returns the string passed into the function
.group() returns the part of the string where there was a match
"""

txt = "Thhhh"
x = re.search("h", txt)
print(f"{x.span() = }")
print(f"{x.string = }")
print(f"{x.group() = }")

print(separator.separator())

# MY Experimentation
# find all adverbs
text = "He was carefully disguised but captured quickly by police."
print(re.findall(r"\w+ly\b", text))

# '.' all characters
text = "hey maan he is hero"
print(re.findall(r"..", text))

print(separator.separator())

# From video tutorial of Python Engineer ####################
test_string = "123abc456789abc#/@(),123ABC."

# How to write it - version 1
pattern = re.compile(r"abc")
matches = pattern.finditer(test_string)

# How to write it - version 2
matches_ = re.finditer(r"abc", test_string)

# loop through matches
# we can use 4 methods on Match object:
#   - group, start, end, span
for match in matches:
    print(match)  # returns Match object
    print(match.span(), match.start(), match.end())  # returns positions of matches
    print(match.group())  # return match we are looking for

print(separator.separator())

# Meta characters and special characters:

# look for all characters
pattern = re.compile(r"..")
matches = pattern.finditer(test_string)
print([match.group() for match in matches])

pattern = re.compile(r"..")  # search for a dot only
matches = pattern.finditer(test_string)
print([match for match in matches])

# look if string starts with
pattern = re.compile(r"^123")
matches = pattern.finditer(test_string)
print([match for match in matches])

# look if string ends with
pattern = re.compile(r"ABC\.$")
matches = pattern.finditer(test_string)
print([match for match in matches])

test_string_2 = "hello 123_ heyho # hohey"

# look if string has digits
pattern = re.compile(r"\d")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string has non digits - including underscore
pattern = re.compile(r"\D")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string has whitespace (space)
pattern = re.compile(r"\s")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string has non whitespace (space) - including underscore
pattern = re.compile(r"\S")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string has alphanumeric chars
pattern = re.compile(r"\w")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string has non alphanumeric chars
pattern = re.compile(r"\W")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

# look if string at the beginning of each block (block is every word separated by space)
pattern = re.compile(r"\bhe")
matches = pattern.finditer(test_string_2)
print([match.group() for match in matches])

print(separator.separator())

# SETS
test_string_3 = "helloHELLO 123_"
pattern = re.compile(r"[lo]")  # it will not look for "lo" but it will return each separate "l" "o"
matches = pattern.finditer(test_string_3)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"[a-z]")  # return all lowercase characters
matches = pattern.finditer(test_string_3)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"[23]")  # return only specified digits
matches = pattern.finditer(test_string_3)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"[0-9]")  # return all numbers (same as \d)
matches = pattern.finditer(test_string_3)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"[a-zA-Z0-9]")  # return all characters from multiple specified ranges
matches = pattern.finditer(test_string_3)
for match in matches:
    print(match)

print(separator.separator())

# COMBINATIONS with METACHARACTERS
test_string_4 = "hello_123"
pattern = re.compile(r"\d*")  # returns empty str, where it does not match search criteria, concatinat matches
matches = pattern.finditer(test_string_4)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"\d+")  # combines matches into one match
matches = pattern.finditer(test_string_4)
for match in matches:
    print(match)
    print("\d")

print(separator.separator())

pattern = re.compile(r"_?\d")  # check if there is "_" before each digit. It returns the digits regless of "_"
matches = pattern.finditer(test_string_4)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"\d{3}")  # look for any 3 digits in sequence
matches = pattern.finditer(test_string_4)
for match in matches:
    print(match)

print(separator.separator())

pattern = re.compile(r"\d{1,3}")  # look for any 3 digits in sequence (range specification)
matches = pattern.finditer(test_string_4)
for match in matches:
    print(match)

print(separator.separator())

# EXERCISE ############
dates = """
01.04.2020
2020.04.01

2020-04-01
2020-05-23
2020-06-11
2020-07-11
2020-08-11

2020/04/02

2020_04_04
2020_04_04
"""

# search for all dates that are in format XXX-XX-XX or XXX/XX/XX
pattern = re.compile("\d{4}[-/]\d{2}[-/]\d{2}")
# explanation: \d{4} string which has a number with 4 digits [any character from specified] \d{2} another..->
#               "2020                                          -                              06 ...->"
matches = pattern.finditer(dates)
for match in matches:
    print(match)

print(separator.separator())

# search for all dates in April
pattern = re.compile("\d{4}.04.\d{2}")
# explanation \d = 4digits in row; . = any character; 04 = raw string (april);...etc
matches = pattern.finditer(dates)
for match in matches:
    print(match)

print(separator.separator())

# CONDITIONS
my_str = """
hello world
1223
2020-05-20
Mr Simpson
Mrs Simpson
Mr. Brown
Ms Smith
Mr. T
pythonengineer@gmail.com
python-engineer@gmx.de
python-engineer123@my-domain.org

"""

# region Search for names only
# how to do it without conditions
pattern_ = re.compile(r"\bM\B[rs].?.+")

# how to do it with conditions, (Mr|Mrs|Ms) - only one of these stays
pattern = re.compile(r"(Mr|Mrs|Ms)\.?\s\w+")

matches = pattern.finditer(my_str)
for match in matches:
    print(match)
# endregion

print(separator.separator())

# GROUPING - region Search for mails only
pre_at_sign = r"[a-zA-Z-.0-9]"
domain = r"[a-zA-Z-]"
ending = f"[a-z]"
pattern_ = re.compile(rf"{pre_at_sign}+@{domain}+\.{ending}+")  # works as f strings
pattern = re.compile(rf"({pre_at_sign}+)@({domain}+)\.({ending}+)")

matches = pattern.finditer(my_str)
for match in matches:
    print(match.group())  # return whole string
    print(match.group(1))  # return position of first parentheses ()
    print(match.group(2))  # return position of second parentheses ()
    print(match.group(3))  # return position of third parentheses ()
    break
# endregion

print(separator.separator())

# MODIFICATION
# Split method - split at each occurrence and return a  list
test_string_5 = "123abc456789abc123ABC"
pattern = re.compile(r"abc")
splitted = pattern.split(string=test_string_5, maxsplit=3)  # split the whole string at each occurence of abc
print(splitted)

print(separator.separator())

# Sub method - replace each occurence and return a complete string
test_string_5 = "hello world, you are the best world"
pattern = re.compile(r"world")
subbed_str = pattern.sub("planet", test_string_5)
print(subbed_str)

print(separator.separator())

urls = """
hello
2020-05-20
http://www.python-engineer.com
https://python-engineer.com
http://www.pyeng.com
"""

# return only urls
pattern = re.compile(r"https?://(www\.)?([a-zA-Z0-9-_.]+)(\.[a-zA-Z]+)")
matches = pattern.finditer(urls)
for match in matches:
    print(match.group())  # return whole str
    print(match.group(1))  # return www
    print(match.group(2))  # return page
    print(match.group(3))  # return ending
    break

print(separator.separator())

# return only urls without www or http/s at the beginning
# TODO: It returns also other two string, dunno why...
subbed_str = pattern.sub(repl=r"\2\3", string=urls)  # return group 2 and group 3 from pattern
print(subbed_str)

print(separator.separator())

# COMPILATION FLAGS
my_str = "Hello world"
pattern = re.compile(r"heLLO", flags=re.IGNORECASE)
matches = pattern.finditer(my_str)
print([match.group() for match in matches])

txt = '<img alt="Jodie Comer" height="209" src="https://m.media-amazon.com/images/M/MV5BZmViMjQxYTUtZDExNy00NjU1LWI4MmEtY2RhODRkMzNkODM1XkEyXkFqcGdeQXVyNjkwNzEwMzY@._V1_UY209_CR37,0,140,209_AL_.jpg" width="140">'
pattern = re.compile(r"https.+\.jpg")
matches = pattern.finditer(txt)
print([match.group() for match in matches])
