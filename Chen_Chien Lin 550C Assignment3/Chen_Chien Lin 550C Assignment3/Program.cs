/*******************************************************************************************************
 * Assignment 3 :  Complex Number__Program Class                                                       *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Create a new class from scratch and use its instances to perform math operations    *
 *                                                                                                     *
 * Description:    In this project, a new class is created to defined a complex number.                *
 *                 Another class, ComplexCalculator, is created to perform math operation              *
 *                 related to complex numbers.                                                         *
 *                 Several tests are done in Program class.                                            *          
 *******************************************************************************************************/
using System;
/*************************************** NAMESPACE DECLARATION *****************************************/
namespace Chen_Chien_Lin_550C_Assignment3
{
    public class Program
    {

        /*==============================================================================
         * Function:   Main
         * Arguments:  None
         * Returns:    None
         */

        static void Main(string[] args)
        {
            //Implement ComplexNumber and ComplexCalculator Classes
            ComplexCalculator calculator = new ComplexCalculator();
            ComplexNumber complexNumber1 = new ComplexNumber(1d, 1d);
            ComplexNumber complexNumber2 = new ComplexNumber(5d, -5d);

            ComplexNumber complexNumber3 = new ComplexNumber(2d, 0);
            ComplexNumber complexNumber4 = new ComplexNumber(0, 4.2);


            //Calculate the result of multiplication
            var multiplyResult1 = calculator.MutiplyComplex(complexNumber1, complexNumber2);
            var multiplyResult2 = calculator.MutiplyComplex(complexNumber3, complexNumber4);


            //Print the first multiplication result
            Console.Write(String.Format("{0} + {1}i  Mutiply  {2} + {3}i :  ", 
                complexNumber1.RealPart, complexNumber1.ImaginaryPart,
                complexNumber2.RealPart, complexNumber2.ImaginaryPart));
            
            multiplyResult1.PrintComplexNumber();

            //Print the second multiplication result
            Console.Write(String.Format("{0} + {1}i  Mutiply  {2} + {3}i :  ",
                complexNumber3.RealPart, complexNumber3.ImaginaryPart,
                complexNumber4.RealPart, complexNumber4.ImaginaryPart));
            
            multiplyResult2.PrintComplexNumber();

            //Add two multiplyresults 
            var addResult1 = calculator.AddComplex(multiplyResult1, multiplyResult2);

            //Print addResult1
            Console.Write(String.Format("{0} + {1}i  Add  {2} + {3}i :  ",
                multiplyResult1.RealPart, multiplyResult1.ImaginaryPart,
                multiplyResult2.RealPart, multiplyResult2.ImaginaryPart));

            addResult1.PrintComplexNumber();


            /*====================================== CASE 1 ======================================*/

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

            //Calculate the multiplication of two 2x2 matrices
            ComplexNumber[,] result1 = calculator.MultipyComplexMatrices(matrix1, matrix2);

            //Print the matrix calculated above
            Console.WriteLine("Result of matrix1 multiply matrix2");
            calculator.PrintMatrix(result1);


            /*====================================== CASE 2 ======================================*/

            //Define two 2x3 matrices
            ComplexNumber[,] matrix3 = new ComplexNumber[2, 3]
            {
                {new ComplexNumber(1,1), new ComplexNumber(2,0), new ComplexNumber(5,-5)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5), new ComplexNumber(0,4.2)}
            };

            //Calculate the multiplication of one 2x2 and one 2x3 matrices
            ComplexNumber[,] result2 = calculator.MultipyComplexMatrices(result1, matrix3);

            //Print the matrix calculated above
            Console.WriteLine("Result of result1 multiply matrix3");
            calculator.PrintMatrix(result2);


            /*====================================== CASE 3 ======================================*/

            //Define two 3x3 matrices
            ComplexNumber[,] matrix4 = new ComplexNumber[3, 3]
            {
                {new ComplexNumber(1,1), new ComplexNumber(2,0), new ComplexNumber(2,0)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5), new ComplexNumber(0,9)},
                {new ComplexNumber(1,-1), new ComplexNumber(3.7,-4.5), new ComplexNumber(9.5,-3)}
            };

            //Calculate the multiplication of one 2x3 and one 3x3 matrices
            ComplexNumber[,] result3 = calculator.MultipyComplexMatrices(result2, matrix4);

            //Print the matrix calculated above
            Console.WriteLine("Result of result2 multiply matrix4");
            calculator.PrintMatrix(result3);


            /*====================================== CASE 4 ======================================*/

            //Define two 3x2 matrices
            ComplexNumber[,] matrix5 = new ComplexNumber[3, 2]
            {
                {new ComplexNumber(5,4), new ComplexNumber(2,0)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5)},
                {new ComplexNumber(1,-1), new ComplexNumber(3.7,-4.5)}
            };

            //Calculate the multiplication of one 2x3 and one 3x2 matrices
            ComplexNumber[,] result4 = calculator.MultipyComplexMatrices(result3, matrix5);

            //Print the matrix calculated above
            Console.WriteLine("Result of result3 multiply matrix5");
            calculator.PrintMatrix(result4);


            /*====================================== CASE 5 ======================================*/

            //Define two 2x2 matrices
            ComplexNumber[,] matrix6 = new ComplexNumber[2, 2]
            {
                {new ComplexNumber(0,0), new ComplexNumber(0,0)},
                {new ComplexNumber(0,0), new ComplexNumber(0,0)}
            };

            //Calculate the multiplication of the 2x2 matrix obtained in CASE 4 and one 2x2 zero matrix 
            ComplexNumber[,] result5 = calculator.MultipyComplexMatrices(result4, matrix6);

            //Print the matrix calculated above
            Console.WriteLine("Result of result4 multiply matrix6");
            calculator.PrintMatrix(result5);

            /*====================================== CASE 6 ======================================*/

            //Calculate the multiplication of the 2x2 zero matrix obtained above and matrix1
            ComplexNumber[,] result6 = calculator.MultipyComplexMatrices(result5, matrix1);

            //Print the matrix calculated above
            Console.WriteLine("Result of result5 multiply matrix1");
            calculator.PrintMatrix(result6);
        }
    }
}
