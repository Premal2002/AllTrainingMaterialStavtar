USE InvoiceTrackingDB;
GO

--3.Write a query to get 

--InvoiceId,

--InoviceNumber ,

--InvoiceAmount  (Should be in comma separated format) ,

--DueDate ( should be in ‘Jan 04 , 2021’ format )  ,

--DaysDiffrerence     

--where difference between CurrentDate and DueDate is more than 30 days.

-- =============================================
-- sOLUTION
-- =============================================

SELECT 
	InvoiceId,
	InvoiceNumber,
	FORMAT(InvoiceAmount, 'N2'),
	FORMAT(InvoiceDueDate, 'MMMM dd, yyyy'),
	DateDiff(day,GETDATE(),InvoiceDueDate) as DaysDifference
	from Invoice
	where DateDiff(day,GETDATE(),InvoiceDueDate) > 30;
