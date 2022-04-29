select o.orderid, c.name
from Orders o
inner join Customers c
on c.customerid = o.customerid;