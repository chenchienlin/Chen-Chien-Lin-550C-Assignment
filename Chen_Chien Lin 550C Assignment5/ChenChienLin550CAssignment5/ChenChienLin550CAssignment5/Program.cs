using System;

namespace ChenChienLin550CAssignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int inputValue;
            while (true)
            {
                Console.WriteLine("Array(1) or Matrix(2)");
                userInput = Console.ReadLine();
                try
                {
                    inputValue = Convert.ToInt32(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Enter again");
                    continue;
                }

                if (inputValue == 1)
                {
                    string arraySize;
                    int sizeValue;
                    Console.WriteLine("Enter the size of two arrays");
                    arraySize = Console.ReadLine();

                    try
                    {
                        sizeValue = Convert.ToInt32(arraySize);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("Enter again");
                    }
                    break;
                }

                if (inputValue == 2)
                {
                    string matrixRowNumber1;
                    string matrixRowNumber2;
                    string matrixColNumber1;
                    string matrixColNumber2;
                    int rowNumberValue1;
                    int rowNumberValue2;
                    int colNumberValue1;
                    int colNumberValue2;
                    Console.WriteLine("Enter the size of matrices");
                    break;
                }
            }
        }
    }
}
