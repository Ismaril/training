import unittest
from unittest.mock import patch, mock_open, call, MagicMock
from Utilities.folder_crawler.folder_crawler import \
    FolderCrawler  # Assuming this is the module name and class where the method belongs


class TestReadContentOfFile(unittest.TestCase):
    @patch('builtins.open', new_callable=mock_open, read_data="line1: data\nline2: filter data\nline3: more data")
    @patch('builtins.print')
    def test_read_content_of_file(self, mock_print, mock_file):
        # Test case to verify that only lines containing the filter string are printed
        FolderCrawler.read_content_of_file("dummy_path", filter_="filter")

        # Assertions to check if the correct lines are printed
        mock_print.assert_called_once_with("line2: filter data")

    @patch('builtins.open', new_callable=mock_open, read_data="no relevant data\nnothing matches")
    @patch('builtins.print')
    def test_read_content_of_file_no_matches(self, mock_print, mock_file):
        # Test case where no lines should match the filter
        FolderCrawler.read_content_of_file("dummy_path", filter_="filter")

        # Check that print was never called because no lines matched
        mock_print.assert_not_called()

    @patch('builtins.open', new_callable=mock_open, read_data="filter line\nanother filter line\njust another line")
    @patch('builtins.print')
    def test_read_content_of_file_multiple_matches(self, mock_print, mock_file):
        # Test case where multiple lines should match the filter
        FolderCrawler.read_content_of_file("dummy_path", filter_="filter")

        # Ensure print was called the correct number of times
        calls = [call("filter line"), call("another filter line")]
        mock_print.assert_has_calls(calls, any_order=True)

    @patch('builtins.open', new_callable=mock_open, read_data="")
    @patch('builtins.print')
    def test_read_content_of_file_empty_file(self, mock_print, mock_file):
        # Test case with an empty file
        FolderCrawler.read_content_of_file("dummy_path", filter_="filter")

        # Ensure print was not called because the file is empty
        mock_print.assert_not_called()


class TestFormatDuration(unittest.TestCase):
    def test_seconds_only(self):
        result = FolderCrawler.format_duration(30)
        self.assertEqual(result, "30 SECONDS")

    def test_minutes_and_seconds(self):
        result = FolderCrawler.format_duration(150)
        self.assertEqual(result, "2 MINUTES and 30 SECONDS")

    def test_hours_minutes_and_seconds(self):
        result = FolderCrawler.format_duration(3672)
        self.assertEqual(result, "1 HOUR, 1 MINUTE and 12 SECONDS")

    def test_days_hours_minutes_and_seconds(self):
        result = FolderCrawler.format_duration(93772)
        self.assertEqual(result, "1 DAY, 2 HOURS, 2 MINUTES and 52 SECONDS")

    def test_zero_seconds(self):
        result = FolderCrawler.format_duration(0)
        self.assertEqual(result, "NOW")

    def test_exact_minute(self):
        result = FolderCrawler.format_duration(60)
        self.assertEqual(result, "1 MINUTE")

    def test_exact_hour(self):
        result = FolderCrawler.format_duration(3600)
        self.assertEqual(result, "1 HOUR")

    def test_exact_day(self):
        result = FolderCrawler.format_duration(86400)
        self.assertEqual(result, "1 DAY")

    def test_exact_year(self):
        result = FolderCrawler.format_duration(31536000)
        self.assertEqual(result, "1 YEAR")


