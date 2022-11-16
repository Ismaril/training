import pprint
import textwrap
# todo: check this out more

t = [[[1, 2, 3], [4, 5, 6], [7, 8, 9]],
     [[10, 11, 12], [13, 14, 15], [16, 17, 18]]]
print(t)
pprint.pprint(t, width=30)

doc = """The wrap() method is just like fill() except that it returns
a list of strings instead of one big string with newlines to separate
the wrapped lines."""

print(textwrap.fill(doc, width=40))
