--5.write a query to get the vendors whose invoice is never created in system
-- =============================================
-- sOLUTION
-- =============================================

SELECT 
    Vendor.VendorId,
    Vendor.VendorLongName,
    Vendor.VendorCode,
    Vendor.VendorPhoneNumber,
    Vendor.VendorEmail,
    Vendor.VendorCreatedOn,
    Vendor.IsActive
FROM 
    Vendor
    LEFT JOIN Invoice ON Vendor.VendorId = Invoice.VendorId
WHERE 
    Invoice.VendorId IS NULL;