/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Model__SSModel                                           *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a state space model                                          *
 *                                                                                                     *
 * Description:    In the C# script, an abstract class is defined.                                     *
 *                 This abstract class is the parent class of Continous Time                           * 
 *                 and Discrete Time State Space System.                                               *
 *                 Classes derived from StateSpaceSystem class should use the constructor              *
 *                 initiate the state space system.                                                    *
 *                 4 non-abstract getters are created to define a state space model.                   *
 *                 Calculation and concept of stability and pole location is slightly                  *
 *                 different, these methods are defined as abstract methods.                           *
 *                 This class is dealing with minimum phase system,                                    *
 *                 thus state matrices cannot contain complex numbers                                  *          
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using System;
using ChenChienLin550CAssignment8ComplexNumber;

namespace ChenChienLin550CAssignment8Model
{
    public abstract class SSModel
    {
        // Define fields of a state space system
        protected double[,] matrixA;
        protected double[,] matrixB;
        protected double[,] matrixC;
        protected double[,] matrixD;

        public SSModel(double[,] matrixA, double[,] matrixB,
            double[,] matrixC, double[,] matrixD)
        {
            this.matrixA = matrixA;
            this.matrixB = matrixB;
            this.matrixC = matrixC;
            this.matrixD = matrixD;

        }

        public double[,] MatrixA { get => matrixA; }
        public double[,] MatrixB { get => matrixB; }
        public double[,] MatrixC { get => matrixC; }
        public double[,] MatrixD { get => matrixD; }



        // Transfer a state space model to transfer function;
        public abstract void ToTransferFunction();

        // Check BIBO stability
        public abstract bool BIBOStability();

        // Check internal stability
        public abstract bool EigenValueStability();

        // Check Lyapunov stability
        public abstract bool LyapunovStability();

        // Compute pole location
        public abstract ComplexNumber[] PoleLocation(double[,] matrixA);
    }
}

