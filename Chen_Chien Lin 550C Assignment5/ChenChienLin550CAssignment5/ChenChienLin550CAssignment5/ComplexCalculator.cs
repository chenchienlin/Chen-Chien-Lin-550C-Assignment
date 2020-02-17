/*****************************************************************************************************************
 * Assignment 4 :  Complex Number Operation__Complex Calculator Class                                            *
 *                                                                                                               *
 * Name:           Chen-Chien Lin                                                                                *
 * Student Number: 46205175                                                                                      *
 * Purpose:        Create a class to perform math operation related to ComplexNumber Class                       *
 *                                                                                                               *
 * Description:    In this C# script, a helper class is created,                                                 *
 *                 no fields are declared in this class.                                                         *
 *                 The purpose of this class is to calculate                                                     *
 *                 arrays and matrices made of complex numbers.                                                  *
 *****************************************************************************************************************/


/************************************************ USING NAMESPACES ***********************************************/
using System;

/********************************************* NAMESPACE DECLARATION *********************************************/
namespace ChenChienLin550CAssignment5
{
    public class ComplexCalculator
    {

        /*======================================================================================================
         * Function:   MultiplyComplexArray
         * Arguments:  Two arrays contain complex numbers
         * Returns:    One array made of complex numbers
         */

        public ComplexNumber MultiplyComplexArray(ComplexNumber[] array1, ComplexNumber[] array2)
        {
            // The dimension of the row vector and the column vector must be match 
            if (array1.Length != array2.Length)
            {
                throw new IndexOutOfRangeException("Column number in the first array(matrix) and " +
                    "row number in the second array(matrix) should be the same");
            }

            // Initialize a new complex number
            ComplexNumber newComplex = new ComplexNumber(0, 0);

            // Compute new complex number using opertors overloaded in ComplexNumber class
            for (int i = 0; i < array1.Length; i++)
            {

                // The elements in the vector cannot be null
                try
                {
                    newComplex = newComplex + (array1[i] * array2[i]);
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
         * Function:   MultipyComplexMatrices
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadRight(15));
                }
                Console.Write("]");
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine();

        }

        //public void PrintMatrix2(ComplexNumber[,] matrix)
        //{
        //    try
        //    {
        //        Console.WriteLine();

        //        // Display each element in the matrix in a specific format
        //        for (int i = 0; i < matrix.GetLength(0); i++)
        //        {
        //            Console.Write("[");
        //            for (int j = 0; j < matrix.GetLength(1); j++)
        //            {
        //                Console.Write(matrix[i, j].ToString().PadRight(15));
        //            }
        //            Console.Write("]");
        //            Console.WriteLine(Environment.NewLine);
        //        }
        //        Console.WriteLine();
        //    }
        //    catch (NullReferenceException)
        //    {
        //        throw new NullReferenceException("Elements in the array(matrix) cannot be null");
        //    }

        //}

        public ComplexNumber[,] SetComplexMatrix(int[] matrixSize)
        {
            bool needHint = true;
            int rowNumber = matrixSize[0];
            int colNumber = matrixSize[1];
            ComplexNumber[,] matrix = new ComplexNumber[rowNumber, colNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < colNumber; j++)
                {
                    Console.WriteLine(String.Format("Set the element [{0}, {1}] in the matrix",
                                      i + 1, j + 1));
                    matrix[i, j] = SetComplexNumber(needHint);
                    needHint = false;
                }
            }

            return matrix;
        }

        public string[] ReadInput()
        {
            return Console.ReadLine().Replace(" ", "").Split(',');
        }

        public ComplexNumber SetComplexNumber(bool needHint)
        {
            do
            {
                if (needHint)
                {
                    Console.WriteLine("Enter two numeric numbers and seperate them with a comma." +
                        Environment.NewLine + "Ex:  2,2  or  -2,-2  or  0,2  or  2,0 ");
                }

                string[] userInput = ReadInput();
                if (userInput.Length != 2)
                {
                    Console.WriteLine("A complex number should contain 2 components." +
                        "One Real Part and One Imaginary Part");
                    needHint = true;
                    continue;
                }
                if (!CanConvertToDouble(userInput[0]) || !CanConvertToDouble(userInput[1]))
                {
                    Console.WriteLine("Input must be numeric!");
                    needHint = true;
                    continue;
                }
                else
                {
                    return new ComplexNumber(Convert.ToDouble(userInput[0]),
                                             Convert.ToDouble(userInput[1]));
                }
            } while (true);
        }

