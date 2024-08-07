
# Create a minimal API with ASP.NET Core

## Steps to install using CLI in VS Code

> Create folder with your desired name for project. Here I am going with *'http-api-minimal-student'*
>> ***dotnet new web***
>
> Command to create project without creating folder
>> ***dotnet new web -o 'your-project-name'***

* In order to run project on your windows system simply click on ***F5*** and ***select current project to run*** or run `dotnet run` command in terminal

## Adding NuGet packages

* NuGet packages help to run connect database with out application.
* Here I am going with In-Memory database provider for Entity Framework Core. This provider is useful for testing purposes as it allows you to run your application with an in-memory database, which is fast and does not require a physical database setup.

> *dotnet add package Microsoft.EntityFrameworkCore.InMemory*

* Here there is another package that provides integration between ASP.NET Core diagnostics and Entity Framework Core. It enables detailed error reporting and debugging information related to Entity Framework Core operations in your ASP.NET Core applications.

> dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
