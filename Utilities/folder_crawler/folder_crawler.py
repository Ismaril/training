import datetime
import os
import sys
import time
import pandas as pd
import numpy as np

from tabulate import tabulate
from structures import ItemType, SavedCrawls, ExceptionMessage, Messages, FileOps, EqualitySign
from multiprocessing import Pool


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its sub-folders and prints the paths with sizes.
    """
    # region Constants

    NONE = np.nan
    DEFAULT_COLOR = "\033[0m"
    COLUMN_NAMES = ["Path", "Changed", "Size readable", "Size bytes"]
    INITIAL_DATAFRAME = {"Path": [],
                         "Changed": [],
                         "Size readable": [],
                         "Size bytes": []
                         }

    # endregion

    # region Constructor
    def __init__(self, path: str, crawl_deep: bool):
        """
        This is the constructor method for the FolderCrawler class.

        :param path: The path of the folder that needs to be crawled.
        """

        self.path = path
        self.crawl_deep = crawl_deep
        self.files = pd.DataFrame(self.INITIAL_DATAFRAME)
        self.folders = pd.DataFrame(self.INITIAL_DATAFRAME)
        self.skipped = pd.DataFrame(self.INITIAL_DATAFRAME)
        self.timer = time.perf_counter()  # start the timer

    # endregion

    # region Public Methods
    def crawl(self):
        """
        This method decides whether to perform a deep crawl or a shallow crawl based on the crawl_deep parameter.
        This means that the crawler will either stay in inputted folder or go deeper into the sub-folders.
        The result will be extracted either file of folder. Both of them will also contain its size.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl. Default is False.

        :return: None
        """
        self._initialize_files()

        if self.crawl_deep:
            self._crawl_items(go_deep=True)
        else:
            self._crawl_items(go_deep=False)

        self._prepare_skipped_items()
        self._save_file_or_folder(path=SavedCrawls.FILES, container=self.files, item_type=ItemType.FILES)
        self._save_file_or_folder(path=SavedCrawls.FOLDERS, container=self.folders, item_type=ItemType.FOLDERS)
        self._save_file_or_folder(path=SavedCrawls.SKIPPED, container=self.skipped, item_type=ItemType.SKIPPED)

    def print_items(self, print_folders=True, print_files=True, print_skipped_items=True,
                    filter_path="", filter_sign=">=", filter_size=0):
        """
        This method is used to print the files and folders that were found during the crawling process.
        It also prints the number of files and folders that were listed.
        The method can be customized to print only files, only folders, or both.
        It can also filter the files and folders based on text and size.
        At the end of the method, it calls the _show_time method to print the time taken for the crawling process.

        :param print_folders: A boolean value that determines whether to print the folders or not. Default is True.
        :param print_files: A boolean value that determines whether to print the files or not. Default is True.
        :param filter_path: A string value that is used to filter the files and folders. Default is an empty string.
        :param filter_sign: A string value that is used to compare the sizes of the files and folders. Default is ">=".
        :param filter_size: An integer value that is used to filter the files and folders based on their sizes. Default is 0.
        :param print_sizes: A boolean value that determines whether to work with sizes or not. Default is False.
        :param read_out_saved_files: A boolean value that determines whether to read out the saved files and folders from the txt files. Default is False.

        :returns: None
        """

        if print_files:
            self._print_container(filter_path, filter_size, filter_sign,
                                  item_type=ItemType.FILES, container=self.files)
        if print_folders:
            self._print_container(filter_path, filter_size, filter_sign,
                                  item_type=ItemType.FOLDERS, container=self.folders)
        if print_skipped_items:
            self._print_container(filter_path, filter_size, filter_sign,
                                  item_type=ItemType.SKIPPED, container=self.skipped)

        self._show_time()

    def read_content_of_file(self, path: str, filter_: str = "", print_=True):
        """
        This function reads the content of a file and prints the lines that contain the filter string.

        :param path: The path of the file that needs to be read.
        :param filter_: Filter string that filters out the lines.
        :return: None
        """

        array_ = []

        with open(path, FileOps.READ_MODE, encoding=FileOps.ENCODING) as file:
            for line in file:
                if filter_ in line:
                    if print_:
                        print(line.strip())
                    array_.append(line.strip())

        return array_

    def compare_saved_crawls(self, path1: str, path2: str, print_=True):
        set1 = set(self.read_content_of_file(path1, print_=False))
        set2 = set(self.read_content_of_file(path2, print_=False))

        array_difference = list(set1.symmetric_difference(set2))

        # Optionally print the differences
        if print_:
            for item in array_difference:
                print(item)

        return array_difference

    # endregion

    # region Private Methods

    def _prepare_skipped_items(self):
        nan_files = self.files[self.files["Size bytes"].isna()]
        nan_folders = self.folders[self.folders["Size bytes"].isna()]

        self.files = self.files[~self.files["Size bytes"].isna()].copy()
        self.folders = self.folders[~self.folders["Size bytes"].isna()].copy()

        self.skipped = pd.concat([nan_files, nan_folders], ignore_index=True)
        print(self._get_current_time(), "Preparation of dataframe is done:", ItemType.SKIPPED.upper())

    @staticmethod
    def _arguments(*args):
        return args

    def _process_item(self, path_tuple):
        path, is_file = path_tuple
        item_path = os.path.join(self.path, path) if self.path not in path else path
        is_folder = not is_file
        last_change = self._get_last_change_of_item(item_path)
        size_readable, size_total = self._get_size(item_path, get_size_folder=is_folder)

        return self._arguments(item_path, last_change, size_readable, size_total), is_folder

    def _crawl_items(self, go_deep=False):
        """
        Crawls through the folder at the given path, with the option to go deeper into subdirectories,
        using multiprocessing to calculate the sizes of files and folders.
        """
        if go_deep:
            print(self._get_current_time(), Messages.DEEP_CRAWL)
            paths = self._crawl_deep()
        else:
            print(self._get_current_time(), Messages.SHALLOW_CRAWL)
            paths = self._crawl_shallow()

        # Use multiprocessing Pool to handle item processing
        print(self._get_current_time(), "Starting multiprocessing pool.")
        with Pool() as pool:
            results = pool.map(self._process_item, paths)

        print(self._get_current_time(), "Preparing dataframes.")
        dataframe = pd.DataFrame(results)

        # todo: perhpas create a method for this
        for is_folder in [False, True]:
            items = dataframe[dataframe[1] == is_folder].copy()
            items = items.drop(columns=1)
            unpacked = items[0].apply(pd.Series)
            unpacked.columns = self.COLUMN_NAMES
            if is_folder:
                self.folders = pd.DataFrame(unpacked)
                print(self._get_current_time(), "Preparation of dataframe is done:", ItemType.FOLDERS.upper())
            else:
                self.files = pd.DataFrame(unpacked)
                print(self._get_current_time(), "Preparation of dataframe is done:", ItemType.FILES.upper())

    def _get_current_time(self):
        return datetime.datetime.now()

    def _crawl_shallow(self):
        result = []
        items = os.listdir(self.path)
        for item in items:
            item_path = os.path.join(self.path, item)
            is_folder = os.path.isdir(item_path)
            result.append((item_path, not is_folder))
        return result

    def _crawl_deep(self):
        result = []
        for root, folders, files in os.walk(self.path):
            for file in files:
                file_path = os.path.join(root, file)
                result.append((file_path, True))
            for folder in folders:
                folder_path = os.path.join(root, folder)
                result.append((folder_path, False))
        return result

    def _initialize_files(self):
        """ Ensure all necessary directories and files are created. """

        os.makedirs(SavedCrawls.SAVED_CRAWLS_FOLDER, exist_ok=True)

        for txt_file in (SavedCrawls.FILES, SavedCrawls.FOLDERS, SavedCrawls.SKIPPED):
            # Create empty txt files if they don't exist or just append empty string if they do exist
            open(txt_file, FileOps.APPEND_MODE, encoding=FileOps.ENCODING).close()

    # todo: rename this method to _save_crawl_results
    def _save_file_or_folder(self, path: str, container: pd.DataFrame, item_type: str):
        # This first if statement is used to save the files and folders (list container)
        # These containers are saved once the arrays are completely filled with the crawled data.
        if isinstance(container, pd.DataFrame):
            print(self._get_current_time(), f"Saving {item_type.upper()} into txt file.")
            if os.path.exists(path):
                os.remove(path)
            container.to_csv(path, index=False)
            print(self._get_current_time(), f"Saving {item_type.upper()} done")

    def _read_out_saved_items(self, item_type: str):
        """
        This private method is used to read out the saved files and folders from the txt files and store them in the respective lists.

        :param item_type: A string value that determines whether to read out the files or the folders. "files" or "folders".
        :return:
        """
        item_path = os.path.join(SavedCrawls.SAVED_CRAWLS_FOLDER, f"{item_type}{SavedCrawls.EXTENSION}")

        if item_type is ItemType.FILES:
            self.files = pd.read_csv(item_path)
        elif item_type is ItemType.FOLDERS:
            self.folders = pd.read_csv(item_path)
        elif item_type is ItemType.SKIPPED:
            self.skipped = pd.read_csv(item_path)

    def _get_size(self, path: str, get_size_folder: bool):
        """
        Calculate the size of a file or a folder. If get_size_folder is True, it calculates
        the size of the folder at the given path by summing the sizes of all files in the
        folder and its subfolders. Otherwise, it calculates the size of the file.
        The size is returned as a string in a human-readable format and in bytes.

        :param path: The path of the file or folder whose size needs to be calculated.
        :param get_size_folder: Boolean indicating whether the size of a folder (True) or
                                file (False) should be calculated.
        :return: A tuple containing the size in a readable format and the size in bytes.
        """
        size_bytes = 0
        try:
            if get_size_folder:
                for root, _, files in os.walk(path):
                    for file in files:
                        file_path = os.path.join(root, file)
                        size_bytes += os.path.getsize(file_path)
            else:
                size_bytes = os.path.getsize(path)
        except FileNotFoundError:
            return self.NONE, self.NONE

        color, size_readable = self._convert_bytes_to_readable_format(size_bytes)
        size_readable = color + size_readable + self.DEFAULT_COLOR
        size_bytes = f"{color} {str(size_bytes)} {self.DEFAULT_COLOR}"

        return size_readable, size_bytes

    def _convert_bytes_to_readable_format(self, size: int | float):
        """
        This private method is used to convert the size from bytes to a more readable format.
        The size is converted to the highest unit that is less than 1024.
        The units used are Bytes (B), Kilobytes (KB), Megabytes (MB), Gigabytes (GB), and Terabytes (TB).
        The method also changes the color of the "size" string based on the unit.
        The colors used are red for B, yellow for KB, green for MB, blue for GB, and cyan for TB.
        The size is returned as a string with the color formatting and the unit.

        :param size: The size in bytes that needs to be converted.
        :return: A string that represents the size in a more readable format with color formatting and the unit.
        """

        UNITS = ["B", "KB", "MB", "GB", "TB"]
        COLORS = (31, 33, 32, 34, 36)

        for color, unit in zip(COLORS, UNITS):
            if size < 1024:
                return f"\033[0;{color};40m", f"{size:.2f} {unit}"
            size /= 1024

    def _check_if_necessary_to_read_out_saved_files(self, container: pd.DataFrame, item_type: str):
        # This will read out saved files if no crawling was done in current run of a program.
        if container.empty:
            if container is ItemType.SKIPPED and os.path.getsize(SavedCrawls.SKIPPED) == 0:
                return
            self._read_out_saved_items(item_type)

    def _print_crawl_summary(self, total_size: int, print_total_size: bool):

        if print_total_size:
            color, size_readable = self._convert_bytes_to_readable_format(total_size)
            # todo: perhaps create a method for this, I gues it is used in multiple places
            size_readable = color + size_readable + self.DEFAULT_COLOR
            total_size = color + str(total_size) + self.DEFAULT_COLOR + " bytes"

            print(Messages.NR_OF_DATA_CRAWLED, size_readable, total_size, end="\n\n")

    def _print_container(self, filter_path="", filter_size=0, sign=">=",
                         item_type: str = None, container=None):
        """
        This private method is used to print the folder or file paths that were found during the crawling process, based
        on the container parameter.
        It also prints the total number of folders/files that were listed.
        The method can be customized to filter the folders/files based on the filter_ parameter.

        :param default_color: A string value that represents the default color for the console output.
        :param filter_path: A string value that is used to filter the folders/files. Default is an empty string, meaning no filter.

        :return: None
        """

        self._check_if_necessary_to_read_out_saved_files(container, item_type)

        if item_type is ItemType.FILES:
            self._print_file_or_folder(self.files, filter_path, filter_size, item_type, sign)
        elif item_type is ItemType.FOLDERS:
            self._print_file_or_folder(self.folders, filter_path, filter_size, item_type, sign)
        elif item_type is ItemType.SKIPPED:
            self._print_skipped_items(self.skipped)

    def _print_skipped_items(self, container):
        container = self._filter_subdirectories(items=container)
        print(tabulate(container, headers='keys', tablefmt='psql'))

    def _print_file_or_folder(self, container: pd.DataFrame, filter_path: str, filter_size: int, item_type: str,
                              sign: str):
        print_total_size = not (self.crawl_deep and item_type == ItemType.FOLDERS)

        # In the column Size bytes, split the string and get the second element which is the size in bytes. The
        # positions before and after are the color formatting.
        split = container["Size bytes"].str.split(" ").str[1]
        sum_of_bytes = split.astype(np.int64).sum()
        print(tabulate(container, headers='keys', tablefmt='psql'))
        self._print_crawl_summary(sum_of_bytes, print_total_size)

    def _show_time(self):
        """
        This private method is used to calculate the time since initialization of class till the print of the files and folders.

        :return: None
        """
        print(Messages.WHOLE_PROCES_TOOK,
              self._format_duration(time.perf_counter() - self.timer),
              end=Messages.PRINT_ENDING)

    @staticmethod
    def _format_duration(seconds):
        SEC_PER_YEAR = 31536000  # 365*24*60*60
        SEC_PER_DAY = 86400  # 24*60*60
        SEC_PER_HR = 3600  # 60*60
        SEC_PER_MIN = 60

        years, seconds = divmod(seconds, SEC_PER_YEAR)
        days, seconds = divmod(seconds, SEC_PER_DAY)
        hours, seconds = divmod(seconds, SEC_PER_HR)
        minutes, seconds = divmod(seconds, SEC_PER_MIN)

        years = f"{years:.0f} Years, " if years > 0 else ""
        days = f"{days:.0f} Days, " if days > 0 else ""
        hours = f"{hours:.0f} Hours, " if hours > 0 else ""
        minutes = f"{minutes:.0f} Minutes, " if minutes > 0 else ""
        seconds = f"{seconds:.4f} Seconds" if seconds > 0 else ""

        return years + days + hours + minutes + seconds

    def _get_last_change_of_item(self, path: str):
        """
        This private method is used to get the last change of a file.

        :param path: The path of the file whose last change needs to be calculated.
        :return: The last change of the file.
        """
        try:
            return datetime.datetime.fromtimestamp(os.path.getmtime(path))
        except FileNotFoundError:
            return self.NONE

    @staticmethod
    def _filter_subdirectories(items):
        # This method filters out subdirectories from the list of skipped items

        # Sort paths to ensure that shorter paths come before their potential subdirectories
        paths = items.sort_values(by="Path", ascending=True)
        paths_list = paths["Path"].tolist().copy()
        for i, path in enumerate(paths_list):
            for paths_rest in paths_list[i + 1:]:
                if path in paths_rest:
                    paths.drop(paths[paths["Path"] == path].index, inplace=True)

        return paths

    # endregion

    # todo: check all the tests, they were written by AI
    # todo: check documentation
    # todo: create a interface executable from the command line
    # todo: create a readout option with filter across multiple files


########################################################################################################################
# HOW TO CRAWL AND PRINT ITEMS:
# Start with specifying the path of the folder you want to crawl in ctor. Then chose if you want to crawl deep or not.
# Call method crawl.
# Call method print_items with parameters you want to print. You can also filter the output.
# In case you performed time-consuming crawl already, comment out the crawl method and just call print_items method.
#   The previous crawl will be instantly read out from the saved txt files.


# HOW TO READ OUT SAVED FILES:
# Call method read_content_of_file with the path of the file you want to read out.


# HOW TO COMPARE SAVED CRAWLS:
# Perform a crawl in a first desired folder and then rename the output txt file in saved_crawls folder.
# Perform a crawl in a second desired folder.
# Call method compare_saved_crawls with the paths of the two files you want to compare.
# The method will return the difference between the two files.


# PERFORMANCE:
# For you info, you can also crawl complete disk. With multiprocessing implemented in this code, it will be quite fast.
# 4.57 GHz 8Core utilised therefore at 100% will crawl and save all paths from 715GB in 3 minutes.
########################################################################################################################
if __name__ == '__main__':
    cr = FolderCrawler(path=r"C:\Users\lazni\Downloads", crawl_deep=False)
    # cr = FolderCrawler(path=r"C:\\", crawl_deep=True)
    cr.crawl()
    cr.print_items(True, True, True, filter_path="", filter_sign=">=", filter_size=0)
