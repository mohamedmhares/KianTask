# Project Documentation: Device Management System

## Introduction
This document outlines the functionality and design principles of the Device Management System project. The project was developed using ASP.NET Core, Entity Framework Core, and follows best practices in software development, including the N-Tier Architecture and Naming Conventions.

## Project Overview
The Device Management System is a web application designed for managing devices. It enables users to create and read devices, along with managing their categories and associated properties. The application emphasizes user-friendliness, efficient data management, and scalability.

## Functionality

### Key Features
1. **Employee Management**: Users can create, edit, view, and delete employee records. Each employee record contains the following attributes:
   - First Name
   - Last Name
   - Username
   - Salary

2. **Form Handling**: The application allows users to manage employee forms, including adding new employees and editing existing ones.

3. **Data Retrieval**: Users can view a list of all employees along with their details and can filter or reload the list as needed.

### User Flow
- **Creating an Employee**:
  1. Click the "Add Employee" button to open the form.
  2. Enter employee details and submit the form to create a new employee record.

- **Viewing Employees**:
  - Navigate to the employee listing page to view all employee records, which include their details and action buttons for editing or deleting.

- **Editing Employees**:
  - Click the "Edit" button next to an employee record to populate the form with existing data and modify it as needed.

- **Deleting Employees**:
  - Click the "Remove" button next to an employee record to delete that employee from the system.

## Design Principles

### N-Tier Architecture
The project is structured using N-Tier Architecture, promoting separation of concerns and enhancing maintainability. The architecture consists of the following layers:
- **Core Layer**: Contains the entity models and interfaces, defining the business logic and application services related to employee management.
- **Infrastructure Layer**: Handles data access, including repository implementations and the database context, business logic.
- **Presentation Layer**: Comprises the Angular frontend, which handles user interaction and displays employee data, and coordinates data exchange between the core and presentation.

## Frontend Development
- **Angular Framework**: The frontend is built using Angular, providing a dynamic user interface and seamless interactions with the backend API.
  - **Reactive Forms**: Angular's reactive forms are utilized for handling employee data input, ensuring robust validation and user experience.
  - **Bootstrap**: Bootstrap is integrated for responsive design.

## Best Practices
- **Dependency Injection**: The project uses dependency injection to manage service lifetimes and dependencies, improving testability and modularity.
- **RESTful API Design**: The backend is designed as a RESTful API, facilitating CRUD operations for employee records while adhering to standard HTTP methods.
- **Asynchronous Programming**: Asynchronous programming is utilized in API calls to improve performance and responsiveness in the Angular frontend.

## Prerequisites
Before running the project, ensure you have the following installed:
- .NET SDK: version 8.0.
- Node.js (version 14 or later) for the frontend.
- Angular CLI (version 15 or later) for managing the Angular project.
- A suitable code editor (e.g., Visual Studio, Visual Studio Code).

## Running the Application
1. Navigate to the project root directory.
2. Run the following command to start the backend:
   ```bash
   dotnet run
