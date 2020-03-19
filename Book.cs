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

/***************************************** USING NAMESPACES ********************************************/

using System.Collections.Generic;

/*************************************** NAMESPACE DECLARATION *****************************************/
namespace ChenChienLin550CAssignment6
{
    public class Book
    {
        //Define fields 
        public readonly string title;
        public readonly double isbn;
        public readonly double stars;

        //Create a Queue
        Queue<Student> waitQueue = new Queue<Student>();

        
        //Define constructor 
        public Book(string title, double isbn, double stars)
        {
            this.title = title;
            this.isbn = isbn;
            this.stars = stars;
        }

        /*======================================================================
         * Function:   AddToWaitQueue
         * Arguments:  Student
         * Returns:    None
         */

        public void AddToWaitQueue(Student student)
        {
            //Add student in the Queue
            waitQueue.Enqueue(student);
        }

        /*======================================================================
         * Function:   GetWaitQueue
         * Arguments:  None
         * Returns:    Queue<Student> 
         */

        public Queue<Student> GetWaitQueue()
        {
            //return Queue
            return waitQueue;
        }

    }
}
