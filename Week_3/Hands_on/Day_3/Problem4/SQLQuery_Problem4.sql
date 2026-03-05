USE CustomerDb

CREATE TABLE store
(
  StoreId INT PRIMARY KEY,
  StoreName VARCHAR(50) NOT NULL,
  );
CREATE TABLE productstore
(
  ProductId INT PRIMARY KEY,
  ProductName VARCHAR(50) NOT NULL,
  );
CREATE TABLE stocks
(
  StoreId INT,
  ProductId INT,
  Quantity INT DEFAULT 0,
  PRIMARY KEY(StoreId,ProductId),
  FOREIGN KEY (StoreId) REFERENCES store(StoreId),
  FOREIGN KEY (ProductId) REFERENCES productstore(ProductId)
  );
  CREATE TABLE orderitem
  (
    OrderId INT,
    ItemId INT,
    ProductId INT,
    Quantity INT,
    PRIMARY KEY(OrderId,ItemId),
    FOREIGN KEY (ProductId) REFERENCES productstore(ProductId)
    );

INSERT INTO store VALUES (1, 'honda Bikes');
INSERT INTO store VALUES(2,'hero bikes');

INSERT INTO productstore VALUES (101, 'Mountain King');
INSERT INTO productstore VALUES (102, 'Road Runner');
INSERT INTO productstore VALUES (103, 'City Cruiser');

INSERT INTO stocks VALUES (1, 101, 50);
INSERT INTO stocks VALUES(1,102,20);
INSERT INTO stocks VALUES(1,103,10);

INSERT INTO orderitem VALUES (1001, 1, 101, 5);
INSERT INTO orderitem VALUES(1002,1,101,2);

--Display productname,atorename,quantity,total_sold and grouped arranged in ascending order

SELECT  p.ProductName, s.StoreName, st.Quantity AS available_stock,COALESCE(SUM(oi.quantity), 0) AS total_sold
FROM productstore AS p INNER JOIN stocks AS st ON p.ProductId = st.ProductId
INNER JOIN store AS s ON st.StoreId = s.StoreId LEFT JOIN orderitem AS oi ON p.ProductId = oi.ProductId
GROUP BY p.ProductName, s.StoreName, st.quantity
ORDER BY p.ProductName;










