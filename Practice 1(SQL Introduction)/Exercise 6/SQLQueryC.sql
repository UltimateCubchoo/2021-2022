select salesmenid
from Orders o
group by salesmenid having count(salesmenid) > 2;
