//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_FOR_WHILE_LOOPS_H
#define C_S_FOR_WHILE_LOOPS_H

#endif //C_S_FOR_WHILE_LOOPS_H


// WHILE, FOR & DO LOOPS
// While loop check the condition before it continues to the code.
// Do loop does the code first and then checks the condition.
// For loop does the same thing as while loop. It is just shorter syntax.

void loops() {
    // While loop
    int index = 0;
    while (index <= 5) {
        printf("Looping 'WHILE'...%d\n", index);

        // Below code is incremented by one. Just like this would also
        // work -> index = index + 1;
        index++;
    }

    // Do loop
    index = 0;
    do {
        printf("Looping 'DO'...%d\n", index);
        index++;
    } while (index <= 5);

    // For loop
    for (index = 0; index <= 5; index++) {
        printf("Looping 'FOR'...%d\n", index);
    }

    int numbers[] = {10, 20, 30, 40, 50, 60};
    for (index = 0; index < 6; index++) {
        printf("Lucky number - %d\n", numbers[index]);
    }

    // 2D ARRAYS AND NESTED LOOPS
    // You have to specify number of elements in each axis in square brackets.
    int two_dim_array[3][2] = {{1, 2},
                               {3, 4},
                               {5, 6}};
    printf("%d\n", two_dim_array[2][1]);

    int i, j; // possible to have two variables in one row
    for (i = 0; i < 3; i++) {
        for (j = 0; j < 2; j++) {
            printf("%d\n", two_dim_array[i][j]);

        }
    }

    // BREAK, CONTINUE
    // Continue - breaks of current iteration
    // Break - breaks of complete loop
    // This code does not make much sense. Only the
    //    syntax of break and continue is important.
    int l;
    for (l = 0; l < 10; l++) {
        if (l < 3) {
            continue;
        } else if (l == 8) {
            break;
        } else {
            printf("Number: %d\n", l);
        }
    }
}