using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmqDemo.Client
{
    public interface IRabbitMQClient
    {
        ModelWrapper PullModel();
    }
}
