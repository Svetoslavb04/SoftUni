using BasicWebServer.Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    public class Program
    {
        public static void Main()
        {
            var ipAddress = "127.0.0.1";
            var port = 8080;

            var server = new HttpServer(ipAddress, port);
            server.Start();
        }
    }
}