select name, price
from Articles
where Price <=(select min(Price) from Articles);