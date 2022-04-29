select Vendors.vendorid, Vendors.name, refnum
from Vendors 
inner join Products 
on Vendors.vendorid = Products.vendorid
where price =(select max(price) from Products);
