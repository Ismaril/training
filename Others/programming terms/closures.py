# closure is a function that has still access to variables/attributes of
#   function in which it was created, even though that the parent function
#   has already been executed.


def outer_funct(msg):
    def inner_funct():
        print(msg)

    return inner_funct


# here the outer_funct returns inner_funct, meaning my_funct==inner_funct
my_funct = outer_funct("hello")

my_funct()  # inner_funct still remembers the 'msg' parameter from outer_fuct
my_funct()  # inner_funct still remembers the 'msg' parameter from outer_fuct
my_funct()  # inner_funct still remembers the 'msg' parameter from outer_fuct
