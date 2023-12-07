from s_cheff import NormalCheff

try:
    class ChineseCheff(NormalCheff):
        def make_an_icecream(self):
            print("makes a fucking čajníz icecream")

        def make_a_dog(self):
            print("makes a dog")

        def make_rice(self):
            print("makes chinese rice")

    myCheff = NormalCheff()
    myCheff.make_an_icecream()

    myChineseCheff = ChineseCheff()
    myChineseCheff.make_an_icecream()

except TypeError as err:
    print(err)

