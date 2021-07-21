using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MessangerBackend.MessagesHubs
{
    public class MessageHub : Hub
    {
        public Task SendMessage(string username, string content)
        {
            return Clients.Others.SendAsync("ReceiveMessage", username, content);
        }
    }
}
