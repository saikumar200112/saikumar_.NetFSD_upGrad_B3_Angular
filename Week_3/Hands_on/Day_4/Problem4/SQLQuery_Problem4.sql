
USE AutoDb


CREATE TABLE Customers_1 (
    CustomerId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50)
);

CREATE TABLE Orders_1 (
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    OrderDate DATE,
    RequiredDate DATE,
    ShippedDate DATE,
    [Status] INT, 
    OrderValue DECIMAL(10,2),
    FOREIGN KEY (CustomerId) REFERENCES Customers_1(CustomerId)
);

CREATE TABLE Archived_Orders (
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    OrderDate DATE,
    OrderValue DECIMAL(10,2),
    ArchiveDate DATETIME DEFAULT GETDATE()
);

INSERT INTO Customers_1 VALUES (1, 'Sai', 'Kagithala'), (2, 'Kumar', 'Sai'), (3, 'Vamsi', 'Anand');

INSERT INTO Orders_1 VALUES 
(101, 1, '2023-01-10', '2023-01-15', '2023-01-14', 2, 5000.00), 
(102, 2, '2023-02-05', '2023-02-10', '2023-02-12', 3, 2000.00), 
(103, 3, '2025-01-01', '2025-01-05', '2025-01-10', 2, 7500.00), 
(104, 1, '2024-12-20', '2024-12-25', '2024-12-24', 2, 3000.00); 

--Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.

INSERT INTO Archived_Orders (OrderId, CustomerId, OrderDate, OrderValue, ArchiveDate)
SELECT OrderId, CustomerId, OrderDate, OrderValue, GETDATE()
FROM Orders_1
WHERE [Status] = 3
AND OrderId NOT IN (SELECT OrderId FROM Archived_Orders);

-- Delete orders where order_status = 3 (Rejected) and older than 1 year.

DELETE FROM Orders_1
WHERE Status = 3 
AND OrderId IN (
    SELECT OrderId 
    FROM Orders_1 
    WHERE DATEDIFF(day, OrderDate, GETDATE()) > 365
);
 


SELECT FirstName, LastName 
FROM Customers_1
WHERE CustomerId NOT IN (
    SELECT DISTINCT CustomerId 
    FROM Orders_1 
    WHERE [Status] <> 2
);

-- Display order processing delay (DATEDIFF between shipped_date and order_date).
--Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date

SELECT 
    OrderId,
    DATEDIFF(day, OrderDate, ShippedDate) AS ProcessingDelayDays,
    CASE 
        WHEN ShippedDate <= RequiredDate THEN 'On Time'
        ELSE 'Delayed'
    END AS DeliveryStatus
FROM Orders_1
WHERE ShippedDate IS NOT NULL;