class TestCompareSizes(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")

    def test_compare_sizes_greater_or_equal_true(self):
        result = self.crawler._compare_sizes(1024, "1025B", ">=")
        self.assertTrue(result)

    def test_compare_sizes_greater_or_equal_false(self):
        result = self.crawler._compare_sizes(1024, "1023B", ">=")
        self.assertFalse(result)

    def test_compare_sizes_less_or_equal_true(self):
        result = self.crawler._compare_sizes(1024, "1024B", "<=")
        self.assertTrue(result)

    def test_compare_sizes_less_or_equal_false(self):
        result = self.crawler._compare_sizes(1024, "1025B", "<=")
        self.assertFalse(result)

    def test_compare_sizes_greater_true(self):
        result = self.crawler._compare_sizes(1024, "1025B", ">")
        self.assertTrue(result)

    def test_compare_sizes_greater_false(self):
        result = self.crawler._compare_sizes(1024, "1024B", ">")
        self.assertFalse(result)

    def test_compare_sizes_less_true(self):
        result = self.crawler._compare_sizes(1024, "1023B", "<")
        self.assertTrue(result)

    def test_compare_sizes_less_false(self):
        result = self.crawler._compare_sizes(1024, "1024B", "<")
        self.assertFalse(result)

    def test_compare_sizes_equal_true(self):
        result = self.crawler._compare_sizes(1024, "1024B", "==")
        self.assertTrue(result)

    def test_compare_sizes_equal_false(self):
        result = self.crawler._compare_sizes(1024, "1025B", "==")
        self.assertFalse(result)

    def test_compare_sizes_not_equal_true(self):
        result = self.crawler._compare_sizes(1024, "1025B", "!=")
        self.assertTrue(result)

    def test_compare_sizes_not_equal_false(self):
        result = self.crawler._compare_sizes(1024, "1024B", "!=")
        self.assertFalse(result)

    def test_compare_sizes_invalid_sign(self):
        with self.assertRaises(AssertionError):
            self.crawler._compare_sizes(1024, "1025B", "invalid_sign")

    def test_compare_sizes_invalid_size_format(self):
        result = self.crawler._compare_sizes(1024, "None", ">=")
        self.assertFalse(result)

    def test_size_ends_with_new_line(self):
        self.assertTrue(self.crawler._compare_sizes(2000, "2000B\n", "=="))


class TestConvertBytesToReadableFormat(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")

    def test_convert_bytes(self):
        # Testing conversion to bytes without scaling
        result = self.crawler._convert_bytes_to_readable_format(512)
        self.assertEqual(result, "\033[0;31;40m512.00B")  # Assuming red color for bytes

    def test_convert_kilobytes(self):
        # Testing conversion to kilobytes
        result = self.crawler._convert_bytes_to_readable_format(1024)
        self.assertEqual(result, "\033[0;33;40m1.00KB")  # Assuming yellow color for KB

    def test_convert_megabytes(self):
        # Testing conversion to megabytes
        result = self.crawler._convert_bytes_to_readable_format(1024 ** 2)
        self.assertEqual(result, "\033[0;32;40m1.00MB")  # Assuming green color for MB

    def test_convert_gigabytes(self):
        # Testing conversion to gigabytes
        result = self.crawler._convert_bytes_to_readable_format(1024 ** 3)
        self.assertEqual(result, "\033[0;34;40m1.00GB")  # Assuming blue color for GB

    def test_convert_terabytes(self):
        # Testing conversion to terabytes
        result = self.crawler._convert_bytes_to_readable_format(1024 ** 4)
        self.assertEqual(result, "\033[0;36;40m1.00TB")  # Assuming cyan color for TB

    def test_convert_zero_bytes(self):
        # Testing conversion of zero bytes
        result = self.crawler._convert_bytes_to_readable_format(0)
        self.assertEqual(result, "\033[0;31;40m0.00B")  # Assuming red color for zero bytes

    def test_large_number(self):
        # Testing conversion of a very large number of bytes
        result = self.crawler._convert_bytes_to_readable_format(10 * 1024 ** 4)  # 10 TB
        self.assertEqual(result, "\033[0;36;40m10.00TB")  # Assuming cyan color for TB


class TestGetSize(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler._convert_bytes_to_readable_format = MagicMock(return_value="1.00KB")

    @patch('os.path.getsize')
    def test_get_size_file(self, mock_getsize):
        # Testing size calculation for a file
        mock_getsize.return_value = 1024
        readable_size, bytes_size = self.crawler._get_size("/test/file.txt", get_size_file=True)
        self.assertEqual(readable_size, "1.00KB")
        self.assertEqual(bytes_size, "1024B")

    @patch('os.path.getsize')
    @patch('os.walk')
    def test_get_size_folder(self, mock_os_walk, mock_getsize):
        # Testing size calculation for a folder
        mock_os_walk.return_value = [("/test/folder", ("subfolder",), ("file1.txt", "file2.txt"))]
        mock_getsize.side_effect = [512, 512]  # Each file is 512 bytes
        readable_size, bytes_size = self.crawler._get_size("/test/folder", get_size_folder=True)
        self.assertEqual(readable_size, "1.00KB")
        self.assertEqual(bytes_size, "1024B")

    @patch('os.path.getsize')
    def test_get_size_file_not_found(self, mock_getsize):
        # Testing file not found error
        mock_getsize.side_effect = FileNotFoundError
        readable_size, bytes_size = self.crawler._get_size("/test/nonexistent.txt", get_size_file=True)
        self.assertEqual(readable_size, self.crawler.NONE)
        self.assertEqual(bytes_size, self.crawler.NONE)
        self.assertEqual(self.crawler.skipped_items, 1)

# todo: this needs to be fixed
class TestReadOutSavedItems(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")

    @patch('builtins.open',
           new_callable=mock_open,
           read_data="path1, \033[0;31;40m1.00B, 1B"
                     "\npath2, None, None"
                     "\npath3, \033[0;31;40m1.00KB, 1024B"
           )
    @patch('os.path.join')
    def test_read_out_saved_items(self, mock_join, mock_file):
        mock_join.return_value = '/fake_directory/fake_file.txt'
        self.crawler.FILES = "files"
        self.crawler.FOLDERS = "folders"
        self.crawler.EXTENSION = ".txt"
        self.crawler.NONE = "None"
        self.crawler.SAVED_CRAWLS_FOLDER = "/fake_directory"
        self.crawler.ENCODING = "UTF-8"

        self.crawler._read_out_saved_items(self.crawler.FILES)

        expected_files = [
            ('path1', '\033[0;31;40m1.00B', '1B'),
            ('path2\n', 'None', 'None'),
            ('path3', '\033[0;31;40m1.00KB', '1024B')
        ]

        # Ensure the files list is populated correctly
        self.assertEqual(self.crawler.files, expected_files)

        # Test reading folders just to make sure switching works
        self.crawler._read_out_saved_items(self.crawler.FOLDERS)
        self.assertEqual(self.crawler.folders, expected_files)


class TestSaveCrawlResults(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler.SAVED_CRAWLS_FOLDER = "/saved_crawls"
        self.crawler.ENCODING = "UTF-8"

    @patch('os.path.exists')
    @patch('os.makedirs')
    @patch('os.remove')
    @patch('builtins.open', new_callable=mock_open)
    def test_save_crawl_results_new_folder(self, mock_file_open, mock_remove, mock_makedirs, mock_exists):
        # Setup mocks
        mock_exists.side_effect = [False, False]  # First for SAVED_CRAWLS_FOLDER, second for file path

        # Test data
        path = "/saved_crawls/results.txt"
        container = [('item1', '10 KB', '10240B'), ('item2', '20 KB', '20480B')]

        # Method invocation
        self.crawler._save_crawl_results(path, container)

        # Assertions
        mock_makedirs.assert_called_once_with("/saved_crawls")
        mock_remove.assert_not_called()
        mock_file_open.assert_called_once_with(path, 'a', encoding="UTF-8")
        mock_file_open().write.assert_any_call("item1, 10 KB, 10240B\n")
        mock_file_open().write.assert_any_call("item2, 20 KB, 20480B\n")

    @patch('os.path.exists')
    @patch('os.makedirs')
    @patch('os.remove')
    @patch('builtins.open', new_callable=mock_open)
    def test_save_crawl_results_existing_folder_file(self, mock_file_open, mock_remove, mock_makedirs, mock_exists):
        # Setup mocks
        mock_exists.side_effect = [True, True]  # First for SAVED_CRAWLS_FOLDER, second for file path

        # Test data
        path = "/saved_crawls/results.txt"
        container = [('item1', '30 KB', '30720B')]

        # Method invocation
        self.crawler._save_crawl_results(path, container)

        # Assertions
        mock_makedirs.assert_not_called()
        mock_remove.assert_called_once_with(path)
        mock_file_open.assert_called_once_with(path, 'a', encoding="UTF-8")
        mock_file_open().write.assert_called_once_with("item1, 30 KB, 30720B\n")

class TestShowTime(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler.PRINT_ENDING = "\n---\n"
        self.crawler.WHOLE_PROCES_TOOK_MSG = "The whole process took:"

    @patch('builtins.print')
    @patch('time.perf_counter')
    def test_show_time_seconds(self, mock_perf_counter, mock_print):
        # Setting initial timer to simulate elapsed time
        self.crawler.timer = 1000
        mock_perf_counter.return_value = 1010  # Simulate 10 seconds have passed

        # Mocking the format_duration to simply return the number of seconds passed for simplicity
        self.crawler.format_duration = MagicMock(return_value="10 seconds")

        # Execute the method
        self.crawler._show_time()

        # Check print was called correctly
        mock_print.assert_called_once_with(self.crawler.WHOLE_PROCES_TOOK_MSG, "10 seconds", end=self.crawler.PRINT_ENDING)

    @patch('builtins.print')
    @patch('time.perf_counter')
    def test_show_time_minutes(self, mock_perf_counter, mock_print):
        self.crawler.timer = 1000
        mock_perf_counter.return_value = 1060  # Simulate 60 seconds have passed

        # Mocking the format_duration to simply return the formatted string
        self.crawler.format_duration = MagicMock(return_value="1 minute")

        # Execute the method
        self.crawler._show_time()

        # Check print was called correctly
        mock_print.assert_called_once_with(self.crawler.WHOLE_PROCES_TOOK_MSG, "1 minute", end=self.crawler.PRINT_ENDING)


class TestCrawlItemNamesAndSizesWithoutGoingDeeper(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler.files = []
        self.crawler.folders = []

    @patch('os.listdir')
    @patch('os.path.join', side_effect=lambda x, y: f"{x}/{y}")
    @patch('os.path.isdir')
    def test_crawl_without_going_deeper(self, mock_isdir, mock_join, mock_listdir):
        # Mocking directory contents
        mock_listdir.return_value = ['file1.txt', 'folder1']
        mock_isdir.side_effect = [False, True]  # First item is a file, second is a folder

        # Mocking size retrieval
        self.crawler._get_size = MagicMock(side_effect=[('1 KB', '1024B'), ('10 KB', '10240B')])

        # Execute the method
        self.crawler._crawl_item_names_and_sizes_without_going_deeper()

        # Check results
        expected_files = [('/test/path/file1.txt', '1 KB', '1024B')]
        expected_folders = [('/test/path/folder1', '10 KB', '10240B')]
        self.assertEqual(self.crawler.files, expected_files)
        self.assertEqual(self.crawler.folders, expected_folders)


class TestCrawlItemNamesAndSizesGoDeep(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler.files = []
        self.crawler.folders = []

    @patch('os.walk')
    @patch('os.path.join', side_effect=lambda x, y: f"{x}/{y}")
    def test_deep_crawl(self, mock_join, mock_walk):
        # Setup the mock data for os.walk
        mock_walk.return_value = [
            ('/test/path', ['folder1'], ['file1.txt']),
            ('/test/path/folder1', [], ['file2.txt'])
        ]

        # Mock the _get_size method to return a tuple (readable size, total size)
        self.crawler._get_size = MagicMock(side_effect=[
            ('1 KB', '1024B'),  # size for file1.txt
            ('2 KB', '2048B'),  # size for file2.txt
            ('2 KB', '2048B'),  # size for folder1
        ])

        # Execute the method
        self.crawler._crawl_item_names_and_sizes_go_deep()

        # Expected results
        expected_files = [
            ('/test/path/file1.txt', '1 KB', '1024B'),
            ('/test/path/folder1/file2.txt', '2 KB', '2048B')
        ]
        expected_folders = [
            ('/test/path/folder1', '2 KB', '2048B')
        ]

        # Assertions
        self.assertEqual(self.crawler.files, expected_files)
        self.assertEqual(self.crawler.folders, expected_folders)

    @patch('os.walk')
    @patch('os.path.join', side_effect=lambda x, y: f"{x}/{y}")
    def test_empty_directory(self, mock_join, mock_walk):
        # Test with an empty directory
        mock_walk.return_value = [
            ('/test/path', [], [])
        ]
        # No sizes to mock since there are no files or folders
        self.crawler._get_size = MagicMock(return_value=('0 B', '0B'))

        # Execute the method
        self.crawler._crawl_item_names_and_sizes_go_deep()

        # Assertions for empty results
        self.assertEqual(self.crawler.files, [])
        self.assertEqual(self.crawler.folders, [])

class TestPrintContainer(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("/test/path")
        self.crawler.NR_OF_LISTED_ITEMS_MSG = "Number of listed items"
        self.crawler.PRINT_ENDING = "\n---\n"

    @patch('builtins.print')
    def test_print_container_with_sizes(self, mock_print):
        # Setup
        self.crawler.files = [("file1.txt", "10 KB", "10240B")]
        container = self.crawler.files
        item_type = "files"

        # Invoke
        self.crawler._print_container(container=container, working_with_sizes=True)

        # Assert
        mock_print.assert_any_call("file1.txt", "10 KB", "10240B", "\033[0m")
        mock_print.assert_any_call(self.crawler.NR_OF_LISTED_ITEMS_MSG, f"{item_type.upper()}:", 1, end=self.crawler.PRINT_ENDING)

    @patch('builtins.print')
    def test_print_container_without_sizes(self, mock_print):
        # Setup
        self.crawler.folders = [("folder1", "100 KB", "102400B")]
        container = self.crawler.folders
        item_type = "folders"

        # Invoke
        self.crawler._print_container(container=container, working_with_sizes=False)

        # Assert
        mock_print.assert_any_call("folder1")
        mock_print.assert_any_call(self.crawler.NR_OF_LISTED_ITEMS_MSG, f"{item_type.upper()}:", 1, end=self.crawler.PRINT_ENDING)

    @patch('builtins.print')
    def test_print_container_with_filters(self, mock_print):
        # Setup
        self.crawler.files = [("file1.txt", "10 KB", "10240B"), ("file2.txt", "5 KB", "5120B")]
        container = self.crawler.files
        self.crawler._compare_sizes = MagicMock(return_value=True)

        # Invoke
        self.crawler._print_container(container=container, working_with_sizes=True, filter_path="file1", filter_size=10240, sign=">=")

        # Assert
        mock_print.assert_any_call("file1.txt", "10 KB", "10240B", "\033[0m")
        mock_print.assert_called_with(self.crawler.NR_OF_LISTED_ITEMS_MSG, "FILES:", 1, end=self.crawler.PRINT_ENDING)

    # @patch('builtins.print')
    # @patch('your_module_name.FolderCrawler._read_out_saved_items')
    # def test_read_from_saved_files(self, mock_read_out_saved_items, mock_print):
    #     # Setup to simulate no items loaded yet
    #     self.crawler.files = []
    #
    #     # Invoke with read from saved files enabled
    #     self.crawler._print_container(container=self.crawler.files, read_out_saved_files=True)
    #
    #     # Assert
    #     mock_read_out_saved_items.assert_called_once()

if __name__ == '__main__':
    unittest.main()
