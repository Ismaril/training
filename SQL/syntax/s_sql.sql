
-- ---------------------------------------------------
-- ---------------------------------------------------
-- ALL CODE WAS WRITTEN WITH FOCUS ONLY ON MYSQL
-- ---------------------------------------------------
-- ---------------------------------------------------


-- TODO: how to store variables?


-- ---------------------------------------------------
-- SELECT

SELECT * FROM table_name_;

SELECT
	column1,
	column2
FROM
	table_name_;

-- ---------------------------------------------------
-- SELECT DISTINCT
-- used to return only distinct (different) values.
-- Inside a table, a column often contains many duplicate values
--    and sometimes you only want to list the different (distinct) values. 

SELECT DISTINCT
	column1,
    column2
FROM
	table_name_;
    
-- ---------------------------------------------------
-- WHERE
-- used to filter records.
-- used to extract only those records that fulfill a specified condition.
/*
=	Equal
>	Greater than
<	Less than
>=	Greater than or equal
<=	Less than or equal
<>	Not equal. Note: In some versions of SQL this operator may be written as !=
BETWEEN	Between a certain range
LIKE	Search for a pattern
IN	To specify multiple possible values for a column


AND, OR, and NOT operators
-- The WHERE clause can be combined with AND, OR, and NOT operators.
-- The AND and OR operators are used to filter records based on more than one condition
-- The NOT operator displays a record if the condition(s) is NOT TRUE

NULL
-- absence of value
*/

SELECT
	column1,
    column2
FROM
	table_name_
WHERE
	condition_;
    
    
SELECT
	column1,
    column2
FROM
	table_name_
WHERE
	condition1
    OR (condition2 AND condition3)
    AND condition4 IS NOT NULL;

-- ---------------------------------------------------
-- ORDER BY
-- used to sort the result-set in ascending or descending order.
-- if more columns after order by, table will be sorted first by
--    first column, then by second etc...

SELECT
	column1,
    column2
FROM
	table_name_
ORDER BY
	column1 DESC,
    column2 ASC;

-- ---------------------------------------------------
-- INSERT INTO
-- used to insert new records in a table.

-- insert only into specified columns
INSERT INTO
	table_name_ (column1, column2, column3)
VALUES
	(value1, value2, value3),
    (value4, value5, value6);


-- insert into whole table
INSERT INTO
	table_name_
VALUES
	(value1,
    value2,
    value3);

-- ---------------------------------------------------
-- UPDATE 
-- used to modify the existing records in a table.
-- careful with updateing db without WHERE!
--    (all records in the table would be updated)

UPDATE
	table_name_
SET
	column1 = value1,
    column2 = value2
WHERE
	condition_;

-- ---------------------------------------------------
-- DELETE
-- used to delete existing records in a table.
-- careful with updateing db without WHERE!
--    (all records in the table would be deleted)

DELETE FROM table_name_;

DELETE FROM
	table_name_
WHERE
	condition_;

-- ---------------------------------------------------
-- LIMIT
-- return only few first rows from
-- handy when having a huge dataset and wanna check some data

SELECT 
	column1,
    column2
FROM
	table_name_
WHERE
	condition_
LIMIT
	number_; -- some interger
 
-- ---------------------------------------------------
-- FUNCTIONS
-- MIN() returns the smallest value of the selected column.
-- MAX() returns the biggest value of the selected column.
-- COUNT() returns the number of rows that matches a specified criterion.
-- AVG() returns the average value of a numeric column. 
-- SUM() returns the total sum of a numeric column. 

SELECT
	COUNT(column_name_) -- insert your func here
FROM
	table_name_
WHERE
	condition_;

-- ---------------------------------------------------
-- LIKE (REGEX)
-- LIKE operator is used in a WHERE clause to search for a
--    specified pattern in a column.
-- % - represents zero, one, or multiple characters
-- _ - represents one, single character
-- [], ^, -, ! etc.. - do not work for MySQL??

-- EXAMPLE
-- "a%" - string that starts with "a"
-- "_a_" - string that has 3 letters with "a" in the middle
-- "%a%" - string that contains "a" anywhere
-- "Tom__ Laz%" - also possible to combine characters

SELECT
	column1,
    column2
FROM
	table_name_
WHERE
	columnN LIKE pattern;

-- ---------------------------------------------------
-- IN
-- allows you to specify multiple values in a WHERE clause
-- is a shorthand for multiple OR conditions

SELECT
	column1,
    column2
FROM
	table_name_
WHERE
	column_name_ IN (value1, value2);


