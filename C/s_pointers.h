//
// Created by lazni on 19.01.2023.
//

#ifndef C_S_POINTERS_H
#define C_S_POINTERS_H

#endif //C_S_POINTERS_H


void pointers() {
    // POINTERS

    int normal_variable = 5; // this stores value 5 at memory address 0xBLABLA
    printf("normal_variable: %d\n", normal_variable); // this prints value 5

    // this creates new variable "pointer_variable", which is equal to memory address of "normal_variable"
    int *pointer_variable = &normal_variable;
    printf("&normal_variable (address): %p\n", &normal_variable); // these will be equal
    printf("pointer variable (address): %p\n", pointer_variable); // these will be equal

    //------------------------------------------------------------------------------
    // Pointers are just type of data (like str, int, double, ...)
    int age = 30;
    double gpa = 3.5;
    char grade = 'a';

    // Create pointer variable by declaring "* variable" and "p_variable_name", then
    //    after equal sign write down "&variable_name" which is actually physical
    //    memory address
    int *p_age = &age;
    double *p_gpa = &gpa;
    char *p_grade = &grade;

    printf("p_age: %p\n", p_age);
    printf("p_gpa: %p\n", p_gpa);
    printf("p_grade: %p\n", p_grade);

    // DEREFERENCING POINTERS (getting actual value from variable)
    // when used in declaration, like: int * ponter_variable, it creates a pointer datatype
    // when not used in declaration, it dereferences the variable (it gets the actual value from the memory)
    // Both of these do the same:
    //    int* myNum; // Recommended
    //    int *myNum;


    separator("DEREFERENCING POINTERS");
    // Deref pointers means that we want to grab the actual value from a
    //   memory address. Use a star before variable when calling it.
    printf("%d\n", *p_age);

    // Theoretically you can call a memory address of a variable and dereference it
    //    at the same time.
    printf("%d\n", *&age);


    // POINTERS IN ARRAYS
    int myNumbers[4] = {25, 50, 75, 100};
    int i;
    for (i = 0; i < 4; i++) {
        printf("Printing memory address: %p, Actual value: %d\n", &myNumbers[i], myNumbers[i]);
    }

    // First element of an array and array as a whole are equal when we call them as pointer.
    printf("First item of array as pointer: %p\n", &myNumbers[0]); // same memory address
    printf("Complete array as pointer: %p\n", &myNumbers); // same memory address
    printf("Complete array as pointer: %p\n", myNumbers); // same memory address

    // based on above (that %p, array_name returns a memory address)
    // this means you can access the first address element in an array by dereferencing it with '*':
    printf("First dereferenced item of array: %d\n", *myNumbers);
    // access second element
    printf("Second dereferenced item of array: %d\n", *(myNumbers + 1));
    // access third element
    printf("Third dereferenced item of array: %d\n", *(myNumbers + 2));

    // also possible to change values of arrays with pointers
    // Change the value of the first element to 13
    *myNumbers = 13;

    // Change the value of the second element to 17
    *(myNumbers + 1) = 17;

    // Get the value of the first element
    printf("%d\n", *myNumbers);

    // Get the value of the second element
    printf("%d\n", *(myNumbers + 1));
}