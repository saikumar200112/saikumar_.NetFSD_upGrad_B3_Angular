USE ReStored

CREATE TABLE stocks (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    quantity_available INT CHECK (quantity_available >= 0)
);


CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity_ordered INT,
    FOREIGN KEY (product_id) REFERENCES stocks(product_id)
);


INSERT INTO stocks (product_id, product_name, quantity_available)
VALUES (1, 'Smartphone', 10),(2, 'Wireless Earbuds', 5),(3, 'Phone Case', 20);

--Create An After Insert Trigger On Order Items.
--Reduce The Corresponding Quantity In Stocks Table.
--Prevent Stock From Becoming Negative.
--If Stock is Insufficient,RollBack The Transcation With A custom Error Meassage. 

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @ProductID INT;
        DECLARE @OrderedQty INT;
        DECLARE @CurrentStock INT;

        SELECT @ProductID = product_id, @OrderedQty = quantity_ordered FROM inserted;

        SELECT @CurrentStock = quantity_available 
        FROM stocks 
        WHERE product_id = @ProductID;

        IF @CurrentStock < @OrderedQty
        BEGIN
           
            DECLARE @ErrorMessage NVARCHAR(250) = 
                'Transaction Failed: Insufficient stock for Product ID ' + CAST(@ProductID AS VARCHAR) + 
                '. Available: ' + CAST(@CurrentStock AS VARCHAR);
            
            THROW 50001, @ErrorMessage, 1;
        END

        UPDATE stocks
        SET quantity_available = quantity_available - @OrderedQty
        WHERE product_id = @ProductID;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMessage, 16, 1);
    END CATCH
END;


INSERT INTO order_items (order_id, product_id, quantity_ordered)
VALUES (101, 1, 3);

SELECT * FROM stocks WHERE product_id = 1; 

INSERT INTO order_items (order_id, product_id, quantity_ordered)
VALUES (102, 2, 10);

SELECT * FROM order_items WHERE order_id = 102; 
