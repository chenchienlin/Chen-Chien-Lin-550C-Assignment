/*******************************************************************************************************
 * Assignment 3 :  Complex Number                                                                      *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Create a new class from scratch and use its instances to perform math operations    *
 *                                                                                                     *
 * Description:    In this C# script, a class is created to defined complex numbers. The real part     *
 *                 and the imaginary part of a complex number must be given to create a instance of    *
 *                 Complex Number class. Once a complex number is created, its value cannot be change  *
 *                 to prevent changing its value accidentally.                                         *
 *                 Users can get the real part and imaginary part through two getters.                 *                             
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
            var multiplyResult1 = calculator.Mutiply(complexNumber1, complexNumber2);
            var multiplyResult2 = calculator.Mutiply(complexNumber3, complexNumber4);


            //Print the first multiplication result
            Console.Write(String.Format("{0} + {1}i  Mutiply  {2} + {3}i :  ", 
                complexNumber1.GetRealPart, complexNumber1.GetImaginaryPart,
                complexNumber2.GetRealPart, complexNumber2.GetImaginaryPart));
            
            multiplyResult1.PrintComplexNumber();

            //Print the second multiplication result
            Console.Write(String.Format("{0} + {1}i  Mutiply  {2} + {3}i :  ",
                complexNumber3.GetRealPart, complexNumber3.GetImaginaryPart,
                complexNumber4.GetRealPart, complexNumber4.GetImaginaryPart));
            
            multiplyResult2.PrintComplexNumber();

            //Add two multiplyresults 
            var addResult1 = calculator.AddComplex(multiplyResult1, multiplyResult2);

            //Print addResult1
            Console.Write(String.Format("{0} + {1}i  Add  {2} + {3}i :  ",
                multiplyResult1.GetRealPart, multiplyResult1.GetImaginaryPart,
                multiplyResult2.GetRealPart, multiplyResult2.GetImaginaryPart));

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

            //Calculate the multiplication result of two matrices
            ComplexNumber[,] result1 = calculator.MultipyComplexMatrices(matrix1, matrix2);

            //Print the matrix calculated above
            Console.WriteLine("Result of matrix1 multiply matrix2");
            calculator.PrintMatrix(result1);


            /*====================================== CASE 2 ======================================*/

            //Define two 3x3 matrices
            ComplexNumber[,] matrix3 = new ComplexNumber[3, 3]
            {
                {new ComplexNumber(1,1), new ComplexNumber(2,0), new ComplexNumber(2,0)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5), new ComplexNumber(0,9)},
                {new ComplexNumber(1,-1), new ComplexNumber(3.7,-4.5), new ComplexNumber(9.5,-3)}
            };
            ComplexNumber[,] matrix4 = new ComplexNumber[3, 2]
            {
                {new ComplexNumber(5,4), new ComplexNumber(2,0)},
                {new ComplexNumber(0,0), new ComplexNumber(2,5)},
                {new ComplexNumber(1,-1), new ComplexNumber(3.7,-4.5)}
            };

            /*====================================== CASE 3 ======================================*/



            /*====================================== CASE 4 ======================================*/



            /*====================================== CASE 5 ======================================*/



            /*====================================== CASE 6 ======================================*/




            /*====================================== CASE 7 ======================================*/


            //ComplexNumber[,] result2 = calculator.MultipyComplexMatrices(matrix3, matrix3);
            //calculator.PrintMatrix(result2);

            //Define null matrices
            var matrix5 = new ComplexNumber[2, 3];
            var matrix6 = new ComplexNumber[3, 4];
            calculator.PrintMatrix(matrix6);

            //ComplexNumber[,] result3 = calculator.MultipyComplexMatrices(matrix5, matrix6);
            //calculator.PrintMatrix(result3);
        }
    }
}
