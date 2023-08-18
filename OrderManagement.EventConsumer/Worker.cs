using Azure.Messaging.ServiceBus;
using OrderManagement.Core.Models.Messages;
using System.Text;
using System.Text.Json;

namespace OrderManagement.EventConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ServiceBusProcessor _processor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public Worker(ServiceBusProcessor processor,
            IHttpClientFactory httpClienFactory,
            IConfiguration configuration)
        {
            _processor = processor;
            _httpClientFactory = httpClienFactory;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync(stoppingToken);
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            var orderCreatedMessage = JsonSerializer.Deserialize<OrderCreatedMessage>(body);

            var httpClient = _httpClientFactory.CreateClient();
            var baseUrl = _configuration.GetValue<string>("ApiUrl");
            var url = new Uri($"{baseUrl}/customers/{orderCreatedMessage.CustomerId}");

            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                // handle error...
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            // process error from sb
            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await _processor.StopProcessingAsync(stoppingToken);
            await base.StopAsync(stoppingToken);
        }
    }

}