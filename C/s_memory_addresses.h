//
// Created by lazni on 18.01.2023.
//

#ifndef C_S_MEMORY_ADDRESSES_H
#define C_S_MEMORY_ADDRESSES_H

#endif //C_S_MEMORY_ADDRESSES_H

void addresses(){
    // MEMORY ADDRESSES

    // When a variable is created in C, a memory address is assigned to the variable.
    // The memory address is the location of where the variable is stored on the computer.
    // When we assign a value to the variable, it is stored in this memory address.
    // To access it, use the reference operator (&), and the result represents where the variable is stored:

    int age = 20;
    float gpa = 3.5;
    char str_[] = "blabla";

    // getting memory address with "%p" and "&" before variable, both meaning pointer
    printf("Age: %p\n", &age);
    printf("Gpa: %p\n", &gpa);
    printf("Str_: %p\n", &str_);
}