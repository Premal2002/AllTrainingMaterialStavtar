// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using VenderManagementConsole;

List<Vendor> vendorList = new List<Vendor>();
List<Invoice> invoiceList = new List<Invoice>();
List<Currency> currencyList = new List<Currency>();

#region Auto generated vendor Id
int autoVendorId;

if (vendorList.Count == 0)
{
    autoVendorId = 1;
}
else
{
    int maxId = vendorList.Max().VendorId;
    autoVendorId = maxId + 1;
}
#endregion

#region Auto generated Invoice Id
int autoInvoiceId;

if (invoiceList.Count == 0)
{
    autoInvoiceId = 1;
}
else
{
    int maxId = invoiceList.Max().InvoiceId;
    autoInvoiceId = maxId + 1;
}
#endregion

#region Auto generated Currency Id
int autoCurrencyId;

if (currencyList.Count == 0)
{
    autoCurrencyId = 1;
}
else
{
    int maxId = currencyList.Max().CurrencyId;
    autoCurrencyId = maxId + 1;
}
#endregion



//Invoice invoice = new Invoice();
//Currency currency = new Currency();

bool doOperation = true;
int operationChoice;
bool breakInBetween = false;
try
{
    while (doOperation)
    {
        int internalChoice;
        Console.Clear();
        Console.WriteLine("Welcome to Vendor Management System");
        Console.WriteLine("1.Add");
        Console.WriteLine("2.Delete");
        Console.WriteLine("3.Get List of invoices");
        Console.WriteLine("4.Get List of invoices by vendor code");
        Console.WriteLine("5.Get Count invoices by vendor");
        Console.WriteLine("6.Get List of vendors");
        Console.WriteLine("7.Get List of currency");
        Console.WriteLine("8.Store Vendor List in Excel File");
        Console.WriteLine("9.Store Invoice List in Excel");
        Console.WriteLine("10.Exit");
        Console.WriteLine("--------------------------------------------------");
        operationChoice = Convert.ToInt32(Console.ReadLine());
        #region Outer Switch Case
        switch (operationChoice)
        {
            #region Case1 (Add vendor/Invoice/Currency)
            case 1:
                Console.WriteLine("Choose Entity to add");
                Console.WriteLine("1.Vendor");
                Console.WriteLine("2.Invoice");
                Console.WriteLine("3.Currency");
                internalChoice = Convert.ToInt32(Console.ReadLine());
                #region Internal Switch
                switch (internalChoice)
                {
                    #region Case1 (Add vendor)
                    case 1:
                        try
                        {
                            Vendor vendor = new Vendor();

                            vendor.VendorId = autoVendorId++;

                            Console.Write("Please enter the Vendor Name: ");
                            while (true)
                            {
                                string vName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(vName))
                                {
                                    Console.WriteLine("Name cannot be blank!!!");
                                    Console.WriteLine("Enter Your name again");
                                }
                                else if (vName.Any(char.IsDigit))
                                {
                                    Console.WriteLine("Name cannot contain numbers!!!");
                                    Console.WriteLine("Enter Your name again");
                                }
                                else
                                {
                                    vendor.VendorLongName = vName;
                                    break;
                                }
                            }

                            Console.Write("Please enter the Vendor Code: ");
                            while (true)
                            {
                                string vCode = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(vCode))
                                {
                                    Console.WriteLine("Vendor code cannot be blank!!!");
                                    Console.WriteLine("Enter vendor code again");
                                }
                                else if (vendorList.Any(v => v.VendorCode == vCode))
                                {
                                    Console.WriteLine("Vendor already present.");
                                    Console.WriteLine("Enter different vendor code");
                                }
                                else
                                {
                                    vendor.VendorCode = vCode;
                                    break;
                                }
                            }

                            Console.Write("Please enter the Vendor Phone Number: ");
                            while (true)
                            {
                                string vPhone = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(vPhone))
                                {
                                    Console.WriteLine("Phone Number cannot be blank!!!");
                                    Console.WriteLine("Enter Phone Number again");
                                }
                                else if (vPhone.Length != 10 || !vPhone.All(char.IsDigit))
                                {
                                    Console.WriteLine("Phone number should be 10 digits number only");
                                    Console.WriteLine("Enter Phone Number again");
                                }
                                else
                                {
                                    vendor.VendorPhoneNumber = vPhone;
                                    break;
                                }
                            }

                            Console.Write("Please enter the Vendor Email: ");
                            while (true)
                            {
                                string vEmail = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(vEmail))
                                {
                                    Console.WriteLine("Email cannot be blank!!!");
                                    Console.WriteLine("Enter Your email again");
                                }
                                else
                                {
                                    vendor.VendorEmail = vEmail;
                                    break;
                                }
                            }

                            vendor.VendorCreatedOn = DateTime.Now;

                            vendor.IsActive = true;

                            Console.WriteLine(vendor.AddVendor(vendor, vendorList));
                            Console.ReadLine();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    #region Case 2 (Add Invoice)
                    case 2:
                        try
                        {
                            Invoice invoice = new Invoice();

                            invoice.InvoiceId = autoInvoiceId++;

                            Console.WriteLine("Enter Invoice Number : ");
                            while (true)
                            {
                                int iNumber;
                                if (!int.TryParse(Console.ReadLine(), out iNumber))
                                {
                                    Console.WriteLine("Please enter numbers only!!!");
                                    Console.WriteLine("Enter Invoice Number again");
                                }
                                else if (invoiceList.Any(v => v.InvoiceNumber == iNumber))
                                {
                                    Console.WriteLine("Vendor already present.");
                                    Console.WriteLine("Enter different vendor code");
                                }
                                else
                                {
                                    invoice.InvoiceNumber = iNumber;
                                    break;
                                }
                            }

                            Console.WriteLine("Enter Invoice Currency Id : ");
                            while (true)
                            {
                                int iCurrId;
                                if (!int.TryParse(Console.ReadLine(), out iCurrId))
                                {
                                    Console.WriteLine("Please enter numbers only!!!");
                                    Console.WriteLine("Enter Currency Id again");
                                }
                                else if (!currencyList.Any(c => c.CurrencyId == iCurrId))
                                {
                                    Console.WriteLine("Currency with this id is not present!!!");
                                    Console.WriteLine("Please add currency with this id first or enter different currency Id : ");
                                    Console.WriteLine("Do you want to exit(y/n) : ");
                                    string ch = Console.ReadLine();
                                    if (ch.Equals("y") || ch.Equals("Y"))
                                    {
                                        breakInBetween = true;
                                        break;
                                    }
                                    Console.WriteLine("Enter Currency Id again : ");
                                }
                                else
                                {
                                    invoice.InvoiceCurrencyId = iCurrId;
                                    break;
                                }
                            }
                            if (breakInBetween)
                            {
                                breakInBetween = false;
                                break;
                            }

                            Console.WriteLine("Enter vendor id : ");
                            while (true)
                            {
                                int iVendorId;
                                if (!int.TryParse(Console.ReadLine(), out iVendorId))
                                {
                                    Console.WriteLine("Please enter numbers only!!!");
                                    Console.WriteLine("Enter Vendor Id again");
                                }
                                else if (!vendorList.Any(v => v.VendorId == iVendorId))
                                {
                                    Console.WriteLine("Vendor with this id is not present!!!");
                                    Console.WriteLine("Please add Vendor with this id first or enter different vendor Id : ");
                                    Console.WriteLine("Do you want to exit(y/n) : ");
                                    string ch = Console.ReadLine();
                                    if (ch.Equals("y") || ch.Equals("Y"))
                                    {
                                        breakInBetween = true;
                                        break;
                                    }
                                    Console.WriteLine("Enter Vendor Id again : ");
                                }
                                else
                                {
                                    invoice.VendorId = iVendorId;
                                    break;
                                }
                            }
                            if (breakInBetween)
                            {
                                breakInBetween = false;
                                break;
                            }

                            Console.WriteLine("Enter invoice amount : ");
                            while (true)
                            {
                                int iAmount;
                                if (!int.TryParse(Console.ReadLine(), out iAmount))
                                {
                                    Console.WriteLine("Please enter numbers only!!!");
                                    Console.WriteLine("Enter Invoice Amount again");
                                }
                                else
                                {
                                    invoice.InvoiceAmount = iAmount;
                                    break;
                                }
                            }

                            invoice.InvoiceReceivedDate = DateTime.Now;

                            Console.WriteLine("Enter Invoice due date : ");
                            while (true)
                            {
                                DateTime iDueDate;
                                if (!DateTime.TryParse(Console.ReadLine(), out iDueDate))
                                {
                                    Console.WriteLine("Please enter valid date!!!");
                                    Console.WriteLine("Enter Invoice Due Date again");
                                }
                                else if (iDueDate < DateTime.Now)
                                {
                                    Console.WriteLine("Please enter valid date!!!");
                                    Console.WriteLine("Enter Invoice Due Date again");
                                }
                                else
                                {
                                    invoice.InvoiceDueDate = iDueDate;
                                    break;
                                }
                            }

                            invoice.IsActive = true;

                            Console.WriteLine(invoice.AddInvoice(invoice, invoiceList));
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    #region Case 3 (Add Currency)
                    case 3:
                        try
                        {
                            Currency currency = new Currency();

                            currency.CurrencyId = autoCurrencyId++;

                            Console.WriteLine("Enter Currency Code :");
                            while (true)
                            {
                                string cCode = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(cCode))
                                {
                                    Console.WriteLine("Currency code cannot be blank!!!");
                                    Console.WriteLine("Enter Currency code again");
                                }
                                else if (currencyList.Any(c => c.CurrencyCode == cCode))
                                {
                                    Console.WriteLine("Currency already present.");
                                    Console.WriteLine("Do you want to try with different one(y/n) : ");
                                    string ch = Console.ReadLine();
                                    if (ch.Equals("n") || ch.Equals("N"))
                                    {
                                        breakInBetween = true;
                                        break;
                                    }
                                    Console.WriteLine("Enter Currency Code again : ");
                                }
                                else if (cCode.Length != 3 || cCode.Any(char.IsDigit))
                                {
                                    Console.WriteLine("Currency code should be three characters long.");
                                }
                                else
                                {
                                    currency.CurrencyCode = cCode.ToUpper();
                                    break;
                                }
                            }
                            if (breakInBetween)
                            {
                                breakInBetween = false;
                                break;
                            }

                            Console.WriteLine("Enter Currency Name :");
                            while (true)
                            {
                                string cName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(cName))
                                {
                                    Console.WriteLine("Currency name cannot be blank!!!");
                                    Console.WriteLine("Enter Currency name again");
                                }
                                else if (cName.Length < 4)
                                {
                                    Console.WriteLine("Currency name should be atleast 4 charcters long!!!");
                                    Console.WriteLine("Enter Currency name again");
                                }

                                else
                                {
                                    currency.CurrencyName = cName;
                                    break;
                                }
                            }

                            Console.WriteLine(currency.AddCurrency(currency, currencyList));
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    default:
                        Console.WriteLine("You have entered wrong choice try again!!!(Press Enter)");
                        Console.ReadLine();
                        break;

                }
                #endregion
                break;
            #endregion
            #region Case 2 (Delete vendor/Invoice/Currency)
            case 2:
                Console.WriteLine("Choose Entity to delete");
                Console.WriteLine("1.Vendor");
                Console.WriteLine("2.Invoice");
                Console.WriteLine("3.Currency");
                internalChoice = Convert.ToInt32(Console.ReadLine());
                #region Internal SwitchCase
                switch (internalChoice)
                {
                    #region Case 1 (Delete Vendor)
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter vedor Code to delete");
                            string vendorCode = Console.ReadLine();
                            Vendor vendor = new Vendor();
                            Console.WriteLine(vendor.DeleteVendor(vendorCode, vendorList, invoiceList));
                            Console.ReadLine();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    #region Case 2 (Delete Invoice)
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Invoice Number to delete");
                            int invoiceNumber = Convert.ToInt32(Console.ReadLine());
                            Invoice invoice = new Invoice();
                            invoice.DeleteInvoice(invoiceNumber, invoiceList);
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    #region Case 3(Delete Currency)
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Currency Code to delete");
                            string currencyCode = Console.ReadLine();
                            Currency currency = new Currency();
                            currency.DeleteCurrency(currencyCode, currencyList,invoiceList);
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        break;
                    #endregion
                    default:
                        Console.WriteLine("You have entered wrong choice try again!!!(Press Enter)");
                        Console.ReadLine();
                        break;
                }
                #endregion
                break;
            #endregion
            #region Case 3 (List of all Invoices)
            case 3:
                try
                {
                    if (invoiceList.Count() == 0)
                    {
                        throw new Exception("Invoice List is Empty");
                    }
                    else
                    {
                        Console.WriteLine("List of Invoices : ");
                        foreach (Invoice item in invoiceList)
                        {
                            Console.WriteLine("InvoiceId = {0}, Invoice Number = {1}, Invoice Currency Id = {2}, Vendor Id = {3}, Invoice Amount = {4},Invoice Received Date = {5}, Invoice Due Date = {6}, Is Invoice Active = {7}", item.InvoiceId, item.InvoiceNumber, item.InvoiceCurrencyId, item.VendorId, item.InvoiceAmount, item.InvoiceReceivedDate, item.InvoiceDueDate, item.IsActive);
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 4 (Invoice List By Vendor Code)
            case 4:
                try
                {
                    if (invoiceList.Count() == 0)
                    {
                        throw new Exception("Invoice List is Empty");
                    }
                    else
                    {
                        Console.WriteLine("Enter Vendor Code to retrive Invoice List");
                        string vCode = Console.ReadLine();

                        Console.WriteLine("List of Invoices By vendor Code : ");
                        List<Invoice> list = (from i in invoiceList
                                              where i.VendorId == (vendorList.Find(v => v.VendorCode == vCode).VendorId)
                                              select i).ToList();
                        if (list.Count > 0)
                        {
                            foreach (Invoice item in list)
                            {
                                Console.WriteLine("test");
                                Console.WriteLine("InvoiceId = {0}, Invoice Number = {1}, Invoice Currency Id = {2}, Vendor Id = {3}, Invoice Amount = {4},Invoice Received Date = {5}, Invoice Due Date = {6}, Is Invoice Active = {7}", item.InvoiceId, item.InvoiceNumber, item.InvoiceCurrencyId, item.VendorId, item.InvoiceAmount, item.InvoiceReceivedDate, item.InvoiceDueDate, item.IsActive);
                            }
                            Console.ReadLine();
                        }
                        else
                        {
                            throw new Exception("No invoices found for vendor with code " + vCode);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 5 (Invoice count by vendor)
            case 5:
                try
                {
                    Console.WriteLine("Invoices Count By Vendor");
                    var list = invoiceList.GroupBy(i => i.VendorId).Select(g => new { VendorId = g.Key, Count = g.Count() });
                    foreach (var item in list)
                    {
                        Console.WriteLine("Vendor Id = {0}, Invoice Count = {1}", item.VendorId, item.Count);
                    }
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            #endregion
            #region Case 6 (List of Vendors)
            case 6:
                try
                {
                    if (vendorList.Count() == 0)
                    {
                        throw new Exception("Vendor List is Empty");
                    }
                    else
                    {
                        Console.WriteLine("List of Vendors : ");
                        foreach (Vendor item in vendorList)
                        {
                            Console.WriteLine("vendorId = {0}, VendorName = {1}, VendorCode = {2}, VendorPhoneNumber = {3}, VendorEmail = {4}, IsVendorActive = {5}", item.VendorId, item.VendorLongName, item.VendorCode, item.VendorPhoneNumber, item.VendorEmail, item.IsActive);
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 7 (List of Curruncy)
            case 7:
                try
                {
                    if (currencyList.Count() == 0)
                    {
                        throw new Exception("Currency List is Empty");
                    }
                    else
                    {
                        Console.WriteLine("List of Currency : ");
                        foreach (Currency item in currencyList)
                        {
                            Console.WriteLine("Currency Id = {0}, Currency Name = {1}, Currency code = {2}", item.CurrencyId, item.CurrencyName, item.CurrencyCode);
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 8 Export vendor List
            case 8:
                try
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
                    Console.WriteLine("Vendor List Exported Successfully");
                    writer.Close();
                    file.Close();
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 9 Export Invoice List
            case 9:
                try
                {
                    FileStream file = new FileStream("invoiceList.csv", FileMode.Create, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(file);

                    writer.WriteLine("InvoiceId, Invoice Number, Invoice Currency Id, Vendor Id, Vendor Name, Invoice Amount,Invoice Received Date, Invoice Due Date, Is Invoice Active");
                    if (invoiceList.Count() > 0)
                    {
                        foreach (var item in invoiceList)
                        {
                            writer.WriteLine($"{item.InvoiceId},{item.InvoiceNumber},{item.InvoiceCurrencyId},{item.VendorId},{vendorList.Find(v => v.VendorId == item.VendorId).VendorLongName},{item.InvoiceAmount},{item.InvoiceReceivedDate},{item.InvoiceDueDate},{item.IsActive}");
                        }
                    }

                    Console.WriteLine("Vendor List Exported Successfully");
                    writer.Close();
                    file.Close();
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                break;
            #endregion
            #region Case 10 Exit 
            case 10:
                Console.WriteLine("Thank you for interacting");
                doOperation = false;
                break;
            #endregion
            default:
                Console.WriteLine("Please enter valid choice");
                Console.ReadLine();
                break;
        }
        #endregion
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

//#region Check string fields are black or not
////Method to check string fields are empty or not
//bool checkNullEmpty(string data)
//{
//    if (string.IsNullOrWhiteSpace(data))
//    {
//        return true;
//    }
//    return false;
//}

//#endregion
