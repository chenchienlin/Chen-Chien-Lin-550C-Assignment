/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Controller__StateEstimator                               *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a state estimator                                            *
 *                                                                                                     *
 * Description:    In the C# script, StateEsitimator class is defined.                                 *
 *                 One method two methods are defined in this class to calculate the                   *
 *                 state estimator gain of a given system.                                             *
 *                 Users might want to have complex number poles,                                      *
 *                 thus using Complex Number namespace to fulfill their needs.                         *          
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using ChenChienLin550CAssignment8ComplexNumber;
namespace ChenChienLin550CAssignment8
{
    namespace ChenChienLin550CAssignment8Controller
    {
        public class StateEstimator
        {
            public double[,] Observer(double[,] matrixA, double[,] matrixC,
                ComplexNumber[] poleLocation)
            {
                int rowNumber = matrixA.GetLength(1);
                int colNumber = matrixC.GetLength(1);

                if (Observable(matrixA, matrixC) == true)
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

            public bool Observable(double[,] matrixA, double[,] matrixC)
            {
                // Compute Observability 
                return true;

            }
        }
    }
}