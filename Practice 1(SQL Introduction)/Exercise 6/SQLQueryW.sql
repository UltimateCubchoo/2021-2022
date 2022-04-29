select o.orderid, o.purchaseamt, c.city
from Orders o
inner join Customers c
on c.customerid = o.customerid
where purchaseamt >= 500 and purchaseamt <= 2000;