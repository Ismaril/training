from s_oop_anotheritem import AnotherItem
from s_oop_phone import Phone

item1 = AnotherItem("MyItem", 100)
# item1.name = "OtherItem" # this will cause an error because

# print(item1.__name) # this will return error because __ is strictly private
# print(item1._name)  # this calls "self._name" instance attribute (if it was set in class with one underscore)
print(item1.name)  # this calls "name" method

# item1._name = "shit" # seems it is possible to set new value directly to instance attribute with one underscore
# but is is bad practise I think
# print(item1._name) # will return "shit"

item1.name = "DigItem"
print(item1.name)

print(item1.price)

item1.apply_increment(0.2)
print(item1.price)
item1.apply_discount()
print(item1.price, 120 * 0.8)

# Encapsulation - restrict and access to certain attributes to the outer user
# Abstraction - shows necessary attributes and hides unnecessary to the outer user
# Inheritance - already clear
# Polymorphism - means that some functionality will have different input based on what you input, while being
# still the same functionality

# EXAMPLE OF POLYMORPHISM
# here len() function always returns the length of a argument no matter what instance the argument is.
name = "jim"
print(len(name))

some_list = ["some", "sit"]
print(len(some_list))
