Create Table Countries(
	country_id int Identity,
	country_name nvarchar(100),
	region_id int,
	Constraint Pk_Countries Primary Key(country_id),
	unique(country_id)
)