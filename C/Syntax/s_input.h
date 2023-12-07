//
// Created by lazni on 18.01.2023.
//

#ifndef C_S_INPUT_H
#define C_S_INPUT_H

#endif //C_S_INPUT_H

#include "stdio.h"

void input_user() {
    // Use the scanf() function to get a single word as input
    // use fgets() for multiple words.


    // Create an integer variable that will store the number we get from the user
    int myNum;

    // Ask the user to type a number
    printf("Type a number: \n");

    // Get and save the number the user types
    scanf("%d", &myNum);

    // Output the number the user typed
    printf("Your number is: %d\n", myNum);


    // MULTIPLE CHARACTER OR INTEGER INPUTS
    // Create an int and a char variable
    int myNum2;
    char myChar;

    // Ask the user to type a number AND a character
    printf("Type a number AND a character and press enter: \n");

    // Get and save the number AND character the user types
    scanf("%d %c", &myNum2, &myChar);

    // Print the number
    printf("Your number is: %d\n", myNum2);

    // Print the character
    printf("Your character is: %c\n", myChar);


    // STRING INPUT
    // Create a string
    char firstName[30];

    // Ask the user to input some text
    printf("Enter your first name: \n");

    // Get and save the text
    scanf("%s", firstName);

    // Output the text
    printf("Hello %s\n", firstName);


    // STRING INPUT WITH MORE WORDS
    // todo: seems like fgets(), gets ignored when there is some scanf()
    //  already written above. Check why.
    // scanf will stop reading a string if it encounters a whitespace
    char fullName[30];

    printf("Type your full name: \n");
    fgets(fullName, sizeof(fullName), stdin);

    printf("Hello %s\n", fullName);


}