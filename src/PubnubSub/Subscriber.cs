using System;
using PubNubMessaging.Core;

namespace PubnubSub
{
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