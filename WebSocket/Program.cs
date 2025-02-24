using System.Runtime.CompilerServices;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace lesson_24_02
{
    // Client
    public class ChatClient : WebSocketBehavior
    {
        private string _name;
        protected override void OnOpen()
        {
            // string id
            // Sessions
            // Send()

            Console.WriteLine($"Client connected {ID}");
            Send($"You are connected. Your ID is {ID}. Enter your name: ");

        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if(_name == "" || _name == null)
            {
                _name = e.Data.ToString();
                Sessions.Broadcast($"{_name} entered the chat");
                return;

            }
            Console.WriteLine($"{ID}: {e.Data}");
            Sessions.Broadcast($"{_name}: {e.Data}");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine($"{_name}: left the chat");
        }
    }

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