from functools import wraps
import logging

# logging can be for example used to check how many times a specific function
#   has been run and what parameters were inputted inside.

# By default, informational and debugging messages are suppressed
#   and the output is sent to standard error.
# If you uncomment this, the decorator function below will not work in this
# file
"""logging.debug('Debugging information')
logging.info('Informational message')
logging.warning('Warning:config file %s not found', 'server.conf')
logging.error('Error occurred')
logging.critical('Critical error -- shutting down')
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
            f"{original_function.__name__}"),
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

    print(sum_all_numbers(*(1, 2, 3, 4, 5, 6)))
