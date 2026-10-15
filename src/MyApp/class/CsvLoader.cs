namespace JsonWebServer3.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class CsvLoader
{
    /// <summary>
    /// Читает CSV-файл формата "имя;возраст;город" и возвращает массив Person.
    /// Первая строка может быть заголовком — она пропускается, если не парсится как число.
    /// </summary>
    public static Person[] LoadPeople(string filePath)
    {
	int age = 0 ;
	int latitude  = 0 ;
	int longitude = 0 ;
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"[CsvLoader] Файл не найден: {filePath}");
            return Array.Empty<Person>();
        }

        var lines = File.ReadAllLines(filePath);
        var result = new List<Person>(lines.Length);

        for (int i = 0; i < lines.Length; i++)
         {
            var line = lines[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';', StringSplitOptions.TrimEntries);

            // Пропускаем заголовок "name;age;city"
            if (i == 0 && !int.TryParse(parts.ElementAtOrDefault(1), out _))
                continue;

            if (parts.Length < 3)
            {
                Console.WriteLine($"[CsvLoader] Строка {i + 1} пропущена (недостаточно полей): {line}");
                continue;
            }

            if (!int.TryParse(parts[1], out age))
            {
                Console.WriteLine($"[CsvLoader] Строка {i + 1} пропущена (возраст не число): {line}");
                continue;
            }
            
            if (!int.TryParse(parts[3], out latitude))
            {
                Console.WriteLine($"[CsvLoader] Строка {i + 1} пропущена (широта longitude  не число)");
            }
	    
            if (!int.TryParse(parts[4], out longitude)) {
                Console.WriteLine($"[CsvLoader] Строка {i + 1} пропущена (долгота не число): {line}");
                continue;
            }	    
	    
            result.Add(new Person
            {
                Name = parts[0],
                Age = age,
                City = parts[2],
                Latitude = latitude,  
                Longitude = longitude, 
                Notice = parts[5]
            });
         }
         return result.ToArray();
        }
	
	/// <summary>
	/// Записывает массив Person в CSV-файл формата "имя;возраст;город;широта;долгота;заметка".
	/// </summary>
	public static void SavePeople(string filePath, Person[] people)
	{
	    var lines = new List<string>(people.Length + 1);

	    // Заголовок (опционально — можно убрать, если он не нужен)
	    lines.Add("Name;Age;City;Latitude;Longitude;Notice");

	    foreach (var p in people)
	    {
		// Важно: если в полях есть ';', они сломают CSV.
		// Поэтому экранируем — заменяем ';' на ',' или оборачиваем в кавычки.
		var name   = (p.Name   ?? "").Replace(';', ',');
		var city   = (p.City   ?? "").Replace(';', ',');
		var notice = (p.Notice ?? "").Replace(';', ',');

		var line = string.Join(';',
		    name,
		    p.Age,
		    city,
		    p.Latitude,
		    p.Longitude,
		    notice);

		lines.Add(line);
	    }

	    File.WriteAllLines(filePath, lines);
	    Console.WriteLine($"[CsvLoader] Сохранено {people.Length} записей в {filePath}");
        }
}
