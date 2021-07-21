using ChatLib.Users;

namespace ChatLib.Messages
{
    public class Message : IMessage
    {
        public string Content { get; set; }
        public IUser Sender { get; init; }
        
        public override string ToString()
        {
            return $"{Sender.Name}: {Content}";
        }
    }
}
