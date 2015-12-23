using System;
using PubnubMessaging;
using PubNubMessaging.Core;

namespace PubnubPub
{
    public class Publisher
    {
        private readonly Pubnub _pubnub;
        private readonly string _channel;

        public Publisher(Pubnub pubnub, string channel)
        {
            _pubnub = pubnub;
            _channel = channel;
        }

        public void Publish<T>(Message<T> message)
        {
            _pubnub.Publish<string>(
                _channel,
                message,
                _DisplayReturnMessage,
                _DisplayErrorMessage);
        }

        private static void _DisplayReturnMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
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