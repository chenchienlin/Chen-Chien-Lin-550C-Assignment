/*******************************************************************************************************
 * Assignment 6:   Cnamespace ChenChienLin550CAssignment6__Program Class                               *
 *                                                                                                     *
 * Name:           Chen-Chien Lin                                                                      *
 * Student Number: 46205175                                                                            *
 * Purpose:        Implement several data structures                                                   *
 *                                                                                                     *
 * Description:    In program class, one List, Stack, LinkedList, and Dictionary are created           *
 *                 to store instances of Book Class. One Queue is created to store the                 *
 *                 instances of Student Class.                                                         *
 *******************************************************************************************************/

/***************************************** USING NAMESPACES ********************************************/

using System;
using System.Collections.Generic;

/*************************************** NAMESPACE DECLARATION *****************************************/

namespace ChenChienLin550CAssignment6
{
    class Program
    {

        /*==============================================================================
         * Function:   Main
         * Arguments:  string[] args
         * Returns:    None
         */

        static void Main(string[] args)
        {
            Console.WriteLine("=====List=====");
            //Create instances of Book Class
            var book1 = new Book("Twilight", 1234567890123, 4.1);
            var book2 = new Book("Game of Thrones", 2345678901234, 4.8);
            var book3 = new Book("The Glass Hotel", 3456789012345, 4.5);
            var book4 = new Book("Cleanness", 4567890123456, 4.7);

            //Create List
            List<Book> bookList = new List<Book>();
            bookList.Add(book2);
            bookList.Add(book1);
            bookList.Add(book3);
            bookList.Add(book4);
            
            //Retrieve the second element in the list
            Console.WriteLine("The second book in the list: "+ bookList[2].title);


            Console.WriteLine("\n=====Queue=====");

            //Create instances of Student Class
            Student student1 = new Student("Amy");
            Student student2 = new Student("Yummy");
            Student student3 = new Student("Oishi");

            //Add Student to the Queues
            book1.AddToWaitQueue(student1);
            book1.AddToWaitQueue(student2);
            book1.AddToWaitQueue(student3);
            book2.AddToWaitQueue(student3);
            book2.AddToWaitQueue(student2);
            book2.AddToWaitQueue(student1);

            //Print element in Queues
            Console.WriteLine("\nBook1 WaitQueue:");
            foreach(var element in book1.GetWaitQueue())
            {
                Console.WriteLine(element.GetName());
            }

            //Retrieve the element in the Queue
            Console.WriteLine("Who can get first: " + book1.GetWaitQueue().Dequeue().GetName());

            //Peek the element in the Queue
            Console.WriteLine("Who is next: " + book1.GetWaitQueue().Peek().GetName());


            Console.WriteLine("\nBook2 WaitQueue:");
            foreach (var element in book2.GetWaitQueue())
            {
                Console.WriteLine(element.GetName());
            }
            Console.WriteLine("Who can get first: " + book2.GetWaitQueue().Dequeue().GetName());

            //Peek the element in the Queue
            Console.WriteLine("Who is next: " + book2.GetWaitQueue().Peek().GetName());


            Console.WriteLine("\n=====Stack=====");

            //Create Stack
            Stack<Book> bookStack = new Stack<Book>();

            //Add books into the Stack
            bookStack.Push(book2);
            bookStack.Push(book1);
            bookStack.Push(book3);
            bookStack.Push(book4);

            //Print Stack
            Console.WriteLine("Books in the book store");
            foreach(var book in bookStack)
            {
                Console.WriteLine(book.title);
            }

            //Retrieve top element in the stack
            Console.WriteLine("The latest book " + bookStack.Peek().title);


            Console.WriteLine("\n====LinkedList====");

            //Create LinkedList
            LinkedList<Book> bookLinedList = new LinkedList<Book>();
            Console.WriteLine("Best books in 2005");

            //Add books into the LinkedList
            bookLinedList.AddFirst(book1);
            bookLinedList.AddLast(book2);
            bookLinedList.AddLast(book3);
            bookLinedList.AddLast(book4);

            //Print all elements in LinkedList
            foreach (var book in bookLinedList)
            {
                Console.WriteLine(book.title);
            }

            Console.WriteLine("\nBest books in 2010");

            //Remove one element from LinkedList
            bookLinedList.Remove(book3);


            //Print elements in LinkedList
            foreach (var book in bookLinedList)
            {
                Console.WriteLine(book.title);
            }

            Console.WriteLine("\nBest books in 2020");

            //Remove one element from LinkedList
            bookLinedList.Remove(book1);

            //Print elements in LinkedList
            foreach (var book in bookLinedList)
            {
                Console.WriteLine(book.title);
            }


            //Create Dictionary
            Dictionary<double, string> bookDictionary = new Dictionary<double, string>();

            Console.WriteLine("\n=====Dictionary======");

            //Setup Key/Value pairs
            foreach (var book in bookStack)
            {
                bookDictionary.Add(book.isbn, book.title);
                Console.WriteLine(book.title + "is in the dictionary");
            }

            //Using ContainKey() method
            Console.WriteLine("\nTest Dictionary");
            if (bookDictionary.ContainsKey(1234567890123) == true)
            {
                //Obtain value by key
                Console.WriteLine("isbn: 1234567890123 in the bookstore?");
                Console.WriteLine("It is " + bookDictionary[1234567890123] +
                    ". It can be found in this bookstore");
            }
            else
            {
                Console.WriteLine("isbn: 1234567890123 in the bookstore?");
                Console.WriteLine("Cannot find this book!!");
            }

            Console.ReadKey();

        }
    }
}
