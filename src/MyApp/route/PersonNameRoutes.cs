using JsonWebServer3.classes;   
namespace JsonWebServer3.route;

public static class PersonNameRoutes
{
    public static WebApplication MapPersonNameRoutes(this WebApplication app, Person[] people)
    {
      app.MapGet("/api/person/all", () =>
      {
	 return Results.Ok(people);
      });

      return app;
    }
}
