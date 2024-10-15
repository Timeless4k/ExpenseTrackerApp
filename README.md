# Expense Tracker Application

## Overview
The **Expense Tracker Application** is a personal finance management tool designed to help users track and manage their expenses and income. It supports CRUD operations (Create, Read, Update, Delete) for both expenses and income, provides detailed reports and budgeting options, and offers a user-friendly interface. The application is built with high-quality coding principles such as high cohesion, low coupling, polymorphism, and interface implementation, while integrating Entity Framework and LINQ for data operations.

---

## Features
- **Expense Management**: Create, read, update, and delete expenses with support for categorization.
- **Income Management**: Create, read, update, and delete income records with source details.
- **Category-Wise Filtering**: Filter expenses and income by category and date range.
- **Budget Tracking**: Set and track budgets for users.
- **Input Validation**: Proper input validation for user data.
- **User Authentication**: User registration and login with secure password hashing.
- **Reports**: Generate reports for income and expenses.
- **Entity Framework**: Used for database management and persistent data storage.
- **LINQ**: LINQ queries for data filtering and manipulation.

---

## Technologies Used
- **C#** (.NET Framework)
- **Windows Forms**: GUI interface for managing income and expenses.
- **Entity Framework Core**: ORM for handling database interactions.
- **MySQL**: Database for persistent storage.
- **LINQ**: For querying and manipulating data.
- **NUnit** (To be implemented): Unit testing framework.

---

## Code Principles
- **High Cohesion & Low Coupling**: The application follows best practices for separating concerns and reducing dependencies between modules.
- **Polymorphism**: Achieved via inheritance with a `Transaction` base class shared by `Expense` and `Income`.
- **Interfaces**: Used for repository patterns (`IRepository`, `IExpenseRepository`, `IIncomeRepository`).
- **Anonymous Methods**: Implemented with LINQ and lambda expressions.
- **Generics**: Utilized in repository classes to handle generic data types.

---

## Setup Instructions

1. **Database Setup**:
   - Ensure you have MySQL installed and running.
   - Create a database named `ExpenseTrackerDB`.
   - Run the SQL script to create the required tables (can be generated using Entity Framework migrations).

2. **Configuration**:
   - Update the `App.config` file to include the correct MySQL connection string for `ExpenseTrackerDB`.

3. **Build and Run**:
   - Open the project in Visual Studio.
   - Build the solution (`Ctrl+Shift+B`).
   - Run the application (`F5`).

---

## Unit Testing (To be implemented)
- NUnit tests will be added for core features like income and expense operations.

---

## Contributions
This project was developed by:
- Gurudeep Singh Dhinjan
- Lavanya Chandna

---

## License
This project is licensed under the MIT License.
