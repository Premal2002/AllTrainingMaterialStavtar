using System.Xml.Linq;

namespace VendorManagementAPI
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorLongName { get; set; }
        public string VendorCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public DateTime VendorCreatedOn { get; set; }
        public bool IsActive { get; set; }

        #region Vendor List Data
        public static List<Vendor> vendorList = new List<Vendor>()
        {
            new Vendor(){ VendorId = 1, VendorCode = "prem123", VendorLongName = "Premal", VendorPhoneNumber = "9768342809", VendorEmail = "prem@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
            new Vendor(){ VendorId = 2, VendorCode = "sandip123", VendorLongName = "Sandip", VendorPhoneNumber = "8857584585", VendorEmail = "sandip@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
            new Vendor(){ VendorId = 3, VendorCode = "saurabh123", VendorLongName = "Saurabh", VendorPhoneNumber = "9987854852", VendorEmail = "saurabh@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        };
        #endregion

        static public int autoVendorId { get; set; }

        #region Methods

        public List<Vendor> GetAllVendors()
        {
            if(vendorList.Count == 0)
            {
                throw new Exception("Vendor List is empty!!!");
            }
            return vendorList;
        }

        public string AddVendor(Vendor vendor)
        {
            #region Auto generated vendor Id

            autoVendorId = vendorList.Count + 1;
            #endregion
            vendor.VendorId = autoVendorId++;

            #region Validations
            if (string.IsNullOrWhiteSpace(vendor.VendorLongName))
            {
                throw new Exception("Name cannot be blank!!!");
            }
            else if (vendor.VendorLongName.Any(char.IsDigit))
            {
                throw new Exception("Name cannot contain numbers!!!");
            }

            if (string.IsNullOrWhiteSpace(vendor.VendorCode))
            {
                throw new Exception("Vendor code cannot be blank!!!");
            }
            else if (vendorList.Any(v => v.VendorCode == vendor.VendorCode))
            {
                throw new Exception("Vendor already present!!!");
            }

            if (string.IsNullOrWhiteSpace(vendor.VendorPhoneNumber))
            {
                throw new Exception("Phone Number cannot be blank!!!");
            }
            else if (vendor.VendorPhoneNumber.Length != 10 || !vendor.VendorPhoneNumber.All(char.IsDigit))
            {
                throw new Exception("Phone number should be 10 digits number only");
            }

            if (string.IsNullOrWhiteSpace(vendor.VendorEmail))
            {
                throw new Exception("Email cannot be blank!!!");
            }

            vendor.VendorCreatedOn = DateTime.Now;

            vendor.IsActive = true;
            #endregion

            vendorList.Add(vendor);
            return "Vendor Added Successfully";
        }

        public string UpdateVendor(string vCode,Vendor vendor)
        {
            var tempVendor = (from v in vendorList
                              where v.VendorCode == vCode
                              select v).SingleOrDefault();
            if (tempVendor != null)
            {
                #region Validations
                if (string.IsNullOrWhiteSpace(vendor.VendorLongName))
                {
                    throw new Exception("Name cannot be blank!!!");
                }
                else if (vendor.VendorLongName.Any(char.IsDigit))
                {
                    throw new Exception("Name cannot contain numbers!!!");
                }

                if (string.IsNullOrWhiteSpace(vendor.VendorPhoneNumber))
                {
                    throw new Exception("Phone Number cannot be blank!!!");
                }
                else if (vendor.VendorPhoneNumber.Length != 10 || !vendor.VendorPhoneNumber.All(char.IsDigit))
                {
                    throw new Exception("Phone number should be 10 digits number only");
                }

                if (string.IsNullOrWhiteSpace(vendor.VendorEmail))
                {
                    throw new Exception("Email cannot be blank!!!");
                }


                #endregion

                tempVendor.VendorLongName = vendor.VendorLongName;
                tempVendor.VendorEmail = vendor.VendorEmail;
                tempVendor.VendorPhoneNumber = vendor.VendorPhoneNumber;
                tempVendor.IsActive = vendor.IsActive;
                return "Vendor Updated Successfully";
            }
            throw new Exception("Vendor with vendor code " + vCode + " is not present");

        }

        public string DeleteVendor(string vCode)
        {
            Vendor tempVendor = (from v in vendorList
                                 where v.VendorCode == vCode
                                 select v).FirstOrDefault();

            
            if (tempVendor != null)
            {
                if (Invoice.invoiceList.Any(i => i.VendorId == tempVendor.VendorId))
                {
                    throw new Exception("This vendor has invoices pending. First clear those invoices then try to remove this vendor!!!");
                }
                vendorList.Remove(tempVendor);
                return "Vedor removed successfully";

            }
            throw new Exception("Vendor with vendor code " + vCode + " is not present");
        }

        public string ExportVendorList()
        {
            FileStream file = new FileStream("vendorList.csv", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("vendorId, VendorName, VendorCode, VendorPhoneNumber, VendorEmail, IsVendorActive");
            if (vendorList.Count() > 0)
            {
                foreach (var item in vendorList)
                {
                    writer.WriteLine($"{item.VendorId},{item.VendorLongName},{item.VendorCode},{item.VendorPhoneNumber},{item.VendorEmail},{item.IsActive}");
                }
            }
            writer.Close();
            file.Close();
            return "Vendor List Exported Successfully";
        }
        #endregion


    }
}


//throw new Exception(