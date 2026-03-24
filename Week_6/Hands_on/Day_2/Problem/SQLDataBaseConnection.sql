
CREATE DATABASE InventoryDB;

USE InventoryDB

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

INSERT INTO Products (ProductName, Category, Price) VALUES ('Logitech Mouse', 'Electronics', 25.50);
INSERT INTO Products (ProductName, Category, Price) VALUES ('Mechanical Keyboard', 'Electronics', 75.00);
INSERT INTO Products (ProductName, Category, Price) VALUES ('Office Chair', 'Furniture', 120.00);
INSERT INTO Products (ProductName, Category, Price) VALUES ('Coffee Mug', 'Kitchenware', 12.99);
INSERT INTO Products (ProductName, Category, Price) VALUES ('LED Monitor', 'Electronics', 150.00);


SELECT * FROM Products;

CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price);
END;


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price FROM Products;
END;


CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END;



CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId;
END;

CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price 
    FROM Products 
    WHERE ProductId = @ProductId;
END;


