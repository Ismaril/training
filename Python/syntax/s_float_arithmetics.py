from decimal import Decimal, getcontext
from Python.utilities.separate_text_stdout import SeparateText

sep = SeparateText()

print(round(Decimal('0.70') * Decimal('1.05'), 2))
print(round(.70 * 1.05, 2))
print(sep.separator())

print(Decimal('1.00') % Decimal('.10'))
print(1.00 % 0.10)
print(sep.separator())

print(sum([Decimal('0.1')] * 10) == Decimal('1.0'))
print(sum([0.1] * 10) == 1.0)
print(sep.separator())

getcontext().prec = 36  # specify as much precision as you want
Decimal(1) / Decimal(7)
