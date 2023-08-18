using OrderManagement.Data.Entities;

namespace OrderManagement.Core.Models.Requests
{
    public class CreateOrderRequest
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }
    }
}
