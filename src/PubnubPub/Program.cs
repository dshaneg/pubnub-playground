using System;
using System.Configuration;
using System.Threading;
using DummyDomain;
using PubnubMessaging;
using PubNubMessaging.Core;

namespace PubnubPub
{
    public class Program
    {
        public static void Main()
        {
            var pubKey = ConfigurationManager.AppSettings["pubKey"];
            var subKey = ConfigurationManager.AppSettings["subKey"];
            var channel = ConfigurationManager.AppSettings["channel"]; 
            
            var pubnub = new Pubnub(pubKey, subKey);
            var publisher = new Publisher(pubnub, channel);

            var senderName = _GetSenderName();

            for (var i = 0; i < 300; i++)
            {
                var header = new Header(Guid.NewGuid().ToString("N"), Pubnub.TranslateDateTimeToPubnubUnixNanoSeconds(DateTime.UtcNow));
                var body = new DummyEvent(string.Format("{0}_{1}", senderName, i), i, DateTime.Now);

                publisher.Publish(new Message<DummyEvent>(header, body));
                Thread.Sleep(1000);
            }

            Console.WriteLine("Done. <Enter> to continue.");
            Console.ReadLine();
        }

        private static string _GetSenderName()
        {
            Console.Write("Enter your name to begin publishing. Default is \"{0}\". > ", Environment.MachineName);
            var senderName = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(senderName))
                senderName = Environment.MachineName;

            return senderName;
        }
    }
}
