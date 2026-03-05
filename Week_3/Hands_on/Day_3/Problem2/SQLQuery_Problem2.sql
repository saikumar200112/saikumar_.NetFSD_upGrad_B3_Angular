USE CustomerDb


CREATE TABLE Brands
(
  BrandId INT PRIMARY KEY,
  BrandName VARCHAR(50) NOT NULL
  );
  CREATE TABLE Categories
  (
     CategoryId INT PRIMARY KEY,
     CategoryName VARCHAR(50) NOT NULL
     );
CREATE TABLE Products
(
  ProductId INT PRIMARY KEY,
  ProductName VARCHAR(50) NOT NULL,
  BrandId INT NOT NULL,
  CategoryId INT NOT NULL,
  ModelYear INT,
  ListPrice DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (BrandId) REFERENCES Brands(BrandId),
  FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
  );
 
INSERT INTO Brands VALUES (1, 'Tata'), (2, 'Honda'), (3, 'Royalenfiled');

INSERT INTO Categories VALUES (1, 'Cars'), (2, 'Road Bikes'), (3, 'Mountain Bikes');

INSERT INTO Products VALUES (10, 'Fuel EX 8', 1, 1, 2026, 2800.00); 
INSERT INTO Products VALUES (11, 'Straggler', 2, 2, 2025, 1500.00); 
INSERT INTO Products VALUES (12, 'Townie 7D', 3, 3, 2026, 480.00);  
INSERT INTO Products VALUES (13, 'Checkpoint ALR', 1, 2, 2026, 1900.00); 
INSERT INTO Products VALUES (14, 'Verve+ 2', 1, 3, 2024, 2500.00); 

--Display productname,Brandname,CategoryName,ModelYear,ListPrice

SELECT p.ProductName,b.BrandName,c.CategoryName,p.ModelYear,p.ListPrice 
 FROM Products AS p INNER JOIN Brands AS b ON p.BrandId=b.BrandId INNER JOIN Categories
  AS c ON p.CategoryId=c.CategoryId;

--Display productname,Brandname,CategoryName,ModelYear,ListPrice with included condition listprice greater than 500
    
SELECT p.ProductName,b.BrandName,c.CategoryName,p.ModelYear,p.ListPrice 
 FROM Products AS p INNER JOIN Brands AS b ON p.BrandId=b.BrandId INNER JOIN Categories
  AS c ON p.CategoryId=c.CategoryId WHERE p.ListPrice >500;

  ---Display productname,Brandname,CategoryName,ModelYear,ListPrice And Arranged List Price in Ascending order
    
SELECT p.ProductName,b.BrandName,c.CategoryName,p.ModelYear,p.ListPrice 
 FROM Products AS p INNER JOIN Brands AS b ON p.BrandId=b.BrandId INNER JOIN Categories
  AS c ON p.CategoryId=c.CategoryId ORDER BY p.ListPrice ASC;
    





