using System;
namespace Chen_Chien_Lin_550C_Assignment3
{
    public class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber complexNumber1 = new ComplexNumber(8.33d, 17.50d);
            ComplexNumber complexNumber2 = new ComplexNumber(1.40d, 6.3d);
            ComplexCalculator calculator = new ComplexCalculator();
            complexNumber1.Multiply(complexNumber2).PrintComplex();
            

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

            //Define 3x3 matrices
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
            Console.WriteLine("3x3");
            
            //Define null matrices
            var matrix5 = new ComplexNumber[2, 3];
            var matrix6 = new ComplexNumber[3, 4];

            var result1 = MutiplyMatrices(matrix3, matrix4);
            var result2 = calculator.MultipyMatrices(matrix5, matrix6);
            PrintMatrix(result1);
            PrintMatrix(result2);


        }

        public static ComplexNumber[,] MutiplyMatrices(ComplexNumber[,] matrix1, ComplexNumber[,] matrix2)
        {
            try
            {
                ComplexCalculator calculator = new ComplexCalculator();
                if (matrix1.GetLength(1) == matrix2.GetLength(0))
                {
                    ComplexNumber[,] newMatrix = new ComplexNumber[matrix1.GetLength(0), matrix2.GetLength(1)];
                    for (int i = 0; i < newMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < newMatrix.GetLength(1); j++)
                        {
                            newMatrix[i, j] = new ComplexNumber(0, 0);
                            for (int k = 0; k < matrix1.GetLength(1); k++)
                            {
                                newMatrix[i, j] =
                                    calculator.Add(newMatrix[i, j], calculator.Mutiply(matrix1[i, k], matrix2[k, j]));
                            }
                        }
                    }
                    return newMatrix;
                }
                else
                {
                    throw new ArgumentException("The Dimensions of two matrices are not match");
                }
            }
            catch (Exception)
            {

                throw new ArgumentNullException("Elements in matrices cannot be null");
            }
        }
        
        public static void PrintMatrix(ComplexNumber[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0} + {1}i  ",
                        matrix[i, j].GetRealPart, matrix[i, j].GetImaginaryPart));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static ComplexNumber[] GetRow(ComplexNumber[,] complexArray, int rowNumber)
        {
            ComplexNumber[] newArray = new ComplexNumber[complexArray.GetLength(1)];

            for (int i = 0; i < complexArray.GetLength(1); i++)
            {
                newArray[i] = complexArray[rowNumber, i];
            }

            return newArray;
        }

        public static ComplexNumber[] GetColumn(ComplexNumber[,] complexArray, int colNumber)
        {
            ComplexNumber[] newArray = new ComplexNumber[complexArray.GetLength(0)];

            for (int i = 0; i < complexArray.GetLength(0); i++)
            {
                newArray[i] = complexArray[i, colNumber];
            }

            return newArray;
        }
    }
}
