using System;
namespace Bai002;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        Students studens = new Students("Alice", 20, 85.5);
        studens.AddStudentSafe(new Students("Alice", 20, 85.5));

        app.Run();
    }
}
