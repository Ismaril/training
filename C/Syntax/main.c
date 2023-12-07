#include <stdio.h>  // import standard input/output
#include "s_variables.h"
#include "s_data_types.h"
#include "s_boolean.h"
#include "s_if_else.h"
#include "s_switch.h"
#include "s_for_while_loops.h"
#include "utilities.h"
#include "s_arrays.h"
#include "s_functions.h"
#include "s_strings.h"
#include "s_input.h"
#include "s_memory_addresses.h"
#include "s_pointers.h"
#include "scratch.h"
#include "s_structs.h"
#include "s_files.h"
#include "s_enumeration.h"

// SOME BASIC COMMANDS IN C
// Training of C started on 2.1.2023
int main() {

    separator("DRAWING A BASIC SHAPE");
    // here, by // is meant escape character of '/' and
    //  next one is '/n' as a new line
    printf("|\\\n");
    printf("| \\\n");
    printf("|  \\\n");
    printf("|___\\\n");

    separator("VARIABLES");
    variables();

    separator("DATA TYPES & BOOLEANS");
    data_types();
    booleans();

    separator("IF ELSE STATEMENTS");
    if_else_funct();

    separator("SWITCH STATEMENT");
    switch_sttmnt();

    separator("WHILE, FOR & DO LOOPS");
    loops();

    separator("ARRAYS");
    arrays_fnc();

    separator("INPUT FROM USER");
//    input_user();

    separator("MEMORY ADDRESSES");
    addresses();

    separator("FUNCTIONS");
    printf("Executing first\n");
    some_function("Tom", 26);
    some_function("Dude", 40);
    some_function("Martina", 25);
    printf("Squared number: %d\n", square_number(3));
    printf("Sum preceding numbers %d\n", sum_all_numbers(3));
    printf("Executing last\n");

    separator("STRINGS");
    strings();

    separator("POINTERS");
    pointers();

    separator("STRUCTS");
    structs();

    separator("WORKING WITH FILES");
    files();

    separator("ENUMERATION");
    enumeration();

    separator("SCRATCH FILE");
    char stringos[] = "Tomas";
    printf("%s\n", strrev_(stringos));

    return 0;
}
