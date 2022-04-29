create table Jobs(
	job_id int Identity,
	job_title nvarchar,
	min_salary money,
	max_salary money,
	check(max_salary < 2500),
	constraint Pk_Jobs Primary Key(job_id)
)
