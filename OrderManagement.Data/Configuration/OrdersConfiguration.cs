using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Configuration
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
            (
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2023, 1, 15),
                    OrderNumber = "1001",
                    Status = OrderStatus.Created,
                    CustomerId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2023, 2, 20),
                    OrderNumber = "1002",
                    Status = OrderStatus.Processing,
                    CustomerId = 1
                },
                new Order
                {
                    Id = 3,
                    OrderDate = new DateTime(2023, 3, 25),
                    OrderNumber = "1003",
                    Status = OrderStatus.Shipped,
                    CustomerId = 4
                },
                new Order
                {
                    Id = 4,
                    OrderDate = new DateTime(2023, 4, 30),
                    OrderNumber = "1004",
                    Status = OrderStatus.Completed,
                    CustomerId = 4
                },
                new Order
                {
                    Id = 5,
                    OrderDate = new DateTime(2023, 5, 5),
                    OrderNumber = "1005",
                    Status = OrderStatus.Cancelled,
                    CustomerId = 1
                },
                new Order
                {
                    Id = 6,
                    OrderDate = new DateTime(2023, 1, 15),
                    OrderNumber = "1006",
                    Status = OrderStatus.Created,
                    CustomerId = 2
                },
                new Order
                {
                    Id = 7,
                    OrderDate = new DateTime(2023, 2, 20),
                    OrderNumber = "1007",
                    Status = OrderStatus.Processing,
                    CustomerId = 2
                },
                new Order
                {
                    Id = 8,
                    OrderDate = new DateTime(2023, 3, 25),
                    OrderNumber = "1008",
                    Status = OrderStatus.Shipped,
                    CustomerId = 2
                },
                new Order
                {
                    Id = 9,
                    OrderDate = new DateTime(2023, 4, 30),
                    OrderNumber = "1009",
                    Status = OrderStatus.Completed,
                    CustomerId = 5
                },
                new Order
                {
                    Id = 10,
                    OrderDate = new DateTime(2023, 5, 5),
                    OrderNumber = "1010",
                    Status = OrderStatus.Cancelled,
                    CustomerId = 2
                },
                new Order
                {
                    Id = 11,
                    OrderDate = new DateTime(2023, 1, 15),
                    OrderNumber = "1011",
                    Status = OrderStatus.Created,
                    CustomerId = 3
                },
                new Order
                {
                    Id = 12,
                    OrderDate = new DateTime(2023, 2, 20),
                    OrderNumber = "1012",
                    Status = OrderStatus.Processing,
                    CustomerId = 3
                },
                new Order
                {
                    Id = 13,
                    OrderDate = new DateTime(2023, 3, 25),
                    OrderNumber = "1013",
                    Status = OrderStatus.Shipped,
                    CustomerId = 5
                },
                new Order
                {
                    Id = 14,
                    OrderDate = new DateTime(2023, 4, 30),
                    OrderNumber = "1014",
                    Status = OrderStatus.Completed,
                    CustomerId = 3
                },
                new Order
                {
                    Id = 15,
                    OrderDate = new DateTime(2023, 5, 5),
                    OrderNumber = "1015",
                    Status = OrderStatus.Cancelled,
                    CustomerId = 5
                }
            );
        }
    }
}
