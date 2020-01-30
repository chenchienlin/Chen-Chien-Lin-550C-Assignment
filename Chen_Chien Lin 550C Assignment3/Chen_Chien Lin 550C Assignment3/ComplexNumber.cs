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

        public ComplexNumber Multiply(ComplexNumber complexNumber)
        {
            double otherRealPart = complexNumber.GetRealPart;
            double otherImaginaryPart = complexNumber.GetImaginaryPart;
            double newRealPart = realPart * otherRealPart - imaginaryPart * otherImaginaryPart;
            double newImaginaryPart = imaginaryPart * otherRealPart + realPart * otherImaginaryPart;

            return new ComplexNumber(newRealPart, newImaginaryPart);
        }

        public ComplexNumber Add(ComplexNumber complexNumber)
        {

            double newRealPart = realPart + complexNumber.GetRealPart;
            double newImaginaryPart = imaginaryPart + complexNumber.GetImaginaryPart;
            return new ComplexNumber(newRealPart, newImaginaryPart);
        }
        public void PrintComplex()
        {
            Console.WriteLine(String.Format("{0} + {1} ", realPart, imaginaryPart));
        }
    }
}
