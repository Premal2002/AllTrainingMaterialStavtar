using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VendorManagementAPI
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceCurrencyId { get; set; }
        public int VendorId { get; set; }
        public double InvoiceAmount { get; set; }
        public DateTime InvoiceReceivedDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool IsActive { get; set; }

        public static List<Invoice> invoiceList = new List<Invoice>()
        {
            new Invoice(){InvoiceId = 1, InvoiceNumber = 12345678, InvoiceCurrencyId = 1, VendorId = 1, InvoiceAmount = 500, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("12-09-2024"), IsActive = true},
            new Invoice(){InvoiceId = 2, InvoiceNumber = 12345679, InvoiceCurrencyId = 4, VendorId = 2, InvoiceAmount = 750, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("15-09-2024"), IsActive = true},
            new Invoice(){InvoiceId = 3, InvoiceNumber = 12345680, InvoiceCurrencyId = 2, VendorId = 3, InvoiceAmount = 1000, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("18-09-2024"), IsActive = true},
            new Invoice(){InvoiceId = 4, InvoiceNumber = 12345681, InvoiceCurrencyId = 1, VendorId = 1, InvoiceAmount = 1250, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("20-09-2024"), IsActive = true},
            new Invoice(){InvoiceId = 5, InvoiceNumber = 12345682, InvoiceCurrencyId = 5, VendorId = 2, InvoiceAmount = 1500, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("22-09-2024"), IsActive = true},
        };

        static public int autoInvoiceId { get; set; }


        #region Methods

        public List<Invoice> GetAllInvoices()
        {
            if (invoiceList.Count == 0)
            {
                throw new Exception("Vendor List is empty!!!");
            }
            return invoiceList;
        }

        public string AddInvoice(Invoice invoice)
        {
            #region Auto generated invoice Id

            autoInvoiceId = invoiceList.Count + 1;
            #endregion

            invoice.InvoiceId = autoInvoiceId;

            #region Validations

            if (invoiceList.Any(v => v.InvoiceNumber == invoice.InvoiceNumber))
            {
                throw new Exception("Vendor already present.");
            }

            if (!Currency.currencyList.Any(c => c.CurrencyId == invoice.InvoiceCurrencyId))
            {
                throw new Exception("Currency with this id is not present!!!");   
            }

            if (!Vendor.vendorList.Any(v => v.VendorId == invoice.VendorId))
            {
                throw new Exception("Vendor with this id is not present!!!");
            }

            if (invoice.InvoiceDueDate < DateTime.Now)
            {
                throw new Exception("Please enter valid date!!!");
            }
            #endregion

            invoiceList.Add(invoice);
            return "Invoice added successfully";
        }

        public string UpdateInvoice(int iNumber,Invoice invoice)
        {
            var tempInvoice = (from i in invoiceList
                               where i.InvoiceNumber == iNumber 
                               select i).SingleOrDefault();

            if (tempInvoice != null)
            {

                if (invoice.InvoiceDueDate < DateTime.Now)
                {
                    throw new Exception("Please enter valid date!!!");
                }

                tempInvoice.InvoiceDueDate = invoice.InvoiceDueDate;
                tempInvoice.InvoiceAmount = invoice.InvoiceAmount;
                tempInvoice.IsActive = invoice.IsActive;
                return "Invoice Updated successfully";
            }
            throw new Exception("Invoice with invoice number " + iNumber + " is not present");

        }

        public string DeleteInvoice(int iNumber)
        {
            Invoice tempInvoice = (from i in invoiceList
                                 where i.InvoiceNumber == iNumber
                                 select i).FirstOrDefault();

            if (tempInvoice != null)
            {
                invoiceList.Remove(tempInvoice);
                return "Invoice removed successfully";

            }
            throw new Exception("Invoice with invoice number " + iNumber + " is not present");
        }

        public List<Invoice> GetInvoicesByVendorCode(string vCode)
        {
            if (invoiceList.Count() == 0)
            {
                throw new Exception("Invoice List is Empty");
            }
            else
            {
                List<Invoice> list = (from i in invoiceList
                                      where i.VendorId == (Vendor.vendorList.Find(v => v.VendorCode == vCode).VendorId)
                                      select i).ToList();
                if (list.Count > 0)
                {
                    return list;
                }
                throw new Exception("No invoices found for vendor with code " + vCode);
            }
        }

        public IEnumerable<object> GetInvoiceCountByVendor()
        {
            var list = invoiceList.GroupBy(i => i.VendorId).Select(g => new { VendorId = g.Key, Count = g.Count() });
            if (list == null)
            {
                throw new Exception("Invoice List is Empty");
            }
            return list;
        }

        public string ExportInvoiceList()
        {
            FileStream file = new FileStream("invoiceList.csv", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("InvoiceId, Invoice Number, Invoice Currency Id, Vendor Id, Vendor Name, Invoice Amount,Invoice Received Date, Invoice Due Date, Is Invoice Active");
            if (Invoice.invoiceList.Count() > 0)
            {
                foreach (var item in invoiceList)
                {
                    writer.WriteLine($"{item.InvoiceId},{item.InvoiceNumber},{item.InvoiceCurrencyId},{item.VendorId},{Vendor.vendorList.Find(v => v.VendorId == item.VendorId).VendorLongName},{item.InvoiceAmount},{item.InvoiceReceivedDate},{item.InvoiceDueDate},{item.IsActive}");
                }
            }

            writer.Close();
            file.Close();
            return "Invoice List Exported Successfully";
        }

        #endregion



    }
}


//throw new Exception(