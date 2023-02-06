//
// Created by lazni on 19.01.2023.
//

#ifndef C_S_STRUCTS_H
#define C_S_STRUCTS_H

#endif //C_S_STRUCTS_H
#include "stdio.h"

// STRUCTS
void structs(){
    // Might seem as classes in other languages but are rather used for grooping of data in C.
    // You can store all types of data in struct, meaning you can model real world entities better.

    struct Student {  // Structure declaration
        char name[50];  // Member
        char major[50];  // Member
        int age;  // Member
        double gpa;  // Member
    };

    // create structure variable
    struct Student student1;

    // Remember that strings are actually arrays, therefore in order to assign a value
    //  to student1.name we have to use strcpy(destination, value_to_be_pasted)
    strcpy(student1.name, "Ferda");
    strcpy(student1.major, "Informatics");
    student1.gpa = 4.3;
    student1.age = 22;

    // Let's say that this is another variable of original struct template.
    struct Student student2;

    strcpy(student2.name, "Bob");
    strcpy(student2.major, "Informatics");
    student2.gpa = 1.0;
    student2.age = 29;

    printf("%s\n", student1.name);
    printf("%s\n", student1.major);
    printf("%d\n", student1.age);
    printf("%lf\n", student1.gpa);

    printf("%s\n", student2.name);
    printf("%s\n", student2.major);
    printf("%d\n", student2.age);
    printf("%lf\n", student2.gpa);

    // You can assign a values to struct in a single line.
    // Strings do not have to be used with string copy here.
    // Order of inserted values must be aligned with positions of declaration members.
    struct Student student3 = {"Jenda", "Sports", 30, 1.0};
    printf("%s\n", student3.name);
    printf("%s\n", student3.major);
    printf("%d\n", student3.age);
    printf("%lf\n", student3.gpa);

    // Copy structures
    struct Student student4;
    student4 = student1;
    printf("%s\n", student4.name);

}