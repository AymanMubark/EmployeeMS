
---

# Employee Management System

## Overview

Employee Management System is a web application designed to simplify the process of managing employees within an organization. The system allows administrators to perform CRUD (Create, Read, Update, Delete) operations on employee records, making it efficient to manage workforce data.

## Key Features

- **Employee Management:** Create, view, update, and delete employee records.
- **Department Management:** Manage departments to categorize employees.
- **User Authentication:** Admin login functionality to secure the system.
- **Responsive UI:** User-friendly interface accessible on various devices.

## Technology Stack

- **ASP.NET Core:** Backend framework for building robust web applications.
- **Entity Framework Core:** ORM (Object-Relational Mapping) for database operations.
- **SQL Server:** Database management system for data storage.
- **Dependency Injection:** Used for managing class dependencies and promoting loose coupling.
- **MVC (Model-View-Controller):** Architectural pattern for organizing codebase.
- **Swagger:** API documentation and testing tool for API endpoints.
- **Automapper:** Library for object-object mapping.
- **JWT (JSON Web Tokens):** Used for secure user authentication and authorization.

## Installation and Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/AymanMubark/EmployeeMS.git
   ```

2. **Navigate to Project Directory:**
   ```bash
   cd EmployeeMS
   ```

3. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```

4. **Database Setup:**
   - Update database connection string in `appsettings.json`. **Note: Do not check the connection string into version control for security reasons.**
   - Apply database migrations:
     ```bash
     dotnet ef database update
     ```

5. **Run the Application:**
   ```bash
   dotnet run
   ```

6. **Access the Application:**
   Open a web browser and go to `http://localhost:5000`.

## Admin Access

- **Email:** admin@admin.com
- **Password:** P@$$0rd

## API Documentation

API documentation is available using Swagger. After running the application, access the API documentation at `http://localhost:5000/swagger`.

## Contributors

- John Doe - Developer
- Jane Smith - UI/UX Designer

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
