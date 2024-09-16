USE InvoiceTrackingDB;
GO

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
	