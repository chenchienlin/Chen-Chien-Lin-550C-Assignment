using System;

namespace Chen_Chien_Lin_550C_Assignment3
{
    public class ComplexCalculator
    {
        public ComplexNumber Add(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            double newRealPart = complexNumber1.GetRealPart + complexNumber2.GetRealPart;
            double newImaginaryPart = complexNumber1.GetImaginaryPart + complexNumber2.GetImaginaryPart;
            return new ComplexNumber(newRealPart, newImaginaryPart);
        }
        public ComplexNumber Mutiply(ComplexNumber complexNumber1, ComplexNumber complexNumber2)
        {
            double newRealPart = complexNumber1.GetRealPart * complexNumber2.GetRealPart -
                complexNumber1.GetImaginaryPart * complexNumber2.GetImaginaryPart;

            double newImaginaryPart = complexNumber1.GetImaginaryPart * complexNumber2.GetRealPart +
                complexNumber1.GetRealPart * complexNumber2.GetImaginaryPart;

            return new ComplexNumber(newRealPart, newImaginaryPart);
        }

        public ComplexNumber MultiplyArray(ComplexNumber[] array1, ComplexNumber[] array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new IndexOutOfRangeException("Column number in the first array(matrix) and " +
                    "row number in the second array(matrix) should be the same");
            }

            ComplexNumber newComplex = new ComplexNumber(0, 0);
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != null || array2[i] != null)
                {
                   newComplex = Add(newComplex, Mutiply(array1[i], array2[i]));
                }
                else
                {
                    throw new NullReferenceException("Elements in the array(matrix) cannot be null");
                }
            }

            return newComplex;
        }

        public ComplexNumber[,] MultipyMatrices(ComplexNumber[,] matrix1, ComplexNumber[,] matrix2)
        {
            ComplexNumber[,] newMatrix = new ComplexNumber[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    newMatrix[i, j] = MultiplyArray(GetRow(matrix1, i), GetColumn(matrix2, j));
                }
            }

            return newMatrix;
        }

        private ComplexNumber[] GetRow(ComplexNumber[,] complexArray, int rowNumber)
        {
            ComplexNumber[] newArray = new ComplexNumber[complexArray.GetLength(1)];

            for (int i = 0; i < complexArray.GetLength(1); i++)
            {
                newArray[i] = complexArray[rowNumber, i];
            }

            return newArray;
        }

        private ComplexNumber[] GetColumn(ComplexNumber[,] complexArray, int colNumber)
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
