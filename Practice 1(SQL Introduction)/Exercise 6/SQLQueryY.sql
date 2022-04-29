select orderid as [Orders by Paul Adam], purchaseamt, date
from Orders o
inner join Salesmen s
on s.salesmenid = o.salesmenid
where name like 'Paul Adam'