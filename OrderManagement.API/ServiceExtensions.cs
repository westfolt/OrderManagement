using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Contracts;
using OrderManagement.Core.Models.Requests;
using OrderManagement.Core.Services;
using OrderManagement.Core.Validation;
using OrderManagement.Data;
using OrderManagement.Data.Contracts;
using OrderManagement.Data.Repositories;

namespace OrderManagement.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services) =>
            services.AddDbContext<OrderManagementDbContext>(opts =>
                opts.UseInMemoryDatabase("OrderManagementDb"));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureCustomerService(this IServiceCollection services) =>
            services.AddScoped<ICustomerService, CustomerService>();

        public static void ConfigureOrderService(this IServiceCollection services) =>
            services.AddScoped<IOrderService, OrderService>();

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();
            services.AddScoped<IValidator<CreateOrderRequest>, CreateOrdRequestValidator>();
        }
    }
}
