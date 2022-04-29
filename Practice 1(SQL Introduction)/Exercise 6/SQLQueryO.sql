select Count(s.salesmenid) as [Number of Salesmen listing]
from Orders o
inner join Salesmen s
on s.salesmenid = o.salesmenid
inner join Customers c
on c.customerid = o.customerid;