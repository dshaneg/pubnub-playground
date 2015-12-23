using PubnubMessaging;

namespace PubnubSubscriber
{
    public interface ISyncRepository
    {
        void PersistMessage<T>(Message<T> message);

        long GetLatestPersistedTimestamp();
    }
}
