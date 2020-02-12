# Chen-Chien-Lin-MECH 550C-Assignment 3

This project is for MECH 550C Assignment 4
* Name : Chen_Chien Lin
* Student Number : 46205175

## Dependencies
* [Visual Studio](https://visualstudio.microsoft.com/downloads)
* [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/sdk?pivots=os-windows)

## Description
* A class is created to defined a complex number.
* Another class, ComplexCalculator, is created to calculate complex numbers arrays and matrices multiplication.

### Complex Number Class
1. There are two private fields in Complex Number class, real part and imaginary part of a complex number, respectively.
2. Fields can be get by two getters, but there is no setter for these two fields.
3. The real part and imaginary part of a complex number can only be defined once by its constructor.
4. No Fields are created for the magnitude and phase of a complex number.
5. Users cannot set a complex number by using its magnitude and phase,
   but can get the magnitue and phase of one existing complex number by two getters.
6. **Tostring** method inherited from the Object class is overrided to print the specific format for complex numbers.    
7. Operators **+ -*** are overloaded in this class, users can use these operators to calculate complex numbers directly.
### Complex Calculator Class
1. This is a helper class, there is no field defined in this class.
2. Methods which can perform two arrays and two matrices multiplication by using operators overloaded in Complex Number class
   are created in this class.<br/>
&ensp;Two input arrays must be made of complex numbers and cannot be null.<br/>
&ensp;Two input matrices must be matrices made of complex numbers and cannot be null.
4. A method to display a matrix in a specific pattern is created.

## Author
* Chen_Chien Lin
