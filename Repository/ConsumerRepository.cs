using MonitoringServiceAlvaCleanCRM.Models;
using MonitoringServiceAlvaCleanCRM.Repository.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonitoringServiceAlvaCleanCRM.Repository
{
    public class ConsumerRepository : IConsumerRepository
    {
        public async Task ConsumeMessagesFromQueue(CancellationToken cancellationToken = default)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync("LogIn", durable: false, exclusive: false, autoDelete: false);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var message = JsonSerializer.Deserialize<LogInMessageFromQueue>(json);
                    if (message != null)
                    {
                        MessagesStorage.Add(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[!] Error parsing message: {ex.Message}");
                }

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("LogIn", true, consumer);
            await Task.Delay(Timeout.Infinite, cancellationToken);
        }

        public async Task PrintMessageFromQueue()
        {
            var cts = new CancellationTokenSource();

            _ = Task.Run(() => ConsumeMessagesFromQueue(cts.Token));

            Console.WriteLine("\n Reading Messages...");

            while (true)
            {
                var newMessages = MessagesStorage.GetNewMessages();

                foreach (var msg in newMessages)
                {
                    Console.WriteLine($"User: {msg.FirstName} {msg.LastName} Login at {msg.DateTime}");
                }

                await Task.Delay(5000);
            }
        }
    }
}
