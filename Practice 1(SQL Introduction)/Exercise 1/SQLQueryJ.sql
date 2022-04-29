select employeeid, fname, lname, name, annual_budget
from Departments d
inner join Employees e
on e.departmentid = d.departmentid;