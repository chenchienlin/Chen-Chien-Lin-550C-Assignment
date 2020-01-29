//Name: Chen-Chien Lin
//Student Number: 46205175
//Purpose: To compute and compare the area of two rectangular.
//Description: A Rectangular class and two instances of it are created. One static method is defined to compare two rectangulars.

using System;
using System.Runtime.Serialization;

namespace Chen_Chien_Lin_550C_Assignment2
{
    [Serializable]
    internal class IllegalArgumentException : Exception
    {
        public IllegalArgumentException()
        {
        }

        public IllegalArgumentException(string message) : base(message)
        {
        }

        public IllegalArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}