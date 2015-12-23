using System;
using System.Configuration;
using PubNubMessaging.Core;

namespace PubnubSub
{
    public class Program
    {
        public static void Main()
        {
            var subKey = ConfigurationManager.AppSettings["subKey"];
            var channel = ConfigurationManager.AppSettings["channel"];

            var pubnub = new Pubnub(string.Empty, subKey);
            var handler = new Handler();

            var subscriber = new Subscriber(pubnub, channel);

            subscriber.Start();

            Console.WriteLine("Listening. <Enter> to quit.");
            Console.ReadLine();

            subscriber.Stop();

            Console.WriteLine("Unsubscribed.");
            Console.ReadLine();
        }
    }
}
