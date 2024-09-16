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