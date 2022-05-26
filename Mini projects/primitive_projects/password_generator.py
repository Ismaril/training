import random


def password_generator(nr_of_passwords, len_of_passwords):
    """Generate passwords out of all characters of basic ascii table"""
    for _ in range(nr_of_passwords):
        print("".join([chr(random.randint(33, 127)) for _ in range(len_of_passwords)]))


password_generator(nr_of_passwords=10, len_of_passwords=16)
