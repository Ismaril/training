from s_oop_anotheritem import AnotherItem


class Phone(AnotherItem):
    def __init__(self, __name: str, __price: float, quantity=0, broken_phones=0):
        # super method allows us not to repeat again writing down original code like assertion and
        # all those original self.XXX = XXX instance attributes. (I think it really copies all from the old
        # class)
        super().__init__(__name, __price, quantity)

        # Run validation to the received arguments (will return error if it does not match condition)
        assert broken_phones >= 0, f"Broken_phones ({quantity}) is not greater or equal to 0."

        # Assign to self object
        self.broken_phones = broken_phones
