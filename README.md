
# Create a minimal API with ASP.NET Core

## Steps to install using CLI in VS Code

> Create folder with your desired name for project. Here I am going with *'http-api-minimal-student'*
>> ***dotnet new web***
>
> Command to create project without creating folder
>> ***dotnet new web -o 'your-project-name'***

* In order to run project on your windows system simply click on ***F5*** and ***select current project to run*** or run `dotnet run` command in terminal

## Adding NuGet packages

* NuGet packages help to run connect database with in application.

* Here I am going with MySQL. Add following package to your application for MySQL support.

> **Package Name:** *Pomelo.EntityFrameworkCore.MySql*
> **Command to install:** *dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2*

* Here there is another package that provides integration between ASP.NET Core diagnostics and Entity Framework Core. It enables detailed error reporting and debugging information related to Entity Framework Core operations in your ASP.NET Core applications.

> *dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore*
> *dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.8*

___

## How to connect out application to realtime database

Here as I said earlier we are going to connect our application to MySQL database.

Instead of hardcoding connection string in our code we can use ***appsettings.json*** file. Add following lines of code in that file.
>"ConnectionStrings": {
>   "DefaultConnection": "Server=localhost;Port=3306;Database=<**Database name**>;user=<**User**>;password=<**Password**>;"
>}

We can use that connection string to connect to that respective database. There are multiple ways to connect our application with database, here we are going to do with help of ***Program.cs*** file.
*In Program.cs (Recommended)

>builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
>var connString = builder.Configuration.GetConnectionString("DefaultConnection");
>builder.Services.AddDbContext<***DBContextFileClass***>(options =>
>    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

With this minimal setup we can connect our application with Database.
Incase if we don't have database that we specified in our connection string then we can create that database and update it with all the related  classes i.e., Entities we have created with following commands

### Steps to Migrate database with EntityFramework

1. This below command doesn't create database. It just creates the two snapshot files in the Migrations folder.
    > ***dotnet ef migrations add InitialStudentDb***
    > 'InitialStudentDb' -> It just specifies migration name which can we used incase if we need to revert(rollback) our migration.
2. Now, to create a database, use the below command in the Package Manager Console, as shown below.
    > ***dotnet ef database update***
3. Use the following migration command to get the list of all migrations.
    > ***dotnet ef migrations list***
4. We can revert or remove a specific migration also. Explore it on yourself.
5. In-order to get the source script for all the migrations execute following command
    > ***dotnet ef migrations script***
