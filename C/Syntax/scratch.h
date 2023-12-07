//
// Created by lazni on 19.01.2023.
//

#ifndef C_SCRATCH_H
#define C_SCRATCH_H

#endif //C_SCRATCH_H
#include "stdlib.h"

char *strrev_ (char *string)
{
    for (int i = 0; i < strlen(string); i++){
        string[i+strlen(string)] = string[strlen(string)-1-i];
    }
    printf("%s", string);
    for (int i = 0; i < strlen(string); i++) {
        string[i] = string[strlen(string)+i];
    }
    printf("%s", string);

    string[strlen(string)] = '\0';
    printf("%s", string);
    
    return string;
}