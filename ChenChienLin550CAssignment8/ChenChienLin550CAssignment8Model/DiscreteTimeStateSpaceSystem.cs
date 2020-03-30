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
    public class DiscreteTimeStateSpaceSystem : StateSpaceSystem
    {
        private double ts;

        public DiscreteTimeStateSpaceSystem(double[,] matrixA, double[,] matrixB,
            double[,] matrixC, double[,] matrixD, double ts) : base(matrixA, matrixB, matrixC, matrixD)
        {
            this.ts = ts;
        }

        public void SetSamplingTime(double ts)
        {
            this.ts = ts;
            // Compute new A, B, C, D matrices based on given sampling time
            double[,] newMatrixA = new double[matrixA.GetLength(1), matrixA.GetLength(0)];
            double[,] newMatrixB = new double[matrixB.GetLength(1), matrixB.GetLength(0)];
            double[,] newMatrixC = new double[matrixC.GetLength(1), matrixC.GetLength(0)];
            double[,] newMatrixD = new double[matrixD.GetLength(1), matrixD.GetLength(0)];

            //Assign new A, B, C, D matrices
            this.matrixA = newMatrixA;
            this.matrixB = newMatrixB;
            this.matrixC = newMatrixC;
            this.matrixD = newMatrixD;
        }

        public override void ToTransferFunction()
        {
            // Transfer a state space model to transfer functions.
        }
        public override bool BIBOStability()
        {
            // Check whether all poles are in unit disc
            return true;
        }

        public override bool EigenValueStability()
        {
            // Check internal stability
            return true;
        }

        public override bool LyapunovStability()
        {
            // Check discrete time lyapunov equation
            return true;
        }

        public override ComplexNumber[] PoleLocation(double[,] matirxA)
        {
            int poleNumber = matirxA.GetLength(1);
            //Compute pole location
            ComplexNumber[] poleLocation = new ComplexNumber[poleNumber];

            return poleLocation;
        }
    }
}
