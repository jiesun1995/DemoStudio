using System.Threading.Tasks;

namespace rabbitmqDemo.Core
{
    public interface IRabbitEventBusContainer : IConsumerContainer
    {
        Task AutoRegister();
        RabbitEventBus CreateEventBus(string exchange, string routePrefix, int lBCount = 1, bool autoAck = false, bool reenqueue = false, bool persistent = false);
        RabbitEventBus CreateEventBus<MainGrain>(string routePrefix, string queue, int lBCount = 1, bool autoAck = false, bool reenqueue = false, bool persistent = false);
        Task Work(RabbitEventBus bus);
    }
}