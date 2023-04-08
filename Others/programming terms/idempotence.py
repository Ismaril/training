# Idempotent object is when the object does not change no matter
#   how many times you call it. If we take a function as an example, the
#   parameter you fill in can change for the first time, but the result
#   must not change with each other function call.

# f(f(x)) = f(x)

# Not idempotent object:
# If this was idempotent, it should return the same result each time you call
#   the object again.
def add_ten(num):
    return num + 10


print(add_ten(add_ten(-100)))

# Idempotent object, the result is the same no matter how many times you call
#   it.
print(abs(abs(-100)))
