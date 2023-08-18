using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Models.Messages
{
    public class OrderCreatedMessage
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }
    }
}
