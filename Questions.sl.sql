
-- Ryan Oxford helped
SELECT * 
FROM Employee
WHERE ID=1
SELECT d.name, SUM(Salary) as Total_Salary
FROM EmpDetails e
inner Join
(
	SELECT
	e.ID, d.Name
	FROM 
	Employee e
	INNER JOIN
	Department d
	ON e.Department_ID = d.Department_id
	WHERE
	d.Name = 'Marketing'
)d
ON e.ID= d.ID
GROUP BY 
d.name;

--
SELECT COUNT(e.ID) as Employees, d.name
FROM [Employee] e inner join [Department] d
ON e.Department_ID= d.Department_id
GROUP BY d.name;


UPDATE dbo.EmpDetails SET Salary = 90000 WHERE Employee_ID=1;


