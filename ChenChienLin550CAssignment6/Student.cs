/*******************************************************************************************************
 * Assignment 6:   Cnamespace ChenChienLin550CAssignment6__Program Class                               *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Implement several data structures                                                   *
 *                                                                                                     *
 * Description:    In Book class, three readonly fields are created, which are title, isbn, and stars, *
 *                 respectively, to define the features of books.Fields of Book Class can only be      *
 *                 initialized in constructor once, and cannot be changed.One Queue is created,        *
 *                 representing the waitlist of the book.                                              *
 *                 A method is defined to add students into the queue.                                 *
 *                 A method is defined to return Queue to order classes.                               *
 *******************************************************************************************************/

/*************************************** NAMESPACE DECLARATION *****************************************/
namespace ChenChienLin550CAssignment6
{
    public class Student
    {
        //Define a field
        private readonly string name;

        //Define constructor
        public Student(string name)
        {
            this.name = name;
        }

        /*======================================================================
         * Function:   GetName
         * Arguments:  None
         * Returns:    string
         */

        public string GetName()
        {
            //return the field
            return name;
        }

    }
}
