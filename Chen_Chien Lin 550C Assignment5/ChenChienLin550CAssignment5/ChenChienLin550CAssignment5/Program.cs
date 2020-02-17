using System;

namespace ChenChienLin550CAssignment5
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator = new ComplexCalculator();
            int taskType = calculator.GetTaskType();

            switch (taskType)
            {
                case 1:
                    int vectorSize = calculator.SetVectorSize();
                    Console.WriteLine(Environment.NewLine + "Set the first array!");
                    ComplexNumber[] complexArray1 = calculator.SetComplexArray(vectorSize);
                    calculator.ConfirmArray(complexArray1);
                    Console.WriteLine(Environment.NewLine + "Set the second Array!");
                    ComplexNumber[] complexArray2 = calculator.SetComplexArray(vectorSize);
                    calculator.ConfirmArray(complexArray2);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Environment.NewLine + "Result: ");
                    Console.Write(calculator.MultiplyComplexArray(complexArray1, complexArray2).ToString());
                    Console.WriteLine();
                    Console.ResetColor();
                    break;

                case 2:
                    int[] matrixSize1;
                    int[] matrixSize2;
                    while (true)
                    {
                        Console.WriteLine(Environment.NewLine + "Set the first matrix!");
                        matrixSize1 = calculator.SetMatrixSize();
                        Console.WriteLine(Environment.NewLine + "Set the second matrix!");
                        matrixSize2 = calculator.SetMatrixSize();
                        if (calculator.CanMatch(matrixSize1, matrixSize2)) break;
                    }
                    ComplexNumber[,] matrix1 = calculator.SetComplexMatrix(matrixSize1);
                    calculator.ConfirmeMatrix(matrix1);
                    ComplexNumber[,] matrix2 = calculator.SetComplexMatrix(matrixSize2);
                    calculator.ConfirmeMatrix(matrix2);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Environment.NewLine + "Result: ");
                    calculator.PrintMatrix(calculator.MultipyComplexMatrices(matrix1, matrix2));
                    Console.ResetColor();
                    break;
            }

            GC.Collect();
        }
    }
}
