use VendorManageDB;


create view InvoiceVendorCurrencyView as
select 
	 i.InvoiceId,
	 i.InvoiceNumber,
	 i.InvoiceAmount,
	 i.VendorId,
	 v.VendorCode,
	 v.VendorLongName,
	 i.CurrencyId,
	 c.CurrencyCode,
	 i.InvoiceReceivedDate,
	 i.InvoiceDueDate,
	 i.IsActive
 from dbo.Invoice i
 join dbo.Vendor v on i.VendorId = v.VendorId
 join dbo.Currency c on i.CurrencyId = c.CurrencyId;

 select * from InvoiceVendorCurrencyView;