using ChatLib.Messages;
using System.Collections.ObjectModel;

namespace ChatLib.Chats
{
    public interface IChat
    {
        ObservableCollection<IMessage> GetHistory();
        void SendMessage(string username, string content);
        void Start();
    }
}
