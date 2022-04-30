from math import pi

# 4 Principles of OOP

# 1. Inheritance
# 2. Polymorphism
# 3. Encapsulation
# 4. Abstraction

# Why do we need classes?:
#   -They are used when more complex object has to be created.
#   -Also it is much easier to maintain code of classes.
#   -Class is something like blueprint how something should be defined.

# Other info:
# Function - standalone function outside of class.
# Method - function in class

##############################################################################################################
# position, name, age, level, salary
# It would be not practical to store data about one engineer in list. Instead, class should be used.
se10 = ["Software engineer", "Jim", 34, "Junior", 5000]
se11 = ["Software engineer", "Monica", 40, "Senior", 7000]
d10 = ["Designer", "Trevor", 55, "Senior", 6500]


def some_function(some_object):
    print(f"{some_object[1]} is writing a code")


# Visualise "some_function"
some_function(se10)
some_function(d10)  # This code actually works but does not make sense because software engineer should write
# a code in this example. This is then very tedious if one should rewrite everything.

##############################################################################################################
# CLASS, INSTANCE AND FUNCTIONS


# Class created (only blueprint for later use)
class SoftwareEngineer:
    # Class attributes
    # These variables apply to every created instance.
    # Can be used on the class itself
    alias = "Keyboard magician"

    # __init__ is used to initial our object
    def __init__(self, name, age, level, salary):
        # Instance attributes
        # "self.name" will hold the actual value, "name" actually refers only to passed parameter above.
        # These variables only refer to one object, like to se1 below. They do not apply to the whole class.
        # SoftwareEngineer.name would crash the program, because name belongs only to each separate instance.
        self.name = name
        self.age = age
        self.level = level
        self.salary = salary

    # Instance methods (functions)
    def write_a_code(self):
        print(f"{self.name} is writing code")

    def code_in_language(self, language):
        print(f"{self.name} is writing code in {language}")

    def information(self):
        information = f"name = {self.name}, age = {self.age}"
        return information

    # Dunder (double underscored)(magic) methods (functions)
    def __str__(self):
        # def __str__(self) will be executed whenever our object is converted to a string
        information = f"name = {self.name}, age = {self.age}"
        return information

    def __eq__(self, other):
        # __eq__ compares two objects
        # below it is defined that if objects names and ages are the same, then when for example the object
        # are compared, they will be treated as the same
        return self.name == other.name and self.age == other.age

    # function without self
    # can be used on the whole class, but not on things that have already "self"
    # in practise this is not used. Instead a decorator (@) should be used.
    # when the "@staticmethod" is applied now the function can be used for both whole class and instance. But
    # in this case when it will be used with instance, it will not return anything connected to "self"
    @staticmethod
    def entry_salary(age):
        if age < 25:
            return 5000
        elif age < 30:
            return 9000
        return 9000


# Instance of the original class (data are filled here)
se1 = SoftwareEngineer("Jim", 34, "Junior", 5000)
se2 = SoftwareEngineer("Monica", 40, "Senior", 7000)
se3 = SoftwareEngineer("Monica", 40, "Senior", 7000)

# Visualise
print(1, se1.name, se1.age)
print(2, SoftwareEngineer.alias)  # notice that this can be called directly by SoftwareE. and also by instance
print(3, se2.name, se2.name)
print(4, se2.alias)
se1.write_a_code()
se2.write_a_code()
se1.code_in_language("Python")
print(5, se1.information())
print(6, se1)  # with def __str__ it no longer returns this: <__main__.SoftwareEngineer object at 0x0000017A1AA3BCD0>
print(7, se2 == se3, se2 is se3)
# print(se1.entry_salary(24)) # this will not work because the entry_salary function is
# missing self (lets say we want it in some case).
print(8, SoftwareEngineer.entry_salary(se1.age))

# Recap:
# Create class (blueprint)
# Create instance (object)
# instance attributes: defined in __init__(self)


##############################################################################################################
# INHERITANCE

# Parent class is the base class, that provides its functionalities to child classes
# Child class inherits functionalities from parent class

# inherits functionalities,
# extend functionalities - if the method has new name
# override functionalities - if the method has the same name as parent class, it overrides the old method
class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def work(self):
        print(f"{self.name} is working...")

    def shit(self):
        print(f"{self.name} is shitting...")


class Engineer(Employee):
    # notice, that "level" parameter in this class can be used only for this class, not others
    # this is some example of overriding some parameters
    def __init__(self, name, age, salary, level):
        super().__init__(name, age, salary)  # Super calls initializer of its parent class, has to be used,
        # because I am extending parameters by "level". It has to be done with "super" else __init__ in child
        # class wont work.
        self.level = level

    def debug(self):  # this method is only specific to Engineer class
        print(f"{self.name} is debugging...")

    def work(self):
        print(f"{self.name} is coding...")


