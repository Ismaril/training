import unittest
from unittest import TestCase, main
from Python.syntax.s_oop_source import is_prime, zero_division, Employee, Monster

# THIS FILE TALKS ABOUT BUILD IN MODULE UNITTEST
# Usually I see that "unittest" (build in) or "pytest" are used
"""
BEST PRACTISE OF TESTING
- test/tests should be isolated
- test/tests should not rely on other tests = you should be able to run one test independently on another test
- unit testing = testing individual parts separately
- integration testing = testing a program as a whole 
- every method in the code should be covered

BONUS info
- test driven development = sometimes the tests are written even before actual code
- run test with coverage - comes with pycharm professional - shows besides else how many lines of all code I
        covered in total.
"""

a = False
b = None


class Test(TestCase):
    def test_is_prime(self):
        # self.assertTrue(is_prime(5))
        self.assertEqual(11, 11, msg="Must equal 11")

    def test_is_not_prime(self):
        self.assertFalse(is_prime(5))

    def test_zero_division(self):
        # check if function raises an error, parameters: error, your_function, values passed into your funct.
        self.assertRaises(ZeroDivisionError, zero_division, 0)

    @unittest.skip("Comment in the skipped method")  # this skips the test
    def test_skip_this(self):
        self.assertEqual(True, True)


class AssertMethods(TestCase):
    def test_miscellaneous(self):
        self.assertFalse(a, "error message")  # OK if False
        self.assertTrue(not a, "error message")  # OK If True
        self.assertEqual(5, 5)  # "==" operator
        self.assertListEqual([1, 2, 3, 4], [1, 2, 3, 4])
        self.assertIsNone(b)
        self.assertIs(2, 2)
        self.assertAlmostEqual(1.00, 3.300, delta=2.3)  # delta is how much can difference be
        self.assertCountEqual([1, 2, 3, 1], [1, 2, 1, 3])  # number of elements with the same value must equal
        self.assertDictContainsSubset({"a": "A"}, {"a": "A", "b": "B"})
        self.assertDictEqual({"b": "B", "a": "A"}, {"a": "A", "b": "B"})  # positions can be switched
        self.assertGreater(2_000, 1_000)
        self.assertGreaterEqual(5, 4)  # greater or equal
        self.assertIn("a", ("c", "d", "a"))
        self.assertIsInstance(a, bool)  # variable a is False, there fore instance of boolean
        self.assertIsNotNone(a)
        self.assertLess(1_000, 2_000)
        self.assertLessEqual(4, 5)
        self.assert_(20 > 0)  # I guess can be used as a custom assertion? Meaning I can fill in whatever?


class TestEmployee(TestCase):

    # this is build in method that is executed before first test starts
    # specify what to do before everything
    @classmethod
    def setUpClass(cls) -> None:
        print("setUpClass")

    # this is build in method that is executed after last test finishes
    # specify what to do after everything
    @classmethod
    def tearDownClass(cls) -> None:
        print("tearDownClass")

    # this is build in method that specifies what to do before each test_'method_name'
    def setUp(self) -> None:
        print("setUp")
        self.subject_1 = Employee("Ferda", "Mravenec", 5000)
        self.subject_2 = Employee("Perda", "Klikotoč", 8000)

    # this is build in method that specifies what to do after each test_'method_name'
    def tearDown(self) -> None:
        print("tearDown")
        pass

    def test_full_name(self):
        print("TEST_FULL_NAME")
        self.assertEqual(self.subject_1.full_name(), "Ferda Mravenec")
        self.assertEqual(self.subject_2.full_name(), "Perda Klikotoč")

    def test_apply_raise(self):
        print("TEST_APPLY_RAISE")
        self.assertEqual(self.subject_1.apply_raise(), 5250)
        self.assertEqual(self.subject_2.apply_raise(), 8400)


class TestMonster(TestCase):
    def test_defaults(self):
        monster = Monster()
        self.assertEqual(monster.sound, "roar")
        self.assertEqual(monster.hit_points, 20)

    def test_custom_hit_points(self):
        monster = Monster(hit_points=200)
        self.assertEqual(monster.hit_points, 200)

    def test_color(self):
        monster = Monster()
        assert monster.color == "red"


if __name__ == '__main__':
    main()  # execute unittest.main() - run everything that inherits from it
