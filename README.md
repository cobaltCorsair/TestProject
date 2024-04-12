## ASP.NET MVC Project

## Description
This project is an example of a web application using ASP.NET MVC on the .NET Framework. 
The application implements basic CRUD operations for entity management, as well as the About and Contact pages.

## Technologies
- ASP.NET MVC 5
- Entity Framework 6
- .NET Framework 4.8

## Functionality
- Display a list of entities.
- Create a new entity.
- Editing an existing entity.
- Deleting an entity.
- About and Contact pages with basic information.

## Installation

### Pre-requisites
Make sure you have the following components installed on your computer:
- Visual Studio 2019 or higher
- .NET Framework 4.8 SDK
- PostgreSQL 16 (for local database)

### Installation Steps

#### Clone the repository to your local computer:
 ```bash 
 git clone https://github.com/cobaltCorsair/TestProject.git
 ```
#### Open the solution in Visual Studio
- Open Visual Studio.
- Navigate to `File` > `Open` > `Project/Solution`.
- Browse to the location of the cloned repository and open the solution file (`*.sln`).

#### Restore NuGet packages
Restore the necessary NuGet packages by running the following command in the Package Manager Console:
```bash
Update-Package -Reinstall
 ```
#### Configure the connection string in the Web.config file
1. Locate the Web.config file in the root of the project.
2. Find the `<connectionStrings>` section.
3. Modify the connection string to point to your database server. For example:

```xml
  <connectionStrings>
    <!-- Подключение базы данных -->
    <add name="DefaultConnection" connectionString="Server=(localdb); Port=YourPort; Database=YourDatabaseName; User Id=YourUserName; Password=YourPassword;" providerName="Npgsql" />
  </connectionStrings>
 ```

#### Apply migrations to the database to restore the database schema
Apply the existing migrations to update the database schema by running the following command in the Package Manager Console:

```bash
Update-Database
