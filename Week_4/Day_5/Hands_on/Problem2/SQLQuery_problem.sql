
USE OnlineBookStore


CREATE TABLE MyBooks (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE MyOrders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES MyBooks(BookID)
);

CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO MyBooks (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);
        
        PRINT 'Book "' + @Title + '" added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding book: ' + ERROR_MESSAGE();
    END CATCH
END;


CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN
    SET XACT_ABORT ON; 
    
    BEGIN TRY
        BEGIN TRANSACTION;

        
        IF NOT EXISTS (SELECT 1 FROM MyBooks WHERE BookID = @BookID AND Stock >= @Quantity)
        BEGIN
            RAISERROR('Not enough stock or book not found.', 16, 1);
        END

        
        UPDATE MyBooks 
        SET Stock = Stock - @Quantity 
        WHERE BookID = @BookID;

       
        INSERT INTO MyOrders (BookID, Quantity) 
        VALUES (@BookID, @Quantity);

        COMMIT TRANSACTION;
        PRINT 'Order placed successfully.';
    END TRY
    BEGIN CATCH
        
        IF @@TRANCOUNT > 0 
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();
    END CATCH
END;

EXEC sp_AddNewBook 'The SQL Guide', 10, 25.50;
EXEC sp_AddNewBook 'Database Logic', 5, 40.00;
EXEC sp_AddNewBook 'Coding 101', 2, 15.00;

SELECT * FROM Books;



EXEC sp_PlaceOrder @BookID = 1, @Quantity = 2;

EXEC sp_PlaceOrder @BookID = 3, @Quantity = 5;


EXEC sp_PlaceOrder @BookID = 99, @Quantity = 1;