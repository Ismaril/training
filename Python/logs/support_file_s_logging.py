import logging

logger = logging.getLogger(name=__name__)

# by default this is True, but if you set it to False,
#   this logger will not output anything when you import
#   it somewhere else
logger.propagate = True

# create handler
stream_handler = logging.StreamHandler()
file_handler = logging.FileHandler('support_file_s_logging.log')

# set level (by level we mean from which level the message gets printed)
# and format
stream_handler.setLevel(level=logging.WARNING)
file_handler.setLevel(level=logging.ERROR)

formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
stream_handler.setFormatter(formatter)
file_handler.setFormatter(formatter)

logger.addHandler(stream_handler)
logger.addHandler(file_handler)

# logger.warning("this is a warning")
# logger.error("this is a error")