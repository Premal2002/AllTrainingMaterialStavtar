--CREATE DATABASE InvoiceTrackingDB;

USE InvoiceTrackingDB;
GO

---- Table for Vendor
--CREATE TABLE Vendor (
--    VendorId INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment primary key
--    VendorLongName NVARCHAR(255) NOT NULL CHECK(VendorLongName NOT LIKE '%[0-9]%' AND LEN(TRIM(VendorLongName)) > 2),
--    VendorCode NVARCHAR(50) NOT NULL UNIQUE,
--    VendorPhoneNumber CHAR(10) NOT NULL UNIQUE CHECK (ISNUMERIC(VendorPhoneNumber) = 1 AND LEN(VendorPhoneNumber) = 10),
--    VendorEmail NVARCHAR(255) NOT NULL,
--    VendorCreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
--    IsActive BIT NOT NULL DEFAULT 1
--);

---- Table for Currency
--CREATE TABLE Currency (
--    CurrencyId INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment primary key
----    CurrencyName NVARCHAR(100) NOT NULL,
--    CurrencyCode NVARCHAR(10) NOT NULL UNIQUE
--);

---- Table for Invoice
--CREATE TABLE Invoice (
--    InvoiceId INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment primary key
--    InvoiceNumber INT NOT NULL,
--    InvoiceCurrencyId INT NOT NULL,
--    VendorId INT NOT NULL,
--    InvoiceAmount DECIMAL(10, 2) NOT NULL,
--    InvoiceReceivedDate DATETIME NOT NULL,
--    InvoiceDueDate DATETIME NOT NULL,
--    IsActive BIT NOT NULL DEFAULT 1,
--    FOREIGN KEY (InvoiceCurrencyId) REFERENCES Currency(CurrencyId),
--    FOREIGN KEY (VendorId) REFERENCES Vendor(VendorId),
	 
--    CHECK (DATEDIFF(day, InvoiceReceivedDate, InvoiceDueDate) > 1)
--);

--drop table Invoice;
--drop table Vendor;

--delete from Vendor;
--delete from Invoice;

--INSERT INTO Vendor (VendorLongName, VendorCode, VendorPhoneNumber, VendorEmail, VendorCreatedOn, IsActive)
--VALUES ('Acme Corporation', 'ACME123', '1234567890', 'contact@acme.com', GETDATE(), 1);

--INSERT INTO Invoice (
--    InvoiceNumber,
--    InvoiceCurrencyId,
--    VendorId,
--    InvoiceAmount,
--    InvoiceReceivedDate,
--    InvoiceDueDate,
--    IsActive
--)
--VALUES (
--    1001,               -- InvoiceNumber
--    1,                  -- InvoiceCurrencyId (assumes there is a currency with CurrencyId = 1)
--    2,                -- VendorId (assumes there is a vendor with VendorId = 101)
--    500.00,             -- InvoiceAmount
--    '2024-09-03',       -- InvoiceReceivedDate
--    '2024-09-02',       -- InvoiceDueDate
--    1                   -- IsActive (1 = true, assuming this is a flag for active status)
--);


