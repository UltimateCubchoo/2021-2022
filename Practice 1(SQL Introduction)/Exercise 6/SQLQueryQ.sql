select purchaseamt as [Maximum Price for all the purchases]
from Orders
where purchaseamt =( select max(purchaseamt) from Orders);