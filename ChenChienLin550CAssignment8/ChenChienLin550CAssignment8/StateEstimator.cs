/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Controller__StateEstimator                               *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a state estimator                                            *
 *                                                                                                     *
 * Description:    In the C# script, StateEsitimator class is defined.                                 *
 *                 One method is defined in this class to calculate the                                *
 *                 state estimator gain of a given system.                                             *
 *                 Users might want to have complex number poles,                                      *
 *                 thus using Complex Number namespace to fulfill their needs.                         *          
 *******************************************************************************************************/


/***************************************** USING NAMESPACES ********************************************/
using ChenChienLin550CAssignment8Model;
using ChenChienLin550CAssignment8ComplexNumber;

namespace ChenChienLin550CAssignment8Controller
{
    public class StateEstimator
    {
        /*==========================================================================
         * Function:   Observer
         * Arguments:  Two double matrices and One ComplexNumber vector
         * Returns:    One double matrix
         */

        public double[,] Observer(SSModel system, ComplexNumber[] poleLocation)
        {
            // Define local variables
            int rowNumber = system.MatrixA.GetLength(1);
            int colNumber = system.MatrixC.GetLength(1);

            // Check Observability
            if (Observable(system.MatrixA, system.MatrixC) == true)
            {

                //Use specified pole location to compute state estimator gain matrix L
                double[,] L = new double[rowNumber, colNumber];
                return L;
            }
            else
            {
                throw new System.ArgumentException("Input system is not observable");
            }
        }

        /*==========================================================================
         * Function:   Observable
         * Arguments:  Two double matrices
         * Returns:    One boolean
         */

        public bool Observable(double[,] matrixA, double[,] matrixC)
        {
            // Compute Observability 
            return true;

        }
    }
}

