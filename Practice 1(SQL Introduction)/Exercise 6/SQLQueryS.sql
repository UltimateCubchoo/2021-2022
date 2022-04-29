select c.name as [Customer Name], s.name as [Sales who are working for them] 
from Orders o
right join Customers c
on c.customerid = o.customerid
inner join Salesmen s
on s.salesmenid = o.salesmenid;
