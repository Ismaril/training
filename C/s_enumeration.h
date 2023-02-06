//
// Created by lazni on 22.01.2023.
//

#ifndef C_S_ENUMERATION_H
#define C_S_ENUMERATION_H

#endif //C_S_ENUMERATION_H

#include "stdio.h"

void enumeration() {
    // An enum is a special type that represents a group of constants (unchangeable values).
    // To create an enum, use the enum keyword, followed by the name of the enum,
    //  and separate the enum items with a comma:
    enum Level {
        LOW, // default value 0
        MEDIUM, // default value 1
        HIGH // default value 2
    };

    // Note that the last item does not need a comma.
    // It is not required to use uppercase, but often considered as good practice.
    // Enum is short for "enumerations", which means "specifically listed".

    // To access the enum, you must create a variable of it.
    // Inside the main() method, specify the enum keyword,
    // followed by the name of the enum (Level) and then the name of the enum variable (myVar in this example):
    enum Level myVar1;

    // Now that you have created an enum variable (myVar), you can assign a value to it.
    // The assigned value must be one of the items inside the enum (LOW, MEDIUM or HIGH):
    enum Level myVar2 = MEDIUM;

    // By default, the first item (LOW) has the value 0, the second (MEDIUM) has the value 1, etc.
    // If you now try to print myVar, it will output 1, which represents MEDIUM:
    printf("%d\n", myVar2);


    // CHANGE VALUES
    // Iinstead of default ones assign your values
    enum Level2 {
        CONST1 = 25,
        CONST2 = 50,
        CONST3 = 75
    };
    printf("%d\n", CONST2); // Now outputs 50

    // Note that if you assign a value to one specific item, the next items will update their numbers accordingly.
    // If you assigned it previously like this it would increment it accordingly:
    //  enum Level {
    //    LOW = 5,
    //    MEDIUM, // Now 6
    //    HIGH // Now 7
    //  };


    // Enum in a Switch Statement
    // Enums are often used in switch statements to check for corresponding values:
    enum States {
        SMALLEST = 1,
        MED,
        HIGHEST
    };


    enum Level my_variable = MED;

    switch (my_variable) {
        case 1:
            printf("Low Level\n");
            break;
        case 2:
            printf("Medium level\n");
            break;
        case 3:
            printf("High level\n");
            break;
    }

    // WHY AND WHEN TO USE ENUMS?
    // Enums are used to give names to constants, which makes the code easier to read and maintain.
    // Use enums when you have values that you know aren't going to change,
    // like month days, days, colors, deck of cards, etc.
}
