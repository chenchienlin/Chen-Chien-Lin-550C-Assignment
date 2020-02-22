/*******************************************************************************************************
 * Assignment 5:   Complex Number Operation__Program Class                                             *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Implement the ComplexCalculator class, and its method to calculate complex number.  *
 *                                                                                                     *
 * Description:    In this project, a new class is created to defined a complex number.                *
 *                 Another class, ComplexCalculator, is created to calculate matrices                  *
 *                 made of complex numbers.                                                            *
 *                 This class implement the ComplexCalculator calss, and create the sequence           *
 *                 to call the method in ComplexCalculator class.                                      *
 *                 After finishing calculation, garbage collection mechanism is called                 *
 *                 to clean unused objects from the memory. The message will show in Debug mode.       *          
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using System;

/*************************************** NAMESPACE DECLARATION *****************************************/
namespace ChenChienLin550CAssignment5
{
    class Program
    {

        /*==============================================================================
         * Function:   Main
         * Arguments:  string[] args
         * Returns:    None
         */

        static void Main(string[] args)
        {
            //Create an instance of ComplexCalculator class
            var calculator = new ComplexCalculator();

            //Create a integer represent task type
            int taskType = calculator.GetTaskType();

            //Decide the task type
            switch (taskType)
            {
                //Define the process to calculate two arrays
                case 1:

                    Console.WriteLine("\nSet the first vector!");

                    //Define a integer represent vector size
                    int vectorSize = calculator.SetVectorSize();

                    //Set the first array based on user input
                    ComplexNumber[] complexArray1 = calculator.SetComplexVector(vectorSize);
                    calculator.ConfirmVector(complexArray1);

                    Console.WriteLine("\nSet the second vector!");

                    //Set the second array based on user input
                    ComplexNumber[] complexArray2 = calculator.SetComplexVector(vectorSize);
                    calculator.ConfirmVector(complexArray2);

                    //Print calculation result
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nResult: ");
                    Console.Write(calculator.MultiplyComplexVector(complexArray1, complexArray2).ToString());
                    Console.WriteLine();
                    Console.ResetColor();
                    break;

                //Define the process to calculate two matrices
                case 2:

                    //Define two integers strings represent the sizes
                    int[] matrixSize1;
                    int[] matrixSize2;

                    //Check the sizes of two matrices
                    while (true)
                    {
                        Console.WriteLine("\nSet the first matrix or vector!");

                        //Set the first matrix size based on user input
                        matrixSize1 = calculator.SetMatrixSize();

                        Console.WriteLine(Environment.NewLine + "Set the second matrix or vector!");

                        //Set the first matrix size based on user input
                        matrixSize2 = calculator.SetMatrixSize();
                        if (calculator.CanMatch(matrixSize1, matrixSize2)) break;
                    }

                    //Set the first matrix based on user input
                    ComplexNumber[,] matrix1 = calculator.SetComplexMatrix(matrixSize1);
                    calculator.ConfirmeMatrix(matrix1);

                    //Set the second matrix based on user input
                    ComplexNumber[,] matrix2 = calculator.SetComplexMatrix(matrixSize2);
                    calculator.ConfirmeMatrix(matrix2);

                    //Print calculation result
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Environment.NewLine + "Result: ");
                    calculator.PrintMatrix(calculator.MultipyComplexMatrices(matrix1, matrix2));
                    Console.ResetColor();
                    break;
            }

            //Call garbage collection
            GC.Collect();
            Console.ReadKey();
        }
    }
}
