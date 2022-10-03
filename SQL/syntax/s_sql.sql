
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
-- new_table_name will contain column1 and column2 from
--    existing_table_name (AS keyword is probably not used as
--    alias here??? needs to be checked)
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

-- some names of columns are FICTIONAL and do not makes sense...
-- define constraint separately to each column
CREATE TABLE table_name_ (
    column1 INT PRIMARY KEY,
    column2 BOOLEAN NOT NULL,
    column3 VARCHAR(40), -- without constraint
    column4 INT,
    column5 VARCHAR(40) DEFAULT "value when no value specified",
    UNIQUE (column2), -- we can have more constraints one one column
    CHECK (column4>=18)
);

-- define constraint to more columns at once
CREATE TABLE Persons (
    ID INT NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age INT,
    -- here UC_Person is a name of the constraint.
    CONSTRAINT UC_Person UNIQUE (ID,LastName),
    CONSTRAINT CHK_Person CHECK (Age>=18 AND City='Sandnes')
);

-- constraint on one column with alter table
ALTER TABLE Persons
	ADD UNIQUE (column1),
	ADD PRIMARY KEY (column2),
	ADD FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
	ADD CHECK (column4>=18),
	ALTER City SET DEFAULT "value when no value specified";

-- constraint on multiple columns with alter table
ALTER TABLE Persons
	ADD CONSTRAINT UC_Person UNIQUE (column1, column2),
	ADD CONSTRAINT PK_Person PRIMARY KEY (column3,column4),
	ADD CONSTRAINT FK_PersonOrder
		FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
	ADD CONSTRAINT CHK_PersonAge CHECK (Age>=18 AND City='Sandnes');

-- drop constraint (must have a name)
ALTER TABLE Persons
	DROP INDEX UC_Person,
	DROP PRIMARY KEY,
	DROP FOREIGN KEY FK_PersonOrder,
	DROP CONSTRAINT CHK_PersonAge,
	ALTER column_ DROP DEFAULT;

/*
NOT NULL - Ensures that a column cannot have a NULL value
UNIQUE - Ensures that all values in a column are different
PRIMARY KEY - A combination of a NOT NULL and UNIQUE. Uniquely identifies each row in a table
FOREIGN KEY - Prevents actions that would destroy links between tables
			- refers to the PRIMARY KEY in another table
CHECK - Ensures that the values in a column satisfies a specific condition
DEFAULT - Sets a default value for a column if no value is specified
CREATE INDEX - Used to create and retrieve data from the database very quickly
*/

-- ---------------------------------------------------
-- CREATE INDEX
-- Indexes are used to retrieve data from the database more
--    quickly than otherwise. The users cannot see the indexes,
--    they are just used to speed up searches/queries.
-- Updating a table with indexes takes more time than updating
--    a table without (because the indexes also need an update).
--    So, only create indexes on columns that will be used frequently

-- exclude UNIQUE if you want to allow duplicates in INDEX
CREATE UNIQUE INDEX index_name
ON table_name (column1, column2);

ALTER TABLE table_name_
DROP INDEX index_name;

-- ---------------------------------------------------
-- AUTO INCREMENT
-- Auto-increment allows a unique number to be generated
--    automatically when a new record is inserted into a table.
-- Often this is the primary key field that we would like to be
--    created automatically every time a new record is inserted.
-- By default, the starting value for AUTO_INCREMENT is 1,
--    and it will increment by 1 for each new record.
-- if we specify autoincrement, and we want to insert new data
--    into table, we do not have to write the name of that column
--    between other columns in INSERT INTO statement.

CREATE TABLE Persons (
    Personid int NOT NULL AUTO_INCREMENT,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    PRIMARY KEY (Personid)
);

-- start autoincrement from a different value than 1
ALTER TABLE Persons AUTO_INCREMENT=100;

-- ---------------------------------------------------
-- Dates
-- The most difficult part when working with dates is to be sure
--    that the format of the date you are trying to insert, matches
--    the format of the date column in the database.
-- As long as your data contains only the date portion,
--    your queries will work as expected. However, if a time portion
--    is involved, it gets more complicated.
/*
DATE - format YYYY-MM-DD
DATETIME - format: YYYY-MM-DD HH:MI:SS
TIMESTAMP - format: YYYY-MM-DD HH:MI:SS
YEAR - format YYYY or YY
*/

