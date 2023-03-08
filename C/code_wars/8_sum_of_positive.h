/*
You get an array of numbers, return the sum of all of the positives ones.

Example [1,-4,7,12] => 1 + 7 + 12 = 20

Note: if there is nothing to sum, the sum is default to 0.
*/


#include <stddef.h>

int positive_sum(const int *values, size_t count){
    int result = 0;
    for (int i = 0; i < count; i++) {
        int item_from_array = values[i];
        if (item_from_array > 0) result += item_from_array;
    }
    return result;
};