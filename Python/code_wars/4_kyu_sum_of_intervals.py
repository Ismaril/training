# solution written by Pieter Siegel

# Write a function called sumIntervals/sum_intervals() that accepts an array of intervals, and returns the
# sum of all the interval lengths. Overlapping intervals should only be counted once.

# Examples:
# sumIntervals( [
#    [1,2],
#    [6, 10],
#    [11, 15]
# ] ); // => 9
#
# sumIntervals( [
#    [1,4],
#    [7, 10],
#    [3, 5]
# ] ); // => 7
#
# sumIntervals( [
#    [1,5],
#    [10, 20],
#    [1, 6],
#    [16, 19],
#    [5, 11]
# ] ); // => 19

def sum_of_intervals(intervals):
    start = 0
    end = 0
    sum_ = 0
    for i, interval in enumerate(sorted(intervals)):
        start_new = interval[0]
        end_new = interval[1]
        if i == 0:
            start = start_new
            end = end_new
            continue

        if start_new > end:
            sum_ += end - start
            start = start_new
            end = end_new
        elif end_new < end:
            continue
        else:
            end = end_new

    sum_ += end - start

    return sum_
