using ChatLib.Messages;
using ChatLib.Users;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;

namespace ChatLib.Chats
{
    public class Chat : IChat
    {
        private ObservableCollection<IMessage> history;
        private HubConnection hub;

        public Chat()
        {
            history = new ObservableCollection<IMessage>();

            InitHub();
        }
        
        public ObservableCollection<IMessage> GetHistory()
        {
            return history;
        }
        
        public void SendMessage(string username, string content)
        {
            IMessage message = new Message()
            {
                Content = content,
                Sender = new User()
                {
                    Name = "You"
                }
            };

            history.Add(message);
            hub.SendAsync("SendMessage", username, content);
        }
        
        public void Start()
        {
            hub.StartAsync();
        }
        
        private void ReceiveMessage(string username, string content)
        {
            IMessage message = new Message()
            {
                Content = content,
                Sender = new User()
                {
                    Name = username
                }
            };

            history.Add(message);
        }
        
        private void InitHub()
        {
            hub = new HubConnectionBuilder()
                        .WithUrl("https://localhost:44350/chat")
                        .Build();

            hub.On<string, string>("ReceiveMessage", ReceiveMessage);
        }
    }
}
