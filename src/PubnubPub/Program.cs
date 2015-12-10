using System;
using System.Configuration;
using System.Threading;
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
                publisher.Publish(string.Format("Message {0} from {1} at {2}.", i, senderName, DateTime.UtcNow));
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

    public class Publisher
    {
        private readonly Pubnub _pubnub;
        private readonly string _channel;

        public Publisher(Pubnub pubnub, string channel)
        {
            _pubnub = pubnub;
            _channel = channel;
        }

        public void Publish(string message)
        {
            _pubnub.Publish<string>(
                _channel,
                message,
                _DisplayReturnMessage,
                _DisplayErrorMessage);
        }

        private static void _DisplayReturnMessage(string result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        private static void _DisplayErrorMessage(PubnubClientError pubnubError)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(pubnubError.ToString());
            Console.ResetColor();
        }
    }
}
