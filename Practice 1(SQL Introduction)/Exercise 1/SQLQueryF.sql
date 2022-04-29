select e.employeeid, a.departmentid, e.fname, e.lname, e.category, e.activity
from Employees e
	left join Assignments a
		on e.employeeid = a.employeeid
where departmentid = 7 or departmentid = 11;