namespace JsonWebServer3.classes;

public class MapData
{
    public int Rows { get; }
    public int Cols { get; }
    public int[][] MapCart { get; }   // ← зубчатый

    public MapData(int[][] map)
    {
        MapCart = map;
        Rows = map.Length;
        Cols = map[0].Length;
    }
}
