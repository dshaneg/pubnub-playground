using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubnubPub
{
    [Serializable]
    public class Message
    {
        public string Id { get; set; }

        public DateTime Stamp { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:u} {2}", Id, Stamp, Body);
        }
    }
}
