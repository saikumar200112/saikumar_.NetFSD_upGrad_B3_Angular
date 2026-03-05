USE CustomerDb

CREATE TABLE Stores
(
  StoreId INT PRIMARY KEY,
  StoreName VARCHAR(50) NOT NULL,
  );
CREATE TABLE MyOrder
(
   OrderId INT PRIMARY KEY,
   StoreId INT NOT NULL,
   OrderStatus INT NOT NULL,
   FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
   );

CREATE TABLE OrderItems
(
  OrderId INT NOT NULL,
  ItemId INT NOT NULL,
  ProductId INT NOT NULL,
  Quantity INT NOT NULL CHECK(Quantity>0),
  ListPrice DECIMAL(10,2) NOT NULL CHECK(ListPrice>=0),
  Discount DECIMAL(4,2) DEFAULT 0 CHECK(Discount>=0 AND Discount <=1.00),
  PRIMARY KEY(OrderId,ItemId),
  FOREIGN KEY (OrderId) REFERENCES MyOrder(OrderId)
  );
 
INSERT INTO Stores VALUES (1, 'Honda Bikes'), (2, 'Hero Cycles');

INSERT INTO MyOrder VALUES (1001, 1, 4), (1002, 1, 4), (1003, 2, 4), (1004, 2, 1); -- 1004 is Pending

INSERT INTO OrderItems VALUES (1001, 1,101,2, 50000.00, 0.10); 
INSERT INTO OrderItems VALUES (1002, 1,102,1, 100000.00, 0.00); 
INSERT INTO OrderItems VALUES (1003, 1, 103,1, 600000.00, 0.00); 

--Display storename,totalsales and orderstaus=4 group and arrange totalsales Descending.

SELECT  s.StoreName,SUM(oi.Quantity * oi.ListPrice * (1 - oi.Discount)) AS TotalSales
FROM stores AS s INNER JOIN MyOrder AS o ON s.StoreId = o.StoreId
INNER JOIN OrderItems AS oi ON o.OrderId = oi.OrderId
WHERE o.OrderStatus = 4 GROUP BY s.StoreName
ORDER BY TotalSales DESC;













