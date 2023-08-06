# Employee Management Backend 

The Employee Management Backend is a .NET Core web API application that provides backend services for managing employees in a company. It includes features for user authentication, employee CRUD operations, department management, and job title management.

## Table of Contents
- [Technologies](#technologies)
- [Features](#features)
- [Getting Started](#getting-started)
     - [Prerequisites](#prerequisites)
     - [Installation](#installation)
- [Endpoints](#endpoints)


## Technologies <a name="technologies"></a> 
- .NET Core: A cross-platform, open-source framework for building modern applications.
- ASP.NET Core: A web framework for building web APIs using .NET Core.
- Entity Framework Core: An object-relational mapping (ORM) framework for .NET Core.
- PostgreSQL: A relational database for storing employee data.

## Features <a name="features"></a> 
- Create a new employee record.
- Retrieve a list of all employees or search for specific employees.
- Retrieve a single employee by their ID.
- Retrieve a list of employees by job title
- Retrieve a list of employees by department
- Update an existing employee record.
- Delete an employee record.

## Getting Started <a name="getting-started"></a> 
  - ### Prerequisites <a name="prerequisites"></a> 
    - .NET Core SDK installed on your system.
    - PostgreSQL installed and running locally or accessible remotely.
      
  - ### Installation  <a name="installation"></a>
    - Clone the repository: git clone https://github.com/iamtigermaximus/Employee-Management-Backend2.git
    - Navigate to the project directory: cd employee-management-backend
    - Set up the PostgreSQL connection string in the appsettings.json file.
   
## Endpoints <a name="endpoints"></a> 

| Method |                      Endpoint            |          Description                 | Authorization |
|--------|------------------------------------------|--------------------------------------|---------------|
| Get    | api/v1/Employees                         | Get a list of all employees          | Bearer Token  |
| Get    | api/v1/Employees/{id}                    | Get a single employee by ID          | Bearer Token  |
| Post   | api/v1/Employees                         | Create a new employee                | Bearer Token  |
| Put    | api/v1/Employees/{id}                    | Update an existing employee by ID    | Bearer Token  |
| Delete | api/v1/Employees/{id}                    | Delete an employee by ID             | Bearer Token  |
| Get    | api/v1/Employees/department{departmentId}| Get a list of employees by department| Bearer Token  |
| Get    | api/v1/Employees/jobTitle{jobTitleId}    | Get a list of employees by job title | Bearer Token  |
|        |                                          |                                      |               |
| Get    | api/v1/Departments                       | Get a list of all departments        | Bearer Token  |
| Get    | api/v1/Departments/{id}                  | Get a single department by ID        | Bearer Token  |
| Post   | api/v1/Departments                       | Create a new department              | Bearer Token  |
| Put    | api/v1/Departments/{id}                  | Update an existing department by ID  | Bearer Token  |
| Delete | api/v1/Departments/{id}                  | Delete an employee by ID             | Bearer Token  |
|        |                                          |                                      |               |
| Get    | api/v1/JobTitles                         | Get a list of all job titles         | Bearer Token  |
| Get    | api/v1/JobTitles/{id}                    | Get a single job title by ID         | Bearer Token  |
| Post   | api/v1/JobTitles                         | Create a new job title               | Bearer Token  |
| Put    | api/v1/JobTitles/{id}                    | Update an existing job title by ID   | Bearer Token  |
| Delete | api/v1/JobTitles/{id}                    | Delete an job title by ID            | Bearer Token  |
|        |                                          |                                      |               |
| Get    | api/v1/Users                             | Get a list of all users              | Bearer Token  |
| Get    | api/v1/Users/{id}                        | Get a single user by ID              | Bearer Token  |
| Post   | api/v1/Users                             | Create a new user                    | Not required  |
| Put    | api/v1/Users/{id}                        | Update an existing user by ID        | Bearer Token  |
| Delete | api/v1/Users/{id}                        | Delete an user by ID                 | Bearer Token  |
|        |                                          |                                      |               |
| Post   | api/v1/Auths                             | Login and obtain JWT token           | Not required  |