---- Sample data for Vendor
--INSERT INTO Vendor (VendorLongName, VendorCode, VendorPhoneNumber, VendorEmail, VendorCreatedOn, IsActive) VALUES
--('Alpha Corporation', 'ALP001', '1234567890', 'contact@alphacorp.com', GETDATE(), 1),
--('Beta Solutions', 'BET002', '2345678901', 'info@betasolutions.com', GETDATE(), 1),
--('Gamma Enterprises', 'GAM003', '3456789012', 'support@gammaenterprises.com', GETDATE(), 1),
--('Delta Industries', 'DEL004', '4567890123', 'sales@deltaindustries.com', GETDATE(), 1),
--('Epsilon Holdings', 'EPS005', '5678901234', 'admin@epsilonholdings.com', GETDATE(), 1),
--('Zeta Tech', 'ZET006', '6789012345', 'hello@zetatech.com', GETDATE(), 1),
--('Eta Group', 'ETA007', '7890123456', 'contact@etagroup.com', GETDATE(), 1),
--('Theta Corporation', 'THE008', '8901234567', 'info@thetacorp.com', GETDATE(), 1),
--('Iota Partners', 'IOT009', '9012345678', 'support@iotapartners.com', GETDATE(), 1),
--('Kappa Solutions', 'KAP010', '0123456789', 'admin@kappasolutions.com', GETDATE(), 1),
--('Lambda Services', 'LAM011', '1234567891', 'contact@lambdaservices.com', GETDATE(), 1),
--('Mu Enterprises', 'MU012', '2345678902', 'info@muenterprises.com', GETDATE(), 1),
--('Nu Tech', 'NU013', '3456789013', 'support@nutech.com', GETDATE(), 1),
--('Xi Holdings', 'XI014', '4567890124', 'admin@xiholdings.com', GETDATE(), 1),
--('Omicron Corporation', 'OMIC015', '5678901235', 'sales@omicroncorp.com', GETDATE(), 1),
--('Pi Industries', 'PI016', '6789012346', 'contact@piindustries.com', GETDATE(), 1),
--('Rho Solutions', 'RHO017', '7890123457', 'info@rhosolutions.com', GETDATE(), 1),
--('Sigma Partners', 'SIG018', '8901234568', 'support@sigmapartners.com', GETDATE(), 1),
--('Tau Holdings', 'TAU019', '9012345679', 'admin@tauholdings.com', GETDATE(), 1),
--('Upsilon Tech', 'UPS020', '0123456790', 'contact@upsilontech.com', GETDATE(), 1);


---- Sample data for Invoice
--INSERT INTO Invoice (InvoiceNumber, InvoiceCurrencyId, VendorId, InvoiceAmount, InvoiceReceivedDate, InvoiceDueDate, IsActive) VALUES
--(1001, 1, 1, 5200.00, '2023-01-15', '2023-02-15', 1),
--(1002, 2, 2, 4300.00, '2023-01-20', '2023-03-20', 1),
--(1003, 1, 3, 3100.00, '2023-02-05', '2023-04-05', 1),
--(1004, 2, 4, 6200.00, '2023-03-10', '2023-05-10', 1),
--(1005, 1, 5, 2100.00, '2023-04-15', '2023-06-15', 1),
--(1006, 2, 6, 1600.00, '2023-05-20', '2023-07-20', 1),
--(1007, 1, 7, 2600.00, '2023-06-25', '2023-08-25', 1),
--(1008, 2, 8, 3700.00, '2023-07-30', '2023-09-30', 1),
--(1009, 1, 9, 4600.00, '2023-08-15', '2023-10-15', 1),
--(1010, 2, 10, 5700.00, '2023-09-10', '2023-11-10', 1),
--(1011, 1, 1, 4100.00, '2023-10-05', '2023-12-05', 1),
--(1012, 2, 2, 3200.00, '2023-11-10', '2024-01-10', 1),
--(1013, 1, 3, 2100.00, '2023-12-15', '2024-02-15', 1),
--(1014, 2, 4, 5100.00, '2023-12-20', '2024-03-20', 1),
--(1015, 1, 5, 6200.00, '2024-01-10', '2024-04-10', 1),
--(1016, 2, 6, 1200.00, '2024-02-15', '2024-05-15', 1),
--(1017, 1, 7, 3100.00, '2024-03-20', '2024-06-20', 1),
--(1018, 2, 8, 4200.00, '2024-04-25', '2024-07-25', 1),
--(1019, 1, 9, 2300.00, '2024-05-30', '2024-08-30', 1),
--(1020, 2, 10, 3400.00, '2024-06-15', '2024-09-15', 1),
--(1021, 1, 1, 3300.00, '2024-07-20', '2024-10-20', 1),
--(1022, 2, 2, 2700.00, '2024-08-25', '2024-11-25', 1),
--(1023, 1, 3, 4100.00, '2024-09-15', '2024-12-15', 1),
--(1024, 2, 4, 5100.00, '2024-10-10', '2025-01-10', 1),
--(1025, 1, 5, 6000.00, '2024-11-05', '2025-02-05', 1),
--(1026, 2, 6, 1500.00, '2024-12-01', '2025-03-01', 1);



