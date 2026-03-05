CREATE DATABASE CustomerDb

USE CustomerDb

CREATE TABLE Customers
(
   CustomerId INT PRIMARY KEY,
   First_Name VARCHAR(50) NOT NULL,
   Last_Name VARCHAR(50) NOT NULL
   );

CREATE TABLE Orders
(
   OrderId INT PRIMARY KEY,
   CustomerId INT NOT NULL,
   OrderDate DATE NOT NULL,
   OrderStatus INT CHECK(OrderStatus IN(1,2,3,4)),
   FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
   );

INSERT INTO customers VALUES (1, 'saikumar', 'kagithala');
INSERT INTO customers VALUES (2, 'sai', 'kumar');
INSERT INTO customers VALUES (3, 'kumar', 'Davis');

INSERT INTO orders VALUES (101, 1, '2026-03-01', 1);
INSERT INTO orders VALUES (102, 2, '2026-03-02', 3); 
INSERT INTO orders VALUES (103, 3, '2026-03-03', 2);
INSERT INTO orders VALUES (104, 1, '2026-03-04', 4);

--Display fisrtname,lastname,orderid,orderdate,orderstatus

SELECT c.First_Name,c.Last_Name,o.OrderId,o.OrderDate,o.OrderStatus
FROM Customers AS c INNER JOIN Orders AS o ON c.CustomerId=o.CustomerId;

----Display fisrtname,lastname,orderid,orderdate,orderstatus whare order ia pending and completed

SELECT c.First_Name,c.Last_Name,o.OrderId,o.OrderDate,o.OrderStatus
FROM Customers AS c INNER JOIN Orders AS o ON c.CustomerId=o.CustomerId
WHERE o.OrderStatus = 1 OR o.OrderStatus = 4; 

----Display fisrtname,lastname,orderid,orderdate,orderstatus included order is pending and completed with desecending order

SELECT c.First_Name,c.Last_Name,o.OrderId,o.OrderDate,o.OrderStatus
FROM Customers AS c INNER JOIN Orders AS o ON c.CustomerId=o.CustomerId
WHERE o.OrderStatus = 1 OR o.OrderStatus = 4 ORDER BY o.OrderDate DESC 









