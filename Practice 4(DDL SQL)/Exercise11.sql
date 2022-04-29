create table Jobz(
	job_id int identity,
	job_title nvarchar(100),
	min_salary money,
	max_salary money,
	constraint Pk_Jobs Primary Key(job_id)
)

create table Departments(
	department_id int identity,
	department_name nvarchar(100),
	constraint Pk_Departments Primary Key(department_id)
)

create table Employees(
	employee_id int identity,
	first_name nvarchar(100),
	last_name nvarchar(100),
	email nvarchar(100),
	phone_number nvarchar(100),
	hire_date nvarchar(100),
	job_id int,
	salary money,
	commission money,
	manager_id int,
	department_id int
	unique(employee_id),
	constraint Pk_Employees Primary Key(employee_id),
	constraint Fk_Departments Foreign Key(department_id) References Departments,
	constraint Fk_Jobz Foreign Key(job_id) References Jobz
)