//
// Created by lazni on 17.01.2023.
//

#ifndef C_UTILITIES_H
#define C_UTILITIES_H

#endif //C_UTILITIES_H
#include "stdio.h"

// Function that separates the rows by dashes
void separator(char name_of_block[20]) {
    int i;
    printf("\n%s", name_of_block);
    for (i= 0; i < (79 - strlen(name_of_block)); i++) {
        printf("-");
    }
    printf("\n");
}
