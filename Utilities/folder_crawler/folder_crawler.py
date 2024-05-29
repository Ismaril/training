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
    SKIPPED_ITEMS = "skipped_items"
    EXTENSION = ".txt"
    SAVED_CRAWLS_FOLDER = "saved_crawls"
    PATH_TO_SAVED_FILES = os.path.join(SAVED_CRAWLS_FOLDER, f"{FILES}{EXTENSION}")
    PATH_TO_SAVED_FOLDERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{FOLDERS}{EXTENSION}")
    PATH_TO_SKIPPED_ITEMS = os.path.join(SAVED_CRAWLS_FOLDER, f"{SKIPPED_ITEMS}{EXTENSION}")
    PATH_TO_PARAMETERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{PARAMETERS}{EXTENSION}")

    ERR_COMPUTING_SIZE_EXC_MSG = "ERROR COMPUTING THE SIZE. EXCEPTION: "
    INVALID_SIGN_EXC_MSG = "INVALID SIGN!"

    DEEP_CRAWL_MSG = "Going deep into the sub-folders. The process may take a while."
    SHALLOW_CRAWL_MSG = "Staying in the inputted folder. The process may take a while."
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

    # endregion

    # region Constructor
    def __init__(self, path: str, crawl_deep: bool):
        """
        This is the constructor method for the FolderCrawler class.

        :param path: The path of the folder that needs to be crawled.
        """

        self.path = path
        self.skipped_items = 0
        self.files = []
        self.folders = []
        self.skipped = []
        self.timer = time.perf_counter()
        self.crawl_deep = crawl_deep

    # endregion

    # region Public Methods
    def crawl_item_names_with_sizes(self):
        """
        This method decides whether to perform a deep crawl or a shallow crawl based on the crawl_deep parameter.
        This means that the crawler will either stay in inputted folder or go deeper into the sub-folders.
        The result will be extracted either file of folder. Both of them will also contain its size.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl. Default is False.

        :return: None
        """
        self._log_crawling_state(data_to_write=self.STARTED_CRAWLING_MSG)
        if self.crawl_deep:
            print(self.DEEP_CRAWL_MSG)
            self._crawl_item_names_and_sizes_go_deep()
        else:
            print(self.SHALLOW_CRAWL_MSG)
            self._crawl_item_names_and_sizes_without_going_deeper()

        print(self.SAVING_RESULTS_MSG, end=self.PRINT_ENDING)
        self._save_crawl_results(path=self.PATH_TO_SAVED_FILES, container=self.files)
        self._save_crawl_results(path=self.PATH_TO_SAVED_FOLDERS, container=self.folders)
        self._clear_file()
        self._log_crawling_state(data_to_write=self.DONE_CRAWLING_MSG)

    def print_items(self, print_folders=True, print_files=True, print_skipped_items=True,
                    filter_path="", filter_sign=">=", filter_size=0, read_out_saved_files=False):
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
            self._print_container(
                filter_path=filter_path,
                filter_size=filter_size,
                sign=filter_sign,
                item_type=self.FILES,
                container=self.files,
                read_out_from_saved_files=read_out_saved_files
            )
        if print_folders:
            self._print_container(
                filter_size=filter_size,
                filter_path=filter_path,
                sign=filter_sign,
                item_type=self.FOLDERS,
                container=self.folders,
                read_out_from_saved_files=read_out_saved_files
            )

        if print_skipped_items:
            self._print_container(
                filter_size=filter_size,
                filter_path=filter_path,
                sign=filter_sign,
                item_type=self.SKIPPED_ITEMS,
                container=self.skipped,
                read_out_from_saved_files=read_out_saved_files
            )

        self._show_time()

    def read_content_of_file(self, path: str, filter_: str = "", print_=True):
        """
        This function reads the content of a file and prints the lines that contain the filter string.

        :param path: The path of the file that needs to be read.
        :param filter_: Filter string that filters out the lines.
        :return: None
        """

        array_ = []

        with open(path, "r", encoding=self.ENCODING) as file:
            for line in file:
                if filter_ in line:
                    if print_:
                        print(line.strip())
                    array_.append(line.strip())

        return array_

    def compare_saved_crawls(self, path1: str, path2: str, print_=True):
        array1 = self.read_content_of_file(path1, print_=False)
        array2 = self.read_content_of_file(path2, print_=False)

        array_difference = []
        for item in array1:
            if item not in array2:
                array_difference.append(item)
        for item in array2:
            if item not in array1:
                array_difference.append(item)

        if print_:
            for item in array_difference:
                print(item)

        return array_difference

    # endregion

    # region Private Methods
    def _log_crawling_state(self, data_to_write: str):
        with open(self.PATH_TO_PARAMETERS, "w") as f:
            f.write(data_to_write)

    def _process_path(self, path_tuple):
        path, is_file = path_tuple
        last_change = self._get_last_change_of_item(path)

        if is_file:
            size_readable, size_total = self._get_size(path, get_size_file=True)
        else:
            size_readable, size_total = self._get_size(path, get_size_folder=True)

        return path, last_change, size_readable, size_total, is_file

    def _process_item(self, item):
        """
        Determines the type of the item (file or folder), calculates its size, and categorizes it.
        """
        item_path = os.path.join(self.path, item)
        is_folder = os.path.isdir(item_path)
        last_change = self._get_last_change_of_item(self.path)
        size_readable, size_total = self._get_size(item_path, get_size_folder=is_folder)
        return item_path, last_change, size_readable, size_total, is_folder

    def _crawl_item_names_and_sizes_without_going_deeper(self):
        """
        Crawls through the folder at the given path without going deeper into subdirectories,
        using multiprocessing to calculate the sizes of files and folders.
        """
        items = os.listdir(self.path)

        # Use multiprocessing Pool to handle file and folder size calculations
        with Pool() as pool:
            results = pool.map(self._process_item, items)

        # Append results to appropriate lists
        for result in results:
            item_path, last_change, size_readable, size_total, is_folder = result
            if is_folder:
                self.folders.append((item_path, last_change, size_readable, size_total))
            else:
                self.files.append((item_path, last_change, size_readable, size_total))

    def _crawl_item_names_and_sizes_go_deep(self):
        paths = []
        for root, folders, files in os.walk(self.path):
            for file in files:
                file_path = os.path.join(root, file)
                paths.append((file_path, True))
            for folder in folders:
                folder_path = os.path.join(root, folder)
                paths.append((folder_path, False))

        # Use multiprocessing Pool to handle file and folder size calculations
        with Pool() as pool:
            results = pool.map(self._process_path, paths)

        # Append results to appropriate lists
        for result in results:
            path, last_change, size_readable, size_total, is_file = result
            if is_file:
                self.files.append((path, last_change, size_readable, size_total))
            else:
                self.folders.append((path, last_change, size_readable, size_total))

    def _initialize_files(self):
        """ Ensure all necessary directories and files are created. """
        os.makedirs(self.SAVED_CRAWLS_FOLDER, exist_ok=True)
        for txt_file in (self.PATH_TO_SAVED_FILES, self.PATH_TO_SAVED_FOLDERS,
                         self.PATH_TO_SKIPPED_ITEMS, self.PATH_TO_PARAMETERS):
            open(txt_file, 'a', encoding=self.ENCODING).close()

    def _save_crawl_results(self, path: str, container: list | str):
        """
        This private method is used to save the crawled files and folders into txt files.

        :param path: The path of the txt file where the files or folders need to be saved.
        :param container: The list of files or folders that need to be saved.

        :return: None
        """

        self._initialize_files()

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
                if item.count(",") > 4:
                    for i, character in enumerate(item):
                        if item[i:i + 3] == ", \x1b":
                            item_path = item[:i + 1]
                            size_readable, size_bytes = item[i + 1:].split(", ")
                            break
                elif f"{self.NONE}, {self.NONE}" in item:
                    item_path = item.replace(f", {self.NONE}, {self.NONE}", "")
                    size_readable, size_bytes = self.NONE, self.NONE
                elif item.count(",") == 3:
                    item_path, size_readable, size_bytes = item.strip("\n").split(", ")
                elif item_type is self.SKIPPED_ITEMS:
                    item_path = item.strip("\n")
                    size_readable, size_bytes = self.NONE, self.NONE
                    self.skipped_items += 1
                container.append((item_path, size_readable, size_bytes))

    def _get_size(self, path: str, get_size_file: bool = False, get_size_folder: bool = False):
        """
        This private method is used to calculate the size of a file or a folder.
        If get_size_file is True, it calculates the size of the file at the given path.
        If get_size_folder is True, it calculates the size of the folder at the given path by adding up the sizes of all
        the files in the folder and its sub-folders.
        The size is returned as a string in a more readable format (converted by the _convert_size method) and in bytes.

        :param path: The path of the file or folder whose size needs to be calculated.
        :param get_size_file: A boolean value that determines whether to calculate the size of a file. Default is False.
        :param get_size_folder: A boolean value that determines whether to calculate the size of a folder. Default is False.

        :return: A string that represents the size in a more readable format and in bytes.
        """
        size = 0

        get_size_file = get_size_file or not get_size_folder
        get_size_folder = get_size_folder or not get_size_file

        if get_size_file:
            try:
                size += os.path.getsize(path)
            except FileNotFoundError:
                self._log_crawling_state(data_to_write=self.ERR_COMPUTING_SIZE_EXC_MSG)
                self._save_crawl_results(path=self.PATH_TO_SKIPPED_ITEMS, container=f"{path}")
                return self.NONE, self.NONE
        elif get_size_folder:
            for root, _, files in os.walk(path):
                for file in files:
                    try:
                        size += os.path.getsize(os.path.join(root, file))
                    except FileNotFoundError:
                        self._log_crawling_state(data_to_write=self.ERR_COMPUTING_SIZE_EXC_MSG)
                        self._save_crawl_results(path=self.PATH_TO_SKIPPED_ITEMS, container=f"{path}")
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

        assert sign in [self.BIGGER_OR_EQUAL,
                        self.SMALLER_OR_EQUAL,
                        self.BIGGER,
                        self.SMALLER,
                        self.EQUAL,
                        self.NOT_EQUAL], \
            self.INVALID_SIGN_EXC_MSG

        if size_to_compare == self.NONE or size_to_compare is None:
            return False

        if size_to_compare.endswith("\n"):
            size_to_compare = size_to_compare[:-1]

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

    def _check_if_necessary_to_read_out_saved_files(self, read_out_from_saved_files: bool, container: list,
                                                    item_type: str):
        # This will read out saved files if no crawling was done in current run of a program.
        if read_out_from_saved_files and not container:
            if container is self.SKIPPED_ITEMS and os.path.getsize(self.PATH_TO_SKIPPED_ITEMS) == 0:
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
                         item_type: str = None, container: list = None,
                         read_out_from_saved_files=False):
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

        self._check_if_necessary_to_read_out_saved_files(read_out_from_saved_files, container, item_type)

        if item_type is self.FILES or item_type is self.FOLDERS:
            print_total_size = False if self.crawl_deep and item_type is self.FOLDERS else True
            for item, last_change, size_formatted, size_total_bytes in container:
                if filter_path in item and self._compare_sizes(filter_size, size_total_bytes, sign):
                    print(item, last_change, size_formatted, size_total_bytes, self.DEFAULT_COLOR)
                    number_of_items += 1
                    total_size += int(size_total_bytes.strip("\n")[:-1])
            self._print_crawl_summary(item_type, number_of_items, total_size, print_total_size)
        elif item_type is self.SKIPPED_ITEMS:
            for item in container:
                print(item)
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

        with open(self.PATH_TO_PARAMETERS, 'r', encoding=self.ENCODING) as f:
            if self.ERR_COMPUTING_SIZE_EXC_MSG not in f.read():
                delete_skipped_items = True

        if delete_skipped_items:
            open(self.PATH_TO_SKIPPED_ITEMS, 'w+', encoding=self.ENCODING).close()

    # endregion

    # todo: check all the tests, they were written by AI
    # todo: check documentation
    # todo: include last change of the file into the print
    # todo: refactor the multiprocessing part
    # todo: create a interface executable from the command line


if __name__ == '__main__':
    cr = FolderCrawler(path=r"C:/Users/lazni/Downloads", crawl_deep=True)
    # cr = FolderCrawler(path=r"C:/$Recycle.Bin", crawl_deep=True)
    cr.crawl_item_names_with_sizes()
    cr.print_items(
        print_files=True,
        print_folders=True,
        print_skipped_items=False,
        filter_path="",
        filter_sign=">=",
        filter_size=0,
        read_out_saved_files=True
    )
    cr.compare_saved_crawls(path1=..., path2=..., print_=True)
    # cr.read_content_of_file(path="C:/", filter_="")
