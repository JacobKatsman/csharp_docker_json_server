using JsonWebServer3.classes;   
namespace JsonWebServer3.route;

public static class CartRoutes
{
public static WebApplication MapCartRoutes(this WebApplication app, MapData map)
 {
    app.MapGet("/api/map", () =>
    {
	return Results.Ok(map.MapCart);
    });
    return app;
 }
}



