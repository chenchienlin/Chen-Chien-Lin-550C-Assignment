/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Controller__StateFeedBack                                *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define the features of a state feedback controller                                  *
 *                                                                                                     *
 * Description:    In the C# script, StateFeedBack class is defined.                                   *
 *                 One method is defined in this class to calculate the                                *
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

        public double[,] PolePlacement(SSModel system, ComplexNumber[] newPoleLocation)
        {
            // Define local variables
            int rowNumber = system.MatrixA.GetLength(1);
            int colNumber = system.MatrixB.GetLength(0);

            // Check stability
            if(!system.EigenValueStability())
                throw new System.ArgumentException("Input system is not stable");

            // Check controllability
            if (!Controllable(system.MatrixA, system.MatrixB))
                throw new System.ArgumentException("Input system is not controllable");

            //Use new pole location to compute State feedback gain matrix K
            double[,] K = new double[rowNumber, colNumber];
            for (int i = 0; i < K.GetLength(1); i++)
                for (int j = 0; j < K.GetLength(1); j++)
                    K[i, j] = 1d;

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

        /*==========================================================================
         * Function:   CTModelAutoTune
         * Arguments:  one CTModel
         * Returns:    One double matrix
         */

        public double[,] CTModelAutoTune(CTModel model)
        {
            // Define local variables
            ComplexNumber[] poles = model.PoleLocation();

            // Move unstable poles to L.H.P.
            for (int i = 0; i < poles.GetLength(1); i++)
            {
                if (poles[i].RealPart > 0)
                    poles[i] = new ComplexNumber(-1 * poles[i].RealPart, poles[i].ImaginaryPart);
            }

            // Calculate state feedback gain
            double[,] K = PolePlacement(model, poles);
            for (int i = 0; i < K.GetLength(1); i++)
                for (int j = 0; j < K.GetLength(1); j++)
                    K[i, j] = 1d;

            // Return state feedback gain
            return K;
        }
    }
}
