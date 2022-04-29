select s.salesmenid as [Salesmen who work in London], s.name, s.city, s.commission
from Orders o
inner join Salesmen s
on s.salesmenid = o.salesmenid
where city = 'London';