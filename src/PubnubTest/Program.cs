using System;
using PubNubMessaging.Core;

namespace PubnubTest
{
    public class Program
    {
        private const string PublishKey = "";
        private const string SubscribeKey = "sub-c-41ba554e-7f1d-11e5-a4dc-0619f8945a4f";


        public static void Main()
        {
            var pubnub = new Pubnub(PublishKey, SubscribeKey);

            const string channel = "poc-1";

            var subscriber = new Subscriber(pubnub, channel);

            subscriber.Subscribe();

            Console.WriteLine("Done. <Enter> to continue.");
            Console.ReadLine();
        }
    }

    public class Subscriber
    {
        private readonly Pubnub _pubnub;
        private readonly string _channel;

        public Subscriber(Pubnub pubnub, string channel)
        {
            _pubnub = pubnub;
            _channel = channel;
        }

        public void Subscribe()
        {
            _pubnub.Subscribe<string>(
                _channel,
                _DisplaySubscribeReturnMessage,
                _DisplaySubscribeConnectStatusMessage,
                _DisplayErrorMessage);
        }

        private static void _DisplaySubscribeReturnMessage(string result)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        private static void _DisplaySubscribeConnectStatusMessage(string result)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        private static void _DisplayErrorMessage(PubnubClientError pubnubError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(pubnubError.ToString());
            Console.ResetColor();
        }
    }
}
