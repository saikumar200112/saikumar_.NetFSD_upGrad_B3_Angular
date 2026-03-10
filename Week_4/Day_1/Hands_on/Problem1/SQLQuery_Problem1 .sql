CREATE DATABASE ReStored

USE ReStored

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    StoreID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    Discount DECIMAL(5, 2) DEFAULT 0,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
--Store Data
INSERT INTO Stores VALUES (1, 'Samsung Store');
INSERT INTO Stores VALUES(2, 'Apple Store');

--Products Data
INSERT INTO Products VALUES (101, 'Laptop', 12000.00); 
INSERT INTO Products VALUES (102, 'Mouse', 2500.00);
INSERT INTO Products VALUES(103, 'Monitor', 3000.00);
INSERT INTO Products VALUES(104, 'TAB', 3000.00);

--Orders Data
INSERT INTO Orders VALUES (1, 1, 101, '2026-01-10', 1, 10.00);
INSERT INTO Orders VALUES(2, 1, 102, '2026-01-12', 2, 0.00);
INSERT INTO Orders VALUES(3, 2, 103, '2026-02-05', 5, 15.00);
INSERT INTO Orders VALUES(4, 2, 101, '2026-02-10', 1, 5.00);
INSERT INTO Orders VALUES(5, 1, 104, '2026-02-12', 1, 5.00);

--Create ScalaR Function For Discount.
CREATE FUNCTION dbo.fn_CalculateDiscountedPrice (
    @Price DECIMAL(10,2), 
    @Quantity INT, 
    @DiscountPercent DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    -- Handle NULLs by treating them as zero discount or zero price

    SET @Price = ISNULL(@Price, 0);
    SET @DiscountPercent = ISNULL(@DiscountPercent, 0);
    
    DECLARE @Total DECIMAL(10,2);
    SET @Total = (@Price * @Quantity) * (1 - (@DiscountPercent / 100));
    
    RETURN @Total;
END;

--Create Scalar Function For Top Selling Products.
CREATE FUNCTION dbo.fn_GetTopSellingProducts()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 5 
        p.ProductName, 
        SUM(o.Quantity) AS TotalSold
    FROM Products p
    JOIN Orders o ON p.ProductID = o.ProductID
    GROUP BY p.ProductName
    ORDER BY TotalSold DESC
);

--Create Procedure For Products For Calculating Total Revenue
CREATE PROCEDURE sp_GetTotalSalesPerStore
AS
BEGIN
    SELECT 
        s.StoreName,
        SUM(dbo.fn_CalculateDiscountedPrice(p.Price, o.Quantity, o.Discount)) AS TotalRevenue
    FROM Stores s
    JOIN Orders o ON s.StoreID = o.StoreID
    JOIN Products p ON o.ProductID = p.ProductID
    GROUP BY s.StoreName;
END;


--Create Procedure for Orders

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
    
AS
BEGIN
    SELECT 
        o.OrderID, 
        s.StoreName, 
        p.ProductName, 
        o.OrderDate,
        dbo.fn_CalculateDiscountedPrice(p.Price, o.Quantity, o.Discount) AS FinalPrice
    FROM Orders o
    JOIN Stores s ON o.StoreID = s.StoreID
    JOIN Products p ON o.ProductID = p.ProductID
    WHERE o.OrderDate BETWEEN ISNULL(@StartDate, '1900-01-01') AND ISNULL(@EndDate, GETDATE())
    ORDER BY o.OrderDate DESC;
END;

--Calling Scalar Function Of Discount.

SELECT dbo.fn_CalculateDiscountedPrice(100, 2, 10);

--Calling Scalar Function of Products Top Selling Product.

SELECT * FROM dbo.fn_GetTopSellingProducts ();


--Stored Procedure For Poducts For Total Revenue.

EXEC sp_GetTotalSalesPerStore;

--Stored Procedure For Order

EXEC sp_GetOrdersByDateRange'2026-02-01','2026-02-28';



