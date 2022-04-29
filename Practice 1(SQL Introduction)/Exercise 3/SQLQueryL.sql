select m.Name, avg(Price) as 'Average of Manufacturers'
from Manufacturers m
inner join Articles a
on a.MakerID = m.MakerID
group by m.Name
having avg(Price) >=30;