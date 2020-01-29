namespace Chen_Chien_Lin_550C_Assignment2
{
    //Declare a Rectangular class in Chen_Chien_Lin_550C_Assignment2 namespace
    public class Rectangular
    {
        //Define variables
        private double length;
        private double width;

        //Define a constructor of the class 
        public Rectangular(double length, double width)
        {
            if (length <= 0 || width <= 0)
            {
                //Throw the exception if invalid values in constructor.
                throw new IllegalArgumentException("The length or width of a rectangular cannot equal or less than 0");
            }
            else
            {
                //Set length and width
                this.length = length;
                this.width = width;
            }
        }

        // Define the getter of the area of a rectangular
        public double Area
        {
            get
            {
                //Calculate area
                return length * width;
            }
        }
    }
}