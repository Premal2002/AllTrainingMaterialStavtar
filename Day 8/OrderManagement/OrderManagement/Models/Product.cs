using System.Text.Json.Serialization;

namespace OrderManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Many-to-Many: A Product can be in many Orders
        [JsonIgnore]public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
