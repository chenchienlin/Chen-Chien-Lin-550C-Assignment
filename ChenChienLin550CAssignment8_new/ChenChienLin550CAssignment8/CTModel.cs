/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Model__CTModel                                           *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a discrete time state space                                  *
 *                                                                                                     *
 * Description:    In the C# script, a class ContinousTimeStateSpaceSystem is defined                  *
 *                 and inherits from StateSpaceSystem class.                                           *
 *                 5 abstract methods are overrided.                                                   *
 *                 One method is defined to transfer a continuous time system                          *
 *                 to discrete time system.                                                            *               
 *******************************************************************************************************/

namespace ChenChienLin550CAssignment8Model
{

    /*************************************** USING NAMESPACES ******************************************/
    using ChenChienLin550CAssignment8ComplexNumber;


    public class CTModel : SSModel
    {
        public CTModel(double[,] matrixA, double[,] matrixB,
            double[,] matrixC, double[,] matrixD) : base(matrixA, matrixB, matrixC, matrixD) { }

        /*==========================================================================
         * Function:   BIBOStability
         * Arguments:  None
         * Returns:    One boolean
         */

        public override bool BIBOStability()
        {
            // Check whether all poles are in open left hand plane
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
            // Check continous time lyapunov equation
            return true;
        }

        /*==========================================================================
         * Function:   PoleLocation
         * Arguments:  None
         * Returns:    One Vector
         */

        public override ComplexNumber[] PoleLocation()
        {
            int poleNumber = matrixA.GetLength(1);

            // Compute pole location
            ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

            // Return the pole vector
            return poleLocation;
        }

        /*==========================================================================
         * Function:   ToDiscreteTimeSystem
         * Arguments:  double
         * Returns:    One DTModel
         */

        public DTModel ToDiscreteTimeSystem(double ts)
        {
            // Define local variable 
            double[,] newMatrixA = new double[MatrixA.GetLength(1),
                MatrixA.GetLength(0)];
            double[,] newMatrixB = new double[MatrixB.GetLength(1),
                MatrixB.GetLength(0)];
            double[,] newMatrixC = new double[MatrixC.GetLength(1),
                MatrixC.GetLength(0)];
            double[,] newMatrixD = new double[MatrixD.GetLength(1),
                MatrixD.GetLength(0)];

            // Calculate matrix exponetial to obtain new matrix
            // Update newMatrixA, newMatrixB, newMatrixC, newMatrixD

            // Create a discrete time system 
            DTModel dtSystem =
                new DTModel(newMatrixA, newMatrixB, newMatrixC, newMatrixD, ts);

            // Return discrete time system
            return dtSystem;
        }
    }
}
