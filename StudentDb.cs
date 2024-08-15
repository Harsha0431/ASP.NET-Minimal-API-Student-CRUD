using http_api_minimal_student.Model;
using Microsoft.EntityFrameworkCore;

namespace http_api_minimal_student{
    //* This is the class that we manage all our tables(Entity classes)
    class StudentDb : DbContext
    {
        public StudentDb(DbContextOptions<StudentDb> options)
            : base(options) { }
        public DbSet<Student> Students => Set<Student>();

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}

/*
There are two ways to connect our application to database (MySQL)
1. By hardcoding connection string in override method OnConfigure()
Eg: 
var connStr = "Server=localhost;Port=3306;Database=dotnet_StudentDb;user=< User >;password=< Password >;"
optionsBuilder..UseMySql(connString, ServerVersion.AutoDetect(connString)));

2. Another approach is to store the connection string in the appsettings.json file and retrieve it using the configuration API.
If we don't have appsettings.json file do below steps
2.1: Create a file named appsettings.json in root folder
2.2: Write below code that just created file
{
    "ConnectionStrings": {
        "SchoolDBLocalConnection": "Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;"
    }
}
2.3: Install Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json NuGet package to your project.
2.4: After installing the package, you need to build the configuration by adding appsettings.json file, as shown below.
    var configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
2.5: Now we can modify out DbContext file as follows or in Program.cs
Eg: 
public class SchoolContext : DbContext
{
    IConfiguration appConfig;

    public SchoolDbContext(IConfiguration config)
    {
        appConfig = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(appConfig.GetConnectionString("SchoolDBLocalConnection");
    }
}

OR
*In Program.cs (Recommended)

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDb>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));
*/


/*
* Guide: https://www.entityframeworktutorial.net/efcore/generate-sql-script.aspx
Steps to Migrate database with EF
1. This below command doesn't create database. It just creates the two snapshot files in the Migrations folder.
    *dotnet ef migrations add InitialStudentDb*
    'InitialStudentDb' -> It just specifies migration name which can we used incase if we need to revert(rollback) our migration.
2. Now, to create a database, use the below command in the Package Manager Console, as shown below.
    *dotnet ef database update*
3. Use the following migration command to get the list of all migrations.
    *dotnet ef migrations list*
4. We can revert or remove a specific migration also. Explore it on yourself.
5. In-order to get the source script for all the migrations execute following command
    *dotnet ef migrations script

*/