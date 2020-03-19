# Chen-Chien-Lin-MECH 550C-Assignment 7

This project is for MECH 550C Assignment 7
* Name : Chen_Chien Lin
* Student Number : 46205175

## Dependencies
* [Visual Studio](https://visualstudio.microsoft.com/downloads)
* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/sdk?pivots=os-windows)

## Usage 
1. Double click ChenChienLin550CAssignment7.exe.
2. Choose your task. A. two arrays multiplication / B. two matrices multiplication / C. two matrices division 
3. Enter the size of arrays / matrices. These numbers should be positive integers.
4. Set each element in the arrays / matrices. Enter two numbers represent the real part and imaginary part and seperate them with a comma.

## Description
* A class is created to defined a complex number.
* Another class, ComplexCalculator, is created to calculate complex numbers arrays and matrices multiplication, and to read user input.

### Complex Number Class
1. There are two private fields in Complex Number class, real part and imaginary part of a complex number, respectively.
2. Fields can be get by two getters, but there is no setter for these two fields.
3. The real part and imaginary part of a complex number can only be defined once by its constructor.
4. A destructor is defined to show message while an instance is destructed in Debug mode.
5. No Fields are created for the magnitude and phase of a complex number.
6. Users cannot set a complex number by using its magnitude and phase,
   but can get the magnitue and phase of one existing complex number by two getters.
7. **Tostring** method inherited from the Object class is overrided to print the specific format for complex numbers.    
8. Operators + - * / are overloaded in this class, users can use these operators to calculate complex numbers directly.

### Complex Calculator Class
1. This is a helper class, there is no field defined in this class.
2. Methods which can perform two arrays and two matrices multiplication by using operators overloaded in Complex Number class
   are created in this class. Also, this class privides method for matrices division. Ex: inverse(A) * B <br/>
&ensp;Two input arrays must be made of complex numbers and cannot be null.<br/>
&ensp;Two input matrices must be matrices made of complex numbers and cannot be null.
&ensp;For matrices division, two input matrices must be square matrices with same dimensions. Ex: A[3x3] B[3x3]
4. A method to display a matrix in a specific pattern is created.
5. Two methods are created to help users set the size of an array and a matrix, respectively.
6. Two methods are created to help users set the elements in an array and in a matrix, respectively.

## Author
* Chen_Chien Lin
