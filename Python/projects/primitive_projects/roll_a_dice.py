import random


def roll_a_dice(sides_of_a_dice):
    return random.randint(1, sides_of_a_dice)


print(roll_a_dice(6))
