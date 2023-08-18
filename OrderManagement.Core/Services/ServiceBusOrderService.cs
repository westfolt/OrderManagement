using Azure.Messaging.ServiceBus;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Models.Messages;
using System.Text.Json;

namespace OrderManagement.Core.Services
{
    public class ServiceBusOrderService : IServiceBusService<OrderCreatedMessage>
    {
        private readonly ServiceBusSender _sender;

        public ServiceBusOrderService(ServiceBusSender sender)
        {
            _sender = sender;
        }

        public async Task SendMessageAsync(OrderCreatedMessage message)
        {
            string messageContent = JsonSerializer.Serialize(message);
            ServiceBusMessage busMessage = new ServiceBusMessage(messageContent);
            await _sender.SendMessageAsync(busMessage);
        }
    }
}
