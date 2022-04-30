"""
There are 3 basic ways how to fix it.

1. Make the import only in the function that needs the import.
    - this can be used when the function is lets say the only one that needs that module

2. Import modules at global scale (in files that have circular dependencies) like this:
    inside file_1: import module_2 | inside file_2 import: module_1
    Do that ↑ instead of from module import... or import module.function as funct ...

3. Put the two modules together
    - not recommended if the modules should really stay separated for some reason
"""