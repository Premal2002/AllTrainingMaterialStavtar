--9.Write a query to get the highest invoice amount for each vendor. Select the vendor code , vendor long name. order the result by invoice amount.
-- =============================================
-- sOLUTION
-- =============================================
WITH MaxInvoiceAmounts AS (
    SELECT 
        i.VendorId,
        MAX(i.InvoiceAmount) AS MaxInvoiceAmount
    FROM 
        Invoice i
    GROUP BY 
        i.VendorId
)
SELECT 
    v.VendorCode,
    v.VendorLongName,
    m.MaxInvoiceAmount
FROM 
    MaxInvoiceAmounts m
    INNER JOIN Vendor v ON m.VendorId = v.VendorId
ORDER BY 
    m.MaxInvoiceAmount DESC;