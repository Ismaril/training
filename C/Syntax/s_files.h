//
// Created by lazni on 19.01.2023.
//

#ifndef C_S_FILES_H
#define C_S_FILES_H

#endif //C_S_FILES_H


void files() {
    // WORKING WITH FILES

    // open file
    // fopen(filename, mode (w, r, a ...))
    FILE *file_pointer = fopen("employees.txt", "w");

    // write into file
    fprintf(file_pointer, "This is the text you write into txt file.\nNew line!\n");

    fclose(file_pointer); // close file

    // readfile
    char line[255];
    FILE *file_pointer_r = fopen("employees.txt", "r");

    // Read file line by line.
    // fgets(where_to_put_result, nr_of_allowed_characters, source)
    // With each call of fgets, you are going to read next line in the file.
    fgets(line, 255, file_pointer_r);
    printf("%s", line);
    fgets(line, 255, file_pointer_r);
    printf("%s", line);
}