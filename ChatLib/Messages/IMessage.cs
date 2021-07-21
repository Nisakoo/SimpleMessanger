using ChatLib.Users;

namespace ChatLib.Messages
{
    public interface IMessage
    {
        string Content { get; set; }
        IUser Sender { get; init; }
    }
}
