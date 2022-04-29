Update Boxes
set price = price - (price * .20)
where price >(select avg(price) from Boxes);