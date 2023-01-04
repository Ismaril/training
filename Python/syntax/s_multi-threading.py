# The syntax threading and multiprocessing is very similar.

# Threading is often used when we work with IO. (input output)
# This means that the code does not necessarily start in parallel,
# but rather checks if some code is idling. If the code is idling,
# it then moves to the next piece of program in execution order while
# the first program still works at the background.

# Multithreading vs Multiprocessing
# Use threading when you wait for input output.
# Use multiprocessing when you are doing heavy CPU computations.

# + all threads within process share the same memory
# + light weight
# + starting a thread is faster than starting a process
# + great for IO tasks

# - threading is limited bz GIL - only one thread at a time
# - no effect on CPU bound task
# - not killable
# - be careful of race condition (like when the same variable
# is changed by two threads at the same time)

import sys
import threading
import time
import concurrent.futures
from Python.utilities.separate_text_stdout import SeparateText

sep = SeparateText()
start = time.perf_counter()


# you would have to use some other methods from threading in order to get
# return value from the function you are inputting into thread. Actually
# below on this page, it is explained how you can get the return value
# with "concurrent.futures.ThreadPoolExecutor()"


def wait_for_second(seconds):
    print(f'starting sleeping for {seconds} sec')
    time.sleep(seconds)
    print('done sleeping')


# pass in function without parentheses, that is the reason we have
# also args parameter, to input parameters into target function which is
# without parentheses
t1 = threading.Thread(target=wait_for_second, args=(1,))
t2 = threading.Thread(target=wait_for_second, args=(1,))

# start the wait_for_second functions via threading
t1.start()
t2.start()
# let the wait_for_second functions finish before we
# move to the code, which lies below
t1.join()
t2.join()

end = time.perf_counter()

print(f"Finished in {end - start:.2f}s")
print(sep.separator())

start = time.perf_counter()

# Write threading with loops
threads = []
for _ in range(4):
    t = threading.Thread(target=wait_for_second, args=[1])
    t.start()
    threads.append(t)

for thread in threads:
    thread.join()

end = time.perf_counter()
print(threads)
print(f"Finished in {end - start:.2f}s")
print(sep.separator())


# the same function as above, but now with return value
def wait_for_second(seconds):
    print(f'starting sleeping for {seconds} sec')
    time.sleep(seconds)
    return 'done sleeping, ThreadPoolExecutor'


# Do the same as above, but with less code
with concurrent.futures.ThreadPoolExecutor() as executor:
    f1 = executor.submit(wait_for_second, 1)
    print(f1.result())
