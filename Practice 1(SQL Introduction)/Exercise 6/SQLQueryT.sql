select c.name as [Customer Name], s.name as [Salesmen Name]
from Orders o
inner join Customers c
on c.customerid = o.customerid
inner join Salesmen s
on s.salesmenid = o.salesmenid
where c.city != s.city;