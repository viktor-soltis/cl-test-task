/*1. Write a SQL Query to pull all customers*/
/*Limited to a reasonable number (e.g. 1000 rows) to prevent data overloads*/
SELECT TOP(1000) c.ID, c.NAME, c.ADDRESS, c.PHONE_NUMBER, c.EMAIL
FROM Customers c


/*2. Write a SQL Query to pull all customers that have orders (no duplicates)*/
SELECT c.ID, c.NAME
FROM Customers c
	INNER JOIN Orders o ON o.CUSTOMER_ID = c.ID
GROUP BY c.ID, c.NAME
HAVING COUNT(o.ID) > 0


/*3. Write a SQL Query to pull all customers that do not have orders*/
SELECT c.*
FROM Customers c 
	LEFT JOIN Orders o ON c.ID = o.Customer_ID
WHERE o.Customer_ID IS NULL


/*4. If you had to create an index on these tables, which fields would you most likely index and why?*/
/*
In my opinion the best candidates for indexing are Customers.ID and Orders.Customer_ID fields if there are already
no constraints on these fields like PrimaryKey/ForeignKey/Unique. Those fields will often appear in WHERE, GROUP BY, 
ORDER BY and ON clauses in queries. Customers and Orders tables will be used for SELECTION more often then for UPDATING, especially 
if we are talking about updates of Customers.ID or Orders.Customer_ID because apparently they will not be ever updated. 
Without indexes SQL server will SCAN every row in specified table to get requested matches, but after indexing it will 
start to SEEK indexes to get exact matches without scaning every row, this will increase perforamnce of SQL selections.
Honorable mention: Customer.Name and Customer.Email should be indexed in case lookups are executed often.
*/


/*5. Write a query that lists each customer name, email, and the number of order they have*/
SELECT c.NAME as CustomerName, c.EMAIL as CustomerEmail, o.ID as OrderNumber
FROM Customers c
	INNER JOIN Orders o ON c.ID = o.CUSTOMER_ID


/*5a. (in case of typo in 'orderS') Write a query that lists each customer name, email, and the number of orderS they have*/
SELECT c.NAME as CustomerName, c.EMAIL as CustomerEmail, COUNT(o.CUSTOMER_ID) as NumberOfOrders
FROM Customers c
	LEFT JOIN Orders o ON c.ID = o.CUSTOMER_ID
GROUP BY c.NAME, c.EMAIL, o.CUSTOMER_ID


/*6. Write a query that pulls all customers that have between 2 and 5 orders*/
SELECT c.ID, c.NAME, COUNT(o.ID) as OrdersNumber
FROM Customers c
	INNER JOIN Orders o ON o.CUSTOMER_ID = c.ID
GROUP BY c.ID, c.NAME
HAVING COUNT(o.ID) BETWEEN 2 AND 5