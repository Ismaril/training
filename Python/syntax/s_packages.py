# Package: Is a collection of modules
# Some example:

# sound/                          Top-level package
#       __init__.py               Initialize the sound package
#       formats/                  Subpackage for file format conversions
#               __init__.py
#               wavread.py
#               wavwrite.py
#               aiffread.py
#               aiffwrite.py
#               auread.py
#               auwrite.py
#               ...
#       effects/                  Subpackage for sound effects
#               __init__.py
#               echo.py
#               surround.py
#               reverse.py
#               ...
#       filters/                  Subpackage for filters
#               __init__.py
#               equalizer.py
#               vocoder.py
#               karaoke.py
#               ...

###############################################################################
# Example how to load a function:
# sound.effects.echo.echofilter(input, output, delay=0.7, atten=4)

###############################################################################
# Example how the author of package can reduce the number of loaded stuff
#   when end users uses *
# __all__ = [module1, ..., module_n]

# from XXX import *

###############################################################################
# import by dots if the package has subpackages
# from ... import name_you_want_to_import

