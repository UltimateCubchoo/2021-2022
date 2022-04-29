select w.location, avg(price) as 'Average Price per Warehouse'
from Warehouses w
inner join Boxes b
on b.warehouseid = w.warehouseid
group by w.location;