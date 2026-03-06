USE AutoDb

CREATE TABLE Customers
(
  CustomerId INT PRIMARY KEY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL
  );

CREATE TABLE Orders
(
  OrderId INT PRIMARY KEY,
  CustomerId INT,
  OrderValue DECIMAL(10,2),
  FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
  );

  
INSERT INTO Customers VALUES (1, 'Sai', 'Kagithala'); 
INSERT INTO Customers VALUES(2, 'Kumar', 'Sai'); 
INSERT INTO Customers VALUES(3, 'Jaswanth', 'Kahithala'); 
INSERT INTO Customers VALUES(4, 'Vamsi', 'Anand');

INSERT INTO Orders VALUES (101, 1, 12000.00);
INSERT INTO Orders VALUES (102, 2, 7500.00); 
INSERT INTO Orders VALUES (103, 3, 30000.00);  
INSERT INTO Orders VALUES (104, 1, 2000.00); 

-- Use nested query to calculate total order value per customer.
-- Classify customers using conditional logic: 'Premium' if total order value > 10000 'Regular' if total order value between 5000 and 10000 'Basic' if total order value < 5000
--Use UNION to display customers with orders and customers without orders.
-- Display full name using string concatenation.
--Handle NULL cases appropriately.


SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
    CustomerTotals.TotalVal AS TotalOrderValue,
    CASE 
        WHEN CustomerTotals.TotalVal > 10000 THEN 'Premium'
        WHEN CustomerTotals.TotalVal BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS CustomerClass
FROM Customers c
JOIN (
    SELECT CustomerId, SUM(OrderValue) AS TotalVal
    FROM Orders
    GROUP BY CustomerId
) AS CustomerTotals ON c.CustomerId = CustomerTotals.CustomerId

UNION

SELECT 
    CONCAT(FirstName, ' ', LastName) AS FullName, 
    0.00 AS TotalOrderValue, 
    'No Activity' AS CustomerClass
FROM Customers 
WHERE CustomerId NOT IN (SELECT DISTINCT CustomerId FROM Orders);
