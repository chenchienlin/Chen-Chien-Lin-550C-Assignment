using System;

namespace ChenChienLin550CAssignment8ComplexNumber
{
    public class ComplexNumber
    {
        // Two fields are defined in this class. Both of them are private.
        // Users cannot modified these values directly.
        private double realPart;
        private double imaginaryPart;


        // Define a constructor of ComplexNumber class
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.realPart = realPart;
            this.imaginaryPart = imaginaryPart;
        }

        //Define a destructor of ComplexNumber class
        ~ComplexNumber()
        {
            bool isDebug = false;
            System.Diagnostics.Debug.Assert(isDebug = true);

            if (isDebug)
            {
                Console.WriteLine(Environment.NewLine +
                    "The object is destructed at " + System.DateTime.Now);
            }
        }

        /*==========================================================================
         * Function:   RealPart
         * Arguments:  None
         * Returns:    One number which is the real part of a complex number
         */

        public double RealPart
        {
            // Getter for the real part of a complex number
            get { return realPart; }
        }

        /*==========================================================================
         * Function:   ImaginaryPart
         * Arguments:  None
         * Returns:    One number which is the imaginary part of a complex number
         */

        public double ImaginaryPart
        {
            // Getter for the imaginary part of a complex number
            get { return imaginaryPart; }
        }

        /*==========================================================================
         * Function:   AbsoluteValue
         * Arguments:  None
         * Returns:    One number which is the magnitude of a complex number
         */

