


CREATE DATABASE EcommDb

USE EcommDb

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL
);

CREATE TABLE Brands (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName VARCHAR(50) NOT NULL
);

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY IDENTITY(1,1),
    StoreName VARCHAR(100) NOT NULL,
    City VARCHAR(50)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    City VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    BrandID INT FOREIGN KEY REFERENCES Brands(BrandID),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    ModelYear INT,
    ListPrice DECIMAL(10, 2)
);

INSERT INTO Categories (CategoryName) 
VALUES ('Electric Sedans'), ('Luxury SUVs'), ('Sports Cars'), ('Pickup Trucks'), ('Hatchbacks');


INSERT INTO Brands (BrandName) 
VALUES ('Tesla'), ('BMW'), ('Mahindhra'), ('Toyota'), ('Tata');


INSERT INTO Stores (StoreName, City) 
VALUES ('Tesla Motors', 'Hyderabad'), ('BMW', 'Chennai'), ('Mahindhra', 'Banglore'), 
       ('Tata Motors', 'Mumbai'), ('Pacific Rides', 'Delhi');


INSERT INTO Customers (FirstName, LastName, City, Email) 
VALUES ('Saikumar', 'Kagithala', 'Chennai', 'sai@email.com'),
       ('Jaswanth', 'Kagithala', 'Hyderabad', 'jas@email.com'),
       ('Sunny', 'Satish', 'Chennai', 'sunny@email.com'),
       ('Vinod', 'Kumar', 'Delhi', 'vinod@email.com'),
        ('Vamsi', 'Roy', 'Mumbai', 'vamsi@email.com');


INSERT INTO Products (ProductName, BrandID, CategoryID, ModelYear, ListPrice) VALUES 
('Model Y', 1, 1, 2024, 450000.00),
('X5 Extreme', 2, 2, 2023, 750000.00),
('XUV 700', 3, 4, 2024, 600000.00),
('Nexon', 5, 3, 2023, 1100000.00),
('Himalayan', 4, 5, 2024, 280000.00);

--Write SELECT queries to retrieve all products with their brand and catergory names.

SELECT p.ProductName, b.BrandName, c.CategoryName, p.ListPrice
FROM Products p JOIN Brands b ON p.BrandID = b.BrandID
JOIN Categories c ON p.CategoryID = c.CategoryID;

--Retrieve all cusstomers from a specific city.

SELECT * FROM Customers 
WHERE City = 'Chennai';

--Display total number of products avaialable in each category.


SELECT c.CategoryName, COUNT(p.ProductID) AS TotalProducts
FROM Categories c LEFT JOIN Products p ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName;