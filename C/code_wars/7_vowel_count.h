/*
Return the number (count) of vowels in the given string.

We will consider a, e, i, o, u as vowels for this Kata (but not y).

The input string will only consist of lower case letters and/or spaces.
*/


#include <stddef.h>

size_t get_count(char string_[]) {
    char character = string_[0];
    int i = 0;
    int result = 0;
  
    // loop till we encounter string terminator at last position
    while (character != '\0') {
        switch (character) {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                result++;
                break;
        }
        character = string_[i + 1];
        i++;
    }
    return result;
}