        public double AbsoluteValue
        {
            // Getter for the absolute value of a complex number
            get { return System.Math.Round(System.Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), 3); }
        }

        /*==========================================================================
         * Function:   Phase
         * Arguments:  None
         * Returns:    One number which is the phase of a complex number
         */

        public double Phase
        {
            // Getter for the phase of a complex number
            get { return System.Math.Round(System.Math.Atan2(imaginaryPart, realPart), 3); }
        }

        /*==========================================================================
         * Function:   PolarForm
         * Arguments:  None
         * Returns:    One number which is the imaginary part of a complex number
         */

        public string PolarForm
        {
            // Getter for the polar form of a complex number
            get
            {
                return String.Format("{0}( cos({1} + isin({1}) )",
                System.Math.Round(System.Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart), 3),
                System.Math.Round(System.Math.Atan2(imaginaryPart, realPart), 3));
            }
        }

        /*==========================================================================
         * Function:   operator + 
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public static ComplexNumber operator +(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Return the addtion result of two complex numbers
            return new ComplexNumber(complexNumber1.RealPart + complexNumber2.RealPart,
                                     complexNumber1.ImaginaryPart + complexNumber2.ImaginaryPart);
        }

        /*==========================================================================
         * Function:   operator -
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public static ComplexNumber operator -(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Return the subtraction result of two complex numbers
            return new ComplexNumber(complexNumber1.RealPart - complexNumber2.RealPart,
                                     complexNumber1.ImaginaryPart - complexNumber2.ImaginaryPart);
        }

        /*==========================================================================
         * Function:   operator *
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public static ComplexNumber operator *(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Store the real part and imaginary part of two complex numbers as local vairables
            double number1RePart = complexNumber1.RealPart;
            double number1ImPart = complexNumber1.ImaginaryPart;
            double number2RePart = complexNumber2.RealPart;
            double number2ImPart = complexNumber2.ImaginaryPart;

            // Compute and store the real part and imaginary part of the new complex number
            double newRealPart = number1RePart * number2RePart - number1ImPart * number2ImPart;
            double newImaginaryPart = number1ImPart * number2RePart + number1RePart * number2ImPart;

            // Return the multiplication result of two complex numbers
            return new ComplexNumber(newRealPart, newImaginaryPart);
        }

        /*==========================================================================
         * Function:   operator /
         * Arguments:  Two complex numbers
         * Returns:    One complex number
         */

        public static ComplexNumber operator /(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            // Division : Smith's formula.
            double a = complexNumber1.realPart;
            double b = complexNumber1.imaginaryPart;
            double c = complexNumber2.realPart;
            double d = complexNumber2.imaginaryPart;

            ComplexNumber resDiv = new ComplexNumber(0, 0);

            // Computing c * c + d * d will overflow even in cases where the actual result of the division does not overflow.
            if (Math.Abs(d) < Math.Abs(c))
            {
                double doc = d / c;
                resDiv.realPart = (a + b * doc) / (c + d * doc);
                resDiv.imaginaryPart = (b - a * doc) / (c + d * doc);
            }
            else
            {
                double cod = c / d;
                resDiv.realPart = (b + a * cod) / (d + c * cod);
                resDiv.imaginaryPart = (-a + b * cod) / (d + c * cod);
            }

            return resDiv;
        }

        /*==========================================================================
         * Function:   ToString
         * Arguments:  None
         * Returns:    One string
         */
        public override string ToString()
        {
            double roundRealPart = Math.Round(realPart, 4);
            double roundImaginaryPart = Math.Round(imaginaryPart, 4);

            if (this.realPart != 0 && this.imaginaryPart > 0)
            {
                return String.Format("{0} + {1}i", roundRealPart, roundImaginaryPart);
            }
            if (this.realPart != 0 && this.imaginaryPart < 0)
            {
                return String.Format("{0} - {1}i", roundRealPart, roundImaginaryPart * (-1));
            }
            if (this.realPart != 0 && this.imaginaryPart == 0) return roundRealPart.ToString();
            if (this.imaginaryPart != 0) return String.Format("{0}i", roundImaginaryPart);
            return "0";
        }

    }
    public class ComplexCalculator
    {
        private int taskType;

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
         * Function:   PrintArray
         * Arguments:  One array made of complex numbers
         * Returns:    None
         */

        public void PrintArray(ComplexNumber[] complexArray)
        {
            try
            {
                //Print an array in a specific format
                Console.Write("Your array : [ ");
                foreach (var element in complexArray)
                {
                    Console.Write(element.ToString() + "  ");
                }
                Console.Write(" ] " + Environment.NewLine);

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Elements in the array cannot be null");
            }

        }

        /*======================================================================================================
         * Function:   PrintMatrix
         * Arguments:  One matrix made of complex numbers
         * Returns:    None
         */

        public void PrintMatrix(ComplexNumber[,] complexMatrix)
        {
            try
            {
                //Print a matrix in a specific format
                for (int i = 0; i < complexMatrix.GetLength(0); i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < complexMatrix.GetLength(1); j++)
                    {
                        Console.Write(complexMatrix[i, j].ToString().PadRight(20));
                    }
                    Console.Write("]" + Environment.NewLine);
                }
                Console.WriteLine();

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Elements in the matrix cannot be null");
            }

        }

        /*======================================================================================================
         * Function:   SetComplexArray
         * Arguments:  One integer
         * Returns:    One array made of  complex numbers
         */

        public ComplexNumber[] SetComplexArray(int vectorSize)
        {
            //Define a boolean variable
            bool needHint = true;

            //Create a new complex array contains certain element
            ComplexNumber[] complexArray = new ComplexNumber[vectorSize];

            //Assignment each element in the array
            for (int i = 0; i < vectorSize; i++)
            {
                Console.WriteLine(String.Format("Set the {0} element in the array!", i + 1));
                complexArray[i] = SetComplexNumber(needHint);
                needHint = false;
            }

            //Return new array
            return complexArray;
        }

        /*======================================================================================================
         * Function:   SetComplexMatrix
         * Arguments:  One array contains integer
         * Returns:    One matrix made of complex numbers
         */

        public ComplexNumber[,] SetComplexMatrix(int[] matrixSize)
        {
            //Define local variables
            bool needHint = true;
            int rowNumber = matrixSize[0];
            int colNumber = matrixSize[1];

            //Create a new matrix with certain size
            ComplexNumber[,] matrix = new ComplexNumber[rowNumber, colNumber];

            //Assginment each element in the matrix
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
            //Return new matrix
            return matrix;
        }

        /*======================================================================================================
         * Function:   SetVectorSize
         * Arguments:  None
         * Returns:    One integer
         */

        public int SetVectorSize()
        {
            Console.WriteLine("Enter the size of two complex number vectors");

            do
            {
                //Read user input
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

                //Define a integer 
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

                //Return the integer
                return Convert.ToInt32(userInput[0]);

            } while (true);
        }

        /*======================================================================================================
        * Function:   SetMatrixSize
        * Arguments:  None
        * Returns:    One integer array
        */

        public int[] SetMatrixSize()
        {
            Console.WriteLine("Enter the size of a matrix");

            do
            {
                //Read user input
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

                //Define two integer
                int rownumber = Convert.ToInt32(userInput[0]);
                int colnumber = Convert.ToInt32(userInput[1]);
                if (rownumber <= 0 || colnumber <= 0)
                {
                    Console.WriteLine("The row number and column number of a matrix" +
                                      "cannot be or less than zero!");
                }
                if (taskType == 3 && rownumber != colnumber)
                {
                    Console.WriteLine("Must be square matrix to complete division!");
                    continue;
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

                //Return one integer array
                return new int[] { rownumber, colnumber };

            } while (true);
        }

        /*======================================================================================================
         * Function:   CanMatch
         * Arguments:  Two integer arrays
         * Returns:    One boolean
         */

        public bool CanMatch(int[] matrixSize1, int[] matrixSize2)
        {
            //Test the sizes of two matrices
            if (taskType == 3 && matrixSize1[1] != matrixSize2[0])
            {
                Console.WriteLine("The dimensions of two matrices are incorrect!" +
                    Environment.NewLine +
                    "The column number of the first matrix and the row number of the " +
                    "second matrix should be consistant to complete division!" +
                    Environment.NewLine +
                    "Ex: matrix1 : 3,3  matrix2 : 3,3");
                return false;
            }

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

        /*======================================================================================================
         * Function:   ConfirmArray
         * Arguments:  One array made of complex number
         * Returns:    void
         */

        public void ConfirmArray(ComplexNumber[] complexArray)
        {
            while (true)
            {
                //Print array
                PrintArray(complexArray);

                if (!IsCorrect())
                {
                    //Change the specific element in the array
                    ChangeArrayElement(complexArray);
                }
                else break;
            }
        }

        /*======================================================================================================
         * Function:   ConfirmeMatrix
         * Arguments:  One matrix made of complex number
         * Returns:    Void
         */

        public void ConfirmeMatrix(ComplexNumber[,] matrix)
        {
            while (true)
            {
                //Print matrix
                PrintMatrix(matrix);

                if (!IsCorrect())
                {
                    //Change the specific element in the matrix
                    ChangeMatrixElement(matrix);
                }
                else break;
            }
        }

        /*======================================================================================================
         * Function:   IsCorrect
         * Arguments:  Void
         * Returns:    Boolean
         */

        private static bool IsCorrect()
        {
            Console.WriteLine("Is it correct? Please select (y/n)!");
            while (true)
            {
                //Read user input
                char userInput = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (userInput == 'y') return true;
                if (userInput == 'n') return false;
            }
        }

        /*======================================================================================================
         * Function:   ChangeArrayElement
         * Arguments:  One array made of complex numbers
         * Returns:    Void
         */

        private void ChangeArrayElement(ComplexNumber[] array)
        {
            //Define local variables
            int index;
            bool needHint = true;

            Console.WriteLine("Which element you want to replace?" +
                              "Enter the index of that element" +
                              Environment.NewLine +
                              "Ex: 1 or 3 or 6...");
            do
            {
                //Read user input
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

                //Assign the integer
                index = Convert.ToInt32(userinput[0]);
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
                    index -= 1;
                    break;
                }
            } while (true);

            //Reset the specific element in the array
            array[index] = SetComplexNumber(needHint);
        }

        /*======================================================================================================
         * Function:   ChangeMatrixElement
         * Arguments:  One matrix made of complex numbers
         * Returns:    Void
         */

        private void ChangeMatrixElement(ComplexNumber[,] matrix)
        {
            //Define local variables
            int rownumber;
            int colnumber;
            bool needHint = true;

            Console.WriteLine("Which element you want to replace?" +
                              "Enter the position of that element" +
                              Environment.NewLine +
                              "Ex: 1,2  3,4");
            do
            {
                //Read user input
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

                //Assign two integers
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

            //Reset the specific element in the matrix
            matrix[rownumber, colnumber] = SetComplexNumber(needHint);
        }

        /*======================================================================================================
         * Function:   SetComplexNumber
         * Arguments:  One boolean
         * Returns:    One complex number
         */

        public ComplexNumber SetComplexNumber(bool needHint)
        {
            do
            {
                //Print hint 
                if (needHint)
                {
                    Console.WriteLine("Enter two numeric numbers and seperate them with a comma." +
                        Environment.NewLine + "Ex:  2,2  or  -2,-2  or  0,2  or  2,0 ");
                }

                //Read user input
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
                    //Return the complex number set by user
                    return new ComplexNumber(Convert.ToDouble(userInput[0]),
                                             Convert.ToDouble(userInput[1]));
                }
            } while (true);
        }

        /*======================================================================================================
         * Function:   ReadInput
         * Arguments:  None
         * Returns:    One string
         */

        public string[] ReadInput()
        {
            //Return a string
            return Console.ReadLine().Replace(" ", "").Split(',');
        }

        /*======================================================================================================
         * Function:   CanConvertToInt
         * Arguments:  One string
         * Returns:    One boolean
         */

        private bool CanConvertToInt(string userInput)
        {
            //Define a local variable
            int n;

            //Test the type of user input
            bool isInt = int.TryParse(userInput, out n);

            //Return a boolean value
            return isInt;
        }

        /*======================================================================================================
         * Function:   CanConvertToDouble
         * Arguments:  One string
         * Returns:    One boolean
         */

        private bool CanConvertToDouble(string userInput)
        {
            //Define a local variable
            double n;

            //Test the type of user input
            bool isDouble = double.TryParse(userInput, out n);

            //Return a boolean value
            return isDouble;
        }

        /*======================================================================================================
         * Function:   GetTaskType
         * Arguments:  Void
         * Returns:    One integer
         */

        public int GetTaskType()
        {
            Console.WriteLine("Welcome to complex number calculator\n" +
                "What do you want to do?\n" +
                "A. Two Arrays Multiplication\n" +
                "B. Two Matrices Multiplication\n" +
                "C. Two Matrices Division ( inverse[1st Matrix] * [2nd Matrix] )"
                );
            while (true)
            {
                //Read user input
                char userInput = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (userInput == 'a')
                {
                    this.taskType = 1;
                    return 1;
                }
                if (userInput == 'b')
                {
                    this.taskType = 2;
                    return 2;

                }
                if (userInput == 'c')
                {
                    this.taskType = 3;
                    return 3;
                }
            }
        }

        /*======================================================================================================
         * Function:   MatrixCreate
         * Arguments:  Two integers
         * Returns:    One jagged array
         */

        private ComplexNumber[][] MatrixCreate(int rows, int cols)
        {
            //Create a jagged array
            ComplexNumber[][] result = new ComplexNumber[rows][];

            //Initiate values
            for (int i = 0; i < rows; ++i) { result[i] = new ComplexNumber[cols]; }

            //Resutre a jagged array
            return result;
        }

        /*======================================================================================================
         * Function:   MatrixDuplicate
         * Arguments:  TOne jagged array
         * Returns:    One jagged array
         */

        private ComplexNumber[][] MatrixDuplicate(ComplexNumber[][] matrix)
        {
            // Create a duplicate of a matrix.
            ComplexNumber[][] result = MatrixCreate(matrix.Length, matrix[0].Length);

            for (int i = 0; i < matrix.Length; ++i)
                for (int j = 0; j < matrix[i].Length; ++j)

                    // copy the values
                    result[i][j] = matrix[i][j];
            return result;
        }

        /*======================================================================================================
         * Function:   MatrixInverse
         * Arguments:  One jagged array
         * Returns:    One jagged array
         */

        public ComplexNumber[][] MatrixInverse(ComplexNumber[][] matrix)
        {
            //Define local variables
            int n = matrix.Length;
            ComplexNumber[][] result = MatrixDuplicate(matrix);
            int[] perm;
            int toggle;
            ComplexNumber[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            ComplexNumber[] b = new ComplexNumber[n];

            if (lum == null)
                throw new Exception("Unable to compute inverse");

            //Inverse 
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        //b[j] = 1.0;
                        b[j] = new ComplexNumber(1.0, 0);
                    else
                        //b[j] = 0.0;
                        b[j] = new ComplexNumber(0, 0);
                }

                ComplexNumber[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        /*======================================================================================================
         * Function:   HelperSolve
         * Arguments:  One jagged array and One array
         * Returns:    One array
         */

        private ComplexNumber[] HelperSolve(ComplexNumber[][] luMatrix, ComplexNumber[] b)
        {
            //Define local variables
            int n = luMatrix.Length;
            ComplexNumber[] x = new ComplexNumber[n];

            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                //Assign values
                ComplexNumber sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                ComplexNumber sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        private ComplexNumber[][] MatrixDecompose(ComplexNumber[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows; // convenience

            ComplexNumber[][] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                //Find largest value in col
                double colMax = result[j][j].AbsoluteValue;
                int pRow = j;

                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j].AbsoluteValue > colMax)
                    {
                        colMax = result[i][j].AbsoluteValue;
                        pRow = i;
                    }
                }

                //If largest value not on pivot, swap rows
                if (pRow != j)
                {
                    ComplexNumber[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    //Adjust toggle
                    toggle = -toggle;
                }

                if (result[j][j].AbsoluteValue == 0.0)
                {
                    //Find a row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j].AbsoluteValue != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    //Swap rows
                    ComplexNumber[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow];
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    //Adjust toggle
                    toggle = -toggle;
                }

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            }

            return result;
        }

        /*======================================================================================================
        * Function:   ConvertToJagged
        * Arguments:  One matrix
        * Returns:    One jagged array
        */

        public ComplexNumber[][] ConvertToJagged(ComplexNumber[,] matrix)
        {
            //Define local variables
            int rows = matrix.GetLength(1);
            int cols = matrix.GetLength(0);
            ComplexNumber[][] newMatrix = new ComplexNumber[rows][];

            for (int i = 0; i < rows; i++)
            {
                ComplexNumber[] temp = new ComplexNumber[cols];
                for (int j = 0; j < cols; j++)
                {
                    //Assign values
                    temp[j] = matrix[i, j];
                }
                newMatrix[i] = temp;
            }

            //Return matrix
            return newMatrix;
        }

        /*======================================================================================================
        * Function:   ConvertToMatrix
        * Arguments:  One jagged array
        * Returns:    One array
        */

        public ComplexNumber[,] ConvertToMatrix(ComplexNumber[][] matrix)
        {
            //Define local variables
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            ComplexNumber[,] newMatrix = new ComplexNumber[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //Assign values
                    newMatrix[i, j] = matrix[i][j];
                }
            }

            //Return matrix
            return newMatrix;
        }
    }
}
namespace ChenChienLin550CAssignment8Controller
{
    using ChenChienLin550CAssignment8ComplexNumber;

