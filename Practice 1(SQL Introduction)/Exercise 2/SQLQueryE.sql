Select v.vendorid, refnum, v.name, address
from Vendors v
inner join Products p
on v.vendorid = p.vendorid
where p.productid = 5;
