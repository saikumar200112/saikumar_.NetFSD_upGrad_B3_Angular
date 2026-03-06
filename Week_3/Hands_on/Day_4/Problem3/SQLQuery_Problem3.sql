USE AutoDb


CREATE TABLE MyStores (
    StoreId INT PRIMARY KEY,
    StoreName VARCHAR(100)
);

CREATE TABLE MyProducts (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(100),
    ListPrice DECIMAL(10, 2)
);

CREATE TABLE Stocks (
    StoreId INT,
    ProductId INT,
    quantity INT,
    FOREIGN KEY (StoreId) REFERENCES MyStores(StoreId),
    FOREIGN KEY (ProductId) REFERENCES MyProducts(ProductId)
);

CREATE TABLE MyOrders (
    OrderId INT PRIMARY KEY,
    StoreId INT,
    FOREIGN KEY (StoreId) REFERENCES MyStores(StoreId)
);
CREATE TABLE OrderItems (
    Orderid INT,
    ProductId INT,
    Quantity INT,
    ListPrice DECIMAL(10, 2),
    Discount DECIMAL(10, 2),
    FOREIGN KEY (OrderId) REFERENCES MyOrders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES MyProducts(ProductId)
);

INSERT INTO MyStores VALUES (1, 'Tech Central'); 
INSERT INTO MyStores VALUES(2, 'Gadget Galaxy');


INSERT INTO MyProducts VALUES (101, 'Laptop', 1000.00); 
INSERT INTO MyProducts VALUES(102, 'Mouse', 25.00);


INSERT INTO Stocks VALUES (1, 101, 0); 
INSERT INTO Stocks VALUES(1, 102, 50); 
INSERT INTO Stocks VALUES(2, 101, 10);

INSERT INTO MyOrders VALUES (5001, 1);
INSERT INTO MyOrders VALUES(5002,2);

INSERT INTO OrderItems VALUES (5001, 101, 1, 1000.00, 50.00);
INSERT INTO OrderItems VALUES (5002, 102, 2, 800.00, 00.00);
INSERT INTO OrderItems VALUES (5001, 101, 2, 1000.00, 10.00);
INSERT INTO OrderItems VALUES (5002, 102, 1, 800.00, 20.00);

--Identify products sold in each store and compare sold products with current stock using intersect operator.

SELECT o.StoreId, oi.ProductId 
FROM OrderItems oi
JOIN MyOrders o ON oi.OrderId = o.OrderId
INTERSECT
SELECT StoreId, ProductId 
FROM Stocks 
WHERE Quantity = 0;

--Display store name,product name total quantity and calculate total revenue per product.

SELECT s.StoreName, p.ProductName, SalesSummary.TotalSold,SalesSummary.TotalRevenue
FROM (
    SELECT  o.StoreId, oi.ProductId, SUM(oi.Quantity) AS TotalSold,
        SUM((oi.Quantity * oi.ListPrice) - oi.Discount) AS TotalRevenue
        FROM OrderItems oi JOIN MyOrders o ON oi.OrderId = o.OrderId
        GROUP BY o.StoreId, oi.ProductId) AS SalesSummary
        JOIN MyStores s ON SalesSummary.StoreId = s.StoreId
        JOIN MyProducts p ON SalesSummary.ProductId = p.ProductId
        JOIN Stocks st ON SalesSummary.StoreId = st.StoreId 
        AND SalesSummary.ProductId = st.ProductId WHERE st.Quantity = 0; 

--Update stock quantity to 0 for discontinued products.

UPDATE Stocks
SET Quantity = 0
WHERE ProductId = 101;