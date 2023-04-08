using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Keywords
    {
       static void Main__()
        {
            /*
             * abstract
             *     Used to define an incomplete class or member 
             *     that must be implemented by its derived classes.
             *     This keyword is more explained in ClassesSource.cs  
             *
             *
             * as
             *     Used to convert an object to a specific datatype. If the conversion fails
             *     it returns "null".
             *     "I think this object might actually be of this other type,
             *     give me null if it isn't."
             *     
             *     object myObject = "Hello World";
             *     string myString = myObject as string;
             *     
             *     We can also write it like this:
             *     E is T ? (T)(E) : (T)null
             *     => If E is compatible with datatype T then convert E do datatype T else return null.
             *          
             *     "As" keyword is different to cast expression like int a = (int)x;
             *     When you type cast as (datatype)variable and coversion to the desired datatype is not
             *     possible, the program crashes. "as" keyword however returns null in this case.
             *
             *
             * base
             *     1.
             *     Used to call a method on the base class that has been overridden by another method,
             *     meaning, you can access the original method in parent class (not the one overriden
             *     in child class).
             *     base.NameOfTheMethod();
             *   
             *     2.
             *     Used to specify which constructor of parent/base class to call when creating instance
             *     of drived/child class.
             *     Example of this can be found in ClassesSource.cs.
             * 
             * 
             * bool
             *     Dataype which can either hold "true" or "false"
             * 
             * 
             * break
             *     The break statement terminates the closest enclosing iteration 
             *     statement (that is, for, foreach, while, or do loop) or switch statement. 
             *     The break statement transfers control to the statement that follows the
             *     terminated statement, if any.
             *     
             * 
             * byte
             *     Byte is a keyword which is used to declare a variable that can store an 
             *     unsigned value between 0 to 255. byte keyword is an alias of System.Byte. 
             *     It occupies 1 byte (8 bits) in the memory.
             *    
             * 
             * case
             *     Used together with "switch" statement.
             * 
             * 
             * catch
             *     Used together with "try" keyword. When an exception is thrown the 
             *     (CLR) common language runtime looks for catch block which handles
             *     the exception.
             *     
             * 
             * char
             *     char type keyword is a datatype which represents unicode UTF-16 character.
             * 
             * 
             * checked, unchecked
             *     These keywords check wheter the operation or number ended up outside of specified range.
             *     Meaning they check for overflow in the resulting numerical operation. 
             *     In the checked case, an OverflowException exception is raised if the result of the
             *     operation exceeds the minimum or maximum value allowed for the datatype.     
             * 
             * 
             * class
             *     Use class keyword when you want to create your own datatype/object.
             *    
             * 
             * const
             *     Use const keyword to declare a constant field or constant local. Use this keyword
             *     only if you expect it newer to change. 
             *     Constants cannot be modified.
             *     
             * 
             * continue
             *     Continue statement is used in loops to stop current iteration and start with next
             *     iteration in the closest enclosing scope.
             *     
             * 
             * decimal
             *     Datatype which makes sense to use when you take care about not loosing precision
             *     on trailing digits. It is always used with financial operations. It can hold 29 digits
             *     and accuracy is guaranteed on all of them. On the otherhand double can hold more digits
             *     but they are rather outputed in scientific format with visible 15 digits and precision
             *     guaranteed on all of them.
             *     
             * 
             * default
             *     1. Specifies default value to be returned if no case is matched in switch/case.
             *     2. Use default as a built ind function, which returns default value od an datatype.
             *        default(int) - returns 0, because 0 is default value of integer.
             *     3. Use as the default type constraint on a generic method override
             *        or explicit interface implementation.
             *        TODO: this last point has to be explained more.
             *        
             *  
             *  
             */

        } 
    }
} 