-- you can also just select data from another table
SELECT
	column1,
    column2
FROM
	table_name_
WHERE
	column_name_ IN (SELECT STATEMENT);

-- ---------------------------------------------------
-- BETWEEN
-- selects values within a given range.
-- values can be numbers, text, or dates.
-- also possible to use NOT BETWEEN

-- EXAMPLE
-- BETWEEN 10 AND 20
-- BETWEEN "Arnold" AND "Arwen"
-- BETWEEN "1970-01-01" AND "1975-01-01"

SELECT
	column_names_
FROM
	table_name_
WHERE
	column_name_ BETWEEN value1 AND value2;

-- ---------------------------------------------------
-- AS (alias)
-- used to give a table, or a column in a table, a temporary name.
-- more readable
-- only exists for the duration of that query.

SELECT
	column_name_ AS alias_name
FROM
	table_name_;

-- this is the same as above
SELECT
	column_name_ alias_name
FROM
	table_name_;
    
/*
-- EXAMPLE
-- concatenate content to one cell and give to column new name
SELECT CustomerName, CONCAT(Address,', ',PostalCode,', ',City,', ',Country) AS Address
FROM Customers;

-- change the name of tables to improve readability
SELECT o.OrderID, o.OrderDate, c.CustomerName
FROM Customers AS c, Orders AS o
WHERE c.CustomerName='Around the Horn' AND c.CustomerID=o.CustomerID;
*/

-- ---------------------------------------------------
-- JOIN
-- used to combine rows from two or more tables,
--     based on a related column between them.
-- I get it as "combining tables together with columns"

-- (INNER) JOIN: Returns records that have matching values in both tables
-- LEFT (OUTER) JOIN: Returns all records from the left table, and the matched ecords from the right table
-- RIGHT (OUTER) JOIN: Returns all records from the right table, and the matched records from the left table
-- FULL (OUTER) JOIN: Returns all records when there is a match in either left or right table

-- possible to join two or multiple tables together
SELECT
	table99.column1,
	table99.column2,
    table77.column1,
    table44.column2
FROM
	table99
	JOIN table77 ON table99.related_column1=table77.related_column1
	JOIN table44 ON table99.related_column2=table44.related_column2;

-- table could be joined with it self (needs clarification, usecases etc...)
SELECT column_names_
FROM table1 as T1, table1 as T2
WHERE condition_;

-- ---------------------------------------------------
-- UNION
-- used to combine the result-set of two or more SELECT statements
-- Every SELECT statement within UNION must have the same number of columns
-- The columns must also have similar data types
-- The columns in every SELECT statement must also be in the same order
-- I get it as combination/append "into columns"

-- UNION - selects only distinct values by default
-- UNION ALL - alows duplicates

SELECT column_names_ FROM table1
UNION
SELECT column_names_ FROM table2;

-- EXAMPLE
-- customer as type_ is here just an alias, remaining 3 words
--    are columns as usual
-- there will be "customer" and "supplier" strings in Type_ column...fyi
SELECT 'Customer' AS Type_, ContactName, City, Country
FROM Customers
UNION
SELECT 'Supplier', ContactName, City, Country
FROM Suppliers;

-- ---------------------------------------------------
-- GROUP BY
-- groups rows that have the same values into summary rows,
--    like "find the number of customers in each country".
-- is often used with aggregate functions (COUNT(), MAX(),
--    MIN(), SUM(), AVG()) to group the result-set by one or more columns.

SELECT
	column_names
FROM
	table_name_
WHERE
	condition_
GROUP BY
	column_names;
    
-- ---------------------------------------------------
-- HAVING
-- was added to SQL because the WHERE keyword cannot be
--    used with aggregate functions.
-- can only be used with SELECT statement
-- operates on column
-- basically it filters again results after they were worked with aggregate function

SELECT
	column_names
FROM
	table_name_
WHERE
	condition_
GROUP BY
	column_names
HAVING
	condition_
ORDER BY
	column_names;

-- ---------------------------------------------------
-- EXISTS
-- used to test for the existence of any record in a subquery
-- returns TRUE if the subquery returns one or more records

SELECT
	column_names
FROM
	table_name_
WHERE EXISTS(
	SELECT
		column_names
	FROM
		table_name_
	WHERE
		condition_);

-- EXAMPLE
-- these two codes return actually the same result (I was just experimenting)
SELECT SupplierName
FROM Suppliers
WHERE EXISTS(
	SELECT ProductName
	FROM Products
	WHERE Products.SupplierID = Suppliers.supplierID AND Price < 20
    );

