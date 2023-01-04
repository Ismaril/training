import os.path
import sys
import time
from functools import wraps
import logging
from logging.handlers import RotatingFileHandler, TimedRotatingFileHandler
from Python.logs.support_file_s_logging import logger
from Python.constants import PYTHON_TRAINING_PARENT_DIR as PARENT

# logging can be for example used to check how many times a specific function
#   has been run and what parameters were inputted inside.

# By default, informational and debugging messages are suppressed
#   and the output is sent to standard error.
# If you uncomment this, the decorator function below will not work in this
# file

"""
# configure output of logging. (will apply for every logging method)
# by default, name of logger is 'root' but it is a good practise to make the
#   name of logger as the name of file/module
# setting level to logging.DEBUG will make sure that all messages
#   including debug and info will be printed
# check out more inf python docs

logging.basicConfig(level=logging.DEBUG,
                    format='%(asctime)s - %(name)s - %(levelname)s - %(message)s',
                    datefmt='%m/%d/%Y %H:%M:%S')
"""

"""
try:
    listos = [1, 2]
    print(listos[3])
except IndexError as error:
    logger.error(msg=error,  # this will print error message from Try/Except
                 exc_info=True)  # this will output also traceback

# this line will have name of the file from where it was imported
#   instead of root
logger.info("Some info")

logging.debug('Debugging information')
logging.info('Informational message')
logging.warning('Warning:config file %s not found', 'server.conf')
logging.error('Error occurred')
logging.critical('Critical error -- shutting down')
sys.exit()
"""

"""
def my_logger(original_function):
    import logging
    import os.path
    from Python.constants import PYTHON_TRAINING_PARENT_DIR as PARENT

    # set save location and type of logging (here info)
    logging.basicConfig(
        filename=os.path.join(
            PARENT,
            "logs",
            f"{original_function.__name__}.log"),
        level=logging.INFO)

    # wrapper due to decorator function
    # wraps updates the wrapper function to look like wrapped function
    #   by copying attributes such as __name__, __doc__ etc...
    @wraps(original_function)
    def wrapper(*args, **kwargs):
        logging.info(f"Ran with args: {args} and kwargs: {kwargs}")
        return original_function(*args, **kwargs)

    return wrapper


if __name__ == '__main__':
    @my_logger
    def sum_all_numbers(*args):
        return f"Result is: {sum(args)}"


    sum_all_numbers(*(1, 2, 3, 4, 5, 6))
    """

"""
logger_ = logging.getLogger(name=__name__)
logger_.setLevel(logging.INFO)

# create log files with max amount of their size (bytes) and keep the specified
#   count of that files, once all the files are full, roll over them again
#   and rewrite them
handler = RotatingFileHandler(os.path.join(
    PARENT, "logs", "your_app.log"),
    maxBytes=2000,
    backupCount=5)
logger_.addHandler(handler)

for _ in range(1000):
    logger_.info("this is an info")
"""

logger_ = logging.getLogger(name=__name__)
logger_.setLevel(logging.INFO)

# create log files and add to them new info each x amount of time
# this means here, each two seconds add a new record into log file
# s, m, h, d, midnight, w0 (w0 is monday fyi) ...etc
handler = TimedRotatingFileHandler(os.path.join(
    PARENT, "logs", 'timed_log.log'),
    when='s',
    interval=2,
    backupCount=3)
logger_.addHandler(handler)

for _ in range(5):
    logger_.info("this is an info message")
    time.sleep(1)
