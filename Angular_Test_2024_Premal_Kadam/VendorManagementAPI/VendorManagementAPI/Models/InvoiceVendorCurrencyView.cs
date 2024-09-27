namespace VendorManagementAPI.Models
{
    public class InvoiceVendorCurrencyView
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorLongName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime InvoiceReceivedDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool IsActive { get; set; }
    }
}
