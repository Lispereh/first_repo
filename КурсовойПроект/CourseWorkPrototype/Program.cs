using CourseWorkPrototype.Contexts;
using CourseWorkPrototype.Models.DB;
using CourseWorkPrototype.Repositories;
using CourseWorkPrototype.Services;
using WebSocketSharp.Server;

namespace CourseWorkPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ChatDbContext())
            {
                var repository = new ChatRepository(context);
                var server = new WebSocketServer
                            ("ws://localhost:7890");
                server.AddWebSocketService<ChatClient>
                        ("/chat", () => 
                        new ChatClient(repository));

                server.Start();

                Console.WriteLine("Server has started");
                Console.ReadKey();
                server.Stop();
                Console.WriteLine("Server has stoped");
                Console.ReadKey();
            }

            
        }
    }
}