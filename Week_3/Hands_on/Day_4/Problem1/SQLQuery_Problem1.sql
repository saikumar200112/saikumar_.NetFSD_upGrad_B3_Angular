CREATE DATABASE AutoDb
USE AutoDb

CREATE TABLE Products
(
  ProductId INT PRIMARY KEY,
  ProductName VARCHAR(50) NOT NULL,
  CategoryId INT NOT NULL,
  ModelYear INT,
  ListPrice DECIMAL(10,2)
  );


  INSERT INTO products (ProductId, ProductName, CategoryId, ModelYear, ListPrice) 
VALUES
(1, 'Honda', 1, 2023, 35000.00),  
(2, 'Hero', 1, 2022, 42000.00),
(3, 'Tata', 1, 2023, 11000.00),
(4, 'Mahindhra', 2, 2022, 19000.00),   
(5, 'RoyalEnfiled', 2, 2023, 21000.00),
(6, 'Suzuki', 2, 2021, 15000.00);

--Retreive product deatils ansd compare each products price with average price of products in the same category
--Display only Those products whose price is greater than the average category and caluacted difference product price and categogry average.
--Concatenate product name and model year as a single coloumn.

SELECT  CONCAT(ProductName, ' (', ModelYear, ')') AS ProductDetail,
    ListPrice, (ListPrice - (SELECT AVG(p2.ListPrice) 
    FROM products p2 WHERE p2.CategoryId = p1.CategoryId)) AS PriceDifference
    FROM products p1 WHERE ListPrice > ( SELECT AVG(p3.ListPrice)
    FROM products p3 WHERE p3.CategoryId = p1.CategoryId
);