select s.name as [Salesmen Name],  c.name as [Customer Name], s.city as [Location of Both]
from Orders o
inner join Salesmen s
on s.salesmenid = o.salesmenid
inner join Customers c
on c.customerid = o.customerid
where c.city = s.city;