# Runner up score ############################################################################################
# Succesfully executed 2021
print("# Runner up score")
arr = list(input())
arr.sort()
max_num = max(arr)
max_num_count = arr.count(max_num)
print(arr[-1 + (-1)*max_num_count])
print("*" * 100)


# List comprehension #########################################################################################
# I was unable to solve this because at first I did not understand the specification - zadání 2021
print("# List comprehension")

# Badass code
x, y, z, n = (int(input("Number: ")) for _ in range(4))
print([[a, b, c] for a in range(0, x + 1) for b in range(0, y + 1) for c in range(0, z + 1) if a + b + c != n])

# Transformed for better understanding what does the above
x, y, z, n = (int(input("Number: ")) for _ in range(4))
result = []
for a in range(0, x + 1):
    for b in range(0, y + 1):
        for c in range(0, z + 1):
            if a + b + c != n:
                result.append([a, b, c])

print(result)
print("*" * 100)

# Leap year ##################################################################################################
# Succesfully executed 2021


def is_leap(year):
    leap = False
    if year % 4 == 0 and year % 400 == 0:
        leap = True
    elif year % 4 == 0 and year % 100 == 0:
        leap = False
    elif year % 4 == 0:
        leap = True
    else:
        leap = False
    return leap


print(is_leap(2021))

# Badass code:


def is_leap(year):
    return year % 4 == 0 and (year % 400 == 0 or year % 100 != 0)


print(is_leap(2021))
print("*" * 100)

# Nested Lists ###############################################################################################
# Successfully executed on 8/10 tests in 2021, but corrected and 10/10 correct eventually
print("# Nested Lists")

if __name__ == '__main__':
    python_students = []
    for _ in range(int(input())):
        name = input()
        score = float(input())
        python_students.append([name, float(score)])
        python_students.sort(key=lambda x: x[1])

    repeated_scores = []
    for item1 in python_students:
        repeated_scores.append(item1[1])
    repeated_scores.sort()
    repeated_scores_count = repeated_scores.count(min(repeated_scores))

    print(f"Appends score to a list: {repeated_scores}")  # This line is only for my info, should be deleted
    print(f"How many times is there min score: {repeated_scores_count}")  # This line is only for my info, should be del

    for _ in range(repeated_scores_count - 1):
        python_students.remove(python_students[0])

    print(f"Python students after correction: {python_students}")  # This line is only for my info, should be deleted

    second_lasts = []
    second_last_value = python_students[1][1]

    for item1 in python_students:
        for item2 in item1:
            if item2 == second_last_value:
                second_lasts.append(item1[0])
    second_lasts.sort()
    result = second_lasts
    for item_last in result:
        print(item_last)


# Badass code
mark_sheet = []
for _ in range(0, int(input())):
    mark_sheet.append([input(), float(input())])

second_highest = sorted(list(set([marks for name, marks in mark_sheet])))[1]

print('\n'.join([a for a, b in sorted(mark_sheet) if b == second_highest]))


# Finding the percentage #####################################################################################
# Successfully executed on 9/9 tests on 07.11.2021 8PM
print("# Finding the percentage")

if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()
    query_get = student_marks.get(query_name)
    item_value = 0
    for item in query_get:
        item_value += item
    result = item_value/len(query_get)
    print("%.2f" % result)

# My code after my shortening:
if __name__ == '__main__':
    student_marks = {}
    for _ in range(int(input())):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()

    print("{:.2f}".format(sum(student_marks.get(query_name)) / 3))

# Mutate string ##############################################################################################
# Successfully executed on 2/2 tests on 07.11.2021 10PM
print("# Mutate string")

# My code
"""
def mutate_string(string, position, character):
    str_list = str(string)
    new_str = str_list[:position]\
        + str_list[position].replace(str_list[position], character)\
        + str_list[position + 1:]
    return new_str
"""
# Code after unnecessaey stuff was  removed:


def mutate_string(string, position, character):
    return string[:position]\
        + string[position].replace(string[position], character) \
        + string[position + 1:]


if __name__ == '__main__':
    s = input()
    i, c = input().split()
    s_new = mutate_string(s, int(i), c)
    print(s_new)

# Badass code (Python2?):
"""
s = raw_input()
i,k = raw_input().split()
print s[:int(i)]+k+s[int(i)+1:]
"""

# Lists ######################################################################################################
# spent 1 day and did not run sucessfuly due to one last error. Correctly gave up becasue I did not have right
# syntax in
# memory at that time 11.09.2021
print("# Lists")

#My code (idea)
zeroindex = []
first_list = []
action_list = []
result_list = []
final_list = []
N = int(input())

for _ in range(N):
    action_list.append(input().split())
    for one in action_list:
        for two in one:
            if two.isalpha():
                zeroindex.extend(two)
            if two.isnumeric():
                two = int(two)
                zeroindex.append(two)
        action_list.append(zeroindex)
print(action_list)
looper = 0
for x in action_list:
    for y in x:
        if y == "insert":
            idx = action_list[looper][1]
            val = action_list[looper][2]
            result_list.insert(int(idx), val)
        elif y == "remove":
            val = action_list[looper][1]
            result_list.remove(val)
        elif y == "append":
            val = action_list[looper][1]
            result_list.append(val)
        elif y == "sort":
            print(f"1{result_list}")
            result_list.sort()
            print(f"2{result_list}")
        elif y == "pop":
            result_list.pop()
        elif y == "reverse":
            result_list.reverse()
        elif y == "print":
            print(result_list)
    looper += 1

for i in final_list:
    print(i)

# Badass code
if __name__ == '__main__':
    n = int(input())
    L = []
    for _ in range(n):
        s = input().split()
        cmd = s[0]
        args = s[1:]
        if cmd != "print":
            cmd += "(" + ",".join(args) + ")"
            print(cmd)
            eval("L." + cmd)
        else:
            print("\n", L)


# Capitalise #################################################################################################
# Passed all tests on 11.11.2021 at 22:00

s = "k w 2 r 3g hello   world  lol"
listos =[]
listos2 =[]

for x in s:
    listos.append(x)

loop = 0
for y in listos:
    if y == listos[0]:
        listos2.append(y.upper())
    elif listos[loop-1] == " ":
        listos2.append(y.upper())
    else:
        listos2.append(y)
    loop += 1

print("".join(listos2))


# Can be done with title(), but G here will be capitalised when it shouldn't "1 w 2 r 3g"
listos = s.title()
print(listos)


# Can be done with capitalise(), but will not work here for due to spaces "hello   world  lol"
my_list = s.split()
res = []
for x in my_list:
    y = x.capitalize()
    res.append(y)
print(" ".join(res))


# Can be done with upper(), but also will not output the same spaces between strings here
my_list = s.split()
res1 = []
for x in my_list:
    y = x[0].upper()
    z = x[1:]
    res1.append(y)
    res1.append(z)

result = []
names = "".join(res1)

for letter in names:
    if letter is names[0] or letter == letter.lower():
        result.append(letter)
    elif letter.isupper():
        letter = f" {letter}"
        result.append(letter)
print("".join(result))

# List Comprehensions ########################################################################################
# Sucessfully executed, but
if __name__ == '__main__':
    i = int(input())
    j = int(input())
    k = int(input())
    n = int(input())

    final = []
    for x in range(i + 1):
        for y in range(j + 1):
            for z in range(k + 1):
                if sum([x, y, z]) != n:
                    final.append([x, y, z])

    print(final)
