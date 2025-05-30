# Python does automatic memory management (reference counting for
# most objects and garbage collection to eliminate cycles). The memory is
# freed shortly after the last reference to it has been eliminated.
#
# This approach works fine for most applications but occasionally there is
# a need to track objects only as long as they are being used by something
# else.  Unfortunately, just tracking them creates a reference that makes
# them permanent. The weakref module provides tools for tracking objects
# without creating a reference. When the object is no longer needed, it is
# automatically removed from a weakref table and a callback is triggered
# for weakref objects. Typical applications include caching objects that
# are expensive to create:

import weakref, gc


class A:
    def __init__(self, value):
        self.value = value

    def __repr__(self):
        return str(self.value)


a = A(10)  # create a reference
d = weakref.WeakValueDictionary()
d['primary'] = a  # does not create a reference
print(d['primary']) # fetch the object if it is still alive
del a  # remove the one reference
gc.collect()  # run garbage collection right away
print(d['primary']) # entry was automatically removed
