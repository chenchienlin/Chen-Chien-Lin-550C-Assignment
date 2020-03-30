# Chen-Chien-Lin-MECH 550C-Assignment 8

This project is for MECH 550C Assignment 8
* Name : Chen_Chien Lin
* Student Number : 46205175

## Dependencies
* [Visual Studio](https://visualstudio.microsoft.com/downloads)
* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/sdk?pivots=os-windows)

## Description
* A class is created to specify some features of complex number(ComplexNuber Class).
* A Student class is define and has one field.
* In program class, one **List, Stack, LinkedList, and Dictionary** are created to store instances of **Book Class**. One **Queue** is created to store the instances of **Student Class**.

### ComplexNumber Class
1. There are two private fields in Complex Number class, real part and imaginary part of a complex number, respectively.
2. Fields can be get by two getters, but there is no setter for these two fields.
3. The real part and imaginary part of a complex number can only be defined once by its constructor.
4. A destructor is defined to show message while an instance is destructed in Debug mode.
5. No Fields are created for the magnitude and phase of a complex number.
6. Users cannot set a complex number by using its magnitude and phase,
   but can get the magnitue and phase of one existing complex number by two getters.
7. **Tostring** method inherited from the Object class is overrided to print the specific format for complex numbers.    
8. Operators + - * are overloaded in this class, users can use these operators to calculate complex numbers directly.

### SSModel Class
1. SSModel Class is a abstract class defines features of a state space model and provides a blueprint for CTModel and DTModel.
2. Four fields which are matrices define the dynamic behavior of a state space system. These four fields can only be initiated once by the constructor.
3. Four getters are defined to get four matrices.
4. Four abstract methods are defined, which are BIBOStability, EigenValueStability, LyapunovStability, PoleLocation. 
The concepts of these four methods between CTModel and DTModel are very similar. However, due to the calculation process is a little different, CTModel Class and DTModel Class need to customize these four methods.

### CTModel Class
1. CTModel Class is derived from SSModel Class and defines the features of continuous time state space model.
2. The constructor of this class is based on SSModel Class.
3. BIBOStability method is used to check whether all the poles of the system are in the open left half of the complex plane.
4. EigenValueStability(Asympototically stable) method is used to check whether the realparts of all the eigenvalues of a given system A matrix are negative.
5. LyapunovStability method is to solve lyapunov equation: A^TP + PA = -Q. The system is stable if P is positive definite.
6. PoleLocation method is to calculate system poles in s plane.

### CTModel Class
1. DTModel Class is derived from SSModel Class and defines the features of discrete time state space model.
2. The constructor of this class is based on SSModel Class, but sampling time needs to be provided.
3. BIBOStability method is used to check whether all the poles of the system are in the unit disk of the z plane.
4. EigenValueStability(Asympototically stable) method is used to check whether the realparts of all the eigenvalues of a given system A matrix are less than one.
5. LyapunovStability method is to solve lyapunov equation: A^TA - P = -Q. The system is stable if P is positive definite.
6. PoleLocation method is to calculate system poles in z plane.

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
