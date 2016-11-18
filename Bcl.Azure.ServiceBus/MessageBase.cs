using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Azure.ServiceBus
{
    public class MessageBase
    {
        public Guid MessageID { get; set; }

        public string TypeName { get; set; }

        public MessageBase()
        {
            MessageID = Guid.NewGuid();
            TypeName = this.GetType().Name;
        }

    }
}
