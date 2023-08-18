using Azure.Messaging.ServiceBus;
using FluentValidation;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Models.Messages;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Core.Services;
using OrderManagement.Core.Validation;
using OrderManagement.Data.Contracts;
using OrderManagement.Data.Repositories;

namespace OrderManagement.EventConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
             .ConfigureServices((hostContext, services) =>
             {
                 var configuration = hostContext.Configuration;
                 services.AddHostedService<Worker>();
                 services.AddSingleton(x =>
                     new ServiceBusClient(configuration["ServiceBus:ConnectionString"]));
                 services.AddSingleton(x =>
                     x.GetRequiredService<ServiceBusClient>().CreateProcessor(configuration["ServiceBus:TopicName"], configuration["ServiceBus:SubscriptionName"]));
                 services.AddSingleton(x =>
                     x.GetRequiredService<ServiceBusClient>().CreateSender(configuration["ServiceBus:TopicName"]));

                 services.AddHttpClient();
             })
             .Build();

            host.Run();
        }
    }
}