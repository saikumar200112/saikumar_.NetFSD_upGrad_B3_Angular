USE ReStored

CREATE TABLE MyOrders (
    order_id INT PRIMARY KEY,
    customer_name VARCHAR(100),
    order_status INT, 
    shipped_date DATETIME NULL
);

INSERT INTO MyOrders (order_id, customer_name, order_status, shipped_date)
VALUES (101, 'Saikumar', 1, NULL),(102, 'Jsawanth', 3, '2026-03-01 10:00:00'),(103, 'Satish', 1, '2026-03-012 09:00:00');

--Create an after update trigger on orders.
--validate that shipped date is not null whwn order satus=4.
--Prevent update if condition fails.

CREATE TRIGGER trg_ValidateOrderStatus
ON MyOrders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        IF EXISTS (
            SELECT 1 
            FROM inserted 
            WHERE order_status = 4 AND shipped_date IS NULL
        )
        BEGIN
            ;THROW 50001, 'Validation Error: Order status cannot be set to Completed (4) without a Shipped Date.', 1;
        END
    END TRY
    BEGIN CATCH
   
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;

UPDATE MyOrders 
SET order_status = 4 
WHERE order_id = 101;



UPDATE MyOrders 
SET order_status = 4 
WHERE order_id = 102;

SELECT * FROM MyOrders WHERE order_id = 102;
