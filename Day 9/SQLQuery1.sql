use ECommerceDB2;
Go

--CREATE TABLE Customers (
--    CustomerID INT PRIMARY KEY IDENTITY(1,1),
--    FirstName NVARCHAR(50),
--    LastName NVARCHAR(50),
--    Email NVARCHAR(100),
--    CreatedDate DATETIME DEFAULT GETDATE()
--);

--go

--CREATE TABLE Products (
--    ProductID INT PRIMARY KEY IDENTITY(1,1),
--    ProductName NVARCHAR(100),
--    Price DECIMAL(10,2)
--);
--go

--CREATE TABLE Orders (
--    OrderID INT PRIMARY KEY IDENTITY(1,1),
--    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
--    OrderDate DATETIME DEFAULT GETDATE()
--);
--go

--CREATE TABLE OrderDetails (
--    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
--    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
--    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
--    Quantity INT,
--    TotalPrice	DECIMAL(18,2)
--);
--go

--CREATING TRIGGER TO CALCULATE TOTAL PRICE
--CREATE TRIGGER trg_UpdateTotalPrice
--ON OrderDetails
--AFTER INSERT,UPDATE
--AS
--BEGIN
--	UPDATE od
--	SET TotalPrice = i.Quantity * p.Price
--	FROM OrderDetails AS od
--	JOIN inserted AS i ON od.OrderDetailID = i.OrderDetailID
--    JOIN Products AS p ON i.ProductID = p.ProductID
--END;



-------------------------------------------------------------------------------------------------------------------------------------

---- Insert Customers
--INSERT INTO Customers (FirstName, LastName, Email)
--VALUES ('John', 'Doe', 'john.doe@example.com'),
--       ('Jane', 'Smith', 'jane.smith@example.com'),
--       ('Alice', 'Johnson', 'alice.johnson@example.com');

---- Insert more customers
--INSERT INTO Customers (FirstName, LastName, Email, CreatedDate)
--VALUES 
--    ('Alice', 'Williams', 'alice.williams@example.com', GETDATE()),
--    ('David', 'Wilson', 'david.wilson@example.com', GETDATE()),
--    ('Sophia', 'Taylor', 'sophia.taylor@example.com', GETDATE()),
--    ('James', 'Anderson', 'james.anderson@example.com', GETDATE()),
--    ('Olivia', 'Thomas', 'olivia.thomas@example.com', GETDATE());


---- Insert Products
--INSERT INTO Products (ProductName, Price)
--VALUES ('Laptop', 1000.00),
--       ('Smartphone', 500.00),
--       ('Headphones', 150.00);

-- Insert more products
--INSERT INTO Products (ProductName, Price)
--VALUES 
--    ('Tablet', 299.99),
--    ('Smartwatch', 199.99),
--    ('Webcam', 79.99),
--    ('External Hard Drive', 129.99),
--    ('Router', 89.99);


---- Insert Orders
--INSERT INTO Orders (CustomerID)
--VALUES (1), (2), (3);

-- Insert more orders
--INSERT INTO Orders (CustomerID)
--VALUES 
--	(4),
--    (5),  -- Order for Olivia Thomas
--    (6),  -- Order for Alice Williams
--    (7),  -- Order for David Wilson
--    (8);  -- Order for Sophia Taylor
    


---- Insert Order Details
--INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
--VALUES (1, 1, 2),  -- John bought 2 Laptops
--       (2, 2, 1),  -- Jane bought 1 Smartphone
--       (3, 3, 3);  -- Alice bought 3 Headphones

-- Insert more order details
--INSERT INTO OrderDetails (OrderID, ProductID, Quantity, TotalPrice)
--VALUES 
--    (19, 1, 2, 1999.98),  -- Olivia Thomas's order for 2 Laptops
--    (19, 4, 1, 199.99),   -- Olivia Thomas's order for 1 Monitor
--    (20, 2, 1, 499.99),   -- Alice Williams's order for 1 Smartphone
--    (20, 5, 2, 99.98),    -- Alice Williams's order for 2 Keyboards
--    (21, 3, 1, 89.99),    -- David Wilson's order for 1 Headphones
--    (21, 8, 1, 199.99),   -- David Wilson's order for 1 Smartwatch
--    (22, 4, 1, 199.99),   -- Sophia Taylor's order for 1 Monitor
--    (22, 6, 1, 299.99);   -- Sophia Taylor's order for 1 Tablet
    



----------------------------------------------------------------------------------------------------------------

--STORED PROCEDURES 

--create procedure getOrdersByCustomer
--	@CustomerID int
--as
--begin
--	select o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.TotalPrice
--	from dbo.Orders o
--	join dbo.OrderDetails od on o.OrderID = od.OrderID
--	join dbo.Products p on od.ProductID = p.ProductID
--	where o.CustomerID = @CustomerID;
--end;
--go

--CREATE PROCEDURE AddProduct
--    @ProductName NVARCHAR(100),
--    @Price DECIMAL(10,2)
--AS
--BEGIN
--    INSERT INTO dbo.Products (ProductName, Price)
--    VALUES (@ProductName, @Price);
--END;
--GO

--CREATE PROCEDURE PlaceOrder
--    @CustomerID INT,
--    @ProductID INT,
--    @Quantity INT
--AS
--BEGIN
--    DECLARE @OrderID INT;
    
