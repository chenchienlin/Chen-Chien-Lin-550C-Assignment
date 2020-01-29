//Name: Chen-Chien Lin
//Student Number: 46205175
//Purpose: To compute and compare the area of two rectangular.
//Description: A Rectangular class and two instances of it are created. One static method is defined to compare two rectangulars.

namespace Chen_Chien_Lin_550C_Assignment2
{
    //Program start class
    public class Program
    {
        //Main begins program execution
        static void Main(string[] args)
        {
            //Define variables of two rectangulars
            double length1 = 5;
            double width1 = 5;
            double length2 = 4;
            double width2 = 5;

            //Create two instnaces of Rectangular class
            Rectangular rectangular1 = new Rectangular(length1, width1);
            Rectangular rectangular2 = new Rectangular(length2, width2);

            bool identical = RectangularComparator(rectangular1, rectangular2);

        }

        static bool RectangularComparator(Rectangular rectangular1, Rectangular rectangular2)
        {
            //Compare the areas of two rectangulars
            return rectangular1.Area == rectangular2.Area;
        }
    }
}