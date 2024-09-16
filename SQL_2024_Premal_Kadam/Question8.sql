--8.Write a query to get the vendor long name , invoice number , currency code , total invoice amount by invoice currency ,  order the result by vendor code.
-- =============================================
-- sOLUTION
-- =============================================
SELECT 
    v.VendorLongName,
    i.InvoiceNumber,
    c.CurrencyCode,
    SUM(i.InvoiceAmount) AS TotalInvoiceAmount
FROM 
    Invoice i
    INNER JOIN Vendor v ON i.VendorId = v.VendorId
    INNER JOIN Currency c ON i.InvoiceCurrencyId = c.CurrencyId
GROUP BY 
    v.VendorLongName,
    i.InvoiceNumber,
    c.CurrencyCode,
    v.VendorCode
ORDER BY 
    v.VendorCode;
