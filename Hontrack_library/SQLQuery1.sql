DROP TABLE IF EXISTS employee;

CREATE TABLE employee
(
	id INT PRIMARY KEY IDENTITY(1,1),
	employee_id VARCHAR(MAX) NULL,
	fullname VARCHAR(MAX) NULL,
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	usertype VARCHAR(50) NULL,
	insert_date DATE NULL,
	update_date DATE NULL,
	delete_date DATE NULL,
	date_register DATE NOT NULL DEFAULT GETDATE()
);


INSERT INTO employee (username ,password, fullname, usertype)
VALUES ('Admin', '@Admin123', 'John Doe', 'Administrator');

-- Select all rows from the 'employee' table
SELECT * FROM employee;

SELECT * FROM employee WHERE delete_date IS NULL

DELETE FROM employee





