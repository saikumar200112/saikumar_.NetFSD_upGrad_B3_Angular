USE EcommDb

CREATE TABLE categories_1 
(
category_id INT PRIMARY KEY, 
category_name VARCHAR(255)
);
CREATE TABLE brands_1 (
brand_id INT PRIMARY KEY, 
brand_name VARCHAR(255)
);
CREATE TABLE products_1 
(
    product_id INT PRIMARY KEY, 
    product_name VARCHAR(255), 
    brand_id INT, 
    category_id INT, 
    model_year INT, 
    list_price DECIMAL(10,2),
    FOREIGN KEY (category_id) REFERENCES categories_1(category_id),
    FOREIGN KEY (brand_id) REFERENCES brands_1(brand_id)
);

CREATE TABLE customers_1 (
customer_id INT PRIMARY KEY, 
first_name VARCHAR(255), 
last_name VARCHAR(255)
);
CREATE TABLE stores_1 
(
store_id INT PRIMARY KEY, 
store_name VARCHAR(255)
);
CREATE TABLE staffs
(
staff_id INT PRIMARY KEY, 
first_name VARCHAR(255), 
last_name VARCHAR(255), 
store_id INT
);
CREATE TABLE orders (
    order_id INT PRIMARY KEY, 
    customer_id INT, 
    store_id INT, 
    staff_id INT, 
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES customers_1(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores_1(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);


INSERT INTO categories_1 VALUES (1, 'Mountain Bikes');
INSERT INTO categories_1 VALUES(2, 'Road Bikes');

INSERT INTO brands_1 VALUES (1, 'Royal Enfiled'); 
INSERT INTO brands_1 VALUES(2, 'Honda');

INSERT INTO products_1 VALUES (101, 'Himalayan', 1, 1, 2024, 250000.00); 
INSERT INTO products_1 VALUES(102, 'Shine', 2, 2, 2023, 180000.00);

INSERT INTO stores_1 VALUES (1, 'Royal Enfiled');
INSERT INTO stores_1 VALUES (2, 'Honda Bikes');

INSERT INTO customers_1 VALUES (501, 'saikumar', 'Kagithala');
INSERT INTO customers_1 VALUES (502, 'Vinod', 'Kumar');
INSERT INTO customers_1 VALUES (503, 'Jaswanth', 'Kagithala');
INSERT INTO customers_1 VALUES (504, 'Sunny', 'Satish');

INSERT INTO staffs VALUES (1, 'Vamsi', 'Roy', 1);

INSERT INTO orders VALUES (1001, 501, 1, 1, '2025-01-15');
INSERT INTO orders VALUES (1002, 502, 2, 1, '2026-01-15');
INSERT INTO orders VALUES (1003, 504, 1, 1, '2024-01-15');

--Creative views for ProductDeatils

CREATE VIEW vw_ProductDetails AS
SELECT p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price
FROM products_1 p JOIN brands_1 b ON p.brand_id = b.brand_id
JOIN categories_1 c ON p.category_id = c.category_id;

--Create views OrderDetails


CREATE VIEW vw_OrderSummary AS
SELECT o.order_id,CONCAT(cu.first_name, ' ', cu.last_name) AS customer_name,s.store_name,
CONCAT(st.first_name, ' ', st.last_name) AS staff_name
FROM orders o JOIN customers_1 cu ON o.customer_id = cu.customer_id
JOIN stores_1 s ON o.store_id = s.store_id
JOIN staffs st ON o.staff_id = st.staff_id;

-- Indexes for Product
CREATE INDEX idx_products_brand ON products_1(brand_id);
CREATE INDEX idx_products_category ON products_1(category_id);

-- Indexes for Order 
CREATE INDEX idx_orders_customer ON orders(customer_id);
CREATE INDEX idx_orders_store ON orders(store_id);
CREATE INDEX idx_orders_staff ON orders(staff_id);

--Retrive using Select Statement.

SELECT * FROM vw_OrderSummary;
SELECT * FROM vw_ProductDetails;


