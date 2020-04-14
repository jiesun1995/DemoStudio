using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmqDemo.Core
{
    public class EventBusRepeatException : Exception
    {
        public EventBusRepeatException(string message) : base(message)
        {
        }
    }
}
