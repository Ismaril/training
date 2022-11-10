
-- it is possible to return two columns with distinct filtering from one table using select, select.

SELECT
  (SELECT COUNT(*) FROM patients WHERE gender="M") AS male_count,
  (SELECT COUNT(*) FROM patients WHERE gender="F") AS female_count
;

-- Returns:
-- male_count, female_count
-- 2468, 2062

-----------------------------------------------------------------------------------------------------

-- Show first name, last name and role of every person that is either patient or physician.
-- The roles are either "Patient" or "Physician"

SELECT
	first_name,
	last_name,
	'Patient' AS role
FROM
	patients
UNION

SELECT
	first_name,
	last_name,
	'Physician'
FROM
	physicians;


-- Returns:
-- first_name, last_name, role
-- "Abby", "Moritzon", "Patient"
-- ..., ..., ...

-----------------------------------------------------------------------------------------------------

SELECT
	CONCAT(UPPER(last_name), ",", LOWER(first_name))
FROM
	patients
ORDER BY
	first_name DESC;

-- Returns:
-- name
-- "MILLER,zoe"
-- "CORBIE,ziva"

-----------------------------------------------------------------------------------------------------

SELECT MAX(weight) - MIN(weight) AS weight_delta
FROM patients
WHERE last_name="Maroni"

-- Returns:
-- weight_delta
-- 71


SELECT
	physicians.physician_id,
    	CONCAT(physicians.first_name, " ", physicians.last_name) AS full_name,
    	MIN(admission_date) AS first_admission,
	MAX(admission_date) AS last_admission
FROM
	admissions
	JOIN physicians
    	ON admissions.attending_physician_id=physicians.physician_id
GROUP BY
	attending_physician_id;

-- returns
-- physician_id, full_name, first_admission, last_admission
-- 1, "Claude Walls", 2018-06-10, 2019-06-03
-- ..., ..., ..., ...

-----------------------------------------------------------------------------------------------------
-- cast datatype in a new column
-- check with boolean result just like in python

SELECT
  patient_id,
  weight,
  height,
  weight / power(CAST(height AS float) / 100, 2) >= 30 AS obese
FROM patients

-----------------------------------------------------------------------------------------------------
-- have to drop constraints first before dropping the whole table???

ALTER TABLE student
DROP CONSTRAINT fk_student_city_id;
