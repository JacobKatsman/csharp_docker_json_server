using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

// Подключаем namespace'ы из папок class/ и route/
using JsonWebServer3.route;     // ← RootRoutes, PersonRoutes (extension-методы)
using JsonWebServer3.classes;   // ← Person, CsvLoader

// команды компиляции:
// -- dotnet run
// -- dotnet build

var path = Path.GetFullPath("./db/map.db");
Console.WriteLine($"[STARTUP] Ищу карту: {path}");
Console.WriteLine($"[STARTUP] Существует: {File.Exists(path)}");


var csvPath = Path.GetFullPath("./db/test.file");
// Загрузка CSV при старте приложения
var people = CsvLoader.LoadPeople("./db/test.file");
Console.WriteLine($"[STARTUP] Загружено записей: {people.Length}");
// загружаем карту
var mapData = MapLoader.Load("./db/map.db");
if (mapData is null) {
Console.WriteLine($"[STARTUP] не загружена карта:");
} else {
Console.WriteLine($"[STARTUP] Загружена карта");    
}

var builder = WebApplication.CreateBuilder(args);
//0.0.0.0: иначе андройд-студио не найдет наш сервер при отладке
builder.WebHost.UseUrls("http://0.0.0.0:8080");
// Настраиваем JSON-опции
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

app.MapRootRoutes();
app.MapCartRoutes(mapData);
app.MapGetCoorRoutes(people);
app.MapChangeCoorRoutes(people, csvPath);
app.MapPersonRoutes(people);        
app.MapPersonNameRoutes(people);
app.MapPersonShowRoutes();

app.Run();