-- ---------------------------------------------------
-- CREATE VIEW
-- In SQL, a view is a virtual table based on the result-set of an SQL statement.
--    A view contains rows and columns, just like a real table.
--    The fields in a view are fields from one or more real tables
--    in the database. You can add SQL statements and functions to
--    a view and present the data as if the data were coming from
--    one single table.


-- here column1 and column2 will be transfered into veiw view_name.
-- AS keyword is probably not used here for alias??? needs to be checked
CREATE VIEW view_name AS
SELECT column1, column2
FROM table_name_
WHERE condition_;

-- select data from VIEW
SELECT * FROM view_name;

-- update view with 'CREATE OR REPLACE VIEW' statement
CREATE OR REPLACE VIEW view_name AS
SELECT column1, column2
FROM table_name_
WHERE condition_;

-- drop view
DROP VIEW view_name;

-- EXAMPLE
CREATE VIEW Products_Above_Average_Price AS
SELECT ProductName, Price
FROM Products
WHERE Price > (SELECT AVG(Price) FROM Products);

-- ---------------------------------------------------
-- SQL Injection
-- SQL injection is a code injection technique that might destroy
--    your database.
-- SQL injection is one of the most common web hacking techniques.
-- SQL injection is the placement of malicious code in SQL statements,
--    via web page input.

/*
EXAMPLE 1
-- here txtuserid seems to wait for user input (string). It then adds
--    into next variable, which is connected with another SQL command.
txtUserId = getRequestString("UserId");
txtSQL = "SELECT * FROM Users WHERE UserId = " + txtUserId;

-- malicious user insert this into userid field:
"105 OR 1=1"

-- here u see that this statement now returns all rows from database
      since 1=1 is obviously True...
SELECT * FROM Users WHERE UserId = 105 OR 1=1;


EXAMPLE 2
uName = getRequestString("username");
uPass = getRequestString("userpassword");
sql = 'SELECT * FROM Users WHERE Name ="' + uName + '" AND Pass ="' + uPass + '"'

-- malicious user inserts empty string equals empty string ""=""
-- again all rows will be now retruned from database
SELECT * FROM Users WHERE Name ="" or ""="" AND Pass ="" or ""=""
*/

-- ---------------------------------------------------
-- SQL Hosting
/*
If you want your web site to be able to store and retrieve
	data from a database, your web server should have access
    to a database-system that uses the SQL language.
If your web server is hosted by an Internet Service Provider (ISP),
	you will have to look for SQL hosting plans.
The most common SQL hosting databases are MS SQL Server, Oracle, MySQL,
	and MS Access.
*/

