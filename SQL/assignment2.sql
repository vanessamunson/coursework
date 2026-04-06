CREATE TABLE users (
	id INT IDENTITY(1,1) PRIMARY KEY,
	customerName VARCHAR(255),
	phoneNumber NVARCHAR(20),
);

INSERT INTO users(customerName, phoneNumber) VALUES 
	('Jon Doe','+1 680 256 0084'), 
	('Jon Wick','+1 680 256 0085'),
	('Tom Cruise','+1 680 256 0086');

CREATE TABLE orders (
	id INT IDENTITY(1,1) PRIMARY KEY,
	orderBy INT,
	CONSTRAINT FK_orders_orderBy FOREIGN KEY (orderBy) REFERENCES users(id),
);

INSERT INTO orders(orderBy) VALUES (1), (2), (3);

CREATE TABLE orderProducts (
	id INT IDENTITY(1,1) PRIMARY KEY,
	productId INT,
	CONSTRAINT FK_orderProducts_productId FOREIGN KEY (productId) REFERENCES products(id),
	orderId INT,
	CONSTRAINT FK_orderProducts_orderId FOREIGN KEY (orderId) REFERENCES orders(id),
);

INSERT INTO orderProducts(productId, orderId) VALUES 
	(1,1),
	(2,1),
	(3,1),
	(5,2),
	(6,2),
	(7,2),
	(8,2),
	(9,2),
	(11,3),
	(12,3),
	(13,3);

-- 1.
SELECT users.customerName, SUM(products.price) as total_price, COUNT(products.product) as total_products 
FROM (((orderProducts INNER JOIN products ON orderProducts.productId = products.id) INNER JOIN orders ON orderProducts.orderId = orders.id) INNER JOIN users ON orders.orderBy = users.id) 
WHERE users.customerName = 'Jon Wick'
GROUP BY users.customerName; 

-- 2.
WITH orderDetails AS (
	SELECT 
		orderProducts.orderId,
		orderProducts.productId,
		products.id AS product_id,
		products.product AS product_name,
		products.price,
		orders.id AS order_id,
		orders.orderBy,
		users.id AS user_id,
		users.customerName AS customer_name
	FROM (((orderProducts INNER JOIN products ON orderProducts.productId = products.id) INNER JOIN orders ON orderProducts.orderId = orders.id) INNER JOIN users ON orders.orderBy = users.id)
)
SELECT customer_name, STRING_AGG(product_name, ', ') AS products_ordered FROM orderDetails GROUP BY customer_name;
