import csv


# good practise is to separate usually classes into more files. Main.py should really be dedicated to
# creating only instances of classes.

# Instantiate new variables without self (only as an example not actual real life practise) #################
class Item:
    def __init__(self):
        pass

    def calculate_total_price(self, x, y):
        return x * y


# Hardcoded attributes to demonstrate what is happening when we actually define it in class.
item1 = Item()
item1.name = "Phone"
item1.price = 100
item1.quantity = 5
print(item1.calculate_total_price(x=item1.price, y=item1.quantity))

item2 = Item()
item2.name = "Laptop"
item2.price = 1000
item2.quantity = 3
print(item2.calculate_total_price(x=item2.price, y=item2.quantity), end="\n\n")

print(type(item1))
print(type(item1.name))
print(type(item1.price))
print(type(item1.quantity), end="\n\n")

print(item1.name)
print(item1.price)
print(item1.quantity, end="\n\n")


# Class with multiple real life examples ###############################################################
class AnotherItem:
    # class attribute
    pay_rate = 0.8  # The pay rate after 20% discount.
    all = []  # Parent class and all child classes will have access to this (if child do not override)

    def __init__(self, name: str, price: float, quantity=0):
        # Run validation to the received arguments (will return error if it does not match condition)
        assert price >= 0, f"Price ({price}) is not greater or equal to 0."
        assert quantity >= 0, f"Quantity ({quantity}) is not greater or equal to 0."

        # Assign to self object
        self.name = name
        self.price = price
        self.quantity = quantity

        # Actions to execute
        AnotherItem.all.append(self)

    # __str__ defines what happens when method is converted to a string - str()
    # has priority over __repr__ when the name of a instance is called. For example in print statement.
    # it only serves to return "pretty" text representation
    def __str__(self):
        return self.name.capitalize()

    # Formal way of returning name of object. More for developers.
    # best practise is to write this in the same output as it was actually valid code
    # Seems that it is called with higher priority than __str__ when self is called inside the class 🤔
    # self.__class__.__name__ will return name of a class (like "AnotherItem", "Phone")
    def __repr__(self):
        return f"{self.__class__.__name__}(name={self.name}, price={self.price}, quantity={self.quantity})"

    def calculate_total_price(self):
        return self.price * self.quantity

    def apply_discount(self):
        self.price = self.price * self.pay_rate  # AnotherItem.pay_rate - if we wrote it like this, it
        # would be the same for each instance

    @classmethod
    # here this method is made to class method, because it will not be called on any instance but directly
    # on class, also "cls" should be the first argument.
    def instantiate_from_csv(cls):
        with open("items_oop.txt", "r") as f:
            reader = csv.DictReader(f)
            items = list(reader)

        for item in items:
            AnotherItem(
                name=item.get("name"),
                price=float(item.get("price")),
                quantity=int(item.get("quantity")),
            )

    @staticmethod
    # static method is a method inside a function that has no first parameter like self or cls. It is
    # basically just regular function with normal parameters
    # this statics method is named the same as the build in function "is_integer" by the Youtube. So fyi
    # do not confuse it with "is_integer" in the return statement below
    def is_integer(number):
        if isinstance(number, float):
            # this build in function returns True when float is X.0. When for ex. X.4, False
            return number.is_integer()
        elif isinstance(number, int):
            return True
        else:
            return False


item3 = AnotherItem("watches", 100, 2)
item4 = AnotherItem("glasses", 10, 1)

print(item3.calculate_total_price())
print(item4.calculate_total_price(), end="\n\n")

print(AnotherItem.__dict__)  # all the attributes of the class level
print(item3.__dict__, end="\n\n")  # all the attributes of the instance level

print(AnotherItem.pay_rate)
print(item3.pay_rate)  # when the parameter is not found on the instance level, it searches on the class level
print(item4.pay_rate, end="\n\n")  # same as comment above

item3.apply_discount()  # applies discount as specified in the class and in the function
print(item3.price)

item4.pay_rate = 0.7  # we can override the initial values in class with new ones.
item4.apply_discount()
print(item4.price, end="\n\n")

item5 = AnotherItem("mouse", 5, 1)
item6 = AnotherItem("headphones", 10, 2)
item7 = AnotherItem("keyboard", 5, 4)

print(item5)  # Mouse (defined by __str_)
print(repr(item5))  # defined by __repr__
for instance in AnotherItem.all:
    print(instance.name)

AnotherItem.instantiate_from_csv()
print(AnotherItem.all, end="\n\n")

print(AnotherItem.is_integer(7.0))  # True
print(AnotherItem.is_integer(7))  # True
print(AnotherItem.is_integer("7"), end="\n\n")  # False


# Static and class methods ###########################################################################
class Itemoz:
    @staticmethod
    def is_integer(num):
        """
        This function could possibly stand by itself outside of the class, but since we want it to include
        this functionality insite the class due to some relationship it is kept here.

        Static method has nothing to do with unique instances (no self parameter)

        It is not common but can be called from instance.
        Itemoz_10 = Itemoz()
        Itemoz_10.is_integer(num=7)

        But usually the call would look like this:
        Itemoz.is_integer(num=7)
        :return:
        """

    @classmethod
    def instantiate_from_something(cls):
        """
        'instantiate_from_excel_file' (example)

        This should also do something that has a relationship with a class but usually these are used
        to manipulate different structures of data to instantiate object, like it is done with CSV example
        above.

        cls is a first argument with a reference not to instance(self) but to a class(cls)

        It is not common but can be called from instance.
        Itemoz_11 = Itemoz()
        Itemoz_11.instantiate_from_something()

        But usually the call would look like this:
        Itemoz.instantiate_from_something()

        :return:
        """


# Inheritance ##################################################################################

# from best-practise it would not make sense to add new parameter or function into already existing AnotherItem
# class because it would not be relevant probably for majority of another items. It is better idea to create a
# new class and inherit it.

# this is just a example how to add a new parameter without writting it inside a class.
# (only a example not real life practise)
phone1 = AnotherItem("Nokia9978", 500, 5)
phone1.broken_phones = 1
phone2 = AnotherItem("Nokia9999", 700, 5)
phone2.broken_phones = 1


# with child class we have access to attributes and functions from parent class. Meaning we should only add
# new stuff to the child class (if we don't want to override the old stuff)
class Phone(AnotherItem):
    def __init__(self, name: str, price: float, quantity=0, broken_phones=0):
        # super method allows us not to repeat again writing down original code like assertion and
        # all those original self.XXX = XXX instance attributes. (I think it really copies all from the old
        # class)
        super().__init__(name, price, quantity)

        # Run validation to the received arguments (will return error if it does not match condition)
        assert broken_phones >= 0, f"Broken_phones ({quantity}) is not greater or equal to 0."

        # Assign to self object
        self.broken_phones = broken_phones


phone3 = Phone("SonyErricson", 600, 3)
print(phone3.calculate_total_price(), end="\n\n")  # total price method is inherited from parent class

# call to the same "All" attribute from the parent class. Meaning these print should be the same. (With
# Phone class at the end)
print(AnotherItem.all)
print(Phone.all)

# This tutorial continues in the s_oop_main.py (instantiating in some main file from classes from external
# files)
