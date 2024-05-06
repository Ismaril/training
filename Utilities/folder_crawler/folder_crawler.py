import os
import time


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its sub-folders and prints the paths with sizes.

    Attributes:
        path (str): The path of the folder that needs to be crawled.
        files (list): A list to store the files found during the crawling process.
        folders (list): A list to store the folders found during the crawling process.
        timer (float): The time when the crawling process starts.
    """

    def __init__(self, path: str):
        """
        This is the constructor method for the FolderCrawler class.
        It initializes the path, files, folders, files_and_folders, and timer attributes.

        :param path: The path of the folder that needs to be crawled.
        """
        self.path = path
        self.PATH_TO_SAVED_FILES = "saved_crawls/files.txt"
        self.PATH_TO_SAVED_FOLDERS = "saved_crawls/folders.txt"
        self.files = []
        self.folders = []
        self.timer = time.perf_counter()

        if not os.path.exists(self.path):
            raise FileNotFoundError

    def _crawl_items(self):
        """
        This method is used to crawl through the folder at the given path and store the file and folder paths in the
        respective lists.

        :return: None
        """
        for item in os.listdir(self.path):
            item_path = os.path.join(self.path, item)
            if os.path.isdir(item_path):
                self.folders.append(item_path)
            else:
                self.files.append(item_path)

    def _crawl_items_with_sizes(self, crawl_deep=False):
        """
        This method decides whether to perform a deep crawl or a shallow crawl based on the crawl_deep parameter.
        This means that the crawler will either stay in inputted folder or go deeper into the sub-folders.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl. Default is False.

        :return: None
        """
        if crawl_deep:
            self._crawl_items_and_sizes_go_deep()
        else:
            self._crawl_items_and_sizes_without_going_deeper()

    def _crawl_items_and_sizes_without_going_deeper(self):
        """
        This private method is used to crawl through the folder at the given path and store the file and folder
        paths in the respective lists.
        It uses the os.listdir method to get the list of files and folders in the folder.
        For each item in the list, it checks if the item is a folder or a file.
        If the item is a folder, it calculates the size of the folder and appends the folder path and size to the
        folders list.
        If the item is a file, it calculates the size of the file and appends the file path and size to the files list.

        :return: None
        """
        for item in os.listdir(self.path):
            item_path = os.path.join(self.path, item)
            # print(item_path)
            if os.path.isdir(item_path):
                self.folders.append((item_path, self._get_size(item_path, get_size_folder=True)))
            else:
                self.files.append((item_path, self._get_size(item_path, get_size_file=True)))

    def _save_crawl_results(self):
        # delete all files in saved_crawls folder
        if os.path.exists(self.PATH_TO_SAVED_FILES):
            os.remove(self.PATH_TO_SAVED_FILES)
        if os.path.exists(self.PATH_TO_SAVED_FOLDERS):
            os.remove(self.PATH_TO_SAVED_FOLDERS)

        with open(self.PATH_TO_SAVED_FILES, 'a') as f:
            for file in self.files:
                f.write(f"{file[0]},{file[1]}\n")
        with open(self.PATH_TO_SAVED_FOLDERS, 'a') as f:
            for folder in self.folders:
                f.write(f"{folder[0]},{folder[1]}\n")

    def read_out_saved_items(self, read_files=True, read_folders=True):
        if read_files:
            count_files = 0
            with open(self.PATH_TO_SAVED_FILES, "r") as files:
                for file in files:
                    print(file, "\033[0m", end="")
                    count_files += 1
            print("Number of listed files:", count_files)
        if read_folders:
            count_folders = 0
            with open(self.PATH_TO_SAVED_FOLDERS, "r") as folders:
                for folder in folders:
                    print(folder, "\033[0m", end="")
                    count_folders += 1
            print("Number of listed folders:", count_folders)

    def _crawl_items_and_sizes_go_deep(self):
        """
        This private method is used to crawl through the folder and its sub-folders and store the file and folder paths
        in the respective lists.
        It uses the os.walk method to traverse the folder and its sub-folders.
        For each file in the files list, it calculates the size of the file and appends the file path and size to the
        files list.
        For each folder in the dirs list, it calculates the size of the folder and appends the folder path and size to
        the folders list.

        :return: None
        """
        for root, dirs, files in os.walk(self.path):
            for file in files:
                file_path = os.path.join(root, file)
                # print(file_path)
                self.files.append((file_path, self._get_size(file_path, get_size_file=True)))
            for folder in dirs:
                folder_path = os.path.join(root, folder)
                self.folders.append((folder_path, self._get_size(folder_path, get_size_folder=True)))
                # print(folder_path)

        self._save_crawl_results()

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
        if not os.path.exists(path):
            raise FileNotFoundError

        size = 0
        if get_size_file:
            size += os.path.getsize(path)
        if get_size_folder:
            for root, _, files in os.walk(path):
                for file in files:
                    size += os.path.getsize(os.path.join(root, file))
        return f"{self._convert_bytes_to_readable_format(size)}, {size}B"

    @staticmethod
    def _convert_bytes_to_readable_format(size: int | float):
        """
        This private method is used to convert the size from bytes to a more readable format.
        The size is converted to the highest unit that is less than 1024.
        The units used are Bytes (B), Kilobytes (KB), Megabytes (MB), Gigabytes (GB), and Terabytes (TB).
        The method also changes the color of the size string based on the unit.
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

    def _compare_sizes(self, size_filter: int, size_to_compare: str, sign=">="):
        size_to_compare = size_to_compare.split()
        size_to_compare_ = int(size_to_compare[1][:-1])
        if sign == ">=":
            return size_to_compare_ >= size_filter
        elif sign == "<=":
            return size_to_compare_ <= size_filter
        elif sign == ">":
            return size_to_compare_ > size_filter
        elif sign == "<":
            return size_to_compare_ < size_filter
        elif sign == "==":
            return size_to_compare_ == size_filter
        elif sign == "!=":
            return size_to_compare_ != size_filter

    def print_items(
            self,
            print_folders=True,
            print_files=True,
            filter_path="",
            sign=">=",
            filter_size=0,
            working_with_sizes=False
    ):
        """
        This method is used to print the files and folders that were found during the crawling process.
        It also prints the number of files and folders that were listed.
        The method can be customized to print only files, only folders, or both.
        It can also filter the files and folders based on the filter_ parameter.
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
                container=self.files
            )
        if print_folders:
            self._print_container(
                filter_size=filter_size,
                filter_path=filter_path,
                sign=sign,
                working_with_sizes=working_with_sizes,
                container=self.folders
            )

        self._show_time()

    def _print_container(
            self,
            default_color="\033[0m",
            filter_path="",
            filter_size=0,
            sign=">=",
            working_with_sizes=False,
            container: list = None):
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
        item_type = "folders" if container is self.folders else "files"

        if working_with_sizes:
            for item, size in container:
                if f"{filter_path}" in item and self._compare_sizes(size_filter=filter_size, size_to_compare=size,
                                                                    sign=sign):
                    # Print the folder/file path, size, and reset the color to the default color
                    print(item, size, default_color)
                    number_of_items += 1
            print(f"Number of listed {item_type}:", number_of_items)
        else:
            for item in container:
                if f"{filter_path}" in item:
                    print(item)
                    number_of_items += 1
            print(f"Number of listed {item_type}:", number_of_items)

    # TODO: Initialize a timer when crawling starts, not when the class is initialized.
    def _show_time(self):
        """
        This private method is used to calculate and print the time taken for the crawling process.
        It calculates the time difference between the current time and the time when the class was initialized.
        The time is printed in seconds with a precision of two decimal places.

        :return: None
        """
        print(f"Time taken to crawl: {time.perf_counter() - self.timer:.2f} seconds.")

    def crawl_item_names(self, print_files=True, print_folders=True, filter_=""):
        """
        This method is used to crawl through the folder at the given path, store the file and folder paths in the
        respective lists, and print the files and folders paths were found during the crawling process.

        :param print_files: A boolean value that determines whether to print the found file paths or not. Default is True.
        :param print_folders: A boolean value that determines whether to print the found folder paths or not. Default is True.
        :param filter_: A string value that is used to filter the files and folders. Default is an empty string, meaning no filter.

        :returns: None
        """
        self._crawl_items()
        print("-" * 90)
        self.print_items(
            print_files=print_files,
            print_folders=print_folders,
            filter_path=filter_,
            working_with_sizes=False
        )

    def crawl_item_names_and_sizes(self, crawl_deep=True):
        """
        This method is used to crawl through the folder at the given path, store the file and folder paths along with
        their sizes in the respective lists, and print the files and folders paths along with their sizes that were
        found during the crawling process.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl. This means that the crawler will either stay in the inputted folder or go deeper into the sub-folders. Default is True.

        :return: None
        """
        self._crawl_items_with_sizes(crawl_deep=crawl_deep)


if __name__ == '__main__':
    cr = FolderCrawler(r"C:\Users\z003uxda\Desktop")
    cr.crawl_item_names_and_sizes()

    # prints the files and folders with sizes from the containers existing during runtime
    # cr.print_items(print_files=True, print_folders=True, filter_path="", sign=">=", filter_size=0, working_with_sizes=True)

    # prints the files and folders with sizes from the containers saved into txt files (does not require to crawl again)
    cr.read_out_saved_items(read_files=True, read_folders=True)

    # TODO: Adjust the tests to work with the new implementation
    # TODO: Check if possible to refactor and add missing docs
