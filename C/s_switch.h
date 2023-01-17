//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_SWITCH_H
#define C_S_SWITCH_H

#endif //C_S_SWITCH_H
#include "stdio.h"

// SWITCH STATEMENT
// It is basically the same as match case in python
void switch_sttmnt() {
    short day_num = 1;

    switch (day_num) {
        case 1:
            printf("%s\n", "Monday");
            break;
        case 2:
            printf("%s\n", "Tuesday");
            break;
        case 3:
            printf("%s\n", "Wednesday");
            break;
        case 4:
            printf("%s\n", "Thursday");
            break;
        case 5:
            printf("%s\n", "Friday");
            break;
        case 6:
            printf("%s\n", "Saturday");
            break;
        case 7:
            printf("%s\n", "Sunday");
            break;

        // default is going to execute if no match above.
        // It is basically an else.
        default:
            printf("%s", "You have to enter number 1 - 7");
    }
}