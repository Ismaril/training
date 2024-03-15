import os


class FolderCrawler:
    """
    This class is used to crawl through the folder and its subfolders and store the files and folders in the respective lists.
    It also provides methods to print the files and folders and filter them based on the filter_ parameter.
    """

    def __init__(self, path):
        """
        This is the constructor of the FolderCrawler class.
        :param path: Path of the folder to be crawled.
        """
        self.path = path
        self.files = []
        self.folders = []
        self.files_and_folders = self.folders + self.files

    def crawl(self):
        """
        This method is used to crawl through the folder and its
        subfolders and store the files and folders in the respective lists.
        :return: None
        """
        for root, dirs, files in os.walk(self.path):
            for file in files:
                self.files.append((os.path.join(root, file),
                                   f"Bytes: {os.path.getsize(os.path.join(root, file))}"))
            for folder in dirs:
                # todo: implement the size of the folder
                self.folders.append(os.path.join(root, folder))

    def print_files(self):
        """
        This method is used to print the files in the folder and its subfolders.
        :return: None
        """
        print("Number of listed files", len(self.files))
        for file in self.files:
            print(file)

    def print_folders(self):
        """
        This method is used to print the folders in the folder and its subfolders.
        :return: None
        """
        print("Number of listed folders", len(self.folders))
        for folder in self.folders:
            print(folder)

    def filter(self, filter_files=False, filter_folders=False, filter_: str = None):
        """
        This method is used to filter the files and folders based on the filter_ parameter.
        :param filter_files: If True, the files will be filtered.
        :param filter_folders: If True, the folders will be filtered.
        :param filter_: String to filter the files and folders.
        :return: None
        """
        assert filter_files or filter_folders, "At least one of the filter_files or filter_folders must be True."

        if filter_files:
            for file in self.files:
                if filter_.lower() in file.lower():
                    print(file)
        if filter_folders:
            for folder in self.folders:
                if filter_.lower() in folder.lower():
                    print(folder)


if __name__ == '__main__':
    cr = FolderCrawler(r"C:\Users\lazni\Desktop\A")
    cr.crawl()
    cr.print_files()
    # cr.print_folders()
    # cr.filter(filter_files=True, filter_= "txt")
