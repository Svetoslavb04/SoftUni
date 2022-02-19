using BasicWebServer.Server;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Demo
{
    public class StartUp
    {
        public static async Task Main() 
            => await new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from my simple server")))
        .Start();
    }
}