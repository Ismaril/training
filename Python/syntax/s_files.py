from Python.utilities.separate_rows_in_training_files import SeparateCode

separator = SeparateCode()
# OPEN FILE FOR
# r - reading
# r+ - reading and writing
# w - writing (I guess it rewrites it completely). create a new file if the name doesn't exist
# w+ - writing and reading
# x - Opens a file for exclusive creation. If the file already exists, the operation fails. (???)
# a - append to the end. create a new file if the name doesn't exist
# a+ - append and read
# t - Opens in text mode. (default)
# b - Opens in binary mode. (for photos, .exe, etc)
# + - Opens a file for updating (combinations of reading, writing...)

# OPEN FILE
# - open only with open function, and close with close method
f = open("../text_files/items_oop.txt", mode='r', encoding='utf-8')
print(f.read())
f.close()

# - better way is to open with with statement. Python then closes files automatically
with open("../text_files/items_oop.txt", mode='r', encoding='utf-8') as file:
    print(file.read())

print(separator.separator())

# WRITE TO FILE
# - open the file (or create it if it does not exist) and write to it
with open("../text_files/some_random_file.txt", "w", encoding="utf-8") as file:
    file.write("Line1\n")
    file.write("Line2\n")
    file.write("Line3\n")

# - open the file (or create it if it does not exist) and write to it
with open("../text_files/some_random_file.txt", "a", encoding="utf-8") as file:
    file.writelines(["Grass is green.\t", "Let me tell ya\n"])

# READ
# - read() file - tell() - seek()
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(f"{file.read(3) = }")  # can specify number of characters to be read
    print(f"{file.read(3) = }")  # reading continues where last reading with "n" ended
    print(f"{file.tell() = }")  # returns position where we are with reading currently
    print(f"{file.seek(0) = }")  # seek returns cursor to specified position
    print(f"{file.tell() = }")  # seek returned to 0 pos, it means that we can read from the beginning
    # print(file.read())  # read complete file

print(separator.separator())

# - read with for loop
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    for line in file:
        print(line, end="")

print(separator.separator())

# - read with readline - read only individual lines
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(file.readline(2))  # specify how many characters to return from given line
    print(file.readline(2))  # continues where it ended with reading before
    print(file.tell())
    print(file.seek(0))
    print(file.tell())

print(separator.separator())

# - read with readlines -
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(f"{file.readline(6)}")
    print(file.readlines(),
          "readlines")  # returns a list of lines from file. Also continues where the reading ened

# - read photo
# with open("images/prsi_screenshot.jpg", "r+b") as photo:
#     print(photo.read())

print(separator.separator())

# WRITABLE
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(f"{file.writable() = }")

print(separator.separator())

# TRUNCATE - delete all from file except the first number of chars inserted to truncate()
with open("../text_files/some_random_file.txt", "r+", encoding="utf-8") as file:
    file.truncate(6)
    print(file.read(), "file after truncate")

print(separator.separator())

# SEEKABLE - returns TRUE if we can use seek() method
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(f"{file.seekable() = }")

print(separator.separator())

# READABLE
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(f"{file.readable() = }")

print(separator.separator())

# FLUSH
# - pushes the text that was written by any write method from internal (pycharm?/python?) buffer to
# operating system buffer. (Data are actually written to the actual file from operating system buffer)
# - can be useful if for example program crashes or anything
with open("../text_files/some_random_file.txt", "w", encoding="utf-8") as file:
    file.write("Line4\n")
    file.flush()
    file.write("Line5\n")
    file.flush()
with open("../text_files/some_random_file.txt", "r", encoding="utf-8") as file:
    print(file.read())

# Remaining functions
# DETACH() - Returns the separated raw stream from the buffer
# FILENO() - Returns a number that represents the stream, from the operating system's perspective
# ISATTY() - Returns whether the file stream is interactive or not
