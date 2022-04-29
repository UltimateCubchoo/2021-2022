create table Job_History(
	employee_id int Identity,
	start_date date,
	end_date date,
	check(end_date >(start_date)),
	department_id int 
)