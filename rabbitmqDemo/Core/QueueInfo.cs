using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmqDemo.Core
{
    public class QueueInfo
    {
        public string Queue { get; set; }
        public string RoutingKey { get; set; }
        public override string ToString()
        {
            return $"{Queue}_{RoutingKey}";
        }
    }
}
