using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubnubSubscriber
{
    public interface ISubscriberService
    {
        void Start();

        void Stop();
    }
}
