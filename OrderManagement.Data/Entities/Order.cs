namespace OrderManagement.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }

        public int CustomerId { get; set; }
    }
}