---------------------------------------------------------------------------------------
-- =============================================
-- ALL QUESTIONS SOLUTION BELOW
-- =============================================
------------------------------------------------------------------------------------------------
--1.Create a Stored Procedure to  Insert , Update and Delete the  Vendors and Invoices   ( show proper validation message if there is any dependency while deleting )

--Note : Do not allow special characters like ‘ &%@#$’ while inserting the data using stored procedure

--CREATE PROCEDURE ManageRecords
--    @EntityType CHAR(1), -- 'V' for Vendor, 'I' for Invoice
--    @Operation CHAR(1), -- 'I' for Insert, 'U' for Update, 'D' for Delete
--    @VendorId INT = NULL, 
--    @VendorLongName NVARCHAR(255) = NULL,
--    @VendorCode NVARCHAR(50) = NULL,
--    @VendorPhoneNumber CHAR(10) = NULL,
--    @VendorEmail NVARCHAR(255) = NULL,
--    @VendorCreatedOn DATETIME = NULL,
--    @IsActiveVendor BIT = 1,

--    @InvoiceId INT = NULL, 
--    @InvoiceNumber INT = NULL,
--    @InvoiceCurrencyId INT = NULL,
--    @VendorIdInvoice INT = NULL,
--    @InvoiceAmount FLOAT = NULL,
--    @InvoiceReceivedDate DATETIME = NULL,
--    @InvoiceDueDate DATETIME = NULL,
--    @IsActiveInvoice BIT = 1
--AS
--BEGIN
--    SET NOCOUNT ON;

--    IF @EntityType NOT IN ('V', 'I')
--    BEGIN
--        RAISERROR ('Invalid entity type. Use ''V'' for Vendor or ''I'' for Invoice.', 16, 1);
--        RETURN;
--    END

--    IF @EntityType = 'V'
--    BEGIN
--        IF @VendorLongName LIKE '%[^a-zA-Z0-9 ]%' OR
--           @VendorCode LIKE '%[^a-zA-Z0-9]%' OR
--           @VendorPhoneNumber LIKE '%[^0-9- ]%' OR
--           @VendorEmail LIKE '%[^a-zA-Z0-9.@_]%'
--        BEGIN
--            RAISERROR ('Special characters are not allowed.', 16, 1);
--            RETURN;
--        END

--        IF @Operation = 'I'
--        BEGIN
--            INSERT INTO Vendor (VendorLongName, VendorCode, VendorPhoneNumber, VendorEmail, VendorCreatedOn, IsActive)
--            VALUES (@VendorLongName, @VendorCode, @VendorPhoneNumber, @VendorEmail, ISNULL(@VendorCreatedOn, GETDATE()), @IsActiveVendor);
--        END

--        ELSE IF @Operation = 'U'
--        BEGIN
--            IF @VendorId IS NULL
--            BEGIN
--                RAISERROR ('VendorId is required for update.', 16, 1);
--                RETURN;
--            END

--			IF Not EXISTS (SELECT 1 FROM Vendor WHERE VendorId = @VendorId)
--            BEGIN
--                RAISERROR ('Vendor not exist.', 16, 1);
--                RETURN;
--            END

--            UPDATE Vendor
--            SET VendorLongName = @VendorLongName,
--                VendorCode = @VendorCode,
--                VendorPhoneNumber = @VendorPhoneNumber,
--                VendorEmail = @VendorEmail,
--                VendorCreatedOn = ISNULL(@VendorCreatedOn, VendorCreatedOn),
--                IsActive = @IsActiveVendor
--            WHERE VendorId = @VendorId;
--        END


--        ELSE IF @Operation = 'D'
--        BEGIN
--            IF @VendorId IS NULL
--            BEGIN
--                RAISERROR ('VendorId is required for deletion.', 16, 1);
--                RETURN;
--            END

--			IF Not EXISTS (SELECT 1 FROM Vendor WHERE VendorId = @VendorId)
--            BEGIN
--                RAISERROR ('Vendor not exist.', 16, 1);
--                RETURN;
--            END

