# The syntax threading and multiprocessing is very similar.

# Process - an instance of program, like
# multiple opened internet explorers

# + takes advantage of CPUs and cores
# + separate memory space - memory is not shared between processes
# + great for CPU bound processing
# + new process is started independently of other processes
# + processes are killable
# + one GIL(global interreter lock) for each process - avoids GIL limitation

# - heavy weight
# - starting a process is slower then starting tread
# - needs more memory
# - inter-process communication is more complicated

# You can check in your desktop system task manager, all the parallel
# python processes, when you execute this code
import concurrent.futures
import multiprocessing
import time
from Python.utilities.separate_text_stdout import SeparateText


def do_something_(seconds):
    print(f'Sleeping {seconds} second(s)...')
    time.sleep(seconds)
    print(f'Done Sleeping...{seconds}')


def do_something(number):
    return number**number**number


# for some reason multiprocessing must be guarded by '__name__ == '__main__'',
# check why
if __name__ == '__main__':
    sep = SeparateText()
    start = time.perf_counter()
    p1 = multiprocessing.Process(target=do_something_, args=(1,))
    p2 = multiprocessing.Process(target=do_something_, args=(1,))

    p1.start()
    p2.start()

    p1.join()
    p2.join()
    finish = time.perf_counter()

    print(f'Finished in {round(finish - start, 2)} second(s)')
    print(sep.separator())

    start = time.perf_counter()
    with concurrent.futures.ProcessPoolExecutor() as executor:
        numbers = [n for n in range(5, 15)]
        results = executor.map(do_something, numbers)

        # here you can get the results, when using the map function
        # for result in results:
        #     print(result)

    finish = time.perf_counter()
    print(f'Finished in {round(finish - start, 2)} second(s)')
