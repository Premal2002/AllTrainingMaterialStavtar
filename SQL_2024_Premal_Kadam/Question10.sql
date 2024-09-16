--10. Write a query to create temporary table and select the vendor long name , vendor code , invoice number , invoice received date , invoice currency code

 CREATE TABLE #TempVendorInvoiceData (
    VendorLongName NVARCHAR(255),
    VendorCode NVARCHAR(50),
    InvoiceNumber INT,
    InvoiceReceivedDate DATETIME,
    CurrencyCode NVARCHAR(10)
);

INSERT INTO #TempVendorInvoiceData (VendorLongName, VendorCode, InvoiceNumber, InvoiceReceivedDate, CurrencyCode)
SELECT 
    v.VendorLongName,
    v.VendorCode,
    i.InvoiceNumber,
    i.InvoiceReceivedDate,
    c.CurrencyCode
FROM 
    Invoice i
    INNER JOIN Vendor v ON i.VendorId = v.VendorId
    INNER JOIN Currency c ON i.InvoiceCurrencyId = c.CurrencyId;

SELECT * FROM #TempVendorInvoiceData;

DROP TABLE #TempVendorInvoiceData;