select a.Name, a.Price, a.Code, m.Name
from Articles a
inner join Manufacturers m
on a.MakerID = m.MakerID;