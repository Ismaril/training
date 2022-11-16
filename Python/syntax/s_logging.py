import logging

# todo: check this module out more

# By default, informational and debugging messages are suppressed
#   and the output is sent to standard error.
logging.debug('Debugging information')
logging.info('Informational message')
logging.warning('Warning:config file %s not found', 'server.conf')
logging.error('Error occurred')
logging.critical('Critical error -- shutting down')
