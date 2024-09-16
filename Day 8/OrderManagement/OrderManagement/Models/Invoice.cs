using System.Text.Json.Serialization;

namespace OrderManagement.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

        // One-to-One: An Invoice is associated with one Order
        public int OrderId { get; set; }
        [JsonIgnore] public Order Order { get; set; }
    }
}
