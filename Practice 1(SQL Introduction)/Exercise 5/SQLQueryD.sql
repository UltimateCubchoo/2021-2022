select c.lname as [Customers That Have Ford], c.city
from Customers c
inner join Revisions r
on c.customerid = r.customerid
right join Cars a
on r.carid = a.carid
where make = 'Ford';