cmake_minimum_required(VERSION 3.24)
project(C)

set(CMAKE_C_STANDARD 11)

add_executable(C main.c
        s_variables.h
        s_data_types.h
        s_constants.h
        s_operators.h
        s_boolean.h
        s_functions.h
        s_if_else.h
        s_comments.h
        s_switch.h
        s_for_while_loops.h
        utilities.h
        s_arrays.h
        s_input.h
        s_strings.h
        s_memory_addresses.h
        s_pointers.h
        scratch.h
        s_structs.h
        s_files.h
        s_math.h
        s_enumeration.h scratch_2.h s_keywords.h)
