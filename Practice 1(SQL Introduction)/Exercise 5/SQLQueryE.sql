select count(c.model) as [Number of Cars Sold]
from Cars c
inner join Revisions r on c.carid = r.carid
where make != 'Citroen';
select avg(c.price - r.cost) as [Profit of Sales]
from Cars c
inner join Revisions r on c.carid = r.carid
where make != 'Citroen';
select avg(c.price) as [Average Amount Cars were sold at]
from Cars c
inner join Revisions r on c.carid = r.carid
where make != 'Citroen';