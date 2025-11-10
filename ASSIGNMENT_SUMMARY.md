# Assignment 9 - Implementation Summary
## Bernard Bawak

## Requirements Completed

### 1. Project Setup ✅
- Created WinForms .NET Core application (not .NET Framework)
- Project name: COMP3300Assignment9BernardBawak
- Form title: "Assignment 9 by Bawak"
- All naming conventions followed (PascalCase for classes, camelCase for variables)

### 2. Class Hierarchy ✅
- **Base Class**: `BankAccount` (in Models namespace)
  - Properties: OwnerName, CurrentBalance, MonthOpened, Type, MonthlyInterestRate
  - Constructor: Takes all properties as parameters
  - Virtual method: `CalculateMinimumBalanceFee()` - returns 7.3% if balance < 1200.00
  - Overridable method: `ToString()` - returns formatted string with account info

- **Derived Classes** (all in Models namespace):
  - `SavingsAccount` : BankAccount
    - Constructor calls base with "savings" type
    - Full override of CalculateMinimumBalanceFee (tiered structure: 5% < 1000, 3% < 2000, else base)
    - Partial override of ToString (adds "Account Type: savings")
  
  - `CheckingAccount` : BankAccount
    - Constructor calls base with "checking" type
    - Partial override of CalculateMinimumBalanceFee (flat $25 + 2% if < 1500, else base)
    - Partial override of ToString (adds "Account Type: checking")
  
  - `MoneyMarketAccount` : BankAccount
    - Constructor calls base with "money market" type
    - Full override of CalculateMinimumBalanceFee (0% if >= 5000, else 4.5% + dynamic shortfall fee)
    - Partial override of ToString (adds "Account Type: money market")

### 3. Method Overriding ✅
- **CalculateMinimumBalanceFee**:
  - Base: 7.3% if balance < 1200.00
  - SavingsAccount: Tiered structure (full override)
  - CheckingAccount: Flat fee structure (partial override - calls base)
  - MoneyMarketAccount: Dynamic shortfall calculation (full override - no base call)
  
- **ToString**:
  - Base: "Name: {OwnerName}, Balance: {CurrentBalance}, Month Opened: {MonthOpened}, Monthly Interest Rate: {MonthlyInterestRate}"
  - All derived classes: Partial override adding "Account Type: {Type}" at the beginning

### 4. JSON File Reading ✅
- Created `accounts.json` with all 15 account records
- GUI includes file selection dialog
- Reads JSON and deserializes to BankAccount objects
- Creates appropriate derived class instances based on Type property
- Stores each type in separate collections

### 5. GUI Implementation ✅
- MainForm with:
  - "Select JSON File" button - opens file dialog
  - "Display Savings" button - shows all savings accounts
  - "Display Checking" button - shows all checking accounts
  - "Display Money Market" button - shows all money market accounts
  - TextBox for displaying account information
  - Status label showing loaded account counts
- Buttons are enabled only after file is loaded
- User-friendly interface with clear labels

### 6. Class Diagram ⚠️
**Note**: Class diagrams must be added in Visual Studio. Follow these steps:

1. Open the solution in Visual Studio
2. Right-click on the project in Solution Explorer
3. Select "Add" > "New Item..."
4. In the search box, type "Class Diagram"
5. Select "Class Diagram" from the list
6. Name it "ClassDiagram.cd" (or any name you prefer)
7. Click "Add"
8. If prompted to install the Class Designer component, click "Yes" and follow the installation
9. Once the diagram opens, drag the following classes from Solution Explorer onto the diagram:
   - `BankAccount` (from Models folder)
   - `SavingsAccount` (from Models folder)
   - `CheckingAccount` (from Models folder)
   - `MoneyMarketAccount` (from Models folder)
10. The inheritance relationships will be automatically displayed
11. Save the diagram

The class diagram will show:
- BankAccount as the base class
- Three derived classes (SavingsAccount, CheckingAccount, MoneyMarketAccount) with inheritance arrows
- All properties and methods for each class

## File Structure
```
COMP3300Assignment9BernardBawak/
├── COMP3300Assignment9BernardBawak.csproj
├── Program.cs
├── MainForm.cs
├── accounts.json
├── Models/
│   ├── BankAccount.cs
│   ├── SavingsAccount.cs
│   ├── CheckingAccount.cs
│   └── MoneyMarketAccount.cs
└── README.md
```

## Testing the Application
1. Build the solution (Build > Build Solution)
2. Run the application (F5)
3. Click "Select JSON File"
4. Navigate to and select `accounts.json`
5. Click each display button to see accounts of that type
6. Verify that ToString output includes "Account Type: {type}" for each account

## Submission Checklist
- ✅ Project compiles without errors
- ✅ All classes implement inheritance correctly
- ✅ Constructors call base constructors
- ✅ Methods are properly overridden (both full and partial)
- ✅ JSON file reading works
- ✅ GUI displays accounts by type
- ⚠️ Class diagram needs to be added in Visual Studio (see instructions above)
- ⚠️ Clean solution before zipping (Build > Clean Solution)
- ⚠️ Zip project including solution file as "BernardBawakA9.zip"