SELECT DISTINCT SupplierName
FROM Suppliers
JOIN Products ON Suppliers.supplierID=Products.SupplierID
WHERE Price < 20;

-- ---------------------------------------------------
-- ANY, ALL
-- allow to perform a comparison between a single column
--     value and a range of other values.
-- ANY - returns a boolean value as a result
--     - returns TRUE if ANY of the subquery values meet the condition

SELECT
	column_names
FROM
	table_name_
WHERE
	-- "=" could be any other: <>; > etc...
    -- ALL | ANY
	column_name_ = ALL(     
		SELECT column_name_
		FROM table_name_
		WHERE condition_
        );

-- ALL with SELECT
SELECT ALL column_names
FROM table_name_
WHERE condition_;

-- EXAMPLE
-- this code will return the same as the one below it
-- when a cell is equal atleast to one record in ANY(),
--    that row in original table will be returned
SELECT ProductName
FROM Products
WHERE ProductID = ANY (SELECT ProductID FROM OrderDetails WHERE Quantity > 99);

SELECT ProductName
FROM Products
WHERE ProductID = 35 OR ProductID = 55;

-- ---------------------------------------------------
-- SELECT INTO
-- copies data from one table into a new table.
-- The new table will be created with the column-names
--    and types as defined in the old table
-- You can create new column names using the AS clause.

-- TODO: check how to insert also into another database

SELECT column1, column2, column3
INTO newtable
FROM oldtable
WHERE condition_;

-- ---------------------------------------------------
-- SELECT INTO
-- copies data from one table and inserts it into existing table.
-- requires that the data types in source and target tables match.
-- The existing records in the target table are unaffected.

INSERT INTO table2 (column1, column2, column3)
SELECT column1, column2, column3
FROM table1
WHERE condition_;

-- ---------------------------------------------------
-- CASE
-- The CASE expression goes through conditions and returns a
--    value when the first condition is met (like an if-then-else
--    statement). So, once a condition is true, it will stop
--    reading and return the result. If no conditions are true,
--    it returns the value in the ELSE clause.

/*
CASE
    WHEN condition1 THEN result1
    WHEN condition2 THEN result2
    WHEN conditionN THEN resultN
    ELSE result
END;
*/

-- EXAMPLE
-- thione will return 3 columns
-- the last one QuantityText) consist of the CASE condition,
--    where each value of that column will be based on what the 
--    condition returned
SELECT OrderID, Quantity,
CASE
    WHEN Quantity > 30 THEN 'Its greater than 30'
    WHEN Quantity = 30 THEN 'Its 30'
    ELSE 'Its under 30'
END AS QuantityText
FROM OrderDetails;

-- here just order the result by the CASE condition
SELECT CustomerName, City, Country
FROM Customers
ORDER BY
	(CASE
		WHEN City IS NULL THEN Country
		ELSE City
	END);

-- ---------------------------------------------------
-- IFNULL(), COALESCE()
-- used when computing with NULL values

-- EXAMPLE
-- here we are computing new values for UnitPrice column.
--    If there are any any NULL values in UnitsInStock or
--    UnitsOnOrder the computation would fail there
SELECT ProductName, UnitPrice * (UnitsInStock + UnitsOnOrder)
FROM Products;

-- SOLUTION:
-- those cells where is Null will be counted as 0
-- both do the same thing here
SELECT ProductName, UnitPrice * (UnitsInStock + IFNULL(UnitsOnOrder, 0))
FROM Products;
SELECT ProductName, UnitPrice * (UnitsInStock + COALESCE(UnitsOnOrder, 0))
FROM Products;

-- ---------------------------------------------------
-- PROCEDURE
-- A stored procedure is a prepared SQL code that you can save, so the
--    code can be reused over and over again.
-- So if you have an SQL query that you write over and over again, save
--    it as a stored procedure, and then just call it to execute it.

-- we have to use change of delimeter here because ";" will be used for
--    commands stored in procedure
-- everything between BEGIN and END will be stored as code ready to be 
--    executed alter
-- "IN" pass a parameter into procedure
-- "OUT" retun data from procedure

DELIMITER //

CREATE PROCEDURE get_all(IN filter_ VARCHAR(40),
						IN number_of_retunred_results INT)
BEGIN
	SELECT *
    FROM employee
    WHERE last_name <> filter_
    LIMIT number_of_retunred_results; -- select top x results
    /*
    Another SQL code here...;
    Another SQL code here...;
    */
