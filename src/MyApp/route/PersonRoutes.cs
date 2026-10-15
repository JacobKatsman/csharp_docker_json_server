using JsonWebServer3.classes;   
namespace JsonWebServer3.route;

using System.Linq;

public static class PersonRoutes
{
    // people передаём как параметр, т.к. он создаётся в Program.cs
    public static WebApplication MapPersonRoutes(this WebApplication app, Person[] people)
    {
        // GET /api/person/names — вернуть всех людей как JSON
        app.MapGet("/api/person/names", () =>
        {
            Console.WriteLine($"[GET /api/person/names] Отдаём {people.Length} записей");
            return Results.Ok(people);
        });

        // POST /api/person — принять JSON, вернуть эхо
        app.MapPost("/api/person", (Person person) =>
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Получен JSON:");
            Console.WriteLine($"  Name: {person.Name}");
            Console.WriteLine($"  Age:  {person.Age}");
            Console.WriteLine($"  City: {person.City}");

            return Results.Ok(new
            {
                Status = "OK",
                Message = $"Привет, {person.Name}!",
                ReceivedAt = DateTime.UtcNow,
                Echo = person
            });
        });

        return app;
    }
}
