select name as 'Departments with more than 1 employees', count(employeeid) as 'Number of Employees'
	from Departments d
		inner join Employees e
			on d.departmentid = e.departmentid
			group by name
			having count(employeeid) >(1);