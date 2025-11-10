# COMP3300 Assignment 9 - Bernard Bawak

## Project Overview
This is a WinForms .NET Core application that demonstrates inheritance, constructor calling, and method overriding using bank account classes.

## Class Structure
- **BankAccount** (Base Class): Contains common properties and base implementations
- **SavingsAccount** (Derived): Inherits from BankAccount with tiered fee structure
- **CheckingAccount** (Derived): Inherits from BankAccount with flat fee structure
- **MoneyMarketAccount** (Derived): Inherits from BankAccount with dynamic fee structure

## Features
- JSON file reading for bank account data
- Inheritance with constructor calling
- Method overriding (CalculateMinimumBalanceFee and ToString)
- GUI with buttons to display accounts by type

## How to Add Class Diagram in Visual Studio
1. Right-click on the project in Solution Explorer
2. Select "Add" > "New Item"
3. Search for "Class Diagram" or navigate to "General" > "Class Diagram"
4. Name it "ClassDiagram.cd"
5. Drag the classes from Solution Explorer onto the diagram
6. The diagram will show the inheritance relationships automatically

## Running the Application
1. Build the solution (Build > Build Solution)
2. Run the application (F5 or Debug > Start Debugging)
3. Click "Select JSON File" and choose the accounts.json file
4. Use the display buttons to view accounts by type

