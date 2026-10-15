namespace JsonWebServer3.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class MapLoader
{
    /// <summary>
    /// Читает карту из файла в зубчатый массив int[][].
    /// Возвращает null, если файл не найден или пуст.
    /// </summary>
    public static MapData? Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"[MapLoader] Файл карты не найден: {filePath}");
            return null;
        }

        var lines = File.ReadAllLines(filePath);
        if (lines.Length == 0)
        {
            Console.WriteLine($"[MapLoader] Файл пуст: {filePath}");
            return null;
        }

        int rows = lines.Length;
        int cols = lines[0].Trim().Length;

        var map = new int[rows][];   // зубчатый массив

        for (int i = 0; i < rows; i++)
        {
            map[i] = new int[cols];
            var line = lines[i].Trim();

            for (int j = 0; j < cols && j < line.Length; j++)
            {
                char c = line[j];
                map[i][j] = (c >= '0' && c <= '9') ? c - '0' : 0;
            }
        }

        return new MapData(map);
    }
}




	
	
