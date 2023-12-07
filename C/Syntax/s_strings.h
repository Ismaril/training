//
// Created by lazni on 18.01.2023.
//

#ifndef C_S_STRINGS_H
#define C_S_STRINGS_H

#endif //C_S_STRINGS_H

#include "stdio.h"
#include "string.h"

void strings() {
    // Strings are used for storing text/characters.
    // For example, "Hello World" is a string of characters.
    // Unlike many other programming languages, C does not have a
    //     String type to easily create string variables.
    //     Instead, you must use the char type and create
    //     an array of characters to make a string in C:

    char greetings[] = "Hello World!\n";

    // It is possible to change the value of a string at a given index.
    greetings[0] = 'J';
    printf("%s", greetings);
    // Outputs Jello World! instead of Hello World!

    // Looping
    char brand[] = "Ferrari";
    int i;
    for (i = 0; i < 7; i++) {
        printf("%c\n", brand[i]);
    }

    // How strings are actually created
    // Each character actually represent one index position in
    //    an array, terminated with '\0'
    char greet[] = {'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!', '\0'};
    char greet2[] = "Hello World!";

    printf("%llu\n", sizeof(greet));   // Outputs 13
    printf("%llu\n", sizeof(greet2));  // Outputs 13

    // Escape characters (most common)
    // You can find the rest on the internet
    // Every character that is behind "\" is going to be
    //    used as escape character
    printf("Hello\nblabla \" \\ \' \n");

    // STRING FUNCTIONS
    // todo: write down all of them
    // length of string
    char alphabet[] = "abcdef";
    printf("characters: %llu\n", strlen(alphabet));
    printf("bytes: %llu\n", sizeof(alphabet));

    // concatenate strings
    char str1[] = "Hello";
    char str2[] = "World";
    printf("%s\n", strcat(str1, str2));
    printf("str1 %s\n", str1);
    printf("str2 %s\n", str2);

    // copy strings
    char str3[] = "Meeen";
    char str4[10];
    strcpy(str4, str3);
    printf("str3 %s\n", str4);

    // compare strings
    // If strcmp returns 0, then strings are equal
    printf("%d\n", strcmp(str1, str2));
    printf("%d\n", strcmp(str3, str4));


}
