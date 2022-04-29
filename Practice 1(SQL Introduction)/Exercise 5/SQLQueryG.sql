select count(c.carid) as [Amount of Revisions made to Fords]
from Cars c
inner join Revisions r
on r.carid = c.carid
where make = 'Ford';