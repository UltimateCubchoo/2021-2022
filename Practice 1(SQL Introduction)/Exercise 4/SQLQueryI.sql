select b.code as [Codes of Boxes from Naples]
from Warehouses w
inner join Boxes b
on w.warehouseid = b.warehouseid
where location = 'Naples';