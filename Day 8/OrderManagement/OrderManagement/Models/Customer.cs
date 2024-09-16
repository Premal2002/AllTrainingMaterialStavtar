namespace OrderManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        //One-to-Many : customer can have multiple orders
        public ICollection<Order> Orders { get; set; }
    }
}
