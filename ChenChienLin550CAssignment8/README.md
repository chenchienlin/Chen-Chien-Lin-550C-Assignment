# Chen-Chien-Lin-MECH 550C-Assignment 6

This project is for MECH 550C Assignment 6
* Name : Chen_Chien Lin
* Student Number : 46205175

## Dependencies
* [Visual Studio](https://visualstudio.microsoft.com/downloads)
* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/sdk?pivots=os-windows)

## Description
* A class is created to specify some features of books(Book Class).
* A Student class is define and has one field.
* In program class, one **List, Stack, LinkedList, and Dictionary** are created to store instances of **Book Class**. One **Queue** is created to store the instances of **Student Class**.

### Book Class

1. Three readonly fields are created, which are title, isbn, and stars, respectively. 
2. Fields of **Book Class** can only be initialized in constructor once, and cannot be changed.
3. One Queue is created, representing the waitlist of the book.
4. A method is defined to add students into the queue.
5. A getter is defined to return Queue to other classes.

### Student Class
1. There is only one field in **Student Class**, and can only be set in its constructor. One getter is created to get the field in this class.
2. A getter is defined to return the field to other classes.

### Program Class

1. **List**
A **List** is created to store **Book** objects. One benefit of using list is that  it does not need to specify its size at first and an object can be added/removed in a list any time. On the other hand, the size of an array needs to be defined at first, and it would be very expensive to resize an array. In this example, book objects might be added or removed very frequently in real life, thus using **List** is more reasonable.

2. **Queue**
**Queue** implements **First In First Out** concept. For examples, customers waiting in lines for services, needs of the first customer should be satisfied first. In this example, **Student** objects are added in the queue. The first student in the queue can get the book earlier.

3. **Stack**
**Stack** be used to deal with schedule problems. In this example, a bookStack object is created to represent a book store. 
Once the bookstore buys books, they are stored in stack. By using **Stack** customers can know the latest book in the book store.

4. **LinkedList**
**LinkedList** is preferable when need to insert or remove element in the middle of the list. In this example, a list represents rank of books  is created. Sometimes, users might only want to read new books. In this case, a new rank can be created by removing old books from the **LinkedList** .

5. **Dictionary**
If users want to just look up a value using a key, then using **Dictionary** would be better.  In this example, users can find out book title and whether it is in the bookstore.


## Author
* Chen_Chien Lin
