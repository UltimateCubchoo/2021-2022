select a.Name, a.Price, m.Name
from Articles a
inner join Manufacturers m
on m.MakerID = a.MakerID
where a.Price =(select Max(a.Price) from Articles a where m.MakerID = a.MakerID);