        public int SetVectorSize()
        {
            do
            {
                Console.WriteLine("Enter the size of two complex number vectors");
                string[] userInput = ReadInput();
                if (userInput.Length != 1)
                {
                    Console.WriteLine("The size of a vector is only one dimension!" +
                                      "Ex: 2 or 5...");
                    continue;
                }
                if (!CanConvertToInt(userInput[0]))
                {
                    Console.WriteLine("The size must be numeric and should be integer!");
                    continue;
                }

                int size = Convert.ToInt32(userInput[0]);
                if (size <= 0)
                {
                    Console.WriteLine("The size of a vector cannot be or less than zero!");
                    continue;
                }

                if (size == 1)
                {
                    // Set the Foreground color
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Warning: Your arrays only contain 1 element!");
                    Console.ResetColor();
                }
                return Convert.ToInt32(userInput[0]);

            } while (true);
        }

        public int[] SetMatrixSize()
        {
            Console.WriteLine("Enter the size of a matrix");
            do
            {
                string[] userInput = ReadInput();
                if (userInput.Length != 2)
                {
                    Console.WriteLine("Enter the size of a matrix should contain" +
                        "its row number and its column number. Ex: 2,2 or 3,5");
                    continue;
                }
                if (!CanConvertToInt(userInput[0]) || !CanConvertToInt(userInput[1]))
                {
                    Console.WriteLine("The size must be numeric and should be integer!");
                    continue;
                }
                int rownumber = Convert.ToInt32(userInput[0]);
                int colnumber = Convert.ToInt32(userInput[1]);
                if (rownumber <= 0 || colnumber <= 0)
                {
                    Console.WriteLine("The row number and column number of a matrix" +
                                      "cannot be or less than zero!");
                }
                if (rownumber == 1)
                {
                    // Set the Foreground color
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Warning: Your matrix only contains 1 row!");
                    Console.ResetColor();
                }
                if (colnumber == 1)
                {
                    // Set the Foreground color
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Warning: Your matrix only contains 1 column!");
                    Console.ResetColor();
                }
                else
                {
                    return new int[] { rownumber, colnumber };
                }

            } while (true);
        }

        public bool CanMatch(int[] matrixSize1, int[] matrixSize2)
        {
            if (matrixSize1[1] != matrixSize2[0])
            {
                Console.WriteLine("The dimensions of two matrices are incorrect!" +
                    Environment.NewLine +
                    "The column number of the first matrix and the row number of the " +
                    "second matrix should be consistant!" +
                    Environment.NewLine +
                    "Ex: matrix1 : 2,3  matrix2 : 3,4");
                return false;
            }
            return true;
        }

        public bool CanConvertToInt(string userInput)
        {
            int n;
            bool isNumeric = int.TryParse(userInput, out n);
            return isNumeric;
        }

        public bool CanConvertToDouble(string userInput)
        {
            double n;
            bool isNumeric = double.TryParse(userInput, out n);
            return isNumeric;
        }

        public int GetTaskType()
        {
            Console.WriteLine("Which do you want to calculate?" +
                              Environment.NewLine +
                              "A. Two Arrays" + Environment.NewLine +
                              "B. Two Matrices");
            while (true)
            {
                char userInput = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (userInput == 'a') return 1;
                if (userInput == 'b') return 2;
            }
        }

        public void ConfirmArray(ComplexNumber[] complexArray)
        {
            while (true)
            {
                Console.Write("Your array : [ ");
                foreach (var element in complexArray)
                {
                    Console.Write(element.ToString() + "  ");
                }
                Console.Write(" ] " + Environment.NewLine);

                if (!IsCorrect())
                {
                    ChangeArrayElement(complexArray);
                }
                else break;
            }
        }

