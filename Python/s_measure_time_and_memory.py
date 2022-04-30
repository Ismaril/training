import tracemalloc
import time

# perhaps the code will need some more checking or whateva
# source is here:
# https://www.analyticsvidhya.com/blog/2021/01/
# python-code-performance-measurement-measure-the-right-metric-to-optimize-better/


# define
def tracing_start():
    tracemalloc.stop()
    print("nTracing Status : ", tracemalloc.is_tracing())
    tracemalloc.start()
    print("Tracing Status : ", tracemalloc.is_tracing())


def tracing_mem():
    first_size, first_peak = tracemalloc.get_traced_memory()
    peak = first_peak/(1024*1024)
    print("Peak Size in MB - ", peak)


# perform
tracing_start()
start = time.time()

for elem in range(1, 1000):
    print(elem)

end = time.time()
tracing_mem()

print(f"time elapsed {end-start} seconds")
