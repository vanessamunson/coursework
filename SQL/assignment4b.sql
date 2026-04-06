USE restaurant;

SELECT 
	users.id as userId,
	users.customerName,
	users.phoneNumber,
	orders.id as orderId,
	products.product as product_name,
	products.price
INTO 
	#NastyTable
FROM users
INNER JOIN orders ON users.id = orders.orderBy
INNER JOIN orderProducts ON orderProducts.orderId = orders.id
INNER JOIN products ON products.id = orderProducts.productId;

SELECT * FROM #NastyTable;

CREATE PROCEDURE getUserOrderDetailsByUserName
	@name CHAR(3)
AS
BEGIN
	SELECT userId, customerName, phoneNumber, orderId, COUNT(product_name) as noOfProductsOrdered, SUM(price) as totalOrderPrice, MAX(price) as highestProductPrice
	FROM #NastyTable
	WHERE customerName LIKE '%' + @name + '%'
	GROUP BY userId, customerName, phoneNumber, orderId;
END;

EXEC getUserOrderDetailsByUserName @name = 'Wic';

DROP TABLE #NastyTable;