-- ---------------------------------------------------
-- MySQL Data Types
/*
String Data Types:
CHAR(size)		A FIXED length string (can contain letters, numbers,
					and special characters). The size parameter specifies
					the column length in characters - can be from 0 to 255.
					Default is 1
VARCHAR(size)	A VARIABLE length string (can contain letters,
					numbers, and special characters). The size parameter
					specifies the maximum string length in characters - can
					be from 0 to 65535
BINARY(size)	Equal to CHAR(), but stores binary byte strings.
					The size parameter specifies the column length in bytes.
                    Default is 1
VARBINARY(size)	Equal to VARCHAR(), but stores binary byte strings.
					The size parameter specifies the maximum column length in bytes.
TINYBLOB		For BLOBs (Binary Large Objects). Max length: 255 bytes
TINYTEXT		Holds a string with a maximum length of 255 characters
TEXT(size)		Holds a string with a maximum length of 65,535 bytes
BLOB(size)		For BLOBs (Binary Large Objects). Holds up to 65,535 bytes of data
MEDIUMTEXT		Holds a string with a maximum length of 16,777,215 characters
MEDIUMBLOB		For BLOBs (Binary Large Objects). Holds up to 16,777,215 bytes of data
LONGTEXT		Holds a string with a maximum length of 4,294,967,295 characters
LONGBLOB		For BLOBs (Binary Large Objects). Holds up to 4,294,967,295 bytes of data
ENUM(val1, ...)	A string object that can have only one value, chosen from a list of
					possible values. You can list up to 65535 values in an ENUM list.
                    If a value is inserted that is not in the list, a blank value will
                    be inserted. The values are sorted in the order you enter them
SET(val1, ...)	A string object that can have 0 or more values, chosen from a list
					of possible values. You can list up to 64 values in a SET list


Numeric Data Types:
Note: All the numeric data types may have an extra option: UNSIGNED or ZEROFILL.
If you add the UNSIGNED option, MySQL disallows negative values for the column.
If you add the ZEROFILL option, MySQL automatically also adds the UNSIGNED attribute
	to the column.

BIT(size)		A bit-value type. The number of bits per value is specified in size.
					The size parameter can hold a value from 1 to 64. The default value for size is 1.
TINYINT(size)	A very small integer. Signed range is from -128 to 127.
					Unsigned range is from 0 to 255. The size parameter specifies the
                    maximum display width (which is 255)
BOOL			Zero is considered as false, nonzero values are considered as true.
BOOLEAN			Equal to BOOL
SMALLINT(size)	A small integer. Signed range is from -32768 to 32767.
					Unsigned range is from 0 to 65535. The size parameter
                    specifies the maximum display width (which is 255)
MEDIUMINT(size)	A medium integer. Signed range is from -8388608 to 8388607.
					Unsigned range is from 0 to 16777215. The size parameter specifies
                    the maximum display width (which is 255)
INT(size)		A medium integer. Signed range is from -2147483648 to 2147483647.
					Unsigned range is from 0 to 4294967295. The size parameter
                    specifies the maximum display width (which is 255)
INTEGER(size)	Equal to INT(size)
BIGINT(size)	A large integer. Signed range is from -9223372036854775808 to
					9223372036854775807. Unsigned range is from 0 to 18446744073709551615.
                    The size parameter specifies the maximum display width (which is 255)
FLOAT(size, d)	A floating point number. The total number of digits is specified in
					size. The number of digits after the decimal point is specified in
                    the d parameter. This syntax is deprecated in MySQL 8.0.17, and it
                    will be removed in future MySQL versions
FLOAT(p)		A floating point number. MySQL uses the p value to determine whether
					to use FLOAT or DOUBLE for the resulting data type. If p is from 0
                    to 24, the data type becomes FLOAT(). If p is from 25 to 53,
                    the data type becomes DOUBLE()
DOUBLE(size, d)	A normal-size floating point number. The total number of digits is
					specified in size. The number of digits after the decimal point is
                    specified in the d parameter
DOUBLE PRECISION(size, d)	 
DECIMAL(size, d)	An exact fixed-point number. The total number of digits is
						specified in size. The number of digits after the decimal
                        point is specified in the d parameter. The maximum number for
                        size is 65. The maximum number for d is 30. The default value
                        for size is 10. The default value for d is 0.
DEC(size, d)	Equal to DECIMAL(size,d)


Date and Time Data Types:
MySQL 8.0 does not support year in two-digit format.
DATE			A date. Format: YYYY-MM-DD. The supported range is from '1000-01-01'
					to '9999-12-31'
DATETIME(fsp)	A date and time combination. Format: YYYY-MM-DD hh:mm:ss.
					The supported range is from '1000-01-01 00:00:00' to
                    '9999-12-31 23:59:59'. Adding DEFAULT and ON UPDATE in the column
                    definition to get automatic initialization and updating to the
                    current date and time
TIMESTAMP(fsp)	A timestamp. TIMESTAMP values are stored as the number of seconds
					since the Unix epoch ('1970-01-01 00:00:00' UTC).
                    Format: YYYY-MM-DD hh:mm:ss. The supported range is
                    from '1970-01-01 00:00:01' UTC to '2038-01-09 03:14:07' UTC.
                    Automatic initialization and updating to the current date and time
                    can be specified using DEFAULT CURRENT_TIMESTAMP and
                    ON UPDATE CURRENT_TIMESTAMP in the column definition
TIME(fsp)		A time. Format: hh:mm:ss. The supported range is from '-838:59:59'
					to '838:59:59'
YEAR			A year in four-digit format. Values allowed in four-digit
					format: 1901 to 2155, and 0000.

*/

-- Quick test just for fun:
-- https://www.w3schools.com/quiztest/quiztest.asp?qtest=SQL
-- 25/25 correct in 9:26 (min:sec)