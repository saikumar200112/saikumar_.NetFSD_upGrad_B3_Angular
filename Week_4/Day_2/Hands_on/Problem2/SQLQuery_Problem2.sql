USE ReStoredDb



CREATE TABLE MyProducts (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    StockQuantity INT
);


CREATE TABLE MyOrders (
    OrderID INT PRIMARY KEY,
    OrderStatusID INT 
);


CREATE TABLE OrderItems_1 (
    OrderItemID INT PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES MyOrders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES MyProducts(ProductID),
    Quantity INT
);


INSERT INTO MyProducts VALUES (1, 'Laptop', 10);
INSERT INTO MyProducts VALUES(2, 'Mouse', 50);

INSERT INTO MyOrders VALUES (101, 1);


INSERT INTO OrderItems_1 VALUES (1, 101, 1, 2);
INSERT INTO OrderItems_1 VALUES (2, 101, 2, 5);

BEGIN TRY
    BEGIN TRANSACTION;--Begin transaction when cancelling an order.

  
    UPDATE MyOrders 
    SET OrderStatusID = 3 --Update order status to 3.
    WHERE OrderID = 101;

    
    SAVE TRANSACTION StockUpdatePoint;--Use savepoint before stock restoration and Restore stockquantities based on order items.

    
    UPDATE Products
    SET StockQuantity = Products.StockQuantity + OrderItems.Quantity
    FROM Products
    JOIN OrderItems ON Products.ProductID = OrderItems.ProductID
    WHERE OrderItems.OrderID = 101;

    
    COMMIT TRANSACTION;             --Commit transaction only if all operations succed.
    PRINT 'Transaction committed successfully.';

END TRY
BEGIN CATCH
    
    ROLLBACK TRANSACTION;          --If stock restoration fails, roolback to savepoint.
    PRINT 'Error encountered. Entire transaction rolled back.';
    PRINT 'Error details: ' + ERROR_MESSAGE();
END CATCH;


SELECT * FROM MyOrders WHERE OrderID = 101;


SELECT * FROM MyProducts;


SELECT * FROM OrderItems_1 WHERE OrderID = 101;
   

