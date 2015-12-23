using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DummyDomain;
using PubnubMessaging;
using PubnubSubscriber;

namespace PubnubSub
{
    public class Handler : IMessageHandler<DummyEvent>
    {
        public void Handle(Message<DummyEvent> message)
        {
            Console.WriteLine(message.Body.Name);
        }
    }
}
