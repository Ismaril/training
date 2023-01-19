//
// Created by lazni on 17.01.2023.
//

#ifndef C_S_FUNCTIONS_H
#define C_S_FUNCTIONS_H

#endif //C_S_FUNCTIONS_H


// FUNCTIONS
// DECLARATION - the function's name, return type, and parameters (if any)
// DEFINITION - the body of the function (code to be executed)
// void myFunction() { // declaration
//    // the body of the function (definition)
// }

// VOID means that the function will not return anything.
// PARAMETER is here char name[20]
// ARGUMENT will be the string that is going to be equal to parameter.
//   arguments must be passed in the same order as parameters
// All functions have to end up in main() in order to be finally executed
void some_function(char name[20], int age) {
    printf("Hello %s, you are %d\n", name, age);
}

// PROTOTYPE (=define function later)
// You have to define functions above the place, where you're going to call it. If that is
//  not possible, use "prototype", meaning declare the head of the function in advance
//  and define its body later.

// Good practise to organise the code like this:
// // Function declaration
// void myFunction();
//
// // The main method
// int main() {
//    myFunction();  // call the function
//    return 0;
// }
//
// // Function definition
// void myFunction() {
//     printf("I just got executed!");
// }


int square_number(int number);

int cube_number(int number){
    return number * number * number;
}

 // this is the prototyped function from above
int square_number(int number){
    return number * number;
}

// RECURSION
// Sums all the numbers leading to the one inputted as argument.
int sum_all_numbers(int number){
    if(number > 0){
        return number + sum_all_numbers(number - 1);
    }
}