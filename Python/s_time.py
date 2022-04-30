import time
from utilities.separate_rows_in_training_files import SeparateCode

separator = SeparateCode()

# NOTE
# "epoch" = time initial time that computer knows. Usually something like 1970...
# seems like the datetime module is better for working with time, nevertheless time module has still something
#   useful

# check what's inside
print(dir(time))

print(separator.separator())

# ctime
# check the readable version of current time
# with argument 0 in ctime check when is the beginning of time for the pc
print(f"{time.ctime() = }")

print(separator.separator())

# time
# measure how much time has passed since epoch
print(f"{time.time() = }", "seconds")

print(separator.separator())

# localtime
time_object = time.localtime()
print(time_object)

print(separator.separator())

# perf_counter
# - measure time which your program takes to run
limit = 1e8
start = time.perf_counter()
res1 = (_ for _ in range(int(limit)))
stop = time.perf_counter()
print(f"{stop-start:.6f}", "generator - performance in seconds")

start = time.perf_counter()
res2 = {_ for _ in range(int(limit))}
stop = time.perf_counter()
print(f"{stop-start:.4f}", "set comp - performance in seconds")

start = time.perf_counter()
res3 = [_ for _ in range(int(limit))]
stop = time.perf_counter()
print(f"{stop-start:.4f}", "list comp - performance in seconds")

print(separator.separator())

# sleep
print("Executed line")
time.sleep(4)
print("Executed line after sleep method")