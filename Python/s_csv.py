import csv
from utilities.separate_rows_in_training_files import SeparateCode

separator = SeparateCode()
# check what's inside
print(dir(csv))

print(separator.separator())

# csv.reader()
# - read comma separated values
with open("text_files/some_csv.csv", "r") as csv_file:
    # if there is not default separator like "," etc specify in csv.reader(delimiter=?) at what value is shoul
    #   split
    csv_reader = csv.reader(csv_file)

    # skip header of the file
    """next(csv_reader)"""

    # print all
    for line in csv_reader:
        print(line)

    # print only specified column
    """for line in csv_reader:
        print(line[2])"""

print(separator.separator())

# csv.writer()
# - write comma separated values
with open("text_files/some_csv.csv", "r") as old_csv_file:
    csv_reader = csv.reader(old_csv_file)
    with open("text_files/some_csv_2.csv", "w") as new_csv_file:
        csv_writer = csv.writer(new_csv_file, delimiter="-")  # separate the values by dash (check explanatio)
        for line in csv_reader:
            csv_writer.writerow(line)
# EXPLANATION - if the split character is the same as some character in item in csv, the item will be changed
# to "item" in csv. (qoutes will be added so that nextime csv module reads it it knows it is one value)

print(separator.separator())

# DictReader()
# - improves readability (compared with above looping through index)
# - read in this fashion -> [(column 1, item_1a), (column 2, item_1b)]
with open("text_files/some_csv.csv", "r") as csv_file:
    dict_reader = csv.DictReader(csv_file)
    for line in dict_reader:
        print(line["drink"])

# DictWriter()
# - improves readability
# - writes to a file
with open("text_files/some_csv.csv", "r") as old_csv_file:
    dict_reader = csv.DictReader(old_csv_file)
    with open("text_files/some_csv_3.csv", "w") as new_csv_file:
        headers = ["food", "metal", "drink"]
        dict_writer = csv.DictWriter(new_csv_file, fieldnames=headers, delimiter=",")
        dict_writer.writeheader()
        for line in dict_reader:
            dict_writer.writerow(line)
