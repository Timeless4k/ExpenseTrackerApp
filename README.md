# Expense Tracker Application

## Overview
The **Expense Tracker Application** is a personal finance management tool designed to help users track and manage their expenses and income. It supports CRUD operations (Create, Read, Update, Delete) for both expenses and income, and offers a user-friendly interface. The application is built with high-quality coding principles such as high cohesion, low coupling, polymorphism, and interface implementation, while integrating Entity Framework and LINQ for data operations.

---

## Features
- **Expense Management**: Create, read, update, and delete expenses with support for categorization.
- **Income Management**: Create, read, update, and delete income records with source details.
- **Input Validation**: Proper input validation for user data.
- **User Authentication**: User registration and login with secure password hashing.
- **Entity Framework**: Used for database management and persistent data storage.
- **LINQ**: LINQ queries for data filtering and manipulation.
- **NUnit Testing**: Integrated unit testing for core functionalities.

---

## Technologies Used
- **C#** (.NET Framework)
- **Windows Forms**: GUI interface for managing income and expenses.
- **Entity Framework Core**: ORM for handling database interactions.
- **MySQL**: Database for persistent storage.
- **LINQ**: For querying and manipulating data.
- **NUnit**: Unit testing framework for ensuring code quality and functionality.

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
   - Ensure you have MySQL installed and running. If not, download and install it from the [MySQL official website](https://dev.mysql.com/downloads/mysql/).
   - Make sure your application has permissions to create databases.

2. **Configuration**:
   - Open the `App.config` file in your project and locate the `<connectionStrings>` section.
   - Update it to include the correct MySQL connection string for `ExpenseTrackerDB`, for example:
     ```xml
     <connectionStrings>
       <add name="ExpenseTrackerDB" connectionString="server=localhost;database=ExpenseTrackerDB;user=root;password=yourpassword;" providerName="MySql.Data.MySqlClient" />
     </connectionStrings>
     ```
   - Replace `yourpassword` with the actual password for your MySQL root user (or any user you are using).

3. **Applying Entity Framework Migrations**:
   - Open the Package Manager Console in Visual Studio (`Tools > NuGet Package Manager > Package Manager Console`).
   - Set the default project to your application project (usually where your `DbContext` is defined) by using the dropdown at the top of the Package Manager Console.
   - To apply the initial migration and create the necessary tables in your `ExpenseTrackerDB`, run the following command:
     ```bash
     Update-Database
     ```

4. **Build and Run**:
   - Open the project in Visual Studio.
   - Build the solution (`Ctrl+Shift+B`).
   - Run the application (`F5`).

---

## Unit Testing
- The application includes NUnit tests to verify the functionality of core features such as:
  - Adding, updating, and deleting expenses and income.
  - Ensuring that user input is validated correctly.
  - Confirming that the database operations perform as expected.

- To run the tests:
  1. Open the **Test Explorer** in Visual Studio (`Test > Windows > Test Explorer`).
  2. Run all tests or select specific tests to execute.

---

## Contributions
This project was developed by:
- Gurudeep Singh Dhinjan
- Lavanya Chandna

---

## License
This project is licensed under the MIT License. You can freely use, modify, and distribute this software, but please provide attribution to the original authors.


