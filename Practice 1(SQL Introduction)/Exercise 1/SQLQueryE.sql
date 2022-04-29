select e.employeeid, a.departmentid, e.fname, e.lname, e.category, e.activity
from Employees e
Left Join Assignments a
 on e.employeeid = a.employeeid
where departmentid = 2;