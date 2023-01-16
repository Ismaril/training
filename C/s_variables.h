//
// Created by lazni on 10.01.2023.
//

#ifndef C_S_VARIABLES_H
#define C_S_VARIABLES_H

#endif //C_S_VARIABLES_H

#include <stdio.h>

void variables() {

    // VARIABLE SYNTAX
    // type variableName = value;

    int myNum = 15;

    // Declare a variable only at first.
    int myNum_2;
    // Assign a value to the variable later.
    myNum_2 = 30;
    printf("myNum %d\n", myNum);
    printf("myNum_2 %d\n", myNum_2);

    // Change variable (variable must be already defined earlier)
    myNum_2 = 20;
    printf("myNum_2 %d\n", myNum_2);

    // Assign already existing variable to new variable.
    int myNum_3 = 23;
    myNum = myNum_3;
    printf("myNum %d\n", myNum);

    // Add two variables together.
    int x = 4;
    int y = 6;
    int sum = x + y;
    printf("sum %d\n", sum);

    // Declare multiple variables.
    int a = 2, b = 5, c = 40;
    printf("sum of a = 2, b = 5, c = 40 equals %d\n", a + b + c);

    int aa, bb, cc;
    aa = bb = cc = 50;
    printf("%d %d %d\n", aa, bb, cc);

    // VARIABLE NAME CONVENTIONS
    // todo: checkout this more
    // Names can contain letters, digits and underscores
    // Names must begin with a letter or an underscore (_)
    // Names are case sensitive (myVar and myvar are different variables)
    // Names cannot contain whitespaces or special characters like !, #, %, etc.
    //         Reserved words (such as int) cannot be used as names

    // Student data
    int studentID = 15;
    int studentAge = 23;
    float studentFee = 75.25;
    char studentGrade = 'B';

    // Print variables
    printf("Student id: %d\n", studentID);
    printf("Student age: %d\n", studentAge);
    printf("Student fee: %f\n", studentFee);
    printf("Student grade: %c\n", studentGrade);

    // [] means that the char variable can
    // store multiple characters
    char name[] = "Tom";
    int age = 26;
    printf("There was a man called %s.\n", name);
    printf("That man was %d.\n", age);
    printf("He liked the name %s.\n", name);
    printf("But disliked being %d.\n", age);
    age = 30;
    printf("The best age is %d\n", age);

}


