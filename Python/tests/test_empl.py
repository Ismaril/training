import unittest
from unittest.mock import patch
from empl import Employee

# Info:
# Write tests that are completely separated of each other.
# Tests do not necessarily follow order in which they are defined.


class TestEmployee(unittest.TestCase):

    # this method is native to testing and will run the code inside once
    # before all tests start
    @classmethod
    def setUpClass(cls):
        print('setupClass')

    # this method is native to testing and will run the code inside once
    # after all tests end
    @classmethod
    def tearDownClass(cls):
        print('teardownClass')

    # this method is native to testing and will run the code inside before
    # every test
    def setUp(self):
        print('setUp')
        self.emp_1 = Employee('Corey', 'Schafer', 50000)
        self.emp_2 = Employee('Sue', 'Smith', 60000)

    # this method is native to testing and will run the code inside after
    # every test
    def tearDown(self):
        print('tearDown\n')

    def test_email(self):
        print('test_email')
        self.assertEqual(self.emp_1.email, 'Corey.Schafer@email.com')
        self.assertEqual(self.emp_2.email, 'Sue.Smith@email.com')

        self.emp_1.first = 'John'
        self.emp_2.first = 'Jane'

        self.assertEqual(self.emp_1.email, 'John.Schafer@email.com')
        self.assertEqual(self.emp_2.email, 'Jane.Smith@email.com')

    def test_fullname(self):
        print('test_fullname')
        self.assertEqual(self.emp_1.fullname, 'Corey Schafer')
        self.assertEqual(self.emp_2.fullname, 'Sue Smith')

        self.emp_1.first = 'John'
        self.emp_2.first = 'Jane'

        self.assertEqual(self.emp_1.fullname, 'John Schafer')
        self.assertEqual(self.emp_2.fullname, 'Jane Smith')

    def test_apply_raise(self):
        print('test_apply_raise')
        self.emp_1.apply_raise()
        self.emp_2.apply_raise()

        self.assertEqual(self.emp_1.pay, 52500)
        self.assertEqual(self.emp_2.pay, 63000)

    # you can test for example requests to websites ("things that are yout of
    # your control") using 'mock' module.
    # todo: I have not researched this much, so check it out when you got time
    def test_monthly_schedule(self):
        # insert name_of_module_you_want_to_test.requests.get into patch
        with patch('empl.requests.get') as mocked_get:
            mocked_get.return_value.ok = True
            mocked_get.return_value.text = 'Success'

            schedule = self.emp_1.monthly_schedule('May')
            mocked_get.assert_called_with('http://company.com/Schafer/May')
            self.assertEqual(schedule, 'Success')

            mocked_get.return_value.ok = False

            schedule = self.emp_2.monthly_schedule('June')
            mocked_get.assert_called_with('http://company.com/Smith/June')
            self.assertEqual(schedule, 'Bad Response!')


if __name__ == '__main__':
    unittest.main()
