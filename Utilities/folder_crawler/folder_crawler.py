import datetime
import os
import time

from structures import ItemType, SavedCrawls, ExceptionMessage, Messages, FileOps, EqualitySign
from multiprocessing import Pool


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its sub-folders and prints the paths with sizes.
    """
    # region Constants

    NONE = "None"
    DEFAULT_COLOR = "\033[0m"

    # endregion

    # region Constructor
    def __init__(self, path: str, crawl_deep: bool):
        """
        This is the constructor method for the FolderCrawler class.

        :param path: The path of the folder that needs to be crawled.
        """
        self.path = path
        self.crawl_deep = crawl_deep
        self.files = []
        self.folders = []
        self.skipped = []
        self.skipped_items = 0
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
        self._log_crawling_state(data_to_write=Messages.STARTED_CRAWLING)

        if self.crawl_deep:
            print(Messages.DEEP_CRAWL)
            self._crawl_items(go_deep=True)
        else:
            print(Messages.SHALLOW_CRAWL)
            self._crawl_items(go_deep=False)

        print(Messages.SAVING_RESULTS, end=Messages.PRINT_ENDING)
        self._save_crawl_results(path=SavedCrawls.FILES, container=self.files)
        self._save_crawl_results(path=SavedCrawls.FOLDERS, container=self.folders)
        self._clear_file()
        self._log_crawling_state(data_to_write=Messages.DONE_CRAWLING)

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

    @staticmethod
    def _log_crawling_state(data_to_write: str):
        with open(SavedCrawls.PARAMETERS, FileOps.WRITE_MODE) as f:
            f.write(data_to_write)

    def _process_item(self, path_tuple):
        path, is_file = path_tuple
        item_path = os.path.join(self.path, path) if self.path not in path else path
        is_folder = not is_file
        last_change = self._get_last_change_of_item(item_path)
        size_readable, size_total = self._get_size(item_path, get_size_folder=is_folder)

        return item_path, last_change, size_readable, size_total, is_folder

    def _crawl_items(self, go_deep=False):
        """
        Crawls through the folder at the given path, with the option to go deeper into subdirectories,
        using multiprocessing to calculate the sizes of files and folders.
        """
        if go_deep:
            paths = self._crawl_deep()
        else:
            paths = self._crawl_shallow()

        # Use multiprocessing Pool to handle item processing
        with Pool() as pool:
            results = pool.map(self._process_item, paths)

        # Append results to appropriate lists
        for result in results:
            item_path, last_change, size_readable, size_total, is_folder = result
            if is_folder:
                self.folders.append((item_path, last_change, size_readable, size_total))
            else:
                self.files.append((item_path, last_change, size_readable, size_total))

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

        for txt_file in (SavedCrawls.FILES, SavedCrawls.FOLDERS,
                         SavedCrawls.SKIPPED, SavedCrawls.PARAMETERS):
            # Create empty txt files if they don't exist or just append empty string if they do exist
            open(txt_file, FileOps.APPEND_MODE, encoding=FileOps.ENCODING).close()

    def _save_crawl_results(self, path: str, container: list | str):
        """
        This private method is used to save the crawled files and folders into txt files.

        :param path: The path of the txt file where the files or folders need to be saved.
        :param container: The list of files or folders that need to be saved.

        :return: None
        """

        self._save_file_or_folder(path, container)
        self._save_skipped_items(path, container)

    def _save_skipped_items(self, path: str, container: str):
        # This second if statement is used to save the skipped items (string container)
        # This string container is saved
        if isinstance(container, str):
            with open(path, FileOps.READ_PLUS_MODE, encoding=FileOps.ENCODING) as f:
                if container not in f.read():
                    f.write(f"{container}\n")

    def _save_file_or_folder(self, path: str, container: list):
        # This first if statement is used to save the files and folders (list container)
        # These containers are saved once the arrays are completely filled with the crawled data.
        if isinstance(container, list):
            if os.path.exists(path):
                os.remove(path)
            with open(path, FileOps.APPEND_MODE, encoding=FileOps.ENCODING) as f:
                for item_path, last_change, size_readable, size_bytes in container:
                    f.write(f"{item_path}, {last_change}, {size_readable}, {size_bytes}\n")

    def _read_out_saved_items(self, item_type: str, container: list):
        """
        This private method is used to read out the saved files and folders from the txt files and store them in the respective lists.

        :param item_type: A string value that determines whether to read out the files or the folders. "files" or "folders".
        :return:
        """

        START_OF_COLOR_FORMAT = ", \x1b"
        COMMA_WITH_SPACE = ", "
        SEPARATOR = ","

        item_path = os.path.join(SavedCrawls.SAVED_CRAWLS_FOLDER, f"{item_type}{SavedCrawls.EXTENSION}")

        with open(item_path, "r", encoding=FileOps.ENCODING) as items:
            # The reason you will see below assigning None to the variables is, that during iteration
            # in _print_container method, we expect to unpack a tuple with the same amount of elements,
            # regardless of the container.
            for item in items:
                item = item.strip("\n")
                if item.count(SEPARATOR) > 4 and START_OF_COLOR_FORMAT in item:
                    # Sometimes there are more commas in the path, therefore we need to split the
                    # read-out string exactly at the point where we expect the sizes.
                    index = item.index(START_OF_COLOR_FORMAT)
                    item_path, last_change = item[:index + 1].split(COMMA_WITH_SPACE)[0:2]
                    size_readable, size_bytes = item[index + 1:].split(COMMA_WITH_SPACE)
                elif item.endswith(f"{self.NONE}, {self.NONE}"):
                    # Sometimes the computation of size fails, therefore in the read-out string
                    # are "None, None" at the places where the sizes should be.
                    item = item.replace(f", {self.NONE}, {self.NONE}", "")
                    item_path, last_change = item.split(COMMA_WITH_SPACE)
                    size_readable, size_bytes = self.NONE, self.NONE
                elif item.count(SEPARATOR) == 3:
                    # There are correct number of commas and we can split string perfectly.
                    item_path, last_change, size_readable, size_bytes = item.split(COMMA_WITH_SPACE)
                elif item_type is ItemType.SKIPPED:
                    item_path = item
                    last_change, size_readable, size_bytes = self.NONE, self.NONE, self.NONE
                    self.skipped_items += 1
                container.append((item_path, last_change, size_readable, size_bytes))

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
        size = 0
        try:
            if get_size_folder:
                for root, _, files in os.walk(path):
                    for file in files:
                        file_path = os.path.join(root, file)
                        size += os.path.getsize(file_path)
            else:
                size = os.path.getsize(path)
        except FileNotFoundError:
            self._log_crawling_state(data_to_write=ExceptionMessage.ERR_COMPUTING_SIZE)
            self._save_crawl_results(path=SavedCrawls.SKIPPED, container=path)
            return self.NONE, self.NONE

        return f"{self._convert_bytes_to_readable_format(size)}", f"{size}B"

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
                return f"\033[0;{color};40m{size:.2f}{unit}"
            size /= 1024

    def _compare_sizes(self, size_filter: int, size_to_compare: str, sign: str = ">=") -> bool:
        """
        This private method is used to compare the size of a file or folder with the size filter based on the filter_sign.
        :param size_filter: Filter the size of the files and folders based on this value.
        :param size_to_compare: Which size to compare with the filter.
        :param sign: Which filter_sign to use for the comparison.
        :return: A boolean value that represents whether the size of the file or folder satisfies the condition.
        """

        equality_signs = [EqualitySign.BIGGER_OR_EQUAL,
                          EqualitySign.SMALLER_OR_EQUAL,
                          EqualitySign.BIGGER,
                          EqualitySign.SMALLER,
                          EqualitySign.EQUAL,
                          EqualitySign.NOT_EQUAL]

        assert sign in equality_signs, ExceptionMessage.INVALID_SIGN

        if size_to_compare == self.NONE or size_to_compare is None:
            return False

        # sometimes the size_to_compare has a new line character at the end, remove it in that case
        if size_to_compare.endswith("\n"):
            size_to_compare = size_to_compare[:-1]

        # get rid of the "B" representing bytes at the end of the string and get only
        # integer value of bytes
        size_to_compare_ = int(size_to_compare[:-1])

        match sign:
            case EqualitySign.BIGGER_OR_EQUAL:
                return size_to_compare_ >= size_filter
            case EqualitySign.SMALLER_OR_EQUAL:
                return size_to_compare_ <= size_filter
            case EqualitySign.BIGGER:
                return size_to_compare_ > size_filter
            case EqualitySign.SMALLER:
                return size_to_compare_ < size_filter
            case EqualitySign.EQUAL:
                return size_to_compare_ == size_filter
            case EqualitySign.NOT_EQUAL:
                return size_to_compare_ != size_filter

    def _check_if_necessary_to_read_out_saved_files(self, container: list, item_type: str):
        # This will read out saved files if no crawling was done in current run of a program.
        if not container:
            if container is ItemType.SKIPPED and os.path.getsize(SavedCrawls.SKIPPED) == 0:
                return
            self._read_out_saved_items(item_type, container)

    def _print_crawl_summary(self, item_type: str, number_of_items: int, total_size: int, print_total_size: bool):
        ending = Messages.PRINT_ENDING if not print_total_size else "\n"

        print(Messages.NR_OF_LISTED_ITEMS, f"{item_type.upper()}:", number_of_items, end=ending)
        if print_total_size:
            print(Messages.NR_OF_DATA_CRAWLED,
                  self._convert_bytes_to_readable_format(total_size),
                  f"{total_size}B",
                  self.DEFAULT_COLOR,
                  end=Messages.PRINT_ENDING)

    def _print_container(self, filter_path="", filter_size=0, sign=">=",
                         item_type: str = None, container: list = None):
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

        if item_type is ItemType.FILES or item_type is ItemType.FOLDERS:
            self._print_file_or_folder(container, filter_path, filter_size, item_type, sign)
        elif item_type is ItemType.SKIPPED:
            self._print_skipped_items(container)

    def _print_skipped_items(self, container):
        container = self._filter_subdirectories(items=container)
        for item in container:
            print(item)
        print(Messages.NR_OF_SKIPPED_ITEMS, self.skipped_items, end=Messages.PRINT_ENDING)

    def _print_file_or_folder(self, container: list, filter_path: str, filter_size: int, item_type: str, sign: str):
        print_total_size = not (self.crawl_deep and item_type == ItemType.FOLDERS)
        number_of_items = 0
        total_size = 0
        for item, last_change, size_formatted, size_total_bytes in container:
            if filter_path in item and self._compare_sizes(filter_size, size_total_bytes, sign):
                print(item, last_change, size_formatted, size_total_bytes, self.DEFAULT_COLOR)
                number_of_items += 1
                total_size += int(size_total_bytes.strip("\n")[:-1])
        self._print_crawl_summary(item_type, number_of_items, total_size, print_total_size)

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

    def _clear_file(self):
        delete_skipped_items = False

        with open(SavedCrawls.PARAMETERS, FileOps.READ_MODE, encoding=FileOps.ENCODING) as f:
            if ExceptionMessage.ERR_COMPUTING_SIZE not in f.read():
                delete_skipped_items = True

        if delete_skipped_items:
            open(SavedCrawls.SKIPPED, FileOps.WRITE_PLUS_MODE, encoding=FileOps.ENCODING).close()

    @staticmethod
    def _filter_subdirectories(items):
        # Sort paths to ensure that shorter paths come before their potential subdirectories
        items = (x[0] for x in items)
        sorted_items = sorted(items, key=len)

        filtered_paths = []
        for i, path in enumerate(sorted_items):
            path = str(path)
            # Append a backslash to ensure matching complete directory names
            if not any(path + '\\' in other for other in sorted_items[i + 1:]):
                filtered_paths.append(path)

        return filtered_paths
    # endregion

    # todo: check all the tests, they were written by AI
    # todo: check documentation
    # todo: create a interface executable from the command line
    # todo: perhaps create some unpacking structure, in case you wanted to change order of the items in a container
    # todo: create a readout option with filter across multiple files
    # todo: continue with modular column printing


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
    # cr = FolderCrawler(path=r"C:\Users\lazni\Downloads", crawl_deep=False)
    cr = FolderCrawler(path=r"C:\\", crawl_deep=True)
    cr.crawl()
    print_items = True
    cr.print_items(print_items, print_items, False, filter_path="", filter_sign=">=", filter_size=0)
    # cr.compare_saved_crawls(path1=..., path2=..., print_=True)
    # cr.read_content_of_file(path="C:/", filter_="")

    # custom_dict = {"name": ["Jon", "Ponna", "Lada"],
    #                "age": [20, 32, 23],
    #                "sex": ["Male", "Female", "Female"],
    #                "date": ["2024-03-16 15:39:21.244817", "2024-03-17 15:39:21.244817", "2024-03-18 15:39:21.244817"]
    #                }
    # import pandas as pd
    # df = pd.DataFrame(custom_dict)
    # filter1 = (df["sex"].str.contains("Fe"))
    # filter2 = (df["age"] > 20)
    # filter_date = (df["date"] >= "2024-03-17 00:00:00.000000")
    #
    # print(df[filter_date])