END //

DELIMITER ;

-- now call the procedure, with parameters specified by you
CALL get_all("Hudson", 5);

-- also possible to drop it ...
DROP PROCEDURE get_all;

-- ---------------------------------------------------
-- Operators

/*
Arithmetic Operators
+	Add
-	Subtract	
*	Multiply	
/	Divide	
%	Modulo

Bitwise Operators
&	Bitwise AND
|	Bitwise OR
^	Bitwise exclusive OR

Comparison Operators
=	Equal to	
>	Greater than	
<	Less than	
>=	Greater than or equal to	
<=	Less than or equal to	
<>	Not equal to

Compound Operators
+=	Add equals
-=	Subtract equals
*=	Multiply equals
/=	Divide equals
%=	Modulo equals
&=	Bitwise AND equals
^-=	Bitwise exclusive equals
|*=	Bitwise OR equals

Logical Operators
ALL	TRUE if all of the subquery values meet the condition	
AND	TRUE if all the conditions separated by AND is TRUE	
ANY	TRUE if any of the subquery values meet the condition	
BETWEEN	TRUE if the operand is within the range of comparisons	
EXISTS	TRUE if the subquery returns one or more records	
IN	TRUE if the operand is equal to one of a list of expressions	
LIKE	TRUE if the operand matches a pattern	
NOT	Displays a record if the condition(s) is NOT TRUE	
OR	TRUE if any of the conditions separated by OR is TRUE	
SOME	TRUE if any of the subquery values meet the condition
*/

-- ---------------------------------------------------
-- CREATE | DROP DATABASE
-- used to create a new SQL database

CREATE DATABASE syntax_training; 
USE syntax_training;
DROP DATABASE syntax_training;

-- ---------------------------------------------------
-- CREATE, DROP, TRUNCATE TABLE
-- used to create a new table in a database.

-- create a template of empty table
CREATE TABLE table_name_ (
    column1 INT,
    column2 VARCHAR(40),
    column3 BOOLEAN
);

-- create a new table from existing one
CREATE TABLE new_table_name AS
    SELECT column1, column2
    FROM existing_table_name
    WHERE condition_;

-- DROP TABLE
-- drops whole table, table will be totaly erased
DROP TABLE table_name_;

-- TRUNCATE TABLE
-- used to delete the data inside a table, but not the table itself
TRUNCATE TABLE table_name_;

-- ---------------------------------------------------
-- ALTER TABLE
-- used to add, delete, or modify columns in an existing table
-- used to add and drop various constraints on an existing table

ALTER TABLE table_name_
ADD column_name_ VARCHAR(40);

ALTER TABLE table_name_
DROP COLUMN column_name_;

ALTER TABLE table_name_
MODIFY COLUMN column_name_ VARCHAR(40);

-- ---------------------------------------------------
-- Constraints
-- used to limit the type of data that can go into a table. 
-- This ensures the accuracy and reliability of the data in
--    the table. If there is any violation between the constraint
--    and the data action, the action is aborted.
-- Constraints can be column level or table level. Column level
--    constraints apply to a column, and table level constraints
--    apply to the whole table.
-- Constraints can be specified when the table is created
--    with the CREATE TABLE statement, or after the table is
--    created with the ALTER TABLE statement.

-- define constraint separately to each column
CREATE TABLE table_name (
    column1 INT PRIMARY KEY,
    column2 BOOLEAN NOT NULL,
    column3 VARCHAR(40), -- without constraint
    UNIQUE (column2) -- we can have more constraints one one column
);

-- define constraint to more columns at once
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    -- here UC_Person is a name of the constraint.
    CONSTRAINT UC_Person UNIQUE (ID,LastName)
);

-- constraint on one column with alter table
ALTER TABLE Persons
ADD UNIQUE (ID);

-- constraint on multiple columns with alter table
ALTER TABLE Persons
ADD CONSTRAINT UC_Person UNIQUE (ID,LastName);

-- drop constraint (must have a name)
ALTER TABLE Persons
DROP INDEX UC_Person;

/*
NOT NULL - Ensures that a column cannot have a NULL value
UNIQUE - Ensures that all values in a column are different
PRIMARY KEY - A combination of a NOT NULL and UNIQUE. Uniquely identifies each row in a table
FOREIGN KEY - Prevents actions that would destroy links between tables
CHECK - Ensures that the values in a column satisfies a specific condition
DEFAULT - Sets a default value for a column if no value is specified
CREATE INDEX - Used to create and retrieve data from the database very quickly
*/

