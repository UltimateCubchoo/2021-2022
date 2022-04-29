select c.name as [Customer Name], s.name as [Salesmen Name] 
from Customers c
right join Orders o
on c.customerid = o.customerid
inner join Salesmen s
on s.salesmenid = o.salesmenid
order by c.customerid;