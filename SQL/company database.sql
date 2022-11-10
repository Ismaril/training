-- CREATE or DROP DATABASE
CREATE DATABASE syntax_training;
DROP DATABASE syntax_training;

-- USE
-- change current working database
USE testdatabase;
-- -----------------------------------------------------------------------------

CREATE TABLE employee (
	emp_id INT PRIMARY KEY,
    first_name VARCHAR(40),
    last_name VARCHAR(40),
	birth_day DATE,
    sex VARCHAR(1),
    salary INT,
    super_id INT,
    branch_id INT
);

CREATE TABLE branch(
	branch_id INT PRIMARY KEY,
    branch_name VARCHAR(40),
    mgr_id INT,
    mgr_start_date DATE,
    FOREIGN KEY(mgr_id) REFERENCES employee(emp_id) ON DELETE SET NULL
);

-- FOREIGN KEY
-- add foreign key to employee table (we could not do it immediatelly
--     when creating employee table bacause the other tables have not beend 
--     created yet)
ALTER TABLE employee
ADD FOREIGN KEY(branch_id)
REFERENCES branch(branch_id)
ON DELETE SET NULL;

ALTER TABLE employee
ADD FOREIGN KEY(super_id)
REFERENCES employee(emp_id)
ON DELETE SET NULL;


CREATE TABLE client(
	client_id INT PRIMARY KEY,
    client_name VARCHAR(40),
    branch_id INT,
    FOREIGN KEY(branch_id) REFERENCES branch(branch_id) ON DELETE SET NULL
);


CREATE TABLE works_with (
  emp_id INT,
  client_id INT,
  total_sales INT,
  PRIMARY KEY(emp_id, client_id),
  FOREIGN KEY(emp_id) REFERENCES employee(emp_id) ON DELETE CASCADE,
  FOREIGN KEY(client_id) REFERENCES client(client_id) ON DELETE CASCADE
);

CREATE TABLE branch_supplier(
	branch_id INT,
    supplier_name VARCHAR(40),
    supply_type VARCHAR(40),
    PRIMARY KEY(branch_id, supplier_name),
    FOREIGN KEY(branch_id) REFERENCES branch(branch_id) ON DELETE CASCADE
);

-- -----------------------------------------------------------------------------
-- INSERT new values into tables

-- Corporate
INSERT INTO employee VALUES(100, 'David', 'Wallace', '1967-11-17', 'M', 250000, NULL, NULL);

INSERT INTO branch VALUES(1, 'Corporate', 100, '2006-02-09');

UPDATE employee
SET branch_id = 1
WHERE emp_id = 100;

INSERT INTO employee VALUES(101, 'Jan', 'Levinson', '1961-05-11', 'F', 110000, 100, 1);

-- Scranton
INSERT INTO employee VALUES(102, 'Michael', 'Scott', '1964-03-15', 'M', 75000, 100, NULL);

INSERT INTO branch VALUES(2, 'Scranton', 102, '1992-04-06');

UPDATE employee
SET branch_id = 2
WHERE emp_id = 102;

INSERT INTO employee VALUES(103, 'Angela', 'Martin', '1971-06-25', 'F', 63000, 102, 2);
INSERT INTO employee VALUES(104, 'Kelly', 'Kapoor', '1980-02-05', 'F', 55000, 102, 2);
INSERT INTO employee VALUES(105, 'Stanley', 'Hudson', '1958-02-19', 'M', 69000, 102, 2);

-- Stamford
INSERT INTO employee VALUES(106, 'Josh', 'Porter', '1969-09-05', 'M', 78000, 100, NULL);

INSERT INTO branch VALUES(3, 'Stamford', 106, '1998-02-13');

UPDATE employee
SET branch_id = 3
WHERE emp_id = 106;

INSERT INTO employee VALUES(107, 'Andy', 'Bernard', '1973-07-22', 'M', 65000, 106, 3);
INSERT INTO employee VALUES(108, 'Jim', 'Halpert', '1978-10-01', 'M', 71000, 106, 3);

INSERT INTO branch VALUES(4, "Buffalo", NULL, NULL);

-- BRANCH SUPPLIER
INSERT INTO branch_supplier VALUES(2, 'Hammer Mill', 'Paper');
INSERT INTO branch_supplier VALUES(2, 'Uni-ball', 'Writing Utensils');
INSERT INTO branch_supplier VALUES(3, 'Patriot Paper', 'Paper');
INSERT INTO branch_supplier VALUES(2, 'J.T. Forms & Labels', 'Custom Forms');
INSERT INTO branch_supplier VALUES(3, 'Uni-ball', 'Writing Utensils');
INSERT INTO branch_supplier VALUES(3, 'Hammer Mill', 'Paper');
INSERT INTO branch_supplier VALUES(3, 'Stamford Lables', 'Custom Forms');

