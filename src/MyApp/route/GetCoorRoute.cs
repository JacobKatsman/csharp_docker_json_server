using JsonWebServer3.classes;   
namespace JsonWebServer3.route;

using System.Linq;

public static class GetCoorRoutes
{
    public static WebApplication MapGetCoorRoutes(this WebApplication app, Person[] people)
    {
	//{"name": "John"}
        app.MapPost("/api/person/coorforname", (Person person) =>
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Получен JSON:");
            Console.WriteLine($"  Name: {person.Name}");

	        // 1. Ищем человека по имени
                var target = people.FirstOrDefault(p => p.Name == person.Name);
                if (target == null)
                {
                    Console.WriteLine($"[ChangeCoor] Не найден: {person.Name}");
                    return Results.NotFound(new
                    {
                        Status = "ERROR",
                        Message = $"Человек с именем '{person.Name}' не найден"
                    });
                }
                Console.WriteLine($"[ChangeCoor] Обновлён: {target.Name} → " +
                                  $"({target.Latitude}, {target.Longitude})");

            // 2. Возвращаем координаты ИМЕННО target, а не person
            return Results.Ok(new
            {
                    Status = "OK",
                    Name = target.Name,
                    Latitude = target.Latitude,
                    Longitude = target.Longitude
            });
        });
        return app;
    }
}
