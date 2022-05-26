import math as m

# Here I listed only methods that I suppose are useful at current time

print(f"{m.ceil(4.1) = }")
print(f"{m.copysign(20, -35) = }")  # return first value and sign (+ - ...) of the second one
print(f"{m.dist([3, 3], [6, 12]) = }")  # calculate distance of line between points A and B
print(f"{m.exp(4) = }", m.e ** 4)  # calculate exponent 2.71**your_number
print(f"{m.expm1(4) = }", m.e ** 4 - 1)  # calculate exponent 2.71**your_number-1
print(f"{m.fabs(-4) = }")  # returns float absolute
print(f"{m.factorial(5) = }", 1 * 2 * 3 * 4 * 5)
print(f"{m.floor(4.89) = }")
print(f"{m.fmod(10, 3) = }")  # return float mod
print(f"{m.fsum([1, 2, 3, 4, 5]) = }")  # float sum all items in an iterable
print(f"{m.gcd(5, 10, 150) = }")  # greatest number which can divide all selected numbers without remainder
print(f"{m.isclose(2.02, 2.00, rel_tol=0.01) = }")
print(f"{m.isfinite(m.inf) = }", f"{m.isfinite(4) = }")
print(f"{m.isinf(m.inf) = }")
print(f"{m.isnan(m.nan) = }")
print(f"{m.isqrt(11) = }")
print(f"{m.sqrt(11) = }")
print(f"{m.log(m.e) = }")
print(f"{m.pow(3.8, 3.2) = }")
print(f"{m.prod([1, 2, 3, 4, 5]) = }")  # multiply all elements in the iterable
print(f"{m.e = }")
print(f"{m.pi = }")
print(f"{m.inf = }")
print(f"{m.tau = }")

