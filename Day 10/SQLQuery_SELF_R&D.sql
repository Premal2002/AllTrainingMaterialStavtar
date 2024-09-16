use ECommerceDB;

-- Creating the tables

--CREATE TABLE Customers (
--    CustomerID INT PRIMARY KEY IDENTITY(1,1),
--    FirstName VARCHAR(50),
--    LastName VARCHAR(50),
--    Email VARCHAR(100),
--    Phone VARCHAR(20),
--    CreatedDate DATETIME
--);

--CREATE TABLE Categories (
--    CategoryID INT PRIMARY KEY IDENTITY(1,1),
--    CategoryName VARCHAR(50)
--);

--CREATE TABLE Products (
--    ProductID INT PRIMARY KEY IDENTITY(1,1),
--    ProductName VARCHAR(100),
--    CategoryID INT,
--    Price DECIMAL(10, 2),
--    StockQuantity INT,
--    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
--);

--CREATE TABLE Orders (
--    OrderID INT PRIMARY KEY IDENTITY(1,1),
--    OrderDate DATETIME,
--    CustomerID INT,
--    TotalAmount DECIMAL(10, 2),
--    OrderStatus VARCHAR(20),
--    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
--);

--CREATE TABLE OrderItems (
--    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
--    OrderID INT,
--    ProductID INT,
--    Quantity INT,
--    UnitPrice DECIMAL(10, 2),
--    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
--    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
--);

--CREATE TABLE Suppliers (
--    SupplierID INT PRIMARY KEY IDENTITY(1,1),
--    SupplierName VARCHAR(100),
--    ContactName VARCHAR(100),
--    Phone VARCHAR(20)
--);

--CREATE TABLE ProductSuppliers (
--    ProductSupplierID INT PRIMARY KEY IDENTITY(1,1),
--    ProductID INT,
--    SupplierID INT,
--    SupplyDate DATETIME,
--    Quantity INT,
--    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
--    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
--);

---- Inserting sample data

---- Customers
--INSERT INTO Customers (FirstName, LastName, Email, Phone, CreatedDate)
--VALUES 
--('John', 'Doe', 'johndoe@example.com', '555-1234', '2024-01-15 08:00:00'),
--('Jane', 'Smith', 'janesmith@example.com', '555-5678', '2024-02-20 09:30:00'),
--('Michael', 'Johnson', 'mjohnson@example.com', '555-8765', '2024-03-10 10:15:00'),
--('Emily', 'Davis', 'edavis@example.com', '555-4321', '2024-04-05 11:45:00'),
--('Daniel', 'Williams', 'dwilliams@example.com', '555-6789', '2024-05-25 12:30:00');

---- Categories
--INSERT INTO Categories (CategoryName)
--VALUES 
--('Electronics'),
--('Books'),
--('Clothing'),
--('Home & Kitchen'),
--('Sports & Outdoors');

---- Products
--INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity)
--VALUES 
--('Smartphone', 1, 699.99, 100),
--('Laptop', 1, 1199.99, 50),
--('Fiction Book', 2, 19.99, 200),
--('Cookware Set', 4, 149.99, 75),
--('Running Shoes', 5, 89.99, 120);

---- Suppliers
--INSERT INTO Suppliers (SupplierName, ContactName, Phone)
--VALUES 
--('TechSupply Co.', 'Alice Brown', '555-1111'),
--('Book Distributors', 'Bob Green', '555-2222'),
--('Clothing Warehouse', 'Charlie Black', '555-3333'),
--('Home Goods Inc.', 'Diana White', '555-4444'),
--('Sports Gear Ltd.', 'Eve Gray', '555-5555');

---- Orders
--INSERT INTO Orders (OrderDate, CustomerID, TotalAmount, OrderStatus)
--VALUES 
--('2024-07-01 14:30:00', 1, 719.98, 'Shipped'),
--('2024-07-05 09:00:00', 2, 149.99, 'Delivered'),
--('2024-07-10 11:45:00', 3, 89.99, 'Processing'),
--('2024-07-15 16:00:00', 4, 19.99, 'Cancelled'),
--('2024-07-20 12:15:00', 5, 1199.99, 'Shipped');

---- OrderItems
--INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice)
--VALUES 
--(1, 1, 1, 699.99),
--(1, 2, 1, 19.99),
--(2, 4, 1, 149.99),
--(3, 5, 1, 89.99),
--(5, 2, 1, 1199.99);

---- ProductSuppliers
--INSERT INTO ProductSuppliers (ProductID, SupplierID, SupplyDate, Quantity)
--VALUES 
--(1, 1, '2024-06-15 10:00:00', 100),
--(2, 1, '2024-06-20 11:00:00', 50),
--(3, 2, '2024-06-25 12:00:00', 200),
--(4, 4, '2024-06-30 13:00:00', 75),
--(5, 5, '2024-07-01 14:00:00', 120);


--------------------------------------------------------------------------------

