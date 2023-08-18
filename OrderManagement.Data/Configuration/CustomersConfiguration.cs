using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Data.Entities;

namespace OrderManagement.Data.Configuration
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@example.com",
                    Phone = "234-567-8901"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob.smith@example.com",
                    Phone = "345-678-9012"
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    Phone = "456-789-0123"
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Email = "charlie.brown@example.com",
                    Phone = "567-890-1234"
                }
            );
        }
    }
}
