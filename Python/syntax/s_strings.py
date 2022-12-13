from Python.utilities import separate_text_stdout

sep = separate_rows_in_training_files.SeparateText()

txt1 = "hello world"
txt2 = "My name is Ståle"
txt3 = "Shi\tting"
txt4 = "My name is {fname}, I'm {age}"
text5 = "pig"
text6 = {'x': 4, 'y': -5}

print(txt1.capitalize(), "-capitalize")
print(txt1.casefold(), "-casefold")  # more aggressive lower
print(txt1.center(20, "x"), "-center")
print(txt1.count("l", 2, 4), "-count")  # string, start, end

print(sep.separator())

print(txt2.encode(encoding="ascii", errors="backslashreplace"))
print(txt2.encode(encoding="ascii", errors="ignore"))
print(txt2.encode(encoding="ascii", errors="namereplace"))
print(txt2.encode(encoding="ascii", errors="replace"))
print(txt2.encode(encoding="ascii", errors="xmlcharrefreplace"))

print(sep.separator())

print(txt1.endswith("wor", 6, 9), "-endswith")  # string, start, end
print(txt3.expandtabs(4), "-expandtabs")
print(txt1.find("l"), "-find")
print(txt4.format(fname="John", age=36), "-format")
print('{x} {y}'.format_map(text6), "-format map")  # use with dictionaries

print(sep.separator())

print(f"{text5}{5:>5}")
print(f"{5:<5}{text5}")
print(f"{text5}{5:^5}{text5}")
print(f"{text5}{-5:=5}")
print(f"{-5:+}{3:+}")
print(f"{-5:-}{3:-}")
print(f"{-5: }{3: }")
print(f"{100000000000:,}")
print(f"{100000000000:_}")
print(f"{5:b}")
# print(f"{:c}") what does this?
print(f"{0b101:d}")
print(f"{-5:e}")
print(f"{-5:.2e}")
print(f"{-5:.2E}")
print(f"{-5:f}")
print(f"{-5:.2f}")
print(f"{-5:3.2f}")  # here 3 is a width of float number and 2 is precison
print(f"{float('nan'):.2F}")
print(f"{-5.00e+00:g}")  # general format
print(f"{9:o}")
print(f"{-14:x}")
print(f"{-14:X}")
# print(f"{:n}") what does this?
print(f"{-0.4:%}")

print(sep.separator())

for item in [1, 2, 3, 4]:
    print("{item:.{command}}".format(item=item, command='2f' if item % 2 == 1 else '4f'))

print(sep.separator())

text7 = "prdel78"
print(text7.index("p", 0, 4), "-index")
print(text7.isalnum(), "-alnum")  # either alphabets or numbers
print("č".isascii(), "-isascii")
print(text7.isalpha(), "-alpha")  # alphabets
print("²10".isdecimal(), "10".isdecimal(), "-isdecimal")
print("²10".isdigit())
print("33shit".isidentifier(), "33 shit".isidentifier(), "shit33".isidentifier(),
      "-isidentifier")  # just like with creating variables

print(sep.separator())

print("diig".islower(), "d99g".islower(), "-islower")
print("²".isnumeric(), "1+2j".isnumeric(), "-isnumeric")
print("\nTralala".isprintable(), "pigaz\t".isprintable(), "-isprintable")  # only printable
# if all characters are printable
print(" \tfe".isspace(), " a ".isspace(), " ".isspace(), "-isspace")
print("Is Title".istitle(), "ISTITLE".istitle(), "-istitle")

print(sep.separator())

print("IS UPPER".isupper(), "-isupper")
print("XXX".join(["Nazdar", "vy", "kurvy"]), "-join")
print("abc".join("123"), "-join")
print("gwe".ljust(6, "X"), "-ljust")
print("BBBBbbb".lower(), "-lower")
print("   Strip me".lstrip(), "-lstrip")
print("Strip me".lstrip("Strip "), "-lstrip")

print(sep.separator())

txt = "Good night Sam Sam t!"
x = "mSa"  # here m corresponds wit e, S with J and so on...
y = "eJo"
z = "odnght"
mytable = txt.maketrans(x, y, z)  # old, new, delete
print(txt.translate(mytable), "-maketrans, translate")

print(sep.separator())

print("I could eat bananas all day".partition("bananas"), "-partition")
print("one one was a race horse, two two was one too.".replace("one", "three", 2), "-replace")
print("Hello, welcome to my worlde.".rfind("e", 5, 27), "-rfind")  # value, start ,end
print("Hello, welcome to my worlde.".rindex("e", 5, 27), "-rindex")  # value, start ,end
print("gwe".rjust(5, "X"), "-rjust")

print(sep.separator())

print("I could eat bananas all day, bananas are my favorite fruit".rpartition("apples"), "-rpartition")
# setting the maxsplit parameter to 1, will return a list with 2 elements!
# note that the result has only 2 elements "apple, banana" is the first element, and "cherry" is the last.
print("apple, banana, cherry".rsplit(", ", 1), "-rsplit")
print("of all fruits", "     banana     ".rstrip(), "is my favorite", "-rstrip")
print("banana,,,,,ssqqqww.....".rstrip(",.qsw"), "-rstrip")

print(sep.separator())

# setting the maxsplit parameter to 1, will return a list with 2 elements!
print("apple#banana#cherry#orange".split("#", 1), "-split")
print("apple banana cherry orange".split(), "-split")
txt5 = "Thank you for the music\nWelcome to the jungle"
print(txt5.splitlines(True), "-splitlines")
print(txt5.splitlines(), "-splitlines")
print("Hello, welcome to my world.".startswith("wel", 7, 20), "-startswith")

print(sep.separator())

print("of all fruits", "     banana     ".strip(), "is my favorite", "-strip")
print(",,,,,rrttgg.....banana....rrr".strip(",.grt"), "-strip")
print("Hello My Name Is PETER".swapcase(), "-swapcase")
print("hello b2b2b2 and 3g3g3g".title(), "-title")  # notice letter behind number
print("Hello my friends".upper(), "-upper")

print(sep.separator())

# Fill the strings with zeros until they are 10 characters long:
a = "hello"
b = "welcome to the jungle"
c = "10.000"

print(a.zfill(10))
print(b.zfill(10))
print(c.zfill(10))

print(sep.separator())

# Escape characters (ASCII)
print("""0hello \
mothafuka""")
print("1hello\\")
print("2hello\"\'")
print("3hello\a")  # bell (i think it is not used today)
print("4hello\b")  # backspace
print("5hello\f")  # "form feed"  the content which follows is part of a new page
print("6hello\n")  # new line
print("7hello\rwife")  # Carriage return means to return to the beginning of the current line without
# advancing downward
print("8hello\twife")  # Horizontal Tab
print("9hello\vwife")  # Vertical Tab
print("\110\145\154\154\157")  # characters of octal value
print("\x48\x65\x6c\x6c\x6f")  # characters of hex value

print(sep.separator())

print('ka'*10)

print(sep.separator())

# old formating
print("Hello %s" % "Diig")  # s string
print("Hello %d" % 35)  # d decimal
print("Hello %f" % 35)  # f float

print(f"{6*6=}")  # with equals it will keep in what is before it in print statement
