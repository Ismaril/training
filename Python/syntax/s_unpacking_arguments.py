# normal call with separate arguments
a = list(range(3, 6))
print(a)

# use * operator before a container
# call with arguments unpacked from a list
args = [3, 6]
b = list(range(*args))
print(b)


# unpack dictionary into function parameters
def parrot(voltage, state='a stiff', action='voom'):
    print("-- This parrot wouldn't", action, end=' ')
    print("if you put", voltage, "volts through it.", end=' ')
    print("E's", state, "!")


d = {"voltage": "FOUR MILLION", "state": "BLEEDIN' DEMISED", "action": "VOOM"}
parrot(**d)
