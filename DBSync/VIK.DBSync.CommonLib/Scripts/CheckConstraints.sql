select 
	t1.[object_id]				as check_constraint_id,
	t1.[name]					as check_constraint_name,
	t1.parent_object_id			as parent_table_id,
	t1.parent_column_id			as parent_column_id,
	t1.definition				as definition,
	t1.is_disabled				as is_disabled,
	t1.is_not_for_replication	as is_not_for_replication,
	t1.is_not_trusted			as is_not_trusted,
	t1.uses_database_collation	as uses_database_collation,
	t1.is_system_named			as is_system_named
from	sys.check_constraints as t1
order by t1.[name]