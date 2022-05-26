import csv


class AnotherItem:
    # class attribute
    pay_rate = 0.8  # The pay rate after 20% discount.
    all = []  # Parent class and all child classes will have access to this (if child do not override)

    def __init__(self, name: str, price: float, quantity=0):
        # Run validation to the received arguments (will return error if it does not match condition)
        assert price >= 0, f"Price ({price}) is not greater or equal to 0."
        assert quantity >= 0, f"Quantity ({quantity}) is not greater or equal to 0."

        # Assign to self object
        self.__name = name
        self.__price = price
        self.quantity = quantity

        # Actions to execute
        AnotherItem.all.append(self)

    ###############################################################
    # THIS IS A EXAMPLE OF ENCAPSULATION (GETTER, SETTER, DELETER)
    # seems that getters and setters do not differ at the first sight to getting the parameters right away but
    # it gives for example control to execute some code before (like restrictions etc)
    @property
    # property decorator = read-only attribute
    # one underscore has to be used in this case, because else it would cause an error when self.name would be
    # set to equal name (__init__ parameter)
    def name(self):
        return self.__name

    @name.setter
    def name(self, new_name):
        # some examples of validation before the core code is executed. Assert / Raise can be used to check
        # errors.
        # TODO: check what is the difference between assert and raise
        assert len(new_name) < 10, "length of the word is greater than 10"

        if len(new_name) < 2:
            raise Exception("length of the word is smaller than 2")
        else:
            self.__name = new_name

    @property
    def price(self):
        return self.__price

    def apply_discount(self):
        self.__price = self.__price * self.pay_rate

    def apply_increment(self, increment_value):
        self.__price = self.__price + self.__price * increment_value

    # HERE ARE EXAMPLES OF ABSTRACTION (prevent outer user accessing internal methods etc.)
    # Just an examples below (code is not written here to work)
    def __connect(self, smtp_server):
        pass

    def __prepare_mail_body(self):
        return f"""
        Hello someone,
        We have {self.__name} {self.quantity}x times.
        Regards, Tom
        """

    def __send(self):
        pass

    # this only will be visible and usable to outer user
    def send_email(self):
        self.__connect("some_server")
        self.__prepare_mail_body()
        self.__send()

    ########################################

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
        return f"{self.__class__.__name__}(name={self.name}, price={self.__price}, quantity={self.quantity})"

    def calculate_total_price(self):
        return self.__price * self.quantity

    @classmethod
    # here this method is made to class method, because it will not be called on any instance but directly
    # on class, also "cls" should be the first argument.
    def instantiate_from_csv(cls):
        with open("../text_files/items_oop.txt", "r") as f:
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
