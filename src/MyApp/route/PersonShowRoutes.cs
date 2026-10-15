using JsonWebServer3.classes;   
namespace JsonWebServer3.route;


public static class PersonShowRoutes
{
    public static WebApplication MapPersonShowRoutes(this WebApplication app)
    {
        app.MapPost("/api/person/show", (Person person) =>
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Получен JSON (show):");
            Console.WriteLine($"  Name: {person.Name}");
            Console.WriteLine($"  Age:  {person.Age}");
            Console.WriteLine($"  City: {person.City}");
	    Console.WriteLine($"  Latitude: {person.Latitude}");
	    Console.WriteLine($"  Longitude: {person.Longitude}");
	    Console.WriteLine($"  Notice: {person.Notice}");

            return Results.Ok(new
            {
                Status = "OK",
                Message = $"Привет, {person.Name}! (show)",
                ReceivedAt = DateTime.UtcNow,
                Echo = person
            });
        });

        return app;
    }
}
