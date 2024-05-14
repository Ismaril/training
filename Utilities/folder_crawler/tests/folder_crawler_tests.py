import unittest
from unittest.mock import patch, mock_open

from Utilities.folder_crawler.folder_crawler import FolderCrawler


class TestFolderCrawlerWithoutDeep(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler('test_folder')

    def test_crawl_without_going_deeper_files(self):
        self.crawler._crawl_item_names_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.files), 3)

    def test_crawl_without_going_deeper_folders(self):
        self.crawler._crawl_item_names_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.folders), 1)

    def test_crawl_without_going_deeper_empty_folder(self):
        self.crawler = FolderCrawler('empty_test_folder')
        self.crawler._crawl_item_names_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.files), 0)
        self.assertEqual(len(self.crawler.folders), 0)

    def test_crawl_without_going_deeper_non_existent_folder(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler = FolderCrawler('non_existent_folder')
            self.crawler._crawl_item_names_and_sizes_without_going_deeper()


class TestFolderCrawlerGoDeep(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler('test_folder')

    def test_crawl_go_deep_files(self):
        self.crawler._crawl_item_names_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.files), 4)

    def test_crawl_go_deep_folders(self):
        self.crawler._crawl_item_names_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.folders), 2)

    def test_crawl_go_deep_empty_folder(self):
        self.crawler = FolderCrawler('empty_test_folder')
        self.crawler._crawl_item_names_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.files), 0)
        self.assertEqual(len(self.crawler.folders), 0)

    def test_crawl_go_deep_non_existent_folder(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler = FolderCrawler('non_existent_folder')
            self.crawler._crawl_item_names_and_sizes_go_deep()


class TestFolderCrawlerGetSize(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler('test_folder')

    def test_get_size_file(self):
        size = self.crawler._get_size('test_folder/file1.txt', get_size_file=True)
        self.assertEqual(size, '\033[0;31;40m4.00B, 4B')

    def test_get_size_empty_file(self):
        size = self.crawler._get_size('test_folder/empty_file.txt', get_size_file=True)
        self.assertEqual(size, '\033[0;31;40m0.00B, 0B')

    def test_get_size_folder(self):
        size = self.crawler._get_size('test_folder', get_size_folder=True)
        self.assertEqual(size, '\033[0;33;40m3.10KB, 3174B')

    def test_get_size_empty_folder(self):
        size = self.crawler._get_size('empty_test_folder', get_size_folder=True)
        self.assertEqual(size, '\033[0;31;40m0.00B, 0B')


class TestFolderCrawlerConvertSize(unittest.TestCase):

    def setUp(self):
        self.crawler = FolderCrawler("test_folder")

    def test_convert_size_bytes(self):
        size = 500  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;31;40m500.00B")

    def test_convert_size_kilobytes(self):
        size = 1024 * 1.5  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;33;40m1.50KB")

    def test_convert_size_megabytes(self):
        size = 1024 * 1024 * 2.5  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;32;40m2.50MB")

    def test_convert_size_gigabytes(self):
        size = 1024 * 1024 * 1024 * 3.5  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;34;40m3.50GB")

    def test_convert_size_terabytes(self):
        size = 1024 * 1024 * 1024 * 1024 * 4.5  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;36;40m4.50TB")

    def test_convert_size_zero(self):
        size = 0  # size in bytes
        result = self.crawler._convert_bytes_to_readable_format(size)
        self.assertEqual(result, "\033[0;31;40m0.00B")


class TestFolderCrawlerSizeComparison(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("test_folder")

    def test_sizes_are_equal(self):
        self.assertTrue(self.crawler._compare_sizes(2000, "1, 2000B", "=="))

    def test_sizes_are_not_equal(self):
        self.assertTrue(self.crawler._compare_sizes(1000, "1, 2000B", "!="))

    def test_size_is_greater_than(self):
        self.assertTrue(self.crawler._compare_sizes(1000, "1, 2000B", ">"))

    def test_size_is_less_than(self):
        self.assertTrue(self.crawler._compare_sizes(3000, "1, 2000B", "<"))

    def test_size_is_greater_than_or_equal(self):
        self.assertTrue(self.crawler._compare_sizes(1000, "1, 2000B", ">="))

    def test_size_is_less_than_or_equal(self):
        self.assertTrue(self.crawler._compare_sizes(3000, "1, 2000B", "<="))

    def test_invalid_comparison_sign_raises_error(self):
        with self.assertRaises(AssertionError):
            self.crawler._compare_sizes(1000, "1, 2000B", "invalid")


class TestFolderCrawlerReadSavedItems(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("test_folder")

    @patch("builtins.open", new_callable=mock_open, read_data="path,1,2000B\n")
    def test_reading_saved_files_works_correctly(self, mock_file):
        self.crawler._read_out_saved_items(FolderCrawler.FILES)
        self.assertEqual(self.crawler.files, [("path", "1,2000B")])

    @patch("builtins.open", new_callable=mock_open, read_data="path,1,2000B\n")
    def test_reading_saved_folders_works_correctly(self, mock_file):
        self.crawler._read_out_saved_items(FolderCrawler.FOLDERS)
        self.assertEqual(self.crawler.folders, [("path", "1,2000B")])

    @patch("builtins.open", new_callable=mock_open, read_data="path,1,2000B\npath2,2,4000B\n")
    def test_multiple_saved_items_are_read_correctly(self, mock_file):
        self.crawler._read_out_saved_items(FolderCrawler.FILES)
        self.assertEqual(self.crawler.files, [("path", "1,2000B"), ("path2", "2,4000B")])

    @patch("builtins.open", new_callable=mock_open, read_data="")
    def test_no_saved_items_results_in_empty_list(self, mock_file):
        self.crawler._read_out_saved_items(FolderCrawler.FILES)
        self.assertEqual(self.crawler.files, [])


class TestFolderCrawlerSaveResults(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler("test_folder")

    @patch("os.path.exists", return_value=False)
    @patch("os.makedirs")
    @patch("os.remove")
    @patch("builtins.open", new_callable=mock_open)
    def test_saving_results_creates_directory_if_not_exists(self, mock_file, mock_remove, mock_makedirs, mock_exists):
        self.crawler._save_crawl_results()
        mock_makedirs.assert_called_once_with(self.crawler.SAVED_CRAWLS_FOLDER)

    @patch("os.path.exists", return_value=True)
    @patch("os.remove")
    @patch("builtins.open", new_callable=mock_open)
    def test_saving_results_removes_old_files(self, mock_file, mock_remove, mock_exists):
        self.crawler._save_crawl_results()
        mock_remove.assert_any_call(self.crawler.PATH_TO_SAVED_FILES)
        mock_remove.assert_any_call(self.crawler.PATH_TO_SAVED_FOLDERS)

    @patch("os.path.exists", return_value=True)
    @patch("os.remove")
    @patch("builtins.open", new_callable=mock_open)
    def test_saving_results_writes_files_and_folders(self, mock_file, mock_remove, mock_exists):
        self.crawler.files = [("file1", "1,2000B"), ("file2", "2,4000B")]
        self.crawler.folders = [("folder1", "1,2000B"), ("folder2", "2,4000B")]
        self.crawler._save_crawl_results()
        mock_file().write.assert_any_call("file1,1,2000B\n")
        mock_file().write.assert_any_call("file2,2,4000B\n")
        mock_file().write.assert_any_call("folder1,1,2000B\n")
        mock_file().write.assert_any_call("folder2,2,4000B\n")


if __name__ == '__main__':
    unittest.main()
