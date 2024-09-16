using System.Text.Json.Serialization;

namespace OrderManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore] public Customer Customer { get; set; }

        //One-to-one : An order has one invoice
        public Invoice Invoice { get; set; }

        //Many-to-Many : An order can have multiple products
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
