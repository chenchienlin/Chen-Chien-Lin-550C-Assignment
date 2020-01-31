/*****************************************
 *Name: 
 *Student Number: 
 *Purpose:
 *Description:
 *****************************************/

namespace Chen_Chien_Lin_550C_Assignment3
{
    public class Program
    {
        static void Main(string[] args)
        {
            ComplexCalculator calculator = new ComplexCalculator();
            ComplexNumber complexNumber1 = new ComplexNumber(8.33d, 17.50d);
            ComplexNumber complexNumber2 = new ComplexNumber(1.40d, 6.3d);
            var complexNumber3 = calculator.Mutiply(complexNumber1, complexNumber2);
            complexNumber3.PrintComplexNumber();
            
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

            ComplexNumber[,] result1 = calculator.MultipyMatrices(matrix1, matrix2);
            calculator.PrintMatrix(result1);

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

            ComplexNumber[,] result2 = calculator.MultipyMatrices(matrix3, matrix3);
            calculator.PrintMatrix(result2);


            //Define null matrices
            var matrix5 = new ComplexNumber[2, 3];
            var matrix6 = new ComplexNumber[3, 4];

            ComplexNumber[,] result3 = calculator.MultipyMatrices(matrix5, matrix6);
            calculator.PrintMatrix(result3);
        }
    }
}
