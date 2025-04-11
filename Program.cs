using MonitoringServiceAlvaCleanCRM.Repository;
using MonitoringServiceAlvaCleanCRM.Repository.Interfaces;
using RabbitMQ.Client.Events;

namespace MonitoringServiceAlvaCleanCRM
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var consumer = new ConsumerRepository();

            await consumer.PrintMessageFromQueue();
        }
    }
}
