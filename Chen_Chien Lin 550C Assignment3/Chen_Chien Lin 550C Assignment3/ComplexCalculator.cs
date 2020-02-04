/*****************************************************************************************************************
 * Assignment 3 :  Complex Number Operation__Complex Calculator Class                                            *
 *                                                                                                               *
 * Name:           Chen-Chien Lin                                                                                *
 * Student Number: 46205175                                                                                      *
 * Purpose:                                                                                                      *
 * Description:    In this C# script, a helper class is created,                                                 *
 *                 no fields are declared in this class.                                                         *
 *                 The purpose of this class is to calculate complex numbers                                     *
 *                 and matrices made of complex numbers.                                                         *
 *****************************************************************************************************************/


/************************************************ USING NAMESPACES ***********************************************/
using System;

/********************************************* NAMESPACE DECLARATION *********************************************/
namespace Chen_Chien_Lin_550C_Assignment3
{
    public class ComplexCalculator
    {

        /*======================================================================================================
         * Function:   Add
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public ComplexNumber AddComplex(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Compute and store the real part and imaginary part of the new complex number
            double newRealPart = complexNumber1.GetRealPart + complexNumber2.GetRealPart;
            double newImaginaryPart = complexNumber1.GetImaginaryPart + complexNumber2.GetImaginaryPart;

            // Return a new complex number by using the computation results above 
            return new ComplexNumber(newRealPart, newImaginaryPart);
        }

        /*======================================================================================================
         * Function:   Multiply
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public ComplexNumber Mutiply(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Store the real part and imaginary part of two complex numbers as local vairables
            double number1RePart = complexNumber1.GetRealPart;
            double number1ImPart = complexNumber1.GetImaginaryPart;
            double number2RePart = complexNumber2.GetRealPart;
            double number2ImPart = complexNumber2.GetImaginaryPart;

            // Compute and store the real part and imaginary part of the new complex number
            double newRealPart = number1RePart * number2RePart - number1ImPart * number2ImPart;
            double newImaginaryPart = number1ImPart * number2RePart + number1RePart * number2ImPart;

            // Return a new complex number by using the computation results above 
            return new ComplexNumber(newRealPart, newImaginaryPart);
        }

        /*======================================================================================================
         * Function:   MultiplyArray
         * Arguments:  Two arrays contain complex numbers
         * Returns:    One array made of complex numbers
         */

        public ComplexNumber MultiplyComplexArray(ComplexNumber[] array1, ComplexNumber[] array2)
        {
            // If the dimension of the row vector and the column vector must be match, 
            // or the program will throw an IndexOutOfRangeException.
            if (array1.Length != array2.Length)
            {
                throw new IndexOutOfRangeException("Column number in the first array(matrix) and " +
                    "row number in the second array(matrix) should be the same");
            }

            // Initialize a new complex number
            ComplexNumber newComplex = new ComplexNumber(0, 0);

            // Compute new complex number
            for (int i = 0; i < array1.Length; i++)
            {

                // The elements in the vector cannot be null,
                // or the program will throw an NullReferenceException.
                try
                {
                    newComplex = AddComplex(newComplex, Mutiply(array1[i], array2[i]));
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("Elements in the array(matrix) cannot be null");
                }
            }

            // Return the new complex number calculated above
            return newComplex;
        }

        /*======================================================================================================
         * Function:   MultipyMatrices
         * Arguments:  Two matrices contain complex numbers
         * Returns:    One matrix made of complex numbers
         */

        public ComplexNumber[,] MultipyComplexMatrices(ComplexNumber[,] matrix1, ComplexNumber[,] matrix2)
        {
            // Initialize a matrix made of complex numbers
            ComplexNumber[,] newMatrix = new ComplexNumber[matrix1.GetLength(0), matrix2.GetLength(1)];

            //Compute each element in the new matrix
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    newMatrix[i, j] = MultiplyComplexArray(GetRow(matrix1, i), GetColumn(matrix2, j));
                }
            }

            // Return the new matrix calculated above
            return newMatrix;
        }

        /*======================================================================================================
         * Function:   GetRow
         * Arguments:  One matrix made of complex numbers and one row number
         * Returns:    One array made of complex numbers
         */

        private ComplexNumber[] GetRow(ComplexNumber[,] complexMatrix, int rowNumber)
        {

            // Initialize a new array
            ComplexNumber[] newArray = new ComplexNumber[complexMatrix.GetLength(1)];

            // Select each element in a specific row of the matrix and store into the new array
            for (int i = 0; i < complexMatrix.GetLength(1); i++)
            {
                newArray[i] = complexMatrix[rowNumber, i];
            }

            // Return the new array 
            return newArray;
        }

        /*======================================================================================================
         * Function:   GetColumn
         * Arguments:  One matrix made of complex numbers and one column number
         * Returns:    One array made of complex numbers
         */

        private ComplexNumber[] GetColumn(ComplexNumber[,] complexArray, int colNumber)
        {
            // Initialize a new array
            ComplexNumber[] newArray = new ComplexNumber[complexArray.GetLength(0)];

            // Select each element in a specific column of the matrix and store into the new array
            for (int i = 0; i < complexArray.GetLength(0); i++)
            {
                newArray[i] = complexArray[i, colNumber];
            }

            // Return the new array
            return newArray;
        }

        /*======================================================================================================
         * Function:   PrintMatrix
         * Arguments:  One matrix made of complex numbers
         * Returns:    None
         */

        public void PrintMatrix(ComplexNumber[,] matrix)
        {
            try
            {
                Console.WriteLine();

                // Display each element in the matrix in a specific format
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(String.Format("{0,7}   +{1,7}i    ",
                            (decimal)matrix[i, j].GetRealPart, (decimal)matrix[i, j].GetImaginaryPart));
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                Console.WriteLine();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Elements in the array(matrix) cannot be null");
            }
            
        }
    }
}
