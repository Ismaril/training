//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_ARRAYS_H
#define C_S_ARRAYS_H

#endif //C_S_ARRAYS_H


// ARRAYS
void arrays_fnc() {
    int lucky_numbers[] = {4, 5, 6, 0, 44, 600, -4}; // assigning new values to an array
    lucky_numbers[0] = 2000; // updating values in existing array
    printf("%d\n", lucky_numbers[0]);

    // specifying limit of indexes in front, meaning max number of items inside is 10 here
    int some_numbers[10];
    some_numbers[1] = 300;
    some_numbers[0] = 4000;
    printf("%d %d\n", some_numbers[0], some_numbers[1]);


    // loop through an array
    int i;
    int some_array[] = {1, 2, 3, 4, 5};

    // Get length of an array by getting its full size in bytes and dividing
    //    it by size of one item.
    int array_length = sizeof(some_array) / sizeof(some_array[0]);

    for (i = 0; i < array_length; i++){
        printf("%d\n", some_array[i]);
    }

    // 2D ARRAYS AND NESTED LOOPS
    // You have to specify number of elements in each axis
    // in square brackets.
    int two_dim_array[3][2] = {{10, 20},
                               {30, 40},
                               {50, 60}};
    printf("%d\n", two_dim_array[2][1]);

    int m, n; // possible to have two variables in one row
    for (m = 0; m < 3; m++) {
        for (n = 0; n < 2; n++) {
            printf("%d\n", two_dim_array[m][n]);
        }
    }

}
