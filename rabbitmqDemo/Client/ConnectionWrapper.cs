using RabbitMQ.Client;
using rabbitmqDemo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rabbitmqDemo.Client
{
    public class ConnectionWrapper
    {
        private readonly List<ModelWrapper> models = new List<ModelWrapper>();
        private readonly IConnection connection;
        readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
        public ConnectionWrapper(
            IConnection connection,
           RabbitOptions options)
        {
            this.connection = connection;
            Options = options;
        }
        public RabbitOptions Options { get; }
        public (bool success, ModelWrapper model) Get()
        {
            semaphoreSlim.Wait();
            try
            {
                if (models.Count < Options.PoolSizePerConnection)
                {
                    var model = new ModelWrapper(this, connection.CreateModel());
                    models.Add(model);
                    return (true, model);
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
            return (false, default);
        }
        public void Return(ModelWrapper model)
        {
            models.Remove(model);
        }
    }
}
