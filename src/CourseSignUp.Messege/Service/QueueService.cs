using System;
using System.Collections;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CourseSignUp.Messege.Interface;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
namespace CourseSignUp.Messege.Service
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _config;

        public QueueService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessageAsync<T>(T servicesBusMessage, string queueName)
        {
            var queueClient = new QueueClient(_config.GetConnectionString("AzureServiceBus"), queueName);
            var messageBody = JsonSerializer.Serialize(servicesBusMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await queueClient.SendAsync(message);
        }
    }
}
