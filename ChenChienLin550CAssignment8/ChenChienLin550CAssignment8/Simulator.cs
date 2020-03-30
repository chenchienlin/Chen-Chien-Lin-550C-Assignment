/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Simulator__Simulator                                     *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define a class to simulate the response of a system                                 *
 *                                                                                                     *
 * Description:    In the C# script, Simulator class is defined.                                       *
 *                 OpenStepResponse method provides two signatures, users can either use state space   *
 *                 model or transfer function to simulate open loop step response of the system.       *
 *                 ClosedStepResponse is to simulate the closed loop response of the system.           *
 *                 StateFeedBackEstimatorStepResponse is to simulate the system connect to             *
 *                 observe based state feedback contoller.                                             *          
 *******************************************************************************************************/


/***************************************** USING NAMESPACES ********************************************/
using System;
using ChenChienLin550CAssignment8Model;

namespace ChenChienLin550CAssignment8Simulator
{
    public class Simulator
    {

        /*==========================================================================
         * Function:   OpenStepResponse
         * Arguments:  SSModel
         * Returns:    None
         */

        public void OpenStepResponse(SSModel system)
        {
            // Calculate step response

        }

        /*==========================================================================
         * Function:   OpenStepResponse
         * Arguments:  Two double array
         * Returns:    None
         */

        public void OpenStepResponse(double[] num, double[] den)
        {
            // Calculate step response

        }

        /*==========================================================================
         * Function:   ClosedStepResponse
         * Arguments:  One SSModel and one double matrix
         * Returns:    None
         */

        public void ClosedStepResponse(SSModel system, double[,] K)
        {
            // Calculate closed loop step response
            Console.WriteLine("Closed Step Response of " + system.GetType());

        }

        /*==========================================================================
         * Function:   StateFeedBackEstimatorStepResponse
         * Arguments:  SSModel and two double matrices
         * Returns:    None
         */

        public void StateFeedBackEstimatorStepResponse(SSModel system, double[,] K, double[,] L)
        {
            // Calculate closed loop step response for observer based state feedback system
            Console.WriteLine("Closed Step Response of " + system.GetType()
                + " and State FeedBack Controller with Gain: " + K
                + " and State Estimator with Gain " + L);

        }
    }
}
