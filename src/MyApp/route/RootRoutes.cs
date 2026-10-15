using JsonWebServer3.classes;   
namespace JsonWebServer3.route;


public static class RootRoutes
{
    public static WebApplication MapRootRoutes(this WebApplication app)
    {
        app.MapGet("/", () => "Server is running on port 8082");
        return app;
    }
}
