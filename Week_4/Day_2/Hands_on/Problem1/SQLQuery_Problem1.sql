CREATE DATABASE ReStoredDb

USE ReStoredDb

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    StockQuantity INT CHECK (StockQuantity >= 0)
);


CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME DEFAULT GETDATE(),
    CustomerName VARCHAR(100)
);


CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT
);

INSERT INTO Products (ProductID, ProductName, StockQuantity)
VALUES (1, 'samsung', 50),(2, 'apple', 20),(3, 'oppo', 10);

--Create a trigger to reduce stock quality after order insertion

CREATE TRIGGER trg_ReduceStock
ON OrderItems
AFTER INSERT
AS
BEGIN

    UPDATE Products
    SET StockQuantity = StockQuantity - i.Quantity  
    FROM Products p
    JOIN inserted i ON p.ProductID = i.ProductID;
END;

--Transcation to insert data into orders and orderitems.

CREATE PROCEDURE sp_PlaceOrder
    @CustName VARCHAR(50),
    @ProdID INT,
    @Qty INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        
        INSERT INTO Orders (CustomerName) VALUES (@CustName);

        
        DECLARE @CurrOrderID INT;
        SELECT @CurrOrderID = MAX(OrderID) FROM Orders;

        
        INSERT INTO OrderItems (OrderID, ProductID, Quantity)
        VALUES (@CurrOrderID, @ProdID, @Qty);

        COMMIT TRANSACTION;
        PRINT 'Success: Order placed.';
    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;
        PRINT 'Error: Could not place order. Check stock levels.'; --Rollback transaction if stock quantity is insuffcient.
    END CATCH
END;



EXEC sp_PlaceOrder 'Saikumar', 1, 5;

SELECT * FROM Products; 
SELECT * FROM Orders;   

EXEC sp_PlaceOrder 'Jaswanth', 3, 5;


SELECT * FROM Orders; 
SELECT * FROM Products WHERE ProductID = 3;

