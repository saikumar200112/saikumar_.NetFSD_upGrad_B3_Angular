USE ReStored


 
CREATE TABLE Stores_1 (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE Orders_1 (
    order_id INT PRIMARY KEY,
    store_id INT FOREIGN KEY REFERENCES Stores_1(store_id),
    order_status INT 
);

CREATE TABLE Order_Items_1 (
    item_id INT PRIMARY KEY,
    order_id INT FOREIGN KEY REFERENCES Orders_1(order_id),
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2) 
);

INSERT INTO Stores_1 VALUES (1, 'Samsung'), (2, 'Oppo');

INSERT INTO Orders_1 VALUES 
(101, 1, 4), (102, 1, 4), (103, 2, 4), (104, 2, 1); 


BEGIN TRY
    
    BEGIN TRANSACTION;

   
    CREATE TABLE #OrderRevenue (
        order_id INT,
        store_id INT,
        total_revenue DECIMAL(18,2)
    );

    --Use a cursor to iterate through completed orders(orders staus=4)
    
  
    DECLARE @OrderID INT, @StoreID INT;
    DECLARE @CurrentOrderRevenue DECIMAL(18,2);

    DECLARE order_cursor CURSOR FOR 
    SELECT order_id, store_id FROM Orders_1 WHERE order_status = 4;

    OPEN order_cursor;

    FETCH NEXT FROM order_cursor INTO @OrderID, @StoreID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
       
        SELECT @CurrentOrderRevenue = SUM((list_price * quantity) * (1 - discount)) --calculate total revenue per order using order items.
        FROM Order_Items_1
        WHERE order_id = @OrderID;

      
        INSERT INTO #OrderRevenue (order_id, store_id, total_revenue)
        VALUES (@OrderID, @StoreID, ISNULL(@CurrentOrderRevenue, 0));

        FETCH NEXT FROM order_cursor INTO @OrderID, @StoreID;
    END

    CLOSE order_cursor;
    DEALLOCATE order_cursor;


    SELECT 
        s.store_name, 
        SUM(r.total_revenue) AS Grand_Total_Revenue
    FROM #OrderRevenue r                            --Store computed revenue in a temporaray table.
    JOIN Stores_1 s ON r.store_id = s.store_id      --Display store wise revenue summary.
    GROUP BY s.store_name;

    DROP TABLE #OrderRevenue;

    COMMIT TRANSACTION;
    PRINT 'Processing completed successfully.';

END TRY
BEGIN CATCH
  
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    
   
    IF CURSOR_STATUS('global','order_cursor') >= -1
    BEGIN
        IF CURSOR_STATUS('global','order_cursor') > -1 CLOSE order_cursor;
        DEALLOCATE order_cursor;
    END

    PRINT 'Error occurred: ' + ERROR_MESSAGE();
END CATCH;

INSERT INTO Order_Items_1 VALUES 
(1, 101, 2, 500.00, 0.10), 
(2, 102, 1, 200.00, 0.00), 
(3, 103, 3, 100.00, 0.05);