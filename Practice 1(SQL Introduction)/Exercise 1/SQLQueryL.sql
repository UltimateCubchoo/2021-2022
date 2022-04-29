select *
from Departments
where annual_budget >(select avg(annual_budget) from Departments) ;