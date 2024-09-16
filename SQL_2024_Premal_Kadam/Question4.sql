USE InvoiceTrackingDB;
GO

--4.write a query to get the sum of amount for year 2023 and 2024 , show InvoiceId , TotalAmount , Year  and currenycode in result
-- =============================================
-- sOLUTION
-- =============================================

SELECT 
    SUM(Invoice.InvoiceAmount) AS TotalAmount,
    YEAR(Invoice.InvoiceReceivedDate) AS Year,
    Currency.CurrencyCode
FROM 
    Invoice
    INNER JOIN Currency ON Invoice.InvoiceCurrencyId = Currency.CurrencyId
WHERE 
    YEAR(Invoice.InvoiceReceivedDate) IN (2023, 2024)
GROUP BY 
    YEAR(Invoice.InvoiceReceivedDate),
    Currency.CurrencyCode
ORDER BY 
    Year DESC