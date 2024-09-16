--6.Write the query to get the result order by   and invoice amount , get the query result as follow
-- =============================================
-- sOLUTION
-- =============================================

WITH OrderedInvoices AS (
    SELECT 
        Invoice.VendorId,
        Vendor.VendorLongName AS Vendor,
        Invoice.InvoiceAmount AS Amount,
        ROW_NUMBER() OVER (PARTITION BY Invoice.VendorId ORDER BY Invoice.InvoiceAmount DESC) AS Id
    FROM 
        Invoice
        INNER JOIN Vendor ON Invoice.VendorId = Vendor.VendorId
)
SELECT 
    Id,
    Vendor,
    Amount
FROM 
    OrderedInvoices
ORDER BY 
    Vendor,
	Id