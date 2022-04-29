select v.name, v.refnum, p.name, p.code, p.price
from Vendors v
right join Products p
on v.vendorid = p.vendorid
order by v.name;