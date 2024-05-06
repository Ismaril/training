import unittest
from Utilities.folder_crawler.folder_crawler import FolderCrawler


class TestFolderCrawlerWithoutDeep(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler('test_folder')

    def test_crawl_without_going_deeper_files(self):
        self.crawler._crawl_items_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.files), 3)

    def test_crawl_without_going_deeper_folders(self):
        self.crawler._crawl_items_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.folders), 1)

    def test_crawl_without_going_deeper_empty_folder(self):
        self.crawler = FolderCrawler('empty_test_folder')
        self.crawler._crawl_items_and_sizes_without_going_deeper()
        self.assertEqual(len(self.crawler.files), 0)
        self.assertEqual(len(self.crawler.folders), 0)

    def test_crawl_without_going_deeper_non_existent_folder(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler = FolderCrawler('non_existent_folder')
            self.crawler._crawl_items_and_sizes_without_going_deeper()


class TestFolderCrawlerGoDeep(unittest.TestCase):
    def setUp(self):
        self.crawler = FolderCrawler('test_folder')

    def test_crawl_go_deep_files(self):
        self.crawler._crawl_items_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.files), 4)

    def test_crawl_go_deep_folders(self):
        self.crawler._crawl_items_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.folders), 2)

    def test_crawl_go_deep_empty_folder(self):
        self.crawler = FolderCrawler('empty_test_folder')
        self.crawler._crawl_items_and_sizes_go_deep()
        self.assertEqual(len(self.crawler.files), 0)
        self.assertEqual(len(self.crawler.folders), 0)

    def test_crawl_go_deep_non_existent_folder(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler = FolderCrawler('non_existent_folder')
            self.crawler._crawl_items_and_sizes_go_deep()


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

    def test_get_size_non_existent_file(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler._get_size('test_folder/non_existent_file.txt', get_size_file=True)

    def test_get_size_non_existent_folder(self):
        with self.assertRaises(FileNotFoundError):
            self.crawler._get_size('non_existent_folder', get_size_folder=True)


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


if __name__ == '__main__':
    unittest.main()
