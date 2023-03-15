//
// Created by lazni on 16.01.2023.
//

#ifndef C_S_OPERATORS_H
#define C_S_OPERATORS_H

#endif //C_S_OPERATORS_H

// OPERATORS

// Arithmetic Operators
// Operator	Name	        Example
// +	    Addition	    x + y
// -	    Subtraction     x - y
// *	    Multiplication  x * y
// /	    Division        x / y
// %	    Modulus         x % y
// ++	    Increment	    Increases the value of a variable by 1	++x
// --	    Decrement	    Decreases the value of a variable by 1	--x


// Assignment Operators
// - are used to assign values to variables.
// Operator  Example    Same As
// =	     x = 5	    x = 5
// +=	     x += 3	    x = x + 3
// -=	     x -= 3	    x = x - 3
// *=	     x *= 3	    x = x * 3
// /=	     x /= 3	    x = x / 3
// %=	     x %= 3	    x = x % 3

// Bitwise operations
// Number on first row with operator with number on second row = result
// Examples:
//         101 (5 in decimal)
// AND     011 (3 in decimal)
// equals  001 (1 in decimal)

//         101 (5 in decimal)
// OR      011 (3 in decimal)
// equals  111 (7 in decimal)

//         101 (5 in decimal)
// XOR     011 (3 in decimal)
// equals  110 (6 in decimal)

//         101 (5 in decimal)
// >>      011 (3 in decimal)
// equals  000 (0 in decimal)

//         101 (5 in decimal)
// <<      011 (3 in decimal)
// equals  101000 (40 in decimal)

// ~       101 (5 in decimal)
// equals  010 (2 in decimal)

// &=	     x &= 3	    x = x & 3 Bitwise AND
// |=	     x |= 3	    x = x | 3 Bitwise OR
// ^=	     x ^= 3	    x = x ^ 3 Bitwise XOR
// >>=	     x >>= 3    x = x >> 3 Bitwise shift right (shift n bits to the side)
// <<=	     x <<= 3    x = x << 3 Bitwise shift left (shift n bits to the side)
// ~         switches 1 to 0 and each 0 to 1
// Todo: check if actually ~ operator reverses the bits.

// Comparison Operators
// Result of comparison operators is always boolean value
// Operator	Name	                    Example
// ==	    Equal to	                x == y
// !=	    Not equal	                x != y
// >	    Greater than	            x > y
// <	    Less than	                x < y
// >=	    Greater than or equal to	x >= y
// <=	    Less than or equal to	    x <= y


// Logical Operators
// You can also test for true or false values with logical operators.
// Logical operators are used to determine the logic
//     between variables or values:

// &&
// Logical and
// Returns true if both statements are true
// x < 5 &&  x < 10

// ||
// Logical or
// Returns true if one of the statements is true
// x < 5 || x < 4

// !
// Logical not
// Reverse the result, returns false if the result is true
// !(x < 5 && x < 10)
