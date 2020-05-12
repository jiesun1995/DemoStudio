using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmqDemo.Core
{
    public class EventBusRepeatBindingProducerException : Exception
    {
        public EventBusRepeatBindingProducerException(string name) : base(name)
        {
        }
    }
}
