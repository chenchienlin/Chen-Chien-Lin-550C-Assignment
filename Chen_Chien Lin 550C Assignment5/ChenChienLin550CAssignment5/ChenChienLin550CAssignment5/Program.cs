using System;

namespace ChenChienLin550CAssignment5
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator = new ComplexCalculator();
            ComplexNumber[,] matrix1 = new ComplexNumber[2, 2]
        {
                {new ComplexNumber(1.1111111111,1), new ComplexNumber(2.9083920,0)},
                {new ComplexNumber(0.000001,0), new ComplexNumber(2,532198)}
        };
            calculator.PrintMatrix2(matrix1);
            int taskType = GetTaskType();
        

            switch (taskType)
            {
                case 1:
                    int vectorSize = SetVectorSize();
                    Console.WriteLine(Environment.NewLine + "Set the first array!");
                    ComplexNumber[] complexArray1 = SetComplexArray(vectorSize);
                    ConfirmArray(complexArray1);
                    Console.WriteLine(Environment.NewLine + "Set the second Array!");
                    ComplexNumber[] complexArray2 = SetComplexArray(vectorSize);
                    ConfirmArray(complexArray2);
                    break;

                case 2:
                    int[] matrixSize1;
                    int[] matrixSize2;
                    while (true)
                    {
                        Console.WriteLine(Environment.NewLine + "Set the first matrix!");
                        matrixSize1 = SetMatrixSize();
                        Console.WriteLine(Environment.NewLine + "Set the second matrix!");
                        matrixSize2 = SetMatrixSize();
                        if (CanMatch(matrixSize1, matrixSize2)) break;
                    }
                    //ComplexNumber[,] matrix1 = SetComplexMatrix(matrixSize1);
                    ConfirmeMatrix(matrix1);
                    ComplexNumber[,] matrix2 = SetComplexMatrix(matrixSize2);
                    ConfirmeMatrix(matrix2);
                    var result = calculator.MultipyComplexMatrices(matrix1, matrix2);
                    calculator.PrintMatrix2(result);

                    break;
            }
        }

        public static void ConfirmArray(ComplexNumber[] complexArray)
        {
            while(true)
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

        public static void ConfirmeMatrix(ComplexNumber[,] matrix)
        {
            ComplexCalculator calculator = new ComplexCalculator();
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

                calculator.PrintMatrix(matrix);
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
            while(true)
            {
                char userInput = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (userInput == 'y') return true;
                if (userInput == 'n') return false;
            }
        }

        public static void ChangeArrayElement(ComplexNumber[] array)
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
                    elementIndex = index -1;
                    break;
                }
            } while (true);

            array[elementIndex] = SetComplexNumber(needHint);
        }

        public static void ChangeMatrixElement(ComplexNumber[,] matrix)
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

        public static ComplexNumber[] SetComplexArray(int vectorSize)
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

        public static ComplexNumber[,] SetComplexMatrix(int[] matrixSize)
        {
            bool needHint = true;
            int rowNumber = matrixSize[0];
            int colNumber = matrixSize[1];
            ComplexNumber[,] matrix = new ComplexNumber[rowNumber, colNumber];
            for (int i = 0; i < rowNumber;i++)
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

        public static string[] ReadInput()
        {
            return Console.ReadLine().Replace(" ", "").Split(',');
        }

        public static ComplexNumber SetComplexNumber(bool needHint)
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

        public static int SetVectorSize()
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
        
        public static int[] SetMatrixSize()
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

        public static bool CanMatch(int[] matrixSize1, int[] matrixSize2)
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



        public static bool CanConvertToInt(string userInput)
        {
            int n;
            bool isNumeric = int.TryParse(userInput, out n);
            return isNumeric;
        }

        public static bool CanConvertToDouble(string userInput)
        {
            double n;
            bool isNumeric = double.TryParse(userInput, out n);
            return isNumeric;
        }

        public static int GetTaskType()
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
    }
}
