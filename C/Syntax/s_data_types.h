//
// Created by lazni on 16.01.2023.
//

#ifndef C_S_DATA_TYPES_H
#define C_S_DATA_TYPES_H

#endif //C_S_DATA_TYPES_H

# include <stdio.h>

// DATA TYPES
void data_types(){
    // Signed - means number can be positive or negative
    // Unsigned - means number can be only positive
    // If you define number as signed, it means that we define
    //    first bit of binary number as either + or -.

    // 8 Bits --------------------------------------------------------
    char letter = 'a';

    // signed char

    // unsigned char

    printf("%c\n", letter); // for char, use only single quotes

    // double quotes for multiple characters
    // actually char variable[] is an array fyi...
    char phrase[] = "This is phrase.";
    printf("%s\n", phrase);
    printf("Size of the phrase in bytes: %llu \n", sizeof(phrase));
    printf("Size of character in bytes: %llu\n", sizeof(letter));

    // 16 Bits --------------------------------------------------------
    signed short number1 = -32767; // up to 32767
    // short int
    // signed short int

    unsigned short number_1b = 65535;
    // unsigned short int

    int number2 = -32767; // up to 32767
    // signed
    // signed int

    unsigned int number2b = 65535;
    // unsigned

    printf("%hi\n", number1); // possible %hd
    printf("%hu\n", number_1b);
    printf("%i\n", number2); // possible %d
    printf("%u\n", number2b);


    // 32 Bits --------------------------------------------------------
    long number3 = -2147483647; // up to 2,147,483,647
    // long int
    // signed long
    // signed long int

    unsigned long number3b = 4294967295;
    // unsigned long int

    printf("%li\n", number3); // possible %ld
    printf("%lu\n", number3b);


    // 64 Bits --------------------------------------------------------
    long long number4 = -9223372036854775807; // up to −9,223,372,036,854,775,807
    // long long int
    // signed long long
    // signed long long int

    unsigned long long number4b = 18446744073709551615;
    // unsigned long long int

    printf("%lli\n", number4); // possible %lld
    printf("%llu\n", number4b);

    // Others -------------------------------------------------------
    // float - %f %F %g %G %e %E %a %A
    // double - %lf %lF %lg %lG %le %lE %la %lA
    // long double - %Lf %LF %Lg %LG %Le %LE %La %LA


    // TYPE CONVERSION
    // Implicit Conversion (automatically)

    // Automatic conversion: int to float
    float myFloat = 9;
    printf("%f\n", myFloat); // 9.000000

    // Automatic conversion: float to int
    int myInt = 9.99;
    printf("%d\n", myInt); // 9

    int sum = 5 / 2;
    printf("%d\n", sum); // Outputs 2 (But we expect 2.5)


    // Explicit Conversion (manually)
    // Manual conversion: int to float
    float sum2 = (float) 5 / 2;
    printf("%f\n", sum2); // 2.500000


}
