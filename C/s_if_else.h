//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_IF_ELSE_H
#define C_S_IF_ELSE_H

#endif //C_S_IF_ELSE_H

#include "stdio.h"


// IF STATEMENTS

// Create a function that evaluates the max number.
int max_(int number1, int number2, int number3){
    int result;

    // "&&" means boolean operator AND
    if(number1 >= number2 && number1 >= number3){
        result = number1;
    }
    else if(number2 >= number1 && number2 >= number3){
        result = number2;
    }
    else{
        result = number3;
    }
    return result;
}


void if_else_funct(){
    printf("The biggest number is: %d\n", max_(20, 30, 5));

    // Shorter way to write If Else statement
    // variable = (condition) ? expressionTrue : expressionFalse;
    int time = 20;
    int result = (time < 18) ? 1 : 0;
    printf("Shorter if else: %d\n", result);
}