--    -- Insert into Orders
--    INSERT INTO dbo.Orders (CustomerID) VALUES (@CustomerID);
--    SET @OrderID = SCOPE_IDENTITY();
    
--    -- Insert into OrderDetails
--    INSERT INTO dbo.OrderDetails (OrderID, ProductID, Quantity)
--    VALUES (@OrderID, @ProductID, @Quantity);
--END;
--GO


---------------------------------------------------------------------------------------

-- Altering table schema
-- Update Customers table to include City and Country
--ALTER TABLE Customers
--ADD City NVARCHAR(100), 
--Country NVARCHAR(100);

-- Update Products table to include Category
--ALTER TABLE Products
--ADD Category NVARCHAR(100);

-- Update Orders table to include OrderStatus
--ALTER TABLE Orders
--ADD OrderStatus NVARCHAR(50);


------------------------------------------------------------------------------------

--ADDING DATA TO NEW COLUMNS

-- Update existing Customers with City and Country data
--UPDATE Customers
--SET City = 'New York', Country = 'USA'
--WHERE CustomerID = 1;

--UPDATE Customers
--SET City = 'London', Country = 'UK'
--WHERE CustomerID = 2;

--UPDATE Customers
--SET City = 'Paris', Country = 'France'
--WHERE CustomerID = 3;


-- Update existing Products with Category data
--UPDATE Products
--SET Category = 'Electronics'
--WHERE ProductID = 1; -- Laptop

--UPDATE Products
--SET Category = 'Electronics'
--WHERE ProductID = 2; -- Smartphone

--UPDATE Products
--SET Category = 'Accessories'
--WHERE ProductID = 3; -- Headphones


-- Update existing Orders with OrderStatus
--UPDATE Orders
--SET OrderStatus = 'Completed'
--WHERE OrderID = 1;
--ALTERNATE USING CASE WHEN
--UPDATE Customers
--SET 
--    City = CASE 
--        WHEN CustomerID = 1 THEN 'New York'
--        WHEN CustomerID = 2 THEN 'London'
--        WHEN CustomerID = 3 THEN 'Paris'
--        ELSE City -- Keeps the existing value if no match
--    END,
--    Country = CASE 
--        WHEN CustomerID = 1 THEN 'USA'
--        WHEN CustomerID = 2 THEN 'UK'
--        WHEN CustomerID = 3 THEN 'France'
--        ELSE Country -- Keeps the existing value if no match
--    END;



--UPDATE Orders
--SET OrderStatus = 'Shipped'
--WHERE OrderID = 2;

--UPDATE Orders
--SET OrderStatus = 'Processing'
--WHERE OrderID = 3;

--***************************

-- Update City and Country for Customers using CASE
--UPDATE Customers
--SET
--    City = CASE 
--        WHEN CustomerID = 4 THEN 'New York'
--        WHEN CustomerID = 5 THEN 'San Francisco'
--        WHEN CustomerID = 6 THEN 'Los Angeles'
--        WHEN CustomerID = 7 THEN 'Chicago'
--        WHEN CustomerID = 8 THEN 'Boston'
--        ELSE City -- Keeps the existing value if no match
--    END,
--    Country = CASE 
--        WHEN CustomerID = 4 THEN 'USA'
--        WHEN CustomerID = 5 THEN 'USA'
--        WHEN CustomerID = 6 THEN 'USA'
--        WHEN CustomerID = 7 THEN 'USA'
--        WHEN CustomerID = 8 THEN 'USA'
--        ELSE Country -- Keeps the existing value if no match
--    END
--WHERE
--    City IS NULL OR Country IS NULL;


-- Update OrderStatus for Orders using CASE
--UPDATE Orders
--SET
--    OrderStatus = CASE 
--        WHEN OrderID = 19 THEN 'Processing'
--        WHEN OrderID = 20 THEN 'Shipped'
--        WHEN OrderID = 21 THEN 'Completed'
--        WHEN OrderID = 22 THEN 'Cancelled'
--        WHEN OrderID = 23 THEN 'On Hold'
--        ELSE OrderStatus -- Keeps the existing value if no match
--    END
--WHERE
--    OrderStatus IS NULL;


-- Update Category for Products using CASE
--UPDATE Products
--SET
--    Category = CASE 
--        WHEN ProductID = 4 THEN 'Electronics'
--        WHEN ProductID = 5 THEN 'Wearables'
--        WHEN ProductID = 6 THEN 'Accessories'
--        WHEN ProductID = 7 THEN 'Storage'
--        WHEN ProductID = 8 THEN 'Networking'
--        ELSE Category -- Keeps the existing value if no match
--    END
--WHERE
--    Category IS NULL;


----------------------------------------------------------------------

--Group by queries example

--Group Orders by Customers City and Order Status
--select c.City,o.OrderStatus, count(o.OrderID) as TotalOrders
--from Customers c
--join Orders o on c.CustomerID = o.CustomerID
--group by c.City, o.OrderStatus;

--Group Products by Category and Summarize Sales by Category
----SELECT P.Category, SUM(OD.Quantity) AS TotalQuantitySold, SUM(OD.TotalPrice) AS TotalSales
----FROM Products P
----JOIN OrderDetails OD ON P.ProductID = OD.ProductID
----GROUP BY P.Category;

----------------------------------------------------------------------------

--delete from dbo.Products where ProductID = 8;

declare @pID int;
set @pID = 8;

delete from OrderDetails where ProductID = @pID;

delete from Products where ProductID = @pID