--            IF EXISTS (SELECT 1 FROM Invoice WHERE VendorId = @VendorId)
--            BEGIN
--                RAISERROR ('Cannot delete vendor. There are active invoices linked to this vendor.', 16, 1);
--                RETURN;
--            END

--            DELETE FROM Vendor
--            WHERE VendorId = @VendorId;
--        END
--        ELSE
--        BEGIN
--            RAISERROR ('Invalid operation for Vendor. Use ''I'' for Insert, ''U'' for Update, or ''D'' for Delete.', 16, 1);
--        END
--    END

--    ELSE IF @EntityType = 'I'
--    BEGIN

--        IF @Operation = 'I'
--        BEGIN
--            INSERT INTO Invoice (InvoiceNumber, InvoiceCurrencyId, VendorId, InvoiceAmount, InvoiceReceivedDate, InvoiceDueDate, IsActive)
--            VALUES (@InvoiceNumber, @InvoiceCurrencyId, @VendorIdInvoice, @InvoiceAmount, @InvoiceReceivedDate, @InvoiceDueDate, @IsActiveInvoice);
--        END

--        ELSE IF @Operation = 'U'
--        BEGIN
--            IF @InvoiceId IS NULL
--            BEGIN
--                RAISERROR ('InvoiceId is required for update.', 16, 1);
--                RETURN;
--            END
--			IF Not EXISTS (SELECT 1 FROM Invoice WHERE InvoiceId = @InvoiceId)
--            BEGIN
--                RAISERROR ('Invoice not exist.', 16, 1);
--                RETURN;
--            END
--            UPDATE Invoice
--            SET InvoiceNumber = @InvoiceNumber,
--                InvoiceCurrencyId = @InvoiceCurrencyId,
--                VendorId = @VendorIdInvoice,
--                InvoiceAmount = @InvoiceAmount,
--                InvoiceReceivedDate = @InvoiceReceivedDate,
--                InvoiceDueDate = @InvoiceDueDate,
--                IsActive = @IsActiveInvoice
--            WHERE InvoiceId = @InvoiceId;
--        END

--        ELSE IF @Operation = 'D'
--        BEGIN
--            IF @InvoiceId IS NULL
--            BEGIN
--                RAISERROR ('InvoiceId is required for deletion.', 16, 1);
--                RETURN;
--            END
--			IF Not EXISTS (SELECT 1 FROM Invoice WHERE InvoiceId = @InvoiceId)
--            BEGIN
--                RAISERROR ('Invoice not exist.', 16, 1);
--                RETURN;
--            END
--            DELETE FROM Invoice
--            WHERE InvoiceId = @InvoiceId;
--        END
--        ELSE
--        BEGIN
--            RAISERROR ('Invalid operation for Invoice. Use ''I'' for Insert, ''U'' for Update, or ''D'' for Delete.', 16, 1);
--        END
--    END
--END
--GO


-- =============================================
-- Checking sp vendor delete 
-- =============================================
--EXEC ManageRecords
--    @EntityType = 'V',          
--    @Operation = 'D',          
--    @VendorId = 122;  

-- =============================================
-- Checking sp vendor insert
-- =============================================
-- Declare a variable to store the current date
--DECLARE @CurrentDate DATETIME = GETDATE();

---- Insert a new vendor with the current date
--EXEC ManageRecords
--    @EntityType = 'V',
--    @Operation = 'I',
--    @VendorLongName = 'NewTech Solutions',
--    @VendorCode = 'NEW006',
--    @VendorPhoneNumber = '8765432109',
--    @VendorEmail = 'contact@newtech.com',
--    @VendorCreatedOn = @CurrentDate,
--    @IsActiveVendor = 1;

-- =============================================
-- Checking sp vendor update
-- =============================================
--DECLARE @CurrentDate DATETIME = GETDATE();
--EXEC ManageRecords
--    @EntityType = 'V',
--    @Operation = 'U',
--    @VendorId = 1111,
--    @VendorLongName = 'Sunrise Solutions Updated',
--    @VendorCode = 'SUN001',
--    @VendorPhoneNumber = '3216549871',
--    @VendorEmail = 'contact@sunriseupdated.com',
--    @VendorCreatedOn = @CurrentDate,
--    @IsActiveVendor = 1;


