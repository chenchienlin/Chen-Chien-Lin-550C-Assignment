# Chen-Chien-Lin-MECH 550C-Assignment 8

This project is for MECH 550C Assignment 8
* Name : Chen_Chien Lin
* Student Number : 46205175

## Dependencies
* [Visual Studio](https://visualstudio.microsoft.com/downloads)
* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/sdk?pivots=os-windows)

## Assignment Requirement
a. An object has a state (high lighten capsulation where mutable data about the object are stored within your class).

SSModel Class is an abstract class and defines four protected fields which can only be initiated in its constructor.

b.	An object decides what happens to it in response to an outside stimulus (e.g. a public method changes the object’s state). 

In DTModel Class, SetSamplingTime method provides users a way to change the sampling time, accordingly, change the A, B, C, D matrices based on the given sampling time.

c.	An object hides some of its internal details (state) from the outside world (e.g. private variables). 

Fields in SSModel, CTModel, and DTModel Class can only be accessed by the getters. 

d.	Two objects of the same type are used interchangeably in some piece of code (e.g. iterate through and act upon a list of ComplexNumbers objects). This effect can be described with comments rather than code. 

In StateFeedBack Class, AutoTune method, it needs an instance of SSModel Class as an argument. The process will calculate the pole locations of the given model and store as a ComplexNumber vector, then moving all unstable poles to left hand plane, and then calculate the state feedback gain.  

e.	Two objects of different types are used interchangeably in some piece of code (demonstrate polymorphism). This effect can be described with comments rather than code. 

Almost all methods in StateFeedBack, StateEstimator, and Simulator Classes use an instance of SSModel Class as an argument, thus, all child classes of SSModel(In this case, CTModel, DTModel) can use methods in StateFeedBack, StateEstimator, and Simulator Classes.

f.	An object presents itself as two different types (e.g. casting from one type to another, or a derived class stored in a base class variable, used to override a method).

An instance of CTModel Class can either use methods which use a SSModel object as an argument, or use methods need a CTModel object as an argument.

Ex: OpenStepResponse(SSModel system), CTModelAutoTune(CTModel model)




## Description

### ComplexNumber Class
1. There are two private fields in Complex Number class, real part and imaginary part of a complex number, respectively.
2. Fields can be got by two getters, but there is no setter for these two fields.
3. The real part and imaginary part of a complex number can only be defined once by its constructor.
4. A destructor is defined to show message while an instance is destructed in Debug mode.
5. No Fields are created for the magnitude and phase of a complex number.
6. Users cannot set a complex number by using its magnitude and phase,
   but can get the magnitude and phase of one existing complex number by two getters.
7. **Tostring** method inherited from the Object class is overrided to print the specific format for complex numbers.    
8. Operators + - * are overloaded in this class, users can use these operators to calculate complex numbers directly.

### SSModel Class
1. SSModel Class is a abstract class defines features of a state space model and provides a blueprint for CTModel and DTModel.
2. Four fields which are matrices define the dynamic behavior of a state space system. These four fields can only be initiated once by the constructor.
3. Four getters are defined to get four matrices.
4. Four abstract methods are defined, which are BIBOStability, EigenValueStability, LyapunovStability, PoleLocation. 
The concepts of these four methods between CTModel and DTModel are very similar. However, due to the calculation process is a little different, CTModel Class and DTModel Class need to customize these four methods.

#### CTModel Class
1. CTModel Class is derived from SSModel Class and defines the features of continuous time state space model.
2. The constructor of this class is based on SSModel Class.
3. BIBOStability method is used to check whether all the poles of the system are in the open left half of the complex plane.
4. EigenValueStability(Asympototically stable) method is used to check whether the realparts of all the eigenvalues of a given system A matrix are negative.
5. LyapunovStability method is to solve lyapunov equation: A^TP + PA = -Q. The system is stable if P is positive definite.
6. PoleLocation method is to calculate system poles in s plane.

#### DTModel Class
1. DTModel Class is derived from SSModel Class and defines the features of discrete time state space model.
2. The constructor of this class is based on SSModel Class, but sampling time needs to be provided.
3. BIBOStability method is used to check whether all the poles of the system are in the unit disk of the z plane.
4. EigenValueStability(Asympototically stable) method is used to check whether the real parts of all the eigenvalues of a given system A matrix are less than one.
5. LyapunovStability method is to solve lyapunov equation: A^TA - P = -Q. The system is stable if P is positive definite.
6. PoleLocation method is to calculate system poles in z plane.

### StateFeedBack Class
1. This class is a helper class, and there is no field defined in this class.
2. Poleplacement method is to calculate state feedback gain of a given system.
3. CTModelAutoTune method is to calculate a statefeed gain of a given system, but users do not need to enter new pole locations. This method is to move all the unstable poles of the system to the open left hand plane by iterating through all poles of the system.
4. Controllable method is to determine whether the system is controllable by checking the rank of controllablity matrix.

### StateEstimator Class
1. This class is a helper class, and there is no field defined in this class.
2. Observer method is to calculate state estimator gain of a given system.
3. Observable method is to determine whether the system is observable by checking the rank of observability matrix.

### Simulator Class
1. This class is a helper class, and there is no field defined in this class.
2. OpenStepResponse method provides two signatures, users can either use state space model or transfer function to simulate open loop step response of the system.
3. ClosedStepResponse is to simulate the closed loop response of the system. 
4. StateFeedBackEstimatorStepResponse is to simulate the system connect to observe based state feedback controller.  

### Program Class 
1. In this class, other four namespaces are used to demonstrate the process of designing a controller and state estimator of a state space model. 
2. ContinousTimeStateSpaceSystem class is created to initiate a state space system.
3. Instances of ComplexNumber class are the desired pole location of the system.    
4. An instance of StateFeedBack is created to move system poles to desired position. 
5. An instance of StateEstimator is created to estimate states of system. 
6. An instance of Simulator is created to simulate the step response of a system.  

## Author
* Chen_Chien Lin
