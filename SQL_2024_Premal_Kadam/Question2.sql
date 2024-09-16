USE InvoiceTrackingDB;
GO

--2.Write query to get  

--( VendorLongName  +  VendorCode ) with ‘-‘ as separator  ,

--InvoiceNumber ,

--DueDate (Year) ,

--ReceivedDate (Year),  

--( CurrencyCode  + InvoiceAmount ) with space as separator 

--order by  invoice year DESC

-- =============================================
-- SOLUTION
-- =============================================

SELECT 
    CONCAT(Vendor.VendorLongName, '-', Vendor.VendorCode) AS VendorInfo,

    Invoice.InvoiceNumber,

    YEAR(Invoice.InvoiceDueDate) AS DueDateYear,

    YEAR(Invoice.InvoiceReceivedDate) AS ReceivedDateYear,

    CONCAT(Currency.CurrencyCode, ' ', Invoice.InvoiceAmount) AS CurrencyAndAmount

FROM 
    Invoice
    INNER JOIN Vendor ON Invoice.VendorId = Vendor.VendorId
    INNER JOIN Currency ON Invoice.InvoiceCurrencyId = Currency.CurrencyId

ORDER BY 
    DueDateYear DESC;