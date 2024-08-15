using http_api_minimal_student;
using http_api_minimal_student.Model;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDb>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/list", async (StudentDb studentDb) =>
{
    return await studentDb.Students.ToListAsync();
});

app.MapGet("/list/offset/{offset}", async (StudentDb db, int offset, int? limit=10) =>
{
    Console.WriteLine($"{offset} => {offset.GetType()}");
    return await db.Students
        .FromSql($"Select * from Students limit {limit} offset {offset};")
        .ToListAsync();
});

app.MapGet("/details/{id}", async (int id, StudentDb db) =>
{
    return await db.Students.FindAsync(id);
});

app.MapPost("/add", async (Student student, StudentDb db) =>
{
    var response = new ApiResponse<Student>(1, message: "Student deleted successfully.", null);
    try{
        db.Students.Add(student);
        await db.SaveChangesAsync();
        return Results.Created("Created", response);
    }
    catch(Exception e){
        Console.WriteLine("Caught exception in adding student: " + e.Source);
        response.Code = -1;
        response.Message = e.ToString().Contains("students.PRIMARY") ? $"Student with ID {student.Id} already exists": "Failed to add student";
        response.Data = null;
        return Results.BadRequest(response);
    }
});

app.MapDelete("/delete/{id}", async(StudentDb db, int id) =>{
    var student = await db.Students.FindAsync(id);
    if(student!=null){
        db.Remove<Student>(student);
        await db.SaveChangesAsync();
        return Results.Ok(new ApiResponse<string>(1, message: "Student deleted successfully.", null));
    }
    return Results.NotFound(new ApiResponse<string>(0, message: "Student with given ID not found.", null));
});


await app.RunAsync();
