delete r
from Revisions r
inner join Cars c on r.carid = c.carid
where c.make = 'Ford';