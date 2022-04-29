select w.location ,count(b.boxid) as [Count of Boxes]
from Warehouses w
inner join Boxes b
on w.warehouseid = b.warehouseid
group by w.location;