-- =============================================
-- Checking sp invoice insert
-- =============================================
	  --EXEC ManageRecords
   -- @EntityType = 'I',                  
   -- @Operation = 'I',                  
   -- @InvoiceNumber = 2001,              
   -- @InvoiceCurrencyId = 1,             
   -- @VendorIdInvoice = 19,             
   -- @InvoiceAmount = 1500.00,           
   -- @InvoiceReceivedDate = '2024-09-09',
   -- @InvoiceDueDate = '2024-10-15',    
   -- @IsActiveInvoice = 1;              
	

------------------------------------------------------------------------------------------------------


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

--SELECT 
--    CONCAT(Vendor.VendorLongName, '-', Vendor.VendorCode) AS VendorInfo,

--    Invoice.InvoiceNumber,

--    YEAR(Invoice.InvoiceDueDate) AS DueDateYear,

--    YEAR(Invoice.InvoiceReceivedDate) AS ReceivedDateYear,

--    CONCAT(Currency.CurrencyCode, ' ', Invoice.InvoiceAmount) AS CurrencyAndAmount

--FROM 
--    Invoice
--    INNER JOIN Vendor ON Invoice.VendorId = Vendor.VendorId
--    INNER JOIN Currency ON Invoice.InvoiceCurrencyId = Currency.CurrencyId

--ORDER BY 
--    DueDateYear DESC;

------------------------------------------------------------------------------------------------------------------

 

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

--SELECT 
--	InvoiceId,
--	InvoiceNumber,
--	FORMAT(InvoiceAmount, 'N2'),
--	FORMAT(InvoiceDueDate, 'MMMM dd, yyyy'),
--	DateDiff(day,GETDATE(),InvoiceDueDate) as DaysDifference
--	from Invoice
--	where DateDiff(day,GETDATE(),InvoiceDueDate) > 30;

	
 
-------------------------------------------------------------------------------------------------------------------------------------

--4.write a query to get the sum of amount for year 2023 and 2024 , show InvoiceId , TotalAmount , Year  and currenycode in result
-- =============================================
-- sOLUTION
-- =============================================

--SELECT 
--    SUM(Invoice.InvoiceAmount) AS TotalAmount,
--    YEAR(Invoice.InvoiceReceivedDate) AS Year,
--    Currency.CurrencyCode
--FROM 
--    Invoice
--    INNER JOIN Currency ON Invoice.InvoiceCurrencyId = Currency.CurrencyId
--WHERE 
--    YEAR(Invoice.InvoiceReceivedDate) IN (2023, 2024)
--GROUP BY 
--    YEAR(Invoice.InvoiceReceivedDate),
--    Currency.CurrencyCode
--ORDER BY 
--    Year DESC

------------------------------------------------------------------------------------------

--5.write a query to get the vendors whose invoice is never created in system
-- =============================================
-- sOLUTION
-- =============================================

--SELECT 
--    Vendor.VendorId,
--    Vendor.VendorLongName,
--    Vendor.VendorCode,
--    Vendor.VendorPhoneNumber,
--    Vendor.VendorEmail,
--    Vendor.VendorCreatedOn,
--    Vendor.IsActive
--FROM 
--    Vendor
--    LEFT JOIN Invoice ON Vendor.VendorId = Invoice.VendorId
--WHERE 
--    Invoice.VendorId IS NULL;
 
----------------------------------------------------------------------------------------------------------
--6.Write the query to get the result order by   and invoice amount , get the query result as follow
-- =============================================
-- sOLUTION
-- =============================================

--WITH OrderedInvoices AS (
--    SELECT 
--        Invoice.VendorId,
--        Vendor.VendorLongName AS Vendor,
--        Invoice.InvoiceAmount AS Amount,
--        ROW_NUMBER() OVER (PARTITION BY Invoice.VendorId ORDER BY Invoice.InvoiceAmount DESC) AS Id
--    FROM 
--        Invoice
--        INNER JOIN Vendor ON Invoice.VendorId = Vendor.VendorId
--)
--SELECT 
--    Id,
--    Vendor,
--    Amount
--FROM 
--    OrderedInvoices
--ORDER BY 
--    Vendor,
--	Id

