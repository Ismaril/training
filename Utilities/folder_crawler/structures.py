from dataclasses import dataclass
import os

@dataclass
class ItemType:
    FILES = "files"
    FOLDERS = "folders"
    PARAMETERS = "parameters"
    SKIPPED = "skipped_items"


@dataclass
class SavedCrawlsPath:
    SAVED_CRAWLS_FOLDER = "saved_crawls"
    EXTENSION = ".txt"
    FILES = os.path.join(SAVED_CRAWLS_FOLDER, f"{ItemType.FILES}{EXTENSION}")
    FOLDERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{ItemType.FOLDERS}{EXTENSION}")
    SKIPPED = os.path.join(SAVED_CRAWLS_FOLDER, f"{ItemType.SKIPPED}{EXTENSION}")
    PARAMETERS = os.path.join(SAVED_CRAWLS_FOLDER, f"{ItemType.PARAMETERS}{EXTENSION}")


@dataclass
class ExceptionMessages:
    ERR_COMPUTING_SIZE = "ERROR COMPUTING THE SIZE. EXCEPTION: "
    INVALID_SIGN = "INVALID SIGN!"


@dataclass
class Messages:
    DEEP_CRAWL = "Crawling - Going deep into sub-folders. The process may take a while."
    SHALLOW_CRAWL = "Crawling - Staying in the inputted folder. The process may take a while."
    NR_OF_DATA_CRAWLED = "NUMBER OF DATA CRAWLED:"
    NR_OF_SKIPPED_ITEMS = "NUMBER OF SKIPPED ITEMS:"
    NR_OF_LISTED_ITEMS = "NUMBER OF LISTED"
    WHOLE_PROCES_TOOK = "THE WHOLE PROCESS TOOK:"
    SAVING_RESULTS = "Saving the results into txt files."
    DONE_CRAWLING = "DONE CRAWLING"
    STARTED_CRAWLING = "STARTED CRAWLING"
    PRINT_ENDING = f"\n{'-' * 150}\n"


@dataclass
class FileOps:
    ENCODING = "UTF-8"
    READ_MODE = "r"
    READ_PLUS_MODE = "r+"
    WRITE_MODE = "w"
    WRITE_PLUS_MODE = "w+"
    APPEND_MODE = "a"


@dataclass
class EqualitySign:
    BIGGER_OR_EQUAL = ">="
    SMALLER_OR_EQUAL = "<="
    BIGGER = ">"
    SMALLER = "<"
    EQUAL = "=="
    NOT_EQUAL = "!="