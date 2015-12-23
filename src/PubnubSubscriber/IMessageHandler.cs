using PubnubMessaging;

namespace PubnubSubscriber
{
    public interface IMessageHandler<T>
    {
        void Handle(Message<T> message);
    }
}