-------------------------------------------------------------------------------------------------------------------------------------------------------------                  

--7.Write a stored procedure to implement pagination get the list of invoices sorted in invoice amount descending order
-- =============================================
-- sOLUTION
-- =============================================
--CREATE PROCEDURE GetPaginatedInvoices
--    @PageNumber INT,      
--    @PageSize INT        
--AS
--BEGIN
--    IF @PageNumber < 1 SET @PageNumber = 1;
--    IF @PageSize < 1 SET @PageSize = 10;
 
--    SELECT
--        InvoiceId,
--        InvoiceNumber,
--        VendorId,
--        InvoiceCurrencyId,
--        InvoiceAmount,
--        InvoiceReceivedDate,
--        InvoiceDueDate,
--        IsActive
--    FROM
--        Invoice
--    ORDER BY
--        InvoiceAmount DESC
--    OFFSET (@PageNumber - 1) * @PageSize ROWS
--    FETCH NEXT @PageSize ROWS ONLY;
--END
 

--EXEC GetPaginatedInvoices @PageNumber = 2, @PageSize = 5;

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

--8.Write a query to get the vendor long name , invoice number , currency code , total invoice amount by invoice currency ,  order the result by vendor code.
-- =============================================
-- sOLUTION
-- =============================================
--SELECT 
--    v.VendorLongName,
--    i.InvoiceNumber,
--    c.CurrencyCode,
--    SUM(i.InvoiceAmount) AS TotalInvoiceAmount
--FROM 
--    Invoice i
--    INNER JOIN Vendor v ON i.VendorId = v.VendorId
--    INNER JOIN Currency c ON i.InvoiceCurrencyId = c.CurrencyId
--GROUP BY 
--    v.VendorLongName,
--    i.InvoiceNumber,
--    c.CurrencyCode,
--    v.VendorCode
--ORDER BY 
--    v.VendorCode;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--9.Write a query to get the highest invoice amount for each vendor. Select the vendor code , vendor long name. order the result by invoice amount.
-- =============================================
-- sOLUTION
-- =============================================
--WITH MaxInvoiceAmounts AS (
--    SELECT 
--        i.VendorId,
--        MAX(i.InvoiceAmount) AS MaxInvoiceAmount
--    FROM 
--        Invoice i
--    GROUP BY 
--        i.VendorId
--)
--SELECT 
--    v.VendorCode,
--    v.VendorLongName,
--    m.MaxInvoiceAmount
--FROM 
--    MaxInvoiceAmounts m
--    INNER JOIN Vendor v ON m.VendorId = v.VendorId
--ORDER BY 
--    m.MaxInvoiceAmount DESC;

--------------------------------------------------------------------------------------------------------------------------------------------------------------

--10. Write a query to create temporary table and select the vendor long name , vendor code , invoice number , invoice received date , invoice currency code

-- CREATE TABLE #TempVendorInvoiceData (
--    VendorLongName NVARCHAR(255),
--    VendorCode NVARCHAR(50),
--    InvoiceNumber INT,
--    InvoiceReceivedDate DATETIME,
--    CurrencyCode NVARCHAR(10)
--);

--INSERT INTO #TempVendorInvoiceData (VendorLongName, VendorCode, InvoiceNumber, InvoiceReceivedDate, CurrencyCode)
--SELECT 
--    v.VendorLongName,
--    v.VendorCode,
--    i.InvoiceNumber,
--    i.InvoiceReceivedDate,
--    c.CurrencyCode
--FROM 
--    Invoice i
--    INNER JOIN Vendor v ON i.VendorId = v.VendorId
--    INNER JOIN Currency c ON i.InvoiceCurrencyId = c.CurrencyId;

--SELECT * FROM #TempVendorInvoiceData;

--DROP TABLE #TempVendorInvoiceData;