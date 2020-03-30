/*******************************************************************************************************
 * Assignment 8 :  ChenChienLin550CAssignment8Simulator__Simulator                                     *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Define a class to simulate the response of a system                                 *
 *                                                                                                     *
 * Description:    In the C# script, Simulator class is defined.                                       *
 *                 Two methods are defined to simulate step and ramp response of a system.             *
 *                 Users can use either tranfer function or state space model to get the simulation    *
 *                 result.                                                                             *          
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/
using ChenChienLin550CAssignment8Model;

namespace ChenChienLin550CAssignment8Simulator
{
    public class Simulator
    {
        public void OpenStepResponse(StateSpaceSystem system)
        {
            // Calculate step response

        }

        public void OpenStepResponse(double[] num, double[] den)
        {
            // Calculate step response

        }

        public void ClosedStepResponse(StateSpaceSystem system, double[,] K)
        {
            // Calculate closed loop step response

        }

        public void StateFeedBackEstimatorStepResponse(StateSpaceSystem system, double[,] K, double[,] L)
        {
            // Calculate closed loop step response for observer based state feedback system

        }
    }
}
