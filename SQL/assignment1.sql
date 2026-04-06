CREATE DATABASE restaurant;

USE restaurant;

CREATE TABLE categories (
	id INT IDENTITY(1,1) PRIMARY KEY,
	category VARCHAR(255),
);
CREATE UNIQUE INDEX IDX_catId ON categories(id);
INSERT INTO categories(category) VALUES ('Fast Food'), ('Burger'), ('Pizza'), ('Roasted'), ('Drinks'), ('Italian');

CREATE TABLE products (
	id INT IDENTITY(1,1) PRIMARY KEY,
	product VARCHAR(255),
	price DECIMAL(5, 2),
	catId INT,
	CONSTRAINT FK_products_catId FOREIGN KEY (catId) REFERENCES categories(id),
);
CREATE UNIQUE INDEX IDX_productId ON products(id);
INSERT INTO products(product, price, catId) VALUES
	('Fish',20.5,1),
	('Chips',10.5,1),
	('Sandwiches',10.5,1),
	('Turkey burger',50.5,2),
	('Veggie burger',25.5,2),
	('Bean burger',30.5,2),
	('Chicago Deep-Dish Pizza',10.5,3),
	('New York-style Pizza.',5.5,3),
	('Detroit-style Pizza.',45.5,3),
	('Roasted Potatoes',5.1,4),
	('Roasted Butternut Squash',4.56,4),
	('Roasted Chicken',60.5,4),
	('Coke',2.5,5),
	('Pepsi',2.5,5),
	('Mint Margarita',3.2,5),
	('Spaghetti',10.5,6),
	('Risotto',15.5,6),
	('Polenta',12.5,6);


	-- 1.
	-- i.
	SELECT * FROM categories WHERE category LIKE 'bur%';
	-- ii.
	SELECT * FROM categories WHERE category LIKE '%za';

	-- 2.
	SELECT * FROM products WHERE ((price > 5) AND (price < 20));

	-- 3.
	SELECT AVG(price) AS avg FROM products WHERE (catId = 1);

	-- 4.
	UPDATE products SET price = 90 WHERE catId = 1;
	SELECT price, catId FROM products;

	-- 5.
	DELETE FROM products WHERE catId = 6;
	SELECT product, catId FROM products;

	DELETE FROM products;
	SELECT * FROM products;
