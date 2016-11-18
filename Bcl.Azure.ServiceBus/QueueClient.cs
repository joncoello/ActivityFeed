using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Azure.ServiceBus
{
    public class QueueClient
    {

        private Queue<object> _queue;

        public QueueClient()
        {
            _queue = new Queue<object>();
        }

        public void Enqueue(object message)
        {
            _queue.Enqueue(message);
        }

        public object Dequeue()
        {
            object returnValue = null;

            if (_queue.Count > 0)
            {
                returnValue = _queue.Dequeue();
            }

            return returnValue;
        }
    }
}
