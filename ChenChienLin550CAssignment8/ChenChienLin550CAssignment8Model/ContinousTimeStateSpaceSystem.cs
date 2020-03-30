/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Model__ContinousTimeStateSpaceSystem                     *
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

/***************************************** USING NAMESPACES ********************************************/
namespace ChenChienLin550CAssignment8
{
    namespace ChenChienLin550CAssignment8Model
    {
        using ChenChienLin550CAssignment8ComplexNumber;
        internal class ContinousTimeStateSpaceSystem : StateSpaceSystem
        {
            public ContinousTimeStateSpaceSystem(double[,] matrixA, double[,] matrixB,
                double[,] matrixC, double[,] matrixD) : base(matrixA, matrixB, matrixC, matrixD) { }

            public override void ToTransferFunction()
            {
                // Transfer a state space model to transfer functions.
            }

            public override bool BIBOStability()
            {
                //Check whether all poles are in open left hand plane
                return true;
            }

            public override bool EigenValueStability()
            {
                //Check internal stability
                return true;
            }

            public override bool LyapunovStability()
            {
                //Check continous time lyapunov equation
                return true;
            }

            public override ComplexNumber[] PoleLocation(double[,] matirxA)
            {
                int poleNumber = matirxA.GetLength(1);

                //Compute pole location
                ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

                return poleLocation;
            }

            public DiscreteTimeStateSpaceSystem ToDiscreteTimeSystem(double ts)
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
                DiscreteTimeStateSpaceSystem dtSystem =
                    new DiscreteTimeStateSpaceSystem(newMatrixA, newMatrixB, newMatrixC, newMatrixD, ts);

                // Return discrete time system
                return dtSystem;
            }
        }
    }
}