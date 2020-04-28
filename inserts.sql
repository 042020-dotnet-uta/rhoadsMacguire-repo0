INSERT INTO [dbo].[Department] (Department_id, name, Location) VALUES (1, 'Marketing', 'main Office');
INSERT INTO [dbo].[Department] (Department_id, name, Location) VALUES (2, 'Managment', 'office');
INSERT INTO [dbo].[Department] (Department_id, name, Location) VALUES (3, 'Finance', 'place');


INSERT INTO [dbo].[Employee] (ID,  fname, lname, ssn, Department_ID) VALUES (1,'tina', 'smith', '000-00-0000', 1);
INSERT INTO [dbo].[Employee] (ID,  fname, lname, ssn, Department_ID) VALUES (2,'bob', 'horg', '001-00-0000', 2);
INSERT INTO [dbo].[Employee] (ID,  fname, lname, ssn, Department_ID) VALUES (3,'Jake', 'steak', '000-00-1000', 3);

INSERT INTO [dbo].[EmpDetails] (ID, Employee_ID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (1, 1,50000, '123 Birch Street', 'APT 21', 'NYC', 'NY', 'USA');
INSERT INTO [dbo].[EmpDetails] (ID, Employee_ID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (2, 2,65000, '123 Salmon Street', 'APT 25', 'SF', 'CA', 'USA');
INSERT INTO [dbo].[EmpDetails] (ID, Employee_ID, Salary, [Address 1], [Address 2], City, State, Country) VALUES (3, 3,45000, '123 Potter Street', 'APT 214', 'Seattle', 'WA', 'USA');
