namespace PubnubMessaging
{
    public class Message<T>
    {
        public Message(Header header, T body)
        {
            Header = header;
            Body = body;
        }

        public Header Header { get; private set; }

        public T Body { get; private set; }
    }
}
