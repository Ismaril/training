import unittest
import calc


class TestCalc(unittest.TestCase):

    def test_add(self):
        self.assertEqual(calc.add(10, 5), 15)
        self.assertEqual(calc.add(-1, 5), 4)
        self.assertEqual(calc.add(-1, -5), -6)

    def test_subtract(self):
        self.assertEqual(calc.subtract(10, 5), 5)
        self.assertEqual(calc.subtract(-1, 5), -6)
        self.assertEqual(calc.subtract(-1, -5), 4)

    def test_multiply(self):
        self.assertEqual(calc.multiply(10, 5), 50)
        self.assertEqual(calc.multiply(-1, 5), -5)
        self.assertEqual(calc.multiply(-1, -5), 5)

    def test_divide(self):
        self.assertEqual(calc.divide(10, 5), 2)
        self.assertEqual(calc.divide(-5, 5), -1.0)
        self.assertEqual(calc.divide(-5, -5), 1)
        self.assertEqual(calc.divide(-5, -2), 2.5)

        # check if your function raises an error
        # parameters: Type of error, your function, your function arguments
        self.assertRaises(ValueError, calc.divide, 10, 0)

        # this code is the same as the one above
        with self.assertRaises(ValueError):
            calc.divide(10, 0)