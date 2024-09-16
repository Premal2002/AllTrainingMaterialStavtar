using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenderManagementConsole
{
    internal class Invoice
    {
        public  int InvoiceId { get; set; }
        public  int InvoiceNumber { get; set; }
        public int InvoiceCurrencyId { get; set; }
        public int VendorId { get; set; }
        public double InvoiceAmount { get; set; }
        public DateTime InvoiceReceivedDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool IsActive { get; set; }

        #region methods
        public string AddInvoice(Invoice invoice, List<Invoice> invoiceList)
        {
            //Checking if this particular vendor is already there in list

            invoiceList.Add(invoice);
            return "Invoice Added Successfully";

        }

        public string DeleteInvoice(int iNumber, List<Invoice> invoiceList)
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


        #endregion
    }
}
