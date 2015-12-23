using System;

namespace PubnubMessaging
{
    public class Header
    {
        public Header(string messageId, long posixTimeStamp)
        {
            if (messageId == null) throw new ArgumentNullException("messageId");

            MessageId = messageId;
            PosixTimeStamp = posixTimeStamp;
        }

        public string MessageId { get; private set; }

        public long PosixTimeStamp { get; private set; }
    }
}
