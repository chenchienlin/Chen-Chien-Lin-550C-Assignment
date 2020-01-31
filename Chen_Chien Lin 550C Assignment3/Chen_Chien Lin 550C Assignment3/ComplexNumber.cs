using System;
namespace Chen_Chien_Lin_550C_Assignment3
{
    public class ComplexNumber
    {
        private double realPart;
        private double imaginaryPart;

        //Define a constructor of ComplexNumber class
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.realPart = realPart;
            this.imaginaryPart = imaginaryPart;
        }

        public double GetRealPart
        {
            get { return realPart; }
        }

        public double GetImaginaryPart
        {
            get { return imaginaryPart; }
        }

        public void PrintComplexNumber()
        {
            Console.WriteLine(String.Format("{0} + {1} i ", realPart, imaginaryPart));
        }
    }
}
