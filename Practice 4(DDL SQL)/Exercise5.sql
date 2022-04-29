Create Table Countries(
	country_id int Identity,
	country_name nvarchar(100),
	check(country_name in ('Italy', 'India', 'China')),
	region_id int,
	Constraint Pk_Countries Primary Key(country_id)
)