#include <stdio.h>  // import standard input/output
#include <stdlib.h> // import standard library
#include <math.h> // import math library

// SOME BASIC COMMANDS IN C
// Training of C started on 2.1.2023


// DRAWING A SHAPE
// here, by // is meant escape character of '/' and
//  next one is '/n' as a new line
//int main()
//{
//    printf("|\\\n");
//    printf("| \\\n");
//    printf("|  \\\n");
//    printf("|___\\\n");
//    return 0;
//}


// VARIABLES
//int main()
//{
//    // [] means that the char variable can
//    // store multiple characters
//    char name[] = "Tom";
//    int age = 26;
//
//    printf("There was a man called %s.\n", name);
//    printf("That man was %d.\n", age);
//    printf("He liked the name %s.\n", name);
//    printf("But disliked being %d.\n", age);
//
//    age = 30;
//    printf("The best age is %d", age);
//    return 0;
//}
//

// DATA TYPES
//int age = 50;
//double gpa = 3.5;
//char one_letter = 'A';  // has to be single quotes for only one character

// // double quotes for multiple characters
// // actually char variable[] is an array fyi...
//char phrase[] = "This is a phrase";
//
//int main(){
//    printf("%d\n", age);
//    printf("age: %d and letter: %c\n", age, one_letter);
//    printf("%f\n", gpa);
//    printf("%c\n", one_letter);
//    printf("%s\n", phrase);
//    return 0;
//}


// NUMBERS
//int main(){
//    printf("%f\n", 2.3 + 1.7);
//    printf("%f\n", 2.0 * 3.0);
//    printf("%f\n", 2 * 3.0); // decimal with float will result in float
//    printf("%d\n", 10 / 5); // will result in decimal
//    printf("%f\n", pow(2, 3));
//    printf("%f\n", sqrt(144));
//    printf("%f\n", ceil(45.1));
//    printf("%f\n", floor(35.9));
//    return 0;
//}


// COMMENTS
// This is a one line comment
/*
 * This is a multiline comment,
 * got it?
 *
 * End below it ends
 */


// CONSTANTS
// immutable objects like user defined immutable variables, or strings...
//const int THIS_IS_CONSTANT = 3;
//
//int main(){
//    printf("Printing constant %d\n", THIS_IS_CONSTANT);
//
//    // This will not work:
//    //    THIS_IS_CONSTANT = 6;
//    //    printf("Printing constant %d\n", THIS_IS_CONSTANT);
//    return 0;
//}


// INPUT
//int main(){
//    int age;
//    printf("Enter your age:");
//    scanf("%d", &age);
//    printf("You are %d years old.", age);
//
//    // With this setting, when you input a string with space, it will print out only
//    // a string before a space, rest will be omitted.
//    char name[20];
//    printf("Enter your name:");
//    scanf("%s", name);
//    printf("Your name is %s", name);

//    char full_name[20];
//    // Include whole string in a variable with function fgets
//    printf("Enter your whole name:");
//    fgets(full_name, 20, stdin); // fgets(variable, number_of_chars, where_to_output_it)
//    printf("Your whole name is %s", full_name);

//    return 0;
//}


// BASIC CALCULATOR
//int main(){
//    double num1;
//    double num2;
//
//    // If you work with %d, %f, %c ... use "&" to reference correctly back to variable
//    // Usually if you use float string formatting you use "%f" but when you are awaiting
//    //     user input you have to use "%lf"
//    printf("Enter first number: ");
//    scanf("%lf", &num1);
//    printf("Enter second number: ");
//    scanf("%lf", &num2);
//    printf("Result is: %f", num1 + num2);
//    return 0;
//
//}


// MAD LIBS GAME
//int main() {
//    char color[20];
//    char plural_noun[20];
//    char celebrity_first_name[20];
//    char celebrity_second_name[20];
//
//    printf("Enter a color: ");
//    scanf("%s", color);
//    printf("Enter a plural noun: ");
//    scanf("%s", plural_noun);
//    printf("Enter a celebrity (first and last name): ");
//    scanf("%s%s", celebrity_first_name, celebrity_second_name);
//
//    printf("Roses are %s\n", color);
//    printf("%s are blue\n", plural_noun);
//    printf("I love %s %s\n", celebrity_first_name, celebrity_second_name);
//    return 0;
//}


