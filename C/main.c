#include <stdio.h>  // import standard input/output
#include <stdlib.h> // import standard library
#include <math.h> // import math library

// SOME BASIC COMMANDS IN C
// Training of C started on 2.1.2023


// Function that separates the rows by dashes
void separator(char name_of_block[20]) {
    int i = 0;
    printf("\n%s", name_of_block);
    for (i; i < 79; i++) {
        printf("%s", "-");
    }
    printf("\n");
}

// FUNCTIONS
// This functions code block continues in main below. You will be able to track it
// by FUNCTIONS and dashes in console.
// Void means that the function will not return anything.
// Notice that we also specify function parameters here.
// All functions have to end up in main() in order to be finally executed
void some_function(char name[20], int age) {
    printf("Hello %s, you are %d\n", name, age);
}


int main() {

    // DRAWING A SHAPE
    // here, by // is meant escape character of '/' and
    //  next one is '/n' as a new line
    printf("|\\\n");
    printf("| \\\n");
    printf("|  \\\n");
    printf("|___\\\n");

    // VARIABLES
    separator("VARIABLES");
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


    // DATA TYPES
    separator("DATA TYPES");
    age = 50;
    double gpa = 3.5;
    char one_letter = 'A';  // has to be single quotes for only one character

    // double quotes for multiple characters
    // actually char variable[] is an array fyi...
    char phrase[] = "This is a phrase";

    printf("%d\n", age);
    printf("age: %d and letter: %c\n", age, one_letter);
    printf("%f\n", gpa);
    printf("%c\n", one_letter);
    printf("%s\n", phrase);


    // NUMBERS
    separator("NUMBERS");
    printf("%f\n", 2.3 + 1.7);
    printf("%f\n", 2.0 * 3.0);
    printf("%f\n", 2 * 3.0); // decimal with float will result in float
    printf("%d\n", 10 / 5); // will result in decimal
    printf("%f\n", pow(2, 3));
    printf("%f\n", sqrt(144));
    printf("%f\n", ceil(45.1));
    printf("%f\n", floor(35.9));



    // COMMENTS
    // This is a one line comment
    /*
     * This is a multiline comment,
     * got it?
     *
     * End below it ends
     */


    // CONSTANTS
    separator("CONSTANTS");
    // immutable objects like user defined immutable variables, or strings...
    const int THIS_IS_CONSTANT = 3;
    printf("Printing constant %d\n", THIS_IS_CONSTANT);

    // This will not work:
    //    THIS_IS_CONSTANT = 6;
    //    printf("Printing constant %d\n", THIS_IS_CONSTANT);



    // INPUT
    //    separator("INPUT");
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


    // BASIC CALCULATOR
    //    separator("BASIC CALCULATOR");
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



    // MAD LIBS GAME
    //    separator("MAD LIBS GAME");
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


    // ARRAYS
    separator("ARRAYS");
    int lucky_numbers[] = {4, 5, 6, 0, 44, 600, -4}; // assigning new values to an array
    lucky_numbers[0] = 2000; // updating values in existing array
    printf("%d\n", lucky_numbers[0]);

    // specifying limit of indexes in front, meaning max number of items inside is 10 here
    int some_numbers[10];
    some_numbers[1] = 300;
    some_numbers[0] = 4000;
    printf("%d %d\n", some_numbers[0], some_numbers[1]);


    // FUNCTIONS
    separator("FUNCTIONS");
    printf("Executing first\n");
    some_function("Tom", 26);
    some_function("Dude", 40);
    some_function("Martina", 25);
    printf("Executing last\n");



    // RETURN
    // separator("RETURN");
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
    // separator("IF STATEMENTS");
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
    // separator("BETTER CALCULATOR");
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
    separator("SWITCH STATEMENT");
    // It is basically the same as match case in python

    char grade = 'E';

    switch (grade) {
        case 'A':
            printf("%s\n", "You have the best mark");
            break;
        case 'B':
            printf("%s\n", "You have the second best mark");
            break;
        case 'C':
            printf("%s\n", "You have the average mark");
            break;
        case 'D':
            printf("%s\n", "You have the second worst mark");
            break;
        case 'E':
            printf("%s\n", "You have the worst mark");
            break;
            // default is going to execute if no match above. It is basically an else.
        default:
            printf("%s", "You have to enter mark A-E");
    }


    // STRUCTS
    separator("STRUCTS");
    // Might seem as classes in other languages but are rather used for grooping of data in C.
    // You can store all types of data in struct, meaning you can model real world entities better.

    struct Student{
        char name[50];
        char major[50];
        int age;
        double gpa;
    };

    struct Student student1;
    // Remember that strings are actually arrays, therefore in order to assign a value
    //  to student1.name we have to use strcpy(destination, value_to_be_pasted)
    strcpy(student1.name, "Ferda");
    strcpy(student1.major, "Informatics");
    student1.gpa = 4.3;
    student1.age = 22;

    // Lets say that this is another instance of original struct template.
    struct Student student2;
    strcpy(student2.name, "Bob");
    strcpy(student2.major, "Informatics");
    student2.gpa = 1.0;
    student2.age = 29;

    printf("%s\n", student1.name);
    printf("%s\n", student1.major);
    printf("%f\n", student1.gpa);
    printf("%d\n", student1.age);

    printf("%s\n", student2.name);
    printf("%s\n", student2.major);
    printf("%f\n", student2.gpa);
    printf("%d\n", student2.age);


    // WHILE, FOR & DO LOOPS
    separator("WHILE, FOR & DO LOOPS");
    // While loop check the condition before it continues to the code.
    // Do loop does the code first and then checks the condition.
    // For loop does the same thing as while loop. It is just shorter syntax.

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
    }while (index <= 5);

    // For loop
    index = 0;
    for(index; index<=5; index++){
        printf("Looping 'FOR'...%d\n", index);
    }

    index = 0;
    int numbers[] = {10, 20, 30, 40, 50, 60};
    for(index; index < 6; index++){
        printf("Lucky number - %d\n", numbers[index]);
    }


    // GUESSING GAME - SECRET NUMBER
    // separator("GUESSING GAME - SECRET NUMBER");
    //int main() {
    //    int secret_number = 5;
    //    int guessed_number;
    //    int guess_limit = 3;
    //
    //    while (guess_limit >= 0) {
    //        if (guess_limit == 0) {
    //            printf("%s", "You lost the game.\n");
    //            break;
    //
    //        }
    //
    //        printf("Enter your guess:\n");
    //        scanf("%d", &guessed_number);
    //
    //        if (guessed_number == secret_number) {
    //            printf("%s", "You won the game.\n");
    //            break;
    //        } else {
    //            printf("%s", "Wrong guess.\n");
    //            guess_limit--;
    //        }
    //    }
    //
    //    return 0;
    //}


    // 2D ARRAYS AND NESTED LOOPS
    separator("2D ARRAYS AND NESTED LOOPS");
    // You have to specify number of elements in each axis in square brackets.
    int two_dim_array[3][2] = {{1, 2},
                               {3, 4},
                               {5, 6}};
    printf("%d\n", two_dim_array[2][1]);

    int i, j; // possible to have two variables in one row
    for(i=0; i<3; i++){
        for(j=0; j<2; j++){
            printf("%d\n", two_dim_array[i][j]);
        }
    }



    // MEMORY ADDRESSES
    separator("MEMORY ADDRESSES");
    age = 20;
    gpa = 3.5;
    char str_[] = "blabla";

    // getting memory address with "%p" and "&" before variable, both meaning pointer
    printf("Age: %p\n", &age);
    printf("Gpa: %p\n", &gpa);
    printf("Str_: %p\n", &str_);



    return 0;
}

