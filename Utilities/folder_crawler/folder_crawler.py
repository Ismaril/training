import os
import time


def read_content_of_file(path: str, filter: str = ""):
    """
    TODO: Add documentation
    """

    with open(path, "r") as file:
        for line in file:
            if filter in line:
                print(line.strip())


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its sub-folders and prints the paths with sizes.

    Attributes:
        path (str): The path of the folder that needs to be crawled.
        skipped_items (int): The number of items that were skipped during the crawling process.
        files (list): A list to store the file paths found during the crawling process.
        folders (list): A list to store the folder paths found during the crawling process.
        timer (float): The time when the crawling process starts.
    """

    FILES = "files"
    FOLDERS = "folders"
    EXTENSION = ".txt"
    SAVED_CRAWLS_FOLDER = "saved_crawls"
    PATH_TO_SAVED_FILES = os.path.join(SAVED_CRAWLS_FOLDER, f"{FILES}{EXTENSION}")
    PATH_TO_SAVED_FOLDERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{FOLDERS}{EXTENSION}")
    FILE_NOT_FOUND_EXCEPTION_MESSAGE = "The path cannot be found or there is some other error accessing the path."
    GENERAL_EXCEPTION_MESSAGE = "General exception. Debugging required"
    PRINT_ENDING = "\n" + "-" * 150 + "\n"

    def __init__(self, path: str):
        """
        This is the constructor method for the FolderCrawler class.

        :param path: The path of the folder that needs to be crawled.
        """

        self.path = path
        self.skipped_items = 0
        self.files = []
        self.folders = []
        self.timer = time.perf_counter()

        if not os.path.exists(self.path):
            raise FileNotFoundError

    def crawl_item_names_with_sizes(self, crawl_deep=False, include_sizes=True):
        """
        This method decides whether to perform a deep crawl or a shallow crawl based on the crawl_deep parameter.
        This means that the crawler will either stay in inputted folder or go deeper into the sub-folders.
        The result will be extracted either file of folder. Both of them will also contain its size.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl. Default is False.
        :param include_sizes: A boolean value that determines whether to include the sizes of the files and folders. Default is True.

        :return: None
        """
        if crawl_deep:
            self._crawl_item_names_and_sizes_go_deep()
        else:
            self._crawl_item_names_and_sizes_without_going_deeper(include_sizes=include_sizes)

        self._save_crawl_results()

    def _crawl_item_names_and_sizes_go_deep(self):
        """
        This private method is used to crawl through the folder and its sub-folders and store the file and folder paths in the respective lists.
        For each file in the files list, it calculates the size of the file and appends the file path and size to the files list.
        For each folder in the dirs list, it calculates the size of the folder and appends the folder path and size to the folders list.

        :returns: None
        """

        for root, dirs, files in os.walk(self.path):
            for file in files:
                file_path = os.path.join(root, file)
                try:
                    size_formatted, size_bytes_total = self._get_size(file_path, get_size_file=True)
                    self.files.append((file_path, size_formatted, size_bytes_total))
                except:
                    ...
            for folder in dirs:
                folder_path = os.path.join(root, folder)
                size_formatted, size_bytes_total = self._get_size(folder_path, get_size_folder=True)
                self.folders.append((folder_path, size_formatted, size_bytes_total))

    def _crawl_item_names_and_sizes_without_going_deeper(self, include_sizes: bool = True):
        """
        This private method is used to crawl through the folder at the given path and store the file and folder paths in the respective lists.
        It uses the os.listdir method to get the list of files and folders in the folder.
        If the item is a folder, it calculates the size of the folder and appends the folder path and size to the folders list.
        If the item is a file, it calculates the size of the file and appends the file path and size to the files list.

        :return: None
        """
        for item in os.listdir(self.path):
            item_path = os.path.join(self.path, item)
            if os.path.isdir(item_path):
                if include_sizes:
                    # self.folders.append((item_path, self._get_size(item_path, get_size_folder=True)))
                    size_readable, size_total_bytes = self._get_size(item_path, get_size_folder=True)
                    self.folders.append((item_path, size_readable, size_total_bytes))
                else:
                    self.folders.append(item_path)
            else:
                if include_sizes:
                    # self.files.append((item_path, self._get_size(item_path, get_size_file=True)))
                    size_readable, size_total_bytes = self._get_size(item_path, get_size_file=True)
                    self.files.append((item_path, size_readable, size_total_bytes))
                else:
                    self.files.append(item_path)

    def _save_crawl_results(self):
        """
        This private method is used to save the crawled files and folders into txt files.

        :return: None
        """

        if not os.path.exists(self.SAVED_CRAWLS_FOLDER):
            os.makedirs(self.SAVED_CRAWLS_FOLDER)

        # todo: refactor below two blocks into one
        # delete all old saved crawls in saved_crawls folder
        if os.path.exists(self.PATH_TO_SAVED_FILES):
            os.remove(self.PATH_TO_SAVED_FILES)
        if os.path.exists(self.PATH_TO_SAVED_FOLDERS):
            os.remove(self.PATH_TO_SAVED_FOLDERS)

        # save the files and folders into new files
        with open(self.PATH_TO_SAVED_FILES, 'a', encoding="UTF-8") as f:
            for file in self.files:
                f.write(f"{file[0]}, {file[1]}, {file[2]}\n")
        with open(self.PATH_TO_SAVED_FOLDERS, 'a', encoding="UTF-8") as f:
            for folder in self.folders:
                f.write(f"{folder[0]}, {folder[1]}, {folder[2]}\n")

    def _read_out_saved_items(self, item_type: str):
        """
        This private method is used to read out the saved files and folders from the txt files and store them in the respective lists.

        :param item_type: A string value that determines whether to read out the files or the folders. "files" or "folders".
        :return:
        """

        path = os.path.join(self.SAVED_CRAWLS_FOLDER, f"{item_type}{self.EXTENSION}")

        with open(path, "r", encoding="UTF-8") as items:
            for item in items:
                if item.count(",") > 3:
                    for i, character in enumerate(item):
                        if item[i:i + 3] == ", \x1b":
                            path = item[:i + 1]
                            size1, size2 = item[i + 1:].split(", ")
                            break
                elif "None, None" in item:
                    path = item.replace(", None, None", "")
                    size1, size2 = "None", "None"
                elif item.count(",") == 2:
                    path, size1, size2 = item.strip("\n").split(", ")

                if item_type == self.FOLDERS:
                    self.folders.append((path, size1, size2))
                elif item_type == self.FILES:
                    self.files.append((path, size1, size2))

    def _get_size(self, path, get_size_file=False, get_size_folder=False):
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
        if get_size_file:
            try:
                size += os.path.getsize(path)
                return f"{self._convert_bytes_to_readable_format(size)}", f"{size}B"
            except FileNotFoundError as error:
                self.skipped_items += 1
                print(f"Error computing the file size. Exception: {error}")
                return "None", "None"

        elif get_size_folder:
            for root, _, files in os.walk(path):
                for file in files:
                    try:
                        size += os.path.getsize(os.path.join(root, file))
                    except FileNotFoundError as error:
                        self.skipped_items += 1
                        print(f"The resulting computed size of \"{path}\" might "
                              f"be inaccurate due to error of computing size of it's sub component.",
                              f"Exception: {error}")
                        return "None", "None"
            return f"{self._convert_bytes_to_readable_format(size)}", f"{size}B"

    @staticmethod
    def _convert_bytes_to_readable_format(size: int | float):
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
        This private method is used to compare the size of a file or folder with the size filter based on the sign.
        :param size_filter: Filter the size of the files and folders based on this value.
        :param size_to_compare: Which size to compare with the filter.
        :param sign: Which sign to use for the comparison.
        :return: A boolean value that represents whether the size of the file or folder satisfies the condition.
        """

        BIGGER_OR_EQUAL = ">="
        SMALLER_OR_EQUAL = "<="
        BIGGER = ">"
        SMALLER = "<"
        EQUAL = "=="
        NOT_EQUAL = "!="

        assert sign in [BIGGER_OR_EQUAL, SMALLER_OR_EQUAL, BIGGER, SMALLER, EQUAL, NOT_EQUAL], "Invalid sign"

        if size_to_compare == "None" or size_to_compare[0] is None:
            # TODO: This return is called rarely, but it makes sense to handle it better. It
            #  happens when you get a path with size None.
            return True

        # todo: zjistit proc me spadne jednou do size_to_compare ta formatovana velikost

        if "\n" in size_to_compare:
            size_to_compare = size_to_compare[:-1]
        size_to_compare_ = int(size_to_compare[:-1])

        if sign == BIGGER_OR_EQUAL:
            return size_to_compare_ >= size_filter
        elif sign == SMALLER_OR_EQUAL:
            return size_to_compare_ <= size_filter
        elif sign == BIGGER:
            return size_to_compare_ > size_filter
        elif sign == SMALLER:
            return size_to_compare_ < size_filter
        elif sign == EQUAL:
            return size_to_compare_ == size_filter
        elif sign == NOT_EQUAL:
            return size_to_compare_ != size_filter

    def print_items(
            self,
            print_folders=True,
            print_files=True,
            filter_path="",
            sign=">=",
            filter_size=0,
            working_with_sizes=False,
            read_out_from_saved_files=False,
    ):
        """
        This method is used to print the files and folders that were found during the crawling process.
        It also prints the number of files and folders that were listed.
        The method can be customized to print only files, only folders, or both.
        It can also filter the files and folders based on text and size.
        At the end of the method, it calls the _show_time method to print the time taken for the crawling process.

        :param print_folders: A boolean value that determines whether to print the folders or not. Default is True.
        :param print_files: A boolean value that determines whether to print the files or not. Default is True.
        :param filter_path: A string value that is used to filter the files and folders. Default is an empty string.
        :param sign: A string value that is used to compare the sizes of the files and folders. Default is ">=".
        :param filter_size: An integer value that is used to filter the files and folders based on their sizes. Default is 0.
        :param working_with_sizes: A boolean value that determines whether to work with sizes or not. Default is False.

        :returns: None
        """

        if print_files:
            self._print_container(
                filter_path=filter_path,
                filter_size=filter_size,
                sign=sign,
                working_with_sizes=working_with_sizes,
                container=self.files,
                read_out_from_saved_files=read_out_from_saved_files
            )
        if print_folders:
            self._print_container(
                filter_size=filter_size,
                filter_path=filter_path,
                sign=sign,
                working_with_sizes=working_with_sizes,
                container=self.folders,
                read_out_from_saved_files=read_out_from_saved_files
            )

        # Todo: save and readout number of skipped items?
        print("NUMBER OF SKIPPED ITEMS:", self.skipped_items, end=self.PRINT_ENDING)
        self._show_time()

    def _print_container(
            self,
            default_color="\033[0m",
            filter_path="",
            filter_size=0,
            sign=">=",
            working_with_sizes=False,
            container: list = None,
            read_out_from_saved_files=False
    ):
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
        item_type = self.FOLDERS if container is self.folders else self.FILES

        if read_out_from_saved_files and not container:
            self._read_out_saved_items(item_type)

        if working_with_sizes:
            for item, size_formatted, size_total_bytes in container:
                if f"{filter_path}" in item and self._compare_sizes(size_filter=filter_size,
                                                                    size_to_compare=size_total_bytes,
                                                                    sign=sign):
                    # Print the folder/file path, size, and reset the color to the default color
                    print(item, size_formatted, size_total_bytes, default_color)
                    number_of_items += 1
            print(f"NUMBER OF LISTED {item_type.upper()}:", number_of_items, end=self.PRINT_ENDING)
        else:
            for item in container:
                if f"{filter_path}" in item:
                    print(item)
                    number_of_items += 1
            print(f"NUMBER OF LISTED {item_type.upper()}:", number_of_items, end=self.PRINT_ENDING)

    def _show_time(self):
        """
        This private method is used to calculate the time since initialization of class till the print of the files and folders.

        :return: None
        """
        print(f"The whole process took: {self.format_duration(time.perf_counter() - self.timer)}")

    @staticmethod
    def format_duration(seconds):
        SEC_PER_YEAR = 31536000  # 365*24*60*60
        SEC_PER_DAY = 86400  # 24*60*60
        SEC_PER_HR = 3600  # 60*60
        SEC_PER_MIN = 60

        total = seconds

        years, seconds = divmod(seconds, SEC_PER_YEAR)
        days, seconds = divmod(seconds, SEC_PER_DAY)
        hours, seconds = divmod(seconds, SEC_PER_HR)
        minutes, seconds = divmod(seconds, SEC_PER_MIN)

        values = [years, days, hours, minutes, seconds]
        keys = ['year', 'day', 'hour', 'minute', 'second']

        result1 = []
        for index, date in enumerate(values):
            if date:
                result1.append(
                    f"{date} {keys[index]}s"
                    if date > 1
                    else f"{date} {keys[index]}"
                )

        result2 = ", ".join(result1)
        last_comma = result2.rfind(",")

        end_result = f"{result2[:last_comma]}" \
                     f"{' and '}" \
                     f"{result2[last_comma + 2:]}" \
            if result2.count(",") >= 1 else result2

        if not total:
            return "now"
        else:
            return end_result


if __name__ == '__main__':
    cr = FolderCrawler(r"C:/")
    # cr.crawl_item_names_with_sizes(
    #     crawl_deep=True,
    #     include_sizes=True,
    # )
    cr.print_items(
        print_files=True,
        print_folders=True,
        filter_path="",
        sign=">=",
        filter_size=0,
        working_with_sizes=True,
        read_out_from_saved_files=True
    )

    # read_content_of_file(r"C:\Users\z003uxda\Desktop\log;Rack005_SPHA_01;DCP;Passed5b33;20240509-225541.148.txt", filter="failed")

