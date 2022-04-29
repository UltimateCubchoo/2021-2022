select employeeid, fname, lname, name, annual_budget
from Employees e
full outer join Departments d
on e.departmentid = d.departmentid
where d.annual_budget > 150000;