        public void ConfirmeMatrix(ComplexNumber[,] matrix)
        {
            while (true)
            {
                Console.WriteLine("Your Matrix:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j].ToString().PadRight(15));
                    }
                    Console.Write("]" + Environment.NewLine);
                }
                Console.WriteLine();

                if (!IsCorrect())
                {
                    ChangeMatrixElement(matrix);
                }
                else break;
            }
        }

        public static bool IsCorrect()
        {
            Console.WriteLine("Is it correct? Please select (y/n)!");
            while (true)
            {
                char userInput = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (userInput == 'y') return true;
                if (userInput == 'n') return false;
            }
        }

        public void ChangeArrayElement(ComplexNumber[] array)
        {
            int elementIndex;
            bool needHint = true;
            Console.WriteLine("Which element you want to replace?" +
                              "Enter the index of that element" +
                              Environment.NewLine +
                              "Ex: 1 or 3 or 6...");
            do
            {
                string[] userinput = ReadInput();
                if (userinput.Length != 1)
                {
                    Console.WriteLine("The index of a vector is only one dimension!" +
                                      "Ex: 2 or 5...");
                    continue;
                }
                if (!CanConvertToInt(userinput[0]))
                {
                    Console.WriteLine("The index must be numeric and should be integer!");
                    continue;
                }

                int index = Convert.ToInt32(userinput[0]);
                if (index <= 0)
                {
                    Console.WriteLine("The index of a vector cannot be or less than zero!");
                    continue;
                }

                if (index > array.Length)
                {
                    Console.WriteLine(String.Format("Your array only have {0} elemnts, " +
                                                    "you cannot change the {1} element in the array",
                                                    array.Length, index));
                    continue;
                }
                else
                {
                    elementIndex = index - 1;
                    break;
                }
            } while (true);

            array[elementIndex] = SetComplexNumber(needHint);
        }

        public void ChangeMatrixElement(ComplexNumber[,] matrix)
        {
            int rownumber;
            int colnumber;
            bool needHint = true;

            Console.WriteLine("Which element you want to replace?" +
                              "Enter the position of that element" +
                              Environment.NewLine +
                              "Ex: 1,2  3,4");
            do
            {
                string[] position = ReadInput();
                if (position.Length != 2)
                {
                    Console.WriteLine("The position of a element contains its row number " +
                        "and its column number. Ex: 2,2 or 3,5");
                    continue;
                }
                if (!CanConvertToInt(position[0]) || !CanConvertToInt(position[1]))
                {
                    Console.WriteLine("The position must be numeric and should be integer!");
                    continue;
                }
                rownumber = Convert.ToInt32(position[0]);
                colnumber = Convert.ToInt32(position[1]);
                if (rownumber <= 0 || colnumber <= 0)
                {
                    Console.WriteLine("The row number and column number of a matrix" +
                                      "cannot be or less than zero!");
                    continue;
                }
                if (rownumber > matrix.GetLength(0))
                {
                    Console.WriteLine(String.Format("Your matrix only have {0} row, " +
                                                    "you cannot change the element be change in {1} row",
                                                    matrix.GetLength(0), rownumber));
                    continue;
                }
                if (colnumber > matrix.GetLength(1))
                {
                    Console.WriteLine(String.Format("Your matrix only have {0} column, " +
                                                    "you cannot change the element be change in {1} column",
                                                    matrix.GetLength(1), colnumber));
                    continue;
                }
                else
                {
                    rownumber -= 1;
                    colnumber -= 1;
                    break;
                }
            } while (true);
            matrix[rownumber, colnumber] = SetComplexNumber(needHint);
        }

        public ComplexNumber[] SetComplexArray(int vectorSize)
        {
            bool needHint = true;
            ComplexNumber[] complexArray = new ComplexNumber[vectorSize];
            for (int i = 0; i < vectorSize; i++)
            {
                Console.WriteLine(String.Format("Set the {0} element in the array!", i + 1));
                complexArray[i] = SetComplexNumber(needHint);
                needHint = false;
            }
            return complexArray;
        }

        public void PrintMatrix()
        {

        }
    }
}
