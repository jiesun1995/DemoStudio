using System.Collections.Generic;
using System.Threading.Tasks;

namespace rabbitmqDemo.Core
{
    public interface IConsumerContainer
    {
        Task Notice(byte[] bytes);
        Task Notice(List<byte[]> list);
    }
    public interface IConsumer
    {
        Task Notice(byte[] bytes);
        Task Notice(List<byte[]> list);
    }
}