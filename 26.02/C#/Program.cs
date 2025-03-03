using lesson_24_02.Model;
using lesson_24_02.Service;
using System.Text.Json;
using WebSocketSharp.Server;

namespace lesson_24_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            var server = new WebSocketServer("ws://localhost:7890");
            server.AddWebSocketService<ChatClient>("/chat");

            server.Start();

            Console.WriteLine("Server has started");
            Console.ReadKey();
            server.Stop();
            Console.WriteLine("Server has stoped");
            Console.ReadKey();
        }
    }
}