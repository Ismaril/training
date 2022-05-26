def is_prime(number):
    for num in range(2, number):
        if number % num == 0:
            return
        return number
        #     return False
        # return True


# Can work only if is_prime returns False and True respectively
# def next_prime(number):
#     index = 1
#     while True:
#         if is_prime(number + index):
#             return number + index
#         index += 1


def all_primes(number):
    for num in range(2, number):
        if is_prime(num) is not None:
            yield is_prime(num)


# print(tuple(all_primes(1000)))

#############################################################
def zero_division(number):
    if not number:
        raise ZeroDivisionError("Cannot divide by zero")
    else:
        return f"dividing by {number}"


#############################################################

class Employee:
    SALARY_MULTIPLIER = 1.05

    def __init__(self, first_name, last_name, salary):
        self.first_name = first_name
        self.last_name = last_name
        self.salary = salary

    def full_name(self):
        return f"{self.first_name} {self.last_name}"

    def apply_raise(self):
        return self.salary * Employee.SALARY_MULTIPLIER


#############################################################

class Monster:
    sound = "roar"
    color = "red"

    def __init__(self, hit_points=20):  # 20 by default
        self.hit_points = hit_points
