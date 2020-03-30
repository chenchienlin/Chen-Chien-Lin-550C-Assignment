/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Controller__StateFeedBack                                *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a state feedback controller                                  *
 *                                                                                                     *
 * Description:    In the C# script, StateFeedBack class is defined.                                   *
 *                 One method two methods are defined in this class to calculate the                   *
 *                 state feedback gain of a given system.                                              *
 *                 Users might want to have complex number poles to make a system oscillate a bit,     *
 *                 thus using Complex Number namespace to fulfill their needs.                         *          
 *******************************************************************************************************/


/***************************************** USING NAMESPACES ********************************************/
using ChenChienLin550CAssignment8Model;
using ChenChienLin550CAssignment8ComplexNumber;

namespace ChenChienLin550CAssignment8Controller
{
    public class StateFeedBack
    {

        /*==========================================================================
         * Function:   PolePlacement
         * Arguments:  Two double matrices and One ComplexNumber vector
         * Returns:    One double matrix
         */

        public double[,] PolePlacement(double[,] matrixA, double[,] matrixB,
            ComplexNumber[] newPoleLocation)
        {
            int rowNumber = matrixA.GetLength(1);
            int colNumber = matrixB.GetLength(0);

            if (!Controllable(matrixA, matrixB))
                throw new System.ArgumentException("Input system is not controllable");



            //Use new pole location to compute State feedback gain matrix K
            double[,] K = new double[rowNumber, colNumber];
            return K;
        }

        /*==========================================================================
         * Function:   Controllable
         * Arguments:  Two double matrices
         * Returns:    One boolean
         */

        public bool Controllable(double[,] matrixA, double[,] matrixB)
        {
            // Compute Contrallablity
            return true;
        }


        public double[,] CTModelAutoTune(SSModel model)
        {
            if (model.GetType() == typeof(CTModel))
            {
                ComplexNumber[] poles = model.PoleLocation();

                for (int i = 0; i < poles.GetLength(1); i++)
                {
                    if (poles[i].RealPart > 0)
                        poles[i] = new ComplexNumber(-1 * poles[i].RealPart, poles[i].ImaginaryPart);
                }

                double[,] K = PolePlacement(model.MatrixA, model.MatrixB, poles);
                return K;
            }
            else
                throw new System.ArgumentException("Input model must be a" +
                    "continuous time model!");

        }
    }
}
