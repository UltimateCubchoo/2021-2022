select name, count(employeeid) as 'Number of Employees'
	from Departments d
		inner join Employees e
			on d.departmentid = e.departmentid
			group by name;