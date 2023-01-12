# SmartCalc v3.0

Implementation of SmartCalc v3.0 in C#.


## Contents

1. [Chapter I](#chapter-i) \
   1.1. [Introduction](#introduction)
2. [Chapter II](#chapter-ii) \
   2.1. [MVP pattern](#mvp-pattern) \
   2.2. [MVVM pattern](#mvvm-pattern)
3. [Chapter III](#chapter-iii) \
   3.1. [Part 1](#part-1-smartcalc-v30-implementation) \
   3.2. [Part 2](#part-2-bonus-loan-сalculator) \
   3.3. [Part 3](#part-3-bonus-deposit-calculator) \
   3.4. [Part 4](#part-4-bonus-configuration-and-logging) \
   3.5. [Part 5](#part-5-bonus-cross-platform)
4. [Chapter IV](#chapter-iv)


## Chapter I

## Introduction

In this project you will implement an extended version of the usual calculator in the C# programming language, which implements the same functions as the previously developed application in the SmartCalc v2.0 project. You will improve your skills in the new programming language, learn the MVP or MVVM pattern, and add the help and history functionality to the application.


## Chapter II

### MVP pattern

The MVP pattern has two components in common with MVC: the model and the view. But it replaces the controller with a presenter.

The presenter implements the interaction between the model and the view.
When the view notifies the presenter that the user has done something (e.g., pressed a button), 
the presenter decides to update the model and synchronizes all changes between the model and the view.
However, the presenter does not interact with the view directly. Instead, it uses an interface to communicate. 
This allows all components of the application to be tested individually afterwards.

![](misc/images/MVP-Process.png)

### MVVM pattern

MVVM is a more modern update of MVC. The main purpose of MVVM is to provide a clear separation between the presentation and model layers. MVVM supports two-way data binding between View and ViewModel components.

The view acts as a subscriber to property value change events provided by the view model (ViewModel).
If a property has changed in the view model, it notifies all subscribers about it, 
and the view, in turn, requests the updated property value from the view model.
If the user interacts with an interface element, the view calls the corresponding command provided by the view model.

A view model is on the one hand an abstraction of a view, and on the other hand a wrapper of data from the model to be bound. 
In other words, it contains the model transformed to the view, as well as the commands the view can use to affect the model.

![](misc/images/MVVM-Process.png)


## Chapter III

## Part 1. SmartCalc v3.0 implementation

You need to implement SmartCalc v3.0:

- The program must be developed in C# 10
- The program code must be in the src folder
- You must stick to Microsoft Code Style when writing code
- You need to develop a desktop application
- Prepare the installer, which will install the application to the system with the standard settings (installation path, creating shortcut)
- Prepare an implementation with a graphical user interface for Mac OS, based on any GUI library or framework (GUI layer implementation in HTML/CSS/JS is acceptable)
- The program must be implemented using the MVVM or MVP pattern, and
    - There should be no business logic code in the view code
    - there must be no interface code in the model, presenter and view model
- The "core" of the calculator in the form of an algorithm for the formation and calculation of the Polish notation and various computational functions connect as a dynamic library in C/C++ from the SmartCalc v1.0 or SmartCalc v2.0 projects
- The model should be a "core" with a wrapper in C#
- The model must have all the calculator's functionality so that it can be used in the future without the other layers
- Prepare full coverage of methods in the model layer with unit tests
 - The application should have a help section with a description of the program interface in random form
- The program must save the history of operations, allow loading expressions from the history and clear the entire history
- History must be saved between runs of the application
- Both integers and real numbers, written either via a point or in exponential form, can be input to the program
- Calculation should be performed after the complete entry of the calculated expression and pressing the symbol `=`
- Calculation of arbitrary bracketed arithmetic expressions in infix notation
- Calculation of arbitrary bracketed arithmetic expressions in infix notation with substitution of _x_ variable as a number
- Plotting a function defined using an expression in infix notation with the variable _x_ (with coordinate axes, scale marker, and grid with adaptive step)
    - It is not necessary to provide the user with the ability to change the scale
- The range of definition and the range of value of the functions are at least limited to numbers from -1000000 to 1000000
- To plot a function it is necessary to additionally specify the displayed area of definition and area of value
- Checked accuracy of the fractional part is at least 7 decimal places
- The user must be able to enter up to 255 characters
- Bracketed arithmetic expressions in infix notation must support the following arithmetic operations and mathematical functions:
    - **Arithmetic operators**:

      | Operator name | Infix Notation <br />(Classic) | Prefix notation <br /> (Polish notation) |  Postfix notation <br />(Reverse Polish notation) |
      | ------ | ------ | ------ | ------ |
      | Parentheses | (a + b) | (+ a b) | a b + |
      | Addition | a + b | + a b | a b + |
      | Subtraction | a - b | - a b | a b - |
      | Multiplication | a * b | * a b | a b * |
      | Division| a / b | / a b | a b \ |
      | Rasing to the power | a ^ b | ^ a b | a b ^ |
      | Remainder of division | a mod b | mod a b | a b mod |
      | Unary plus | +a | +a | a+ |
      | Unary minus | -a | -a | a- |

      >Please note that the multiplication operator contains a mandatory `*` sign. Processing an expression with the `*` sign omitted is optional and left to the developer's discretion

      | Function description | Function |   
      | ---------------- | ------- |  
      | Calculates cosine | cos(x) |   
      | Calculates sine | sin(x) |  
      | Calculates tangent | tan(x) |  
      | Calculates arc cosine | acos(x) | 
      | Calculates the arcsine | asin(x) | 
      | Calculates arctangent | atan(x) |
      | Calculates square root | sqrt(x) |
      | Calculates natural logarithm | ln(x) | 
      | Calculates decimal logarithm | log(x) |

## Part 2. Bonus. Loan сalculator

Provide a special mode " loan calculator " ( you can take websites like banki.ru and calcus.ru as an example):
- Input: total loan amount, term, interest rate, type (annuity, differentiated)
- Output: monthly payment, overpayment for the loan, total repayment

## Part 3. Bonus. Deposit calculator

Provide a special mode "deposit calculator " ( you can take websites like banki.ru and calcus.ru as an example):
- Input: deposit amount, deposit term, interest rate, tax rate, periodicity of payments, capitalization of interest, list of additions, list of partial withdrawals
- Output: accrued interest, tax amount, amount on deposit by the end of the term

## Part 4. Bonus. Configuration and logging

Add settings to the app:
- Add reading of settings from configuration file when the program runs
- Include in the configuration file 3 or more parameters to choose from, such as background color, font size, etc.
- Add descriptions of editable parameters to help

Add logging to the application:
- Store operation history in logs
- Save logs in the logs folder, one file per rotation period
- It should be possible to set the period of logs rotation (hour/day/month)
- Files must be named according to the following pattern: `logs_dd-MM-yy-hh-mm-ss` ( the time of file creation )

## Part 5. Bonus. Cross-platform

Make your app cross-platform:
- Add support for Linux
- Add support for Windows
- The installer should also be available for Linux and Windows (several different installers are allowed)

