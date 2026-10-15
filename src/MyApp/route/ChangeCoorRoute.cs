using JsonWebServer3.classes;   
namespace JsonWebServer3.route;

using System.Linq;

public static class ChangeCoorRoutes
{
    // people передаём как параметр, т.к. он создаётся в Program.cs
    public static WebApplication MapChangeCoorRoutes(this WebApplication app, Person[] people, string csvPath)
    {
        // POST /api/person/change — принять JSON, вернуть эхо
	// {
        // "text": "пример строки",
	// "number_one": 42,
	// "number_two": 3.14
	//}

	// {"name": "John","latitude": 42,"longitude": 1}
	
        app.MapPost("/api/person/change", (Person person) =>
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Получен JSON:");
            Console.WriteLine($"  Name: {person.Name}");
            Console.WriteLine($"  Latitude:  {person.Latitude}");
            Console.WriteLine($"  Longitude: {person.Longitude}");


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

                // 2. Меняем координаты. Поскольку target — ссылка на объект в массиве,
                // это изменение отразится на всём массиве people.
                target.Latitude  = person.Latitude;
                target.Longitude = person.Longitude;

                Console.WriteLine($"[ChangeCoor] Обновлён: {target.Name} → " +
                                  $"({target.Latitude}, {target.Longitude})");

                // 3. Сохраняем весь массив обратно в CSV
                CsvLoader.SavePeople(csvPath, people);

	    

            return Results.Ok(new
            {
                Status = "OK",
                Message = $"Координаты, {person.Name}; Latitude:  {person.Latitude}; Longitude: {person.Longitude}!",
                ReceivedAt = DateTime.UtcNow,
                Echo = person
            });
        });

        return app;
    }
}
