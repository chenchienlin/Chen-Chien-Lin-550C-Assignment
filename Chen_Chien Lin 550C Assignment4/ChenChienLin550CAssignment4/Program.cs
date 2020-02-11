/*******************************************************************************************************
 * Assignment 4 :  Complex Number Operation__Program Class                                             *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Create a new class from scratch and use its instances to perform math operations    *
 *                                                                                                     *
 * Description:    In this project, a new class is created to defined a complex number.                *
 *                 Another class, ComplexCalculator, is created to calculate matrices                  *
 *                 made of complex numbers.                                                            *
 *                 Several tests are done in Program class.                                            *          
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using System;

/*************************************** NAMESPACE DECLARATION *****************************************/
namespace ChenChienLin550CAssignment4
{
    public class Program
    {

        /*==============================================================================
         * Function:   Main
         * Arguments:  string[] args
         * Returns:    None
         */

        static void Main(string[] args)
        {
            //Implement ComplexNumber and ComplexCalculator Classes
            ComplexCalculator calculator = new ComplexCalculator();
            ComplexNumber complexNumber1 = new ComplexNumber(1d, 1d);
            ComplexNumber complexNumber2 = new ComplexNumber(5d, -5d);
            
            ComplexNumber addResult = complexNumber1 + complexNumber2;
            ComplexNumber subtractResult = complexNumber1 - complexNumber2;
            ComplexNumber multiplyResult = complexNumber1 * complexNumber2;

            // Print the addition result of two complex numbers
            Console.WriteLine(String.Format("({0}) + ({1}) = {2}",
                              complexNumber1, complexNumber2, addResult));

            // Print the subtraction result of two complex numbers
            Console.WriteLine(String.Format("({0}) - ({1}) = {2}",
                  complexNumber1, complexNumber2, subtractResult));

            // Print the multiplication result of two complex numbers
            Console.WriteLine(String.Format("({0}) x ({1}) = {2}",
                 complexNumber1, complexNumber2, multiplyResult));

            // Print the absolute value of complexNumber2
            Console.WriteLine(String.Format("The absolute value of {0} : {1}",
                              complexNumber2, complexNumber2.AbsoluteValue));

            // Print the phase of complexNumber2
            Console.WriteLine(String.Format("The phase of {0} : {1}",
                              complexNumber2, complexNumber2.Phase));

            // Print the polar form of complexNumber2
            Console.WriteLine(String.Format("The polar form of {0} : {1}",
                              complexNumber2, complexNumber2.PolarForm));

            //Define several complex numbers with different sign
            ComplexNumber complexNumber3 = new ComplexNumber(3, 5);
            ComplexNumber complexNumber4 = new ComplexNumber(3, -5);
            ComplexNumber complexNumber5 = new ComplexNumber(0, 5);
            ComplexNumber complexNumber6 = new ComplexNumber(0, -5);
            ComplexNumber complexNumber7 = new ComplexNumber(3, 0);
            ComplexNumber complexNumber8 = new ComplexNumber(0, 0);

            //Print complex numbers
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(String.Format("ComplexNumber(3, 5)  : {0}", complexNumber3));
            Console.WriteLine(String.Format("ComplexNumber(3, -5) : {0}", complexNumber4));
            Console.WriteLine(String.Format("ComplexNumber(0, 5)  : {0}", complexNumber5));
            Console.WriteLine(String.Format("ComplexNumber(0, -5) : {0}", complexNumber6));
            Console.WriteLine(String.Format("ComplexNumber(3, 0)  : {0}", complexNumber7));
            Console.WriteLine(String.Format("ComplexNumber(0, 0)  : {0}", complexNumber8));

            //Define two 2x2 matrices
            ComplexNumber[,] matrix1 = new ComplexNumber[2, 2]
            {
                {new ComplexNumber(1,1), new ComplexNumber(2,0)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5)}
            };
            ComplexNumber[,] matrix2 = new ComplexNumber[2, 2]
            {
                {new ComplexNumber(5,-5), new ComplexNumber(0,-2)},
                {new ComplexNumber(0,4.2), new ComplexNumber(-11.1,0)}
            };

            ComplexNumber[,] result1 = calculator.MultipyComplexMatrices(matrix1, matrix2);

            //Print the matrix calculated above
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Result of matrix1 multiply matrix2");
            calculator.PrintMatrix(result1);
            Console.ReadKey();
        }
    }

}