-- CLIENT
INSERT INTO client VALUES(400, 'Dunmore Highschool', 2);
INSERT INTO client VALUES(401, 'Lackawana Country', 2);
INSERT INTO client VALUES(402, 'FedEx', 3);
INSERT INTO client VALUES(403, 'John Daly Law, LLC', 3);
INSERT INTO client VALUES(404, 'Scranton Whitepages', 2);
INSERT INTO client VALUES(405, 'Times Newspaper', 3);
INSERT INTO client VALUES(406, 'FedEx', 2);

-- WORKS_WITH
INSERT INTO works_with VALUES(105, 400, 55000);
INSERT INTO works_with VALUES(102, 401, 267000);
INSERT INTO works_with VALUES(108, 402, 22500);
INSERT INTO works_with VALUES(107, 403, 5000);
INSERT INTO works_with VALUES(108, 403, 12000);
INSERT INTO works_with VALUES(105, 404, 33000);
INSERT INTO works_with VALUES(107, 405, 26000);
INSERT INTO works_with VALUES(102, 406, 15000);
INSERT INTO works_with VALUES(105, 406, 130000);

-- -----------------------------------------------------------------------------
-- MAIN KEYWORDS

-- ADD COLUMN
ALTER TABLE table_
ADD COLUMN column_ BOOLEAN;

-- RENAME COLUMN
ALTER TABLE table_
RENAME COLUMN column_old TO column_new;

-- MODIFY datatype of a column
ALTER TABLE table_
MODIFY column_ DECIMAL(5, 2) NOT NULL UNIQUE;

-- BETWEEN
SELECT column_
FROM table_
WHERE column_ BETWEEN number_1 AND number_2;

-- LIMIT number of returned rows
SELECT * FROM table_ LIMIT 4;

-- HAVING is used instead of WHERE in aggregate functions
SELECT COUNT(column_), column_, column_2
FROM table_
GROUP BY column_
HAVING column_2 > 0;

-- DELETE a row from table
DELETE FROM table_
WHERE column_ = "something";
DELETE FROM table_; -- used when you want to delete all 

-- DROP TABLE
DROP TABLE table_;

-- DROP COLUMN
ALTER TABLE table_
DROP COLUMN column_1,
DROP COLUMN column_2
;

-- ANY
-- value that we compare to any must be equal
--     atleast to one in the container to be True
SELECT employee.last_name FROM employee
WHERE employee.emp_id = ANY(
	SELECT works_with.emp_id FROM works_with 
);

-- CASE
-- case will contain multiple conditions. The first condition that is true
--    will return the code after "then". If no condition is met, returned is else
--    If there is no else and no condition satisfied, returned is "None".
SELECT employee.salary,
CASE
    WHEN employee.salary > 60000 THEN 'greater than 60000'
    WHEN employee.salary = 60000 THEN 'is 60000'
    ELSE 'under 60000'
END AS new_column
FROM employee;

-- CHECK
-- specify a condition that newly inserted data must fulfill
--    else it returns a error
CREATE TABLE table_(
	column_ INT
    CHECK (column_=10));

-- INDEX
-- todo: check more deeply when it is needed
-- not visible to the user
-- used to speed up searching
-- allows duplicates if UNIQUE not specified -- CREATE UNIQUE INDEX
CREATE INDEX name_of_index_column
ON table_(column_1, column_2);

-- DROP INDEX
ALTER TABLE table_
DROP INDEX name_of_index_col;

-- DEFAULT
-- default value should serve instead of "None" in a given cell
CREATE TABLE table_(
	column_ INT DEFAULT "some_value"
);

-- DROP DEFAULT
-- drops default constraint
ALTER TABLE table_
ALTER COLUMN column_
DROP DEFAULT;

-- EXISTS
-- is used to test for the existence of any record in a subquery.
-- returns TRUE if the subquery returns one or more records.
-- here it will check against the conditon in brackests - if there are
--    any records in super_id that are not Null exists will be True.
SELECT branch_name
FROM branch
WHERE EXISTS(SELECT super_id FROM employee WHERE super_id IS NOT NULL);

-- INSERT INTO SELECT
-- statement copies data from one table and inserts it into another table.
-- statement requires that the data types in source and target tables match.
-- existing records are unaffected
INSERT INTO table2
SELECT * FROM table1
WHERE condition_;

