using BasicWebServer.Server;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    public class StartUp
    {
        public static void Main()
        {
            var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from my simple server"))
            );
            server.Start();
        }
    }
}