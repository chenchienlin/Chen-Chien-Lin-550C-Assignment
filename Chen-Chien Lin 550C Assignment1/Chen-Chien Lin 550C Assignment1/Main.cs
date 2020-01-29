/*
 * Name: Chen-Chien, Lin
 * Student Number: 46205175
 * Purpose: To build familiarity with C# and the assignment submission process
 * Description: The program contains 4 primary elements, a namespace declaration, a class, a Main method, and a program statement,
 * and produce an exe file. The "using System" directive allows users to members of System namespace. The class declaration contains data and method definition in the program. In Program class, 
 * there is no data, and one method. The method name, "Main", is reserved for the starting points of the program. "Main" is the entry
 * point of the program. A static modifier in front of "Main" means that this method cannot work in an instance of the class. Every
 * method needs to define its return type, In Main method, the return type is "void", meaning this method does not return any value.
 * The parameters of a method are defined in the parentheses behind the method name. In Main method, Only one action is excuted. 
 * It is Console.WriteLine(). Console is a class in System namespace, and WriteLine() is a method in Console class. 
 */

// Namespace Declaration
using System;

namespace Chen_Chien_Lin_550C_Assignment1
{
    //Program Start Class
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Always think first, and code later, and try to improve the code after achieve the goal.\n" +
                "Learn how to write an intuitive, readable, and maintainable code.");
            Console.ReadKey();
        }
    }
}
