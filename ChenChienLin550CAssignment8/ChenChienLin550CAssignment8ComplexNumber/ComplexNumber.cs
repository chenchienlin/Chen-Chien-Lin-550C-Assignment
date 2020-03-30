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

        // Define a destructor of ComplexNumber class
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
}
