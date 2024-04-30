import os
import time


class FolderCrawler:
    """
    The FolderCrawler class is used to crawl through a folder and its subfolders (if specified) and store the files and
     folders in respective lists.
    It also calculates the size of each file and folder and stores it along with the file or folder path.
    The class provides methods to print the files and folders that were found during the crawling process, with options
     to print only files, only folders, or both, and to filter the files and folders based on a string.
    The class also provides a method to print the time taken for the crawling process.

    Attributes:
        path (str): The path of the folder that needs to be crawled.
        files (list): A list to store the files found during the crawling process.
        folders (list): A list to store the folders found during the crawling process.
        timer (float): The time when the crawling process starts.
    """

    def __init__(self, path):
        """
        This is the constructor method for the FolderCrawler class.
        It initializes the path, files, folders, files_and_folders, and timer attributes.

        :param path: The path of the folder that needs to be crawled.
        """
        self.path = path
        self.files = []
        self.folders = []
        self.timer = time.perf_counter()

        if not os.path.exists(self.path):
            raise FileNotFoundError

    def _crawl_files(self):
        """
        This method is used to crawl through the folder at the given path and store the files and folders in the
         respective lists.
        It uses the os.listdir method to get the list of files and folders in the folder.
        For each item in the list, it checks if the item is a folder or a file.
        If the item is a folder, it calculates the size of the folder and appends the folder path and size to the
         folders list.
        If the item is a file, it calculates the size of the file and appends the file path and size to the files list.

        :return: None
        """
        for item in os.listdir(self.path):
            item_path = os.path.join(self.path, item)
            if os.path.isdir(item_path):
                self.folders.append(item_path)
            else:
                self.files.append(item_path)

    def _crawl_files_and_sizes(self, crawl_deep=False):
        """
        This method is the main entry point for the crawling process.
        It decides whether to perform a deep crawl or a shallow crawl based on the crawl_deep parameter.
        If crawl_deep is True, it performs a deep crawl by calling the _crawl_go_deep method.
        If crawl_deep is False, it performs a shallow crawl by calling the _crawl_without_going_deeper method.

        :param crawl_deep: A boolean value that determines whether to perform a deep crawl or a shallow crawl.
         Default is False.
        :return: None
        """
        if crawl_deep:
            self._crawl_files_and_sizes_go_deep()
        else:
            self._crawl_files_and_sizes_without_going_deeper()

    def _crawl_files_and_sizes_without_going_deeper(self):
        """
        This private method is used to crawl through the folder at the given path and store the files and folders in the
         respective lists.
        It uses the os.listdir method to get the list of files and folders in the folder.
        For each item in the list, it checks if the item is a folder or a file.
        If the item is a folder, it calculates the size of the folder and appends the folder path and size to the
         folders list.
        If the item is a file, it calculates the size of the file and appends the file path and size to the files list.

        :return: None
        """
        for item in os.listdir(self.path):
            item_path = os.path.join(self.path, item)
            if os.path.isdir(item_path):
                self.folders.append((item_path, self._get_size(item_path, get_size_folder=True)))
            else:
                self.files.append((item_path, self._get_size(item_path, get_size_file=True)))

    def _crawl_files_and_sizes_go_deep(self):
        """
        This private method is used to crawl through the folder and its subfolders and store the files and folders in
         the respective lists.
        It uses the os.walk method to traverse the folder and its subfolders.
        For each file in the files list, it calculates the size of the file and appends the file path and size to the
         files list.
        For each folder in the dirs list, it calculates the size of the folder and appends the folder path and size to
         the folders list.

        :return: None
        """
        for root, dirs, files in os.walk(self.path):
            for file in files:
                file_path = os.path.join(root, file)
                self.files.append((file_path, self._get_size(file_path, get_size_file=True)))
            for folder in dirs:
                folder_path = os.path.join(root, folder)
                self.folders.append((folder_path, self._get_size(folder_path, get_size_folder=True)))

    def _get_size(self, path, get_size_file=False, get_size_folder=False):
        """
        This private method is used to calculate the size of a file or a folder.
        If get_size_file is True, it calculates the size of the file at the given path.
        If get_size_folder is True, it calculates the size of the folder at the given path by adding up the sizes of all
         the files in the folder and its subfolders.
        The size is returned as a string in a more readable format (converted by the _convert_size method) and in bytes.

        :param path: The path of the file or folder whose size needs to be calculated.
        :param get_size_file: A boolean value that determines whether to calculate the size of a file. Default is False.
        :param get_size_folder: A boolean value that determines whether to calculate the size of a folder. Default is
         False.
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
        return f"{self._convert_size(size)}, {size}B"

    @staticmethod
    def _convert_size(size):
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

    def _print_items(self, print_folders=True, print_files=True, filter_="", working_with_sizes=False):
        """
        This method is used to print the files and folders that were found during the crawling process.
        It also prints the number of files and folders that were listed.
        The method can be customized to print only files, only folders, or both.
        It can also filter the files and folders based on the filter_ parameter.
        At the end of the method, it calls the _show_time method to print the time taken for the crawling process.

        :param print_folders: A boolean value that determines whether to print the folders or not. Default is True.
        :param print_files: A boolean value that determines whether to print the files or not. Default is True.
        :param filter_: A string value that is used to filter the files and folders. Default is an empty string.
        :return: None
        """

        if print_files:
            self._print_files(filter_=filter_, working_with_sizes=working_with_sizes)
        if print_folders:
            self._print_folders(filter_=filter_, working_with_sizes=working_with_sizes)

        self._show_time()

    def _print_folders(self, default_color="\033[0m", filter_="", working_with_sizes=False):
        """
        This private method is used to print the folders that were found during the crawling process.
        It also prints the total number of folders that were listed.
        The method can be customized to filter the folders based on the filter_ parameter.

        :param default_color: A string value that represents the default color for the console output.
        :param filter_: A string value that is used to filter the folders. Default is an empty string.
        :return: None
        """
        number_of_folders = 0

        if working_with_sizes:
            for folder, size in self.folders:
                if f"{filter_}" in folder:
                    # Print the folder path, size, and reset the color to the default color
                    print(folder, size, default_color)
                    number_of_folders += 1
            print("Number of listed folders", number_of_folders)
        else:
            for folder in self.folders:
                if f"{filter_}" in folder:
                    print(folder)
                    number_of_folders += 1
            print("Number of listed folders", number_of_folders)

    def _print_files(self, default_color="\033[0m", filter_="", working_with_sizes=False):
        """
        This private method is used to print the files that were found during the crawling process.
        It also prints the total number of files that were listed.
        The method can be customized to filter the files based on the filter_ parameter.

        :param default_color: A string value that represents the default color for the console output.
        :param filter_: A string value that is used to filter the files. Default is an empty string.
        :return: None
        """
        number_of_files = 0

        if working_with_sizes:
            for file, size in self.files:
                # Check if the filter string is in the file path
                if f"{filter_}" in file:
                    # Print the file path, size, and reset the color to the default color
                    print(file, size, default_color)
                    number_of_files += 1
            print("Number of listed files", number_of_files)
        else:
            for file in self.files:
                if f"{filter_}" in file:
                    print(file)
                    number_of_files += 1
            print("Number of listed files", number_of_files)

    def _show_time(self):
        """
        This private method is used to calculate and print the time taken for the crawling process.
        It calculates the time difference between the current time and the time when the crawling process started.
        The time is printed in seconds with a precision of two decimal places.
        """
        print(f"Time taken to crawl: {time.perf_counter() - self.timer:.2f} seconds.")

    def crawl_item_names(self, print_files=True, print_folders=True, filter_=""):
        """
        This method is used to crawl through the folder at the given path, store the files and folders in the respective
         lists, and print the files and folders that were found during the crawling process.

        Args:
            crawl_deep:
            print_files:
            print_folders:
            filter_:

        Returns:

        """
        self._crawl_files()
        self._print_items(
            print_files=print_files,
            print_folders=print_folders,
            filter_=filter_,
            working_with_sizes=False
        )

    def crawl_item_names_and_sizes(self, crawl_deep=True, print_files=True, print_folders=True, filter_=""):
        """
        This method is used to crawl through the folder at the given path, store the files and folders in the respective
         lists, and print the files and folders that were found during the crawling process.
        Note that since the sizes of each item are calculated, the time to execute this method may be longer.


        Args:
            crawl_deep:
            print_files:
            print_folders:
            filter_:

        Returns:

        """
        self._crawl_files_and_sizes(crawl_deep=crawl_deep)
        self._print_items(
            print_files=print_files,
            print_folders=print_folders,
            filter_=filter_,
            working_with_sizes=True
        )


if __name__ == '__main__':
    cr = FolderCrawler(r"C:\Users\z003uxda\Desktop")
    cr.crawl_item_names_and_sizes(filter_="")
    print("\n")
    cr.crawl_item_names(filter_="")
