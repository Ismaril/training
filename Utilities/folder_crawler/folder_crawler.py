import datetime
import os
import time
from multiprocessing import Pool


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its sub-folders and prints the paths with sizes.
    """
    # region Constants
    FILES = "files"
    FOLDERS = "folders"
    PARAMETERS = "parameters"
    SKIPPED = "skipped_items"
    EXTENSION = ".txt"
    SAVED_CRAWLS_FOLDER = "saved_crawls"
    PATH_TO_SAVED_FILES = os.path.join(SAVED_CRAWLS_FOLDER, f"{FILES}{EXTENSION}")
    PATH_TO_SAVED_FOLDERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{FOLDERS}{EXTENSION}")
    PATH_TO_SKIPPED_ITEMS = os.path.join(SAVED_CRAWLS_FOLDER, f"{SKIPPED}{EXTENSION}")
    PATH_TO_PARAMETERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{PARAMETERS}{EXTENSION}")

    ERR_COMPUTING_SIZE_EXC_MSG = "ERROR COMPUTING THE SIZE. EXCEPTION: "
    INVALID_SIGN_EXC_MSG = "INVALID SIGN!"

    DEEP_CRAWL_MSG = "Crawling - Going deep into sub-folders. The process may take a while."
    SHALLOW_CRAWL_MSG = "Crawling - Staying in the inputted folder. The process may take a while."
    NR_OF_DATA_CRAWLED_MSG = "NUMBER OF DATA CRAWLED:"
    NR_OF_SKIPPED_ITEMS_MSG = "NUMBER OF SKIPPED ITEMS:"
    NR_OF_LISTED_ITEMS_MSG = "NUMBER OF LISTED"
    WHOLE_PROCES_TOOK_MSG = "THE WHOLE PROCESS TOOK:"
    SAVING_RESULTS_MSG = "Saving the results into txt files."
    DONE_CRAWLING_MSG = "DONE CRAWLING"
    STARTED_CRAWLING_MSG = "STARTED CRAWLING"
    PRINT_ENDING = f"\n{'-' * 150}\n"

    BIGGER_OR_EQUAL = ">="
    SMALLER_OR_EQUAL = "<="
    BIGGER = ">"
    SMALLER = "<"
    EQUAL = "=="
    NOT_EQUAL = "!="

    NONE = "None"
    ENCODING = "UTF-8"
    DEFAULT_COLOR = "\033[0m"
    READ_MODE = "r"
    WRITE_MODE = "w"
    WRITE_PLUS_MODE = "w+"
    APPEND_MODE = "a"

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
        self._log_crawling_state(data_to_write=self.STARTED_CRAWLING_MSG)

        if self.crawl_deep:
            print(self.DEEP_CRAWL_MSG)
            self._crawl_items(go_deep=True)
        else:
            print(self.SHALLOW_CRAWL_MSG)
            self._crawl_items(go_deep=False)

        print(self.SAVING_RESULTS_MSG, end=self.PRINT_ENDING)
        self._save_crawl_results(path=self.PATH_TO_SAVED_FILES, container=self.files)
        self._save_crawl_results(path=self.PATH_TO_SAVED_FOLDERS, container=self.folders)
        self._clear_file()
        self._log_crawling_state(data_to_write=self.DONE_CRAWLING_MSG)

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
            self._print_container(filter_path, filter_size, filter_sign, item_type=self.FILES, container=self.files)
        if print_folders:
            self._print_container(filter_path, filter_size, filter_sign, item_type=self.FOLDERS, container=self.folders)
        if print_skipped_items:
            self._print_container(filter_path, filter_size, filter_sign, item_type=self.SKIPPED, container=self.skipped)

        self._show_time()

    def read_content_of_file(self, path: str, filter_: str = "", print_=True):
        """
        This function reads the content of a file and prints the lines that contain the filter string.

        :param path: The path of the file that needs to be read.
        :param filter_: Filter string that filters out the lines.
        :return: None
        """

        array_ = []

        with open(path, self.READ_MODE, encoding=self.ENCODING) as file:
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
    def _log_crawling_state(self, data_to_write: str):
        with open(self.PATH_TO_PARAMETERS, self.WRITE_MODE) as f:
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
        paths = []
        if go_deep:
            for root, folders, files in os.walk(self.path):
                for file in files:
                    file_path = os.path.join(root, file)
                    paths.append((file_path, True))
                for folder in folders:
                    folder_path = os.path.join(root, folder)
                    paths.append((folder_path, False))
        else:
            items = os.listdir(self.path)
            for item in items:
                item_path = os.path.join(self.path, item)
                is_folder = os.path.isdir(item_path)
                paths.append((item_path, not is_folder))

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

    # Example usage
    # Create instance and call _crawl_items with go_deep=True for deep crawling or False for shallow

    def _initialize_files(self):
        """ Ensure all necessary directories and files are created. """
        os.makedirs(self.SAVED_CRAWLS_FOLDER, exist_ok=True)
        for txt_file in (self.PATH_TO_SAVED_FILES, self.PATH_TO_SAVED_FOLDERS,
                         self.PATH_TO_SKIPPED_ITEMS, self.PATH_TO_PARAMETERS):
            # Create empty txt files if they don't exist or just append empty string if they do exist
            open(txt_file, 'a', encoding=self.ENCODING).close()

    def _save_crawl_results(self, path: str, container: list | str):
        """
        This private method is used to save the crawled files and folders into txt files.

        :param path: The path of the txt file where the files or folders need to be saved.
        :param container: The list of files or folders that need to be saved.

        :return: None
        """

        # this first if statement is used to save the files and folders (list container)
        if isinstance(container, list):
            if os.path.exists(path):
                os.remove(path)
            with open(path, 'a', encoding=self.ENCODING) as f:
                for item_path, last_change, size_readable, size_bytes in container:
                    f.write(f"{item_path}, {last_change}, {size_readable}, {size_bytes}\n")

        # this second if statement is used to save the skipped items (string container)
        elif isinstance(container, str):
            with open(path, 'r+', encoding=self.ENCODING) as f:
                if container not in f.read():
                    f.write(f"{container}\n")

    def _read_out_saved_items(self, item_type: str, container: list):
        """
        This private method is used to read out the saved files and folders from the txt files and store them in the respective lists.

        :param item_type: A string value that determines whether to read out the files or the folders. "files" or "folders".
        :return:
        """

        item_path = os.path.join(self.SAVED_CRAWLS_FOLDER, f"{item_type}{self.EXTENSION}")

        with open(item_path, "r", encoding=self.ENCODING) as items:
            for item in items:
                item = item.strip("\n")
                start_of_color_format = ", \x1b"
                if item.count(",") > 4 and start_of_color_format in item:
                    # Sometimes there are more commas in the path, therefore we need to split the
                    # read-out string exactly at the point where we expect the sizes.
                    index = item.index(start_of_color_format)
                    item_path, last_change = item[:index + 1].split(", ")[0:2]
                    size_readable, size_bytes = item[index + 1:].split(", ")
                elif item.endswith(f"{self.NONE}, {self.NONE}"):
                    # Sometimes the computation of size fails, therefore in the read-out string
                    # are "None, None" at the places where the sizes should be.
                    item = item.replace(f", {self.NONE}, {self.NONE}", "")
                    item_path, last_change = item.split(", ")
                    size_readable, size_bytes = self.NONE, self.NONE
                elif item.count(",") == 3:
                    # There are correct number of commas and we can split string perfectly.
                    item_path, last_change, size_readable, size_bytes = item.split(", ")
                elif item_type is self.SKIPPED:
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
            self._log_crawling_state(data_to_write=self.ERR_COMPUTING_SIZE_EXC_MSG)
            self._save_crawl_results(path=self.PATH_TO_SKIPPED_ITEMS, container=path)
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

        assert sign in [self.BIGGER_OR_EQUAL, self.SMALLER_OR_EQUAL, self.BIGGER,
                        self.SMALLER, self.EQUAL, self.NOT_EQUAL], self.INVALID_SIGN_EXC_MSG

        if size_to_compare == self.NONE or size_to_compare is None:
            return False

        # sometimes the size_to_compare has a new line character at the end, remove it in that case
        if size_to_compare.endswith("\n"):
            size_to_compare = size_to_compare[:-1]

        # get rid of the "B" representing bytes at the end of the string
        size_to_compare_ = int(size_to_compare[:-1])

        match sign:
            case self.BIGGER_OR_EQUAL:
                return size_to_compare_ >= size_filter
            case self.SMALLER_OR_EQUAL:
                return size_to_compare_ <= size_filter
            case self.BIGGER:
                return size_to_compare_ > size_filter
            case self.SMALLER:
                return size_to_compare_ < size_filter
            case self.EQUAL:
                return size_to_compare_ == size_filter
            case self.NOT_EQUAL:
                return size_to_compare_ != size_filter

    def _check_if_necessary_to_read_out_saved_files(self, container: list, item_type: str):
        # This will read out saved files if no crawling was done in current run of a program.
        if not container:
            if container is self.SKIPPED and os.path.getsize(self.PATH_TO_SKIPPED_ITEMS) == 0:
                return
            self._read_out_saved_items(item_type, container)

    def _print_crawl_summary(self, item_type: str, number_of_items: int, total_size: int, print_total_size: bool):
        ending = self.PRINT_ENDING if not print_total_size else "\n"

        print(self.NR_OF_LISTED_ITEMS_MSG, f"{item_type.upper()}:", number_of_items, end=ending)
        if print_total_size:
            print(self.NR_OF_DATA_CRAWLED_MSG,
                  self._convert_bytes_to_readable_format(total_size),
                  f"{total_size}B",
                  self.DEFAULT_COLOR,
                  end=self.PRINT_ENDING)

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
        number_of_items = 0
        total_size = 0

        self._check_if_necessary_to_read_out_saved_files(container, item_type)

        if item_type is self.FILES or item_type is self.FOLDERS:
            print_total_size = False if self.crawl_deep and item_type is self.FOLDERS else True
            for item, last_change, size_formatted, size_total_bytes in container:
                if filter_path in item and self._compare_sizes(filter_size, size_total_bytes, sign):
                    print(item, last_change, size_formatted, size_total_bytes, self.DEFAULT_COLOR)
                    number_of_items += 1
                    total_size += int(size_total_bytes.strip("\n")[:-1])
            self._print_crawl_summary(item_type, number_of_items, total_size, print_total_size)
        elif item_type is self.SKIPPED:
            for item in container:
                print(item[0])
            print(self.NR_OF_SKIPPED_ITEMS_MSG, self.skipped_items, end=self.PRINT_ENDING)

    def _show_time(self):
        """
        This private method is used to calculate the time since initialization of class till the print of the files and folders.

        :return: None
        """
        print(self.WHOLE_PROCES_TOOK_MSG,
              self._format_duration(time.perf_counter() - self.timer),
              end=self.PRINT_ENDING)

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

        with open(self.PATH_TO_PARAMETERS, self.READ_MODE, encoding=self.ENCODING) as f:
            if self.ERR_COMPUTING_SIZE_EXC_MSG not in f.read():
                delete_skipped_items = True

        if delete_skipped_items:
            open(self.PATH_TO_SKIPPED_ITEMS, self.WRITE_PLUS_MODE, encoding=self.ENCODING).close()

    # endregion

    # todo: check all the tests, they were written by AI
    # todo: check documentation
    # todo: create a interface executable from the command line
    # todo: check if the skipped items are included in files and folders

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
    cr.print_items(
        print_files=True,
        print_folders=True,
        print_skipped_items=True,
        filter_path="",
        filter_sign=">=",
        filter_size=0,
    )
    # cr.compare_saved_crawls(path1=..., path2=..., print_=True)
    # cr.read_content_of_file(path="C:/", filter_="")
