import random
import random as r

# r.seed(a=10, version=2)  # set random seed to keep the returned values the same for next random iterations
# by default random takes its seed from datetime

captured_state = r.getstate()  # capture the state of random module = can be used later to have the same
# initial random conditions
print(random.random())
print(f"{r.getstate() = }")

r.setstate(captured_state)  # sets the state to the conditions it was captured by "getstate"
print(random.random())
print(f"{r.getstate() = }")

print(f"{r.getrandbits(8) = }")  # get random integer based on filled parameter - number of bytes
print(f"{r.randrange(start=1, stop=20, step=2) = }")  # return 1 random item from a given range
print(f"{r.randint(a=1, b=20) = }")  # is basically the same as randrange
print(f"{r.choice([1, 2, 3, 4, 5]) = }")  # chose an item from a given sequence

# chose items from a given sequence
print(f"{r.choices([1, 2, 3, 4, 5], weights=None, cum_weights=None, k=2) = }")

# shuffle given sequence (returns None)
print(f"{r.shuffle([1, 2, 3, 4, 5]) = }")

# return k number of items from a given sequence. Returned items will not repeat in that list.
print(f"{r.sample((1, 2, 3, 4, 5, 6, 7, 8, 9, 10), k=4) = }")

print(f"{r.random() = }")  # return random float between 0 and 1
print(f"{r.uniform(a=10, b=54) = }")  # return random float between two numbers

# return random float between two numbers. mode specifies "midpoint" or "weight" to some direction
print(f"{r.triangular(low=10, high=60, mode=55) = }")

# Returns a random float number between 0 and 1 based on the Beta distribution (used in statistics)
print(f"{r.betavariate(alpha=10, beta=60) = }")

# Returns a random float number based on the Exponential distribution (used in statistics)
print(f"{r.expovariate(10) = }")

# Returns a random float number based on the Gamma distribution (used in statistics)
print(f"{r.gammavariate(alpha=10, beta=60) = }")

# Returns a random float number based on the Gaussian distribution (used in probability theories)
print(f"{r.gauss(mu=10, sigma=60) = }")

# Returns a random float number based on a log-normal distribution (used in probability theories)
print(f"{r.lognormvariate(mu=10, sigma=60) = }")

# Returns a random float number based on the normal distribution (used in probability theories)
print(f"{r.normalvariate(mu=10, sigma=60) = }")

# Returns a random float number based on the von Mises distribution (used in directional statistics)
print(f"{r.vonmisesvariate(mu=10, kappa=60) = }")

# Returns a random float number based on the Pareto distribution (used in probability theories)
print(f"{r.paretovariate(alpha=60) = }")

# Returns a random float number based on the Weibull distribution (used in statistics)
print(f"{r.weibullvariate(alpha=10, beta=60) = }")