// ARRAYS
//int main() {
//    int lucky_numbers[] = {4, 5, 6, 0, 44, 600, -4}; // assigning new values to an array
//    lucky_numbers[0] = 2000; // updating values in existing array
//    printf("%d\n", lucky_numbers[0]);
//
//    // specifying limit of indexes in front, meaning max number of items inside is 10 here
//    int some_numbers[10];
//    some_numbers[1] = 300;
//    some_numbers[0] = 4000;
//    printf("%d %d\n", some_numbers[0], some_numbers[1]);
//    printf("%d", some_numbers[]);
//    return 0;
//}


// FUNCTIONS
// All functions have to end up in main() in order to be finally executed

// Void means that the function will not return anything.
// Notice that we also specify function parameters here.
//void some_function(char name[20], int age){
//    printf("Hello %s, you are %d\n", name, age);
//}
//
//int main(){
//    printf("Executing first\n");
//    some_function("Tom", 26);
//    some_function("Dude", 40);
//    some_function("Martina", 25);
//    printf("Executing last\n");
//    return 0;
//}


// RETURN
// You have to define functions above the place, where you gonna call it. If that is
//  not possible, use "prototype", meaning declare the head of the function in advance
//  and define its body later.
//int square_number(int number);
//
//int cube_number(int number){
//    return number * number * number;
//}
//
//int main(){
//    printf("%d\n", cube_number(2));
//    printf("%d\n", square_number(2));
//    return 0;
//}
//
// // this is the prototyped function from above
//int square_number(int number){
//    return number * number;
//}


// IF STATEMENTS
// Create a function that evaluates the max number.
//int max_(int number1,
//         int number2,
//         int number3){
//    int result;
//
//    // "&&" means boolean operator AND
//    if(number1 >= number2 && number1 >= number3){
//        result = number1;
//    }
//    else if(number2 >= number1 && number2 >= number3){
//        result = number2;
//    }
//    else{
//        result = number3;
//    }
//    return result;
//}
//
// // Seems like True and False are evaluated as 1 and 0 in C.
//int OR_operator(int num1, int num2){
//    return 1 > num1 || num2 > 0;
//}
//int main(){
//    printf("The biggest number is: %d\n", max_(20, 30, 5));
//    printf("Bollean OR operator %d\n", OR_operator(5, 5));
//    return 0;
//}


// BOOLEAN OPERATORS


// BETTER CALCULATOR
//void calculator(double number1, char operator, double number2) {
//    if (operator == '+') {
//        printf("%f\n", number1 + number2);
//    } else if (operator == '-') {
//        printf("%f\n", number1 - number2);
//    } else if (operator == '/') {
//        printf("%f\n", number1 / number2);
//    } else if (operator == '*') {
//        printf("%f\n", number1 * number2);
//    } else {
//        printf("%s\n", "Not valid operator");
//    }
//
//}
//
//int main() {
//    calculator(2.0, '/', 2.0);
//    calculator(2.0, '*', 2.0);
//    calculator(2.0, '+', 2.0);
//    calculator(2.0, '-', 2.0);
//    calculator(2.0, 'x', 2.0);
//    return 0;
//}


// SWITCH STATEMENT
// It is basically the same as match case in python
//int main() {
//    char grade = 'E';
//
//    switch (grade) {
//        case 'A':
//            printf("%s\n", "You have the best mark");
//            break;
//        case 'B':
//            printf("%s\n", "You have the second best mark");
//            break;
//        case 'C':
//            printf("%s\n", "You have the average mark");
//            break;
//        case 'D':
//            printf("%s\n", "You have the second worst mark");
//            break;
//        case 'E':
//            printf("%s\n", "You have the worst mark");
//            break;
//        // default is going to execute if no match above. It is basically an else.
//        default:
//            printf("%s", "You have to enter mark A-E");
//    }
//    return 0;
//}



