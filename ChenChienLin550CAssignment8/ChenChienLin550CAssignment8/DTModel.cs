/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Model__DiscreteTimeStateSpaceSystem                      *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a discrete time state space                                  *
 *                                                                                                     *
 * Description:    In the C# script, a class DiscreteTimeStateSpaceSystem is defined                   *
 *                 and inherits from StateSpaceSystem class.                                           *
 *                 6 abstract methods are overrided.                                                   *
 *******************************************************************************************************/


/***************************************** USING NAMESPACES ********************************************/
using ChenChienLin550CAssignment8ComplexNumber;

namespace ChenChienLin550CAssignment8Model
{
    public class DTModel : SSModel
    {
        // Define a field of the class
        private double ts;

        // Use constructor in parent class
        public DTModel(double[,] matrixA, double[,] matrixB,
            double[,] matrixC, double[,] matrixD, double ts) : base(matrixA, matrixB, matrixC, matrixD)
        {
            this.ts = ts;
        }

        /*==========================================================================
         * Function:   SetSamplingTime
         * Arguments:  One double
         * Returns:    void
         */

        public void SetSamplingTime(double ts)
        {
            this.ts = ts;
            // Compute new A, B, C, D matrices based on given sampling time
            double[,] newMatrixA = new double[matrixA.GetLength(1), matrixA.GetLength(0)];
            double[,] newMatrixB = new double[matrixB.GetLength(1), matrixB.GetLength(0)];
            double[,] newMatrixC = new double[matrixC.GetLength(1), matrixC.GetLength(0)];
            double[,] newMatrixD = new double[matrixD.GetLength(1), matrixD.GetLength(0)];

            // Assign new A, B, C, D matrices
            this.matrixA = newMatrixA;
            this.matrixB = newMatrixB;
            this.matrixC = newMatrixC;
            this.matrixD = newMatrixD;
        }

        /*==========================================================================
         * Function:   BIBOStability
         * Arguments:  None
         * Returns:    One boolean
         */

        public override bool BIBOStability()
        {
            // Check whether all poles are in unit disc
            return true;
        }

        /*==========================================================================
         * Function:   EigenValueStability
         * Arguments:  None
         * Returns:    One boolean
         */

        public override bool EigenValueStability()
        {
            // Check internal stability
            return true;
        }

        /*==========================================================================
         * Function:   LyapunovStability
         * Arguments:  None
         * Returns:    One boolean
         */

        public override bool LyapunovStability()
        {
            // Check discrete time lyapunov equation
            return true;
        }

        /*==========================================================================
         * Function:   PoleLocation
         * Arguments:  None
         * Returns:    One Vector
         */

        public override ComplexNumber[] PoleLocation()
        {
            int poleNumber = MatrixA.GetLength(1);
            //Compute pole location
            ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

            // Return the pole vector
            return poleLocation;
        }
    }
}

    

