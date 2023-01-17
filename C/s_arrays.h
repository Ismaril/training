//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_ARRAYS_H
#define C_S_ARRAYS_H

#endif //C_S_ARRAYS_H


// ARRAYS
void arrays_fnc(){
    int lucky_numbers[] = {4, 5, 6, 0, 44, 600, -4}; // assigning new values to an array
    lucky_numbers[0] = 2000; // updating values in existing array
    printf("%d\n", lucky_numbers[0]);

    // specifying limit of indexes in front, meaning max number of items inside is 10 here
    int some_numbers[10];
    some_numbers[1] = 300;
    some_numbers[0] = 4000;
    printf("%d %d\n", some_numbers[0], some_numbers[1]);

    // loop through an array
    short i;
    for (i = 0; )
}