    public class StateFeedBack
    {
        public double[,] PolePlacement()
        {
            ComplexCalculator complexCalculator = new ComplexCalculator();
            ComplexNumber[] newPoleLocation;

            if (Controllable() == true && Observable() == true)
            {
                int newPoleNumber = complexCalculator.SetVectorSize();

                newPoleLocation = complexCalculator.SetComplexArray(newPoleNumber);

                //Use new pole location to compute State feedback gain matrix K
                //double[,] K = new double[,];
                //return double[,] K;

            }
            else
            {
                throw new System.ArgumentException("Input system is not controllable and observable");
            }
        }

        public bool Controllable()
        {
            // Compute Contrallablity 
            return true;
        }

        public bool Observable()
        {

            // Compute Observability 
            return true;
        }
    }
}

namespace ChenChienLin550CAssignment8Model
{
    using ChenChienLin550CAssignment8ComplexNumber;
    public abstract class StateSpaceSystem
    {
        public void SetStateMatrix()
        {

        }

        public void SetInputMatrix()
        {

        }

        public void SetOutputMatrix()
        {

        }
        public void SetDirectTransitionMatrix()
        {

        }

        public abstract float[] GetTransferFunction();

        public abstract bool BIBOStability();
        public abstract bool EigenValueStability();
        public abstract bool LyapunovStability();
        public abstract ComplexNumber[] PoleLocation();
        public abstract ComplexNumber[] ZeroLocation();

    }

