Create Table Countries(
	country_id int Identity,
	unique(country_id),
	country_name nvarchar(100),
	region_id int,
	Constraint Pk_Countries Primary Key(country_id)
)