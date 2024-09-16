--7.Write a stored procedure to implement pagination get the list of invoices sorted in invoice amount descending order
-- =============================================
-- sOLUTION
-- =============================================
CREATE PROCEDURE GetPaginatedInvoices
    @PageNumber INT,      
    @PageSize INT        
AS
BEGIN
    IF @PageNumber < 1 SET @PageNumber = 1;
    IF @PageSize < 1 SET @PageSize = 10;
 
    SELECT
        InvoiceId,
        InvoiceNumber,
        VendorId,
        InvoiceCurrencyId,
        InvoiceAmount,
        InvoiceReceivedDate,
        InvoiceDueDate,
        IsActive
    FROM
        Invoice
    ORDER BY
        InvoiceAmount DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
 

EXEC GetPaginatedInvoices @PageNumber = 2, @PageSize = 5;