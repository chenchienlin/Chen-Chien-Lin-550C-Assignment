/*******************************************************************************************************
 * Assignment 3 :  Complex Number Operation__Complex Number Class                                      *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Create a new class to define a complex number                                       *
 *                                                                                                     *
 * Description:    In this C# script, a class is created to defined complex numbers. The real part     *
 *                 and the imaginary part of a complex number must be given to create a instance of    *
 *                 Complex Number class. Once a complex number is created, its value cannot be change  *
 *                 to prevent changing its value accidentally.                                         *
 *                 Users can get the real part and imaginary part through two getters.                 *                             
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using System;

/*************************************** NAMESPACE DECLARATION *****************************************/
namespace Chen_Chien_Lin_550C_Assignment3
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

        /*==========================================================================
         * Function:   GetRealPart
         * Arguments:  None
         * Returns:    One number which is the real part of a complex number
         */

        public double RealPart
        {
            // Getter for the real part of a complex number
            get { return realPart; }
        }

        /*==========================================================================
         * Function:   GetImaginaryPart
         * Arguments:  None
         * Returns:    One number which is the imaginary part of a complex number
         */

        public double ImaginaryPart
        {
            // Getter for the imaginary part of a complex number
            get { return imaginaryPart; }
        }


        /*==========================================================================
         * Function:   PrintComplexNumber
         * Arguments:  None
         * Returns:    None
         */

        public void PrintComplexNumber()
        {
            // Print a complex number in a given form
            Console.Write(String.Format("{0} + {1} i ", realPart, imaginaryPart));
            Console.WriteLine(Environment.NewLine);
        }
    }
}