-- -----------------------------------------------------------------------------
-- QUERIES

-- find all employees ordered by salary ASC|DESC
SELECT * FROM employee ORDER BY salary DESC;

-- find all employees ordered by sex, then firstname and then by last name
SELECT * FROM employee ORDER BY sex, first_name, last_name;

-- find first 5 employees in the table
SELECT * FROM employee LIMIT 5;

-- get first and last names from employees
SELECT first_name, last_name FROM employee;

-- use aliases as column names
SELECT first_name AS forename, last_name AS surname
FROM employee;

-- select all distinct values from a given column
SELECT DISTINCT sex
FROM employee;
SELECT COUNT(DISTINCT sex) as Number_of_sexes
FROM employee;

-- find a list of employees and branch names and whateher else u like
SELECT first_name AS name_of_column
FROM employee
UNION
SELECT branch_name
FROM branch
UNION
SELECT last_name
FROM employee;

-- find a list of all clients and branch suppliers names
SELECT client_name, client.branch_id
FROM client
UNION
SELECT supplier_name, branch_supplier.branch_id
FROM branch_supplier;

-- -----------------------------------------------------------------------------
-- WHERE
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
/*/
SELECT * FROM table_
WHERE column_1='Germany' AND NOT column_2='USA' AND (column_3='Berlin' OR column_3='München');

-- -----------------------------------------------------------------------------
-- FUNCTIONS
-- find the number of employees
SELECT COUNT(emp_id)
FROM employee;

-- find the number of employees born after 1970
SELECT COUNT(emp_id)
FROM employee
WHERE sex = "F" AND birth_day > "1970-01-01";

-- find the average of all employees salaries
SELECT AVG(salary)
FROM employee;

-- find the sum of all employee salaries
SELECT SUM(salary)
FROM employee;

-- find out how many males and females there are
SELECT COUNT(sex), sex
FROM employee
GROUP BY sex;

-- fin the total sales of each salesman
SELECT SUM(total_sales), emp_id
FROM works_with
GROUP BY emp_id;

-- -----------------------------------------------------------------------------
-- REGEX

-- find any client that has in its name 'LCC'
SELECT *
FROM client
WHERE client_name LIKE "%LLC%";

-- find all born in october
SELECT *
FROM employee
WHERE birth_day LIKE "____-10%";

-- -----------------------------------------------------------------------------
-- join - used to combine rows from multiple tables based on related column between them

-- find all branches and the names of their managers
SELECT employee.emp_id, employee.last_name, branch.branch_name
FROM employee
JOIN branch
ON employee.emp_id = branch.mgr_id;

-- -----------------------------------------------------
-- NESTED QUERIES

-- find names of all employees who have
--     sold over 30_000 to a single client
SELECT employee.last_name
FROM employee
WHERE employee.emp_id IN (
	SELECT works_with.emp_id
	FROM works_with
	WHERE works_with.total_sales >= 30000
);

-- find all clients who are handled by the branch
--    that michael scott manages
-- asume you know michaels ID
SELECT client.client_name
FROM client
WHERE client.branch_id IN (
	SELECT branch.branch_id
	FROM branch
	WHERE branch.mgr_id = 102
);

-- -----------------------------------------------------------------------------
-- ON DELETE
-- specifies what to do in a linked table, when the base reference
--    gets deleted in original table

-- on delete set null - set NULL in a cell in table that is linked to the original table
-- on delete set cascade - deletes whole row in the table that is linked to the original table
DELETE FROM employee
WHERE employee.emp_id = 102;

SELECT * FROM branch;

-- -----------------------------------------------------------------------------
-- TRIGGER
-- used to execute a certain code, when for example we insert new data
--    into database

CREATE TABLE trigger_test(
	message VARCHAR(40)
);
-- seems like this has to be written in console maybe? Basically we are changing delimiter from ";"
--    to && because ; will be used inside. This code basically means, that when we insert new data
--    into employee table, "added new employee" will be added to my_trigger table.
--    In the ned we are changing back the delimiter to ;.

/*
DELIMITER &&
CREATE
	TRIGGER my_trigger BEFORE INSERT
    ON employee
    FOR EACH ROW BEGIN
		INSERT INTO trigger_test VALUES("added new employee");
	END &&
DELIMITER ;

INSERT INTO employee VALUES(109, "oscar", "martinez", "9999-02-09", "M", 69000, 106, 3);

SELECT * FROM trigger_test;
/*/
CREATE TABLE TRALALA(SSS INT);
INSERT INTO TRALALA VALUES(10);
DELETE FROM TRALALA;

