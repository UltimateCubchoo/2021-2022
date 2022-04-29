create table Jobs(
	job_id int Identity,
	job_title nvarchar,
	min_salary money,
	max_salary money
	constraint job_title default '',
	constraint min_salary default 8000,
	constraint Pk_Jobs Primary Key(job_id)
)
