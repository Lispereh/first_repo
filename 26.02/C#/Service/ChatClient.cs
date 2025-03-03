using WebSocketSharp.Server;
using WebSocketSharp;
using lesson_24_02.Model;

namespace lesson_24_02.Service
{
    // Client
    public class ChatClient : WebSocketBehavior
    {
        public ChatUser User { get; set; }
        protected override void OnOpen()
        {
            // string id
            // Sessions
            // Send()

            Console.WriteLine($"Client connected {ID}");
            Send(ServiceMessageGenerator.GenOpened(ID));
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            ChatMessage messageSentByUSer = MessageJSONService.Deserialize(e.Data.ToString());

            if (User == null)
            {
                SetUser(messageSentByUSer.Message);
                Send(ServiceMessageGenerator.GenConnected(User));

                Sessions.Broadcast(ServiceMessageGenerator.GenEntered(User.Name));
                return;

            }
            Console.WriteLine($"{ID}: {e.Data}");

            messageSentByUSer.User = User;
            messageSentByUSer.Time = DateTime.Now;
            messageSentByUSer.Type = ChatMessageType.User;

            Sessions.Broadcast(MessageJSONService.Serialize(messageSentByUSer));
        }

        protected override void OnClose(CloseEventArgs e)
        {
            if (User == null) return;
            Console.WriteLine(ServiceMessageGenerator.GenLeft(User.Name));
        }

        private void SetUser(string name)
        {
            User = new ChatUser()
            {
                Name = name,
                Id = ID
            };
        }
    }
}