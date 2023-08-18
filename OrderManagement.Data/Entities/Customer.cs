namespace OrderManagement.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int NumberOfConfirmedOrders { get; set; }

        // Navigation property
        public List<Order> Orders { get; set; }
    }
}