    public class ContinousTimeStateSpaceSystem : StateSpaceSystem
    {
        public override bool BIBOStability()
        {
            //Check whether all poles are in open left hand plane
            return true;
        }

        public override bool EigenValueStability()
        {
            //Check internal stability
            return true;
        }

        public override bool LyapunovStability()
        {
            //Check continous time lyapunov equation
            return true;
        }

        public override ComplexNumber[] PoleLocation()
        {
            int poleNumber;
            //Compute pole location
            ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

            return poleLocation;
        }

        public override ComplexNumber[] ZeroLocation()
        {
            int zerosNumber;
            //Compute zero location
            ComplexNumber[] zoreLocation = new ComplexNumber[zerosNumber];

            return zoreLocation;
        }
    }

    public class DiscreteTimeStateSpaceSystem : StateSpaceSystem
    {
        public override bool BIBOStability()
        {
            //Check whether all poles are in unit disc
            return true;
        }

        public override bool EigenValueStability()
        {
            //Check internal stability
            return true;
        }

        public override bool LyapunovStability()
        {
            //Check discrete time lyapunov equation
            return true;
        }

        public override ComplexNumber[] PoleLocation()
        {
            int poleNumber;
            //Compute pole location
            ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

            return poleLocation;
        }

        public override ComplexNumber[] ZeroLocation()
        {
            int zerosNumber;
            //Compute zero location
            ComplexNumber[] zoreLocation = new ComplexNumber[zerosNumber];

            return zoreLocation;
        }
    }
}