select b.code, w.location
from Boxes b
inner join Warehouses w
on b.warehouseid = w.warehouseid
;