using System;
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

        public void Publish(string message)
        {
            _pubnub.Publish<Message>(
                _channel,
                new Message {Body = message, Id = "blah", Stamp = DateTime.Now},
                _DisplayReturnMessage,
                _DisplayErrorMessage);
        }

        private static void _DisplayReturnMessage(Message result)
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