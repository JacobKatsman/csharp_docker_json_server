namespace JsonWebServer3.classes;

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? City { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public string? Notice { get; set; }
    
    public override string ToString() => $"{Name} ({Age}) — {City} - {Latitude} - {Longitude} ";
}