class Designer(Employee):
    def draw(self):  # this method is only specific to Designer class
        print(f"{self.name} is drawing...")

    def work(self):
        print(f"{self.name} is designing...")


employee_1 = Employee("Farkas", 23, 3000)
employee_1.work()

engineer = Engineer("Dude", 34, 6000, "mid-level")
print(9, engineer.name, engineer.age)
engineer.work()
print(10, engineer.level)
engineer.debug()
engineer.shit()

designer = Designer("Trevor", 55, 6500)
print(12, designer.name, designer.age)
designer.work()
designer.draw()


print("*"*50)
##############################################################################################################
# POLYMORPHISM (polymorphism = OF MANY SHAPES)

# My take based on research I made:
# It is possible to call the methods with the same name from different functions by it's name
# (name that is the same in each class) and the method will return each time something else, based on what is
# defined in each class.

firm_employees = [
    Employee("Racek", 99, 0),
    Engineer("Dude", 34, 6000, "mid-level"),
    Engineer("Lisa", 40, 9000, "senior"),
    Designer("Trevor", 55, 6500)
]


def motivate_employees(employees):
    for employee in employees:
        employee.work()


motivate_employees(firm_employees)
print()


class Shape:
    def __init__(self, name):
        self.name = name

    def area(self):
        pass

    def fact(self):
        return "I am a two-dimensional shape."

    def __str__(self):
        return self.name


class Square(Shape):
    def __init__(self, length):
        super().__init__(name="My name is Square")
        self.length = length

    def area(self):
        return self.length**2

    def fact(self):
        return "Squares have each angle equal to 90 degrees."


class Circle(Shape):
    def __init__(self, radius):
        super().__init__(name="My name is Circle")
        self.radius = radius

    def area(self):
        return pi*self.radius**2


print(Shape("My name is Shape"))

a = Square(4)
b = Circle(7)
print(a)
print(b.fact())
print(a.fact())
print(b.area())

print("*"*50)
##############################################################################################################
# ENCAPSULATION AND ABSTRACTION

# Encapsulation = hiding of data implementation
#  - instance variables are kept private, there is only one accessor from the outside which can access these


# _salary (leading underscore) is protected variable
class Programmer:
    def __init__(self, name, age):
        # these can be access from the outside
        self.name = name
        self.age = age
        # these should be kept private (should not be called from outside), but are accessible
        # these are used in practise
        self._salary = None
        self._nr_of_bugs_solved = 0
        # this is kept private (it is not accessible from outside), and is not accessible (error)
        # this is not used in practise that much
        self.__activity_percent = 110

    # These two methods should be the only way to access from the outside the "_salary"
    # "GETTER"
    def get_salary(self):
        """Returns the salary of an employee"""
        return self._salary

    def get_nr_of_bugs_solved(self):
        return self._nr_of_bugs_solved

    # "SETTER"
    def set_salary(self, base_value: int):
        """Insert the size of a salary"""
        self._salary = self._calculate_salary(base_value)

    def bug_solved(self):
        self._nr_of_bugs_solved += 1

    def _calculate_salary(self, base_value):  # even function can be private
        if self._nr_of_bugs_solved < 10:
            return base_value
        elif self._nr_of_bugs_solved < 100:
            return base_value * 2
        else:
            return base_value * 3


programmer_1 = Programmer("Max", 25)
print(1, programmer_1.name, programmer_1.age)
print(2, programmer_1._salary)  # is marked by pycharm, because should be kept private, but is accessible
# print(programmer_1.__activity_percent) # raises an error

programmer_1.set_salary(5000)
print(3, programmer_1.get_salary())

programmer_1.bug_solved()
print(4, programmer_1.get_nr_of_bugs_solved())

for i in range(70):
    programmer_1.bug_solved()

programmer_1.set_salary(5000)
print(5, programmer_1.get_salary())

print("*"*50)
##############################################################################################################
# PROPERTIES


# This is more Pythonic way of doing some encapsulation. (With decorators)
class QualityPlanner:
    def __init__(self):
        self._salary = None

    # This should be the only way to access this from the outside
    @property  # (Getter)
    def salary(self):
        return self._salary

    @salary.setter  # (This is setter)
    def salary(self, value):
        self._salary = value

    @salary.deleter
    def salary(self):
        del self._salary


planner = QualityPlanner

planner.salary = 6000
print(planner.salary)
# del planner.salary # this deletes the value in ._salary and print below will return an error
# print(planner.salary)
