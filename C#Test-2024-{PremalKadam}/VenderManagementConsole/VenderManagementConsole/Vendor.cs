using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenderManagementConsole
{
    internal class Vendor
    {
        public int VendorId { get; set; }
        public string VendorLongName { get; set; }
        public string VendorCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public DateTime VendorCreatedOn { get; set; }
        public bool IsActive { get; set; }

        #region methods
        public string AddVendor(Vendor vendor,List<Vendor> vendorList)
        {
            //Checking if this particular vendor is already there in list
            
            vendorList.Add(vendor);
            return "Vendor Added Successfully";
           
        }


        public string DeleteVendor(string vCode, List<Vendor> vendorList,List<Invoice> invoiceList)
        {

            Vendor tempVendor = (from v in vendorList
                                 where v.VendorCode == vCode
                                 select v).FirstOrDefault();

            if (tempVendor != null)
            {
                if(invoiceList.Any(i => i.VendorId == tempVendor.VendorId))
                {
                    throw new Exception("This vendor has invoices pending. First clear those invoices then try to remove this vendor!!!");
                }
                vendorList.Remove(tempVendor);
                return "Vedor removed successfully";
                
            }
            throw new Exception("Vendor with vendor code " + vCode + " is not present");
        }
        #endregion

    }
}
