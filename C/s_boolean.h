//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_BOOLEAN_H
#define C_S_BOOLEAN_H

#endif //C_S_BOOLEAN_H


// Need to import boolean library first
#include <stdbool.h>
#include <stdio.h>

bool is_programming_fun = true;
bool is_dig_big = false;

void booleans() {
    // Booleans return only 1 or 0

    int num = 0;
    // Return boolean values
    printf("%d\n", is_programming_fun);   // Returns 1 (true)
    printf("%d\n", is_dig_big);        // Returns 0 (false)

    // We can return boolean result just by comparison operator
    // Returns 1 (true) because 10 is greater than 9
    printf("Equality check: %d\n", 10 > 9);

    printf("Logical OR: %d\n", 10 > 9 || num == num);


}
