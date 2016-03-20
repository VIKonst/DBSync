select 
	t.name as table_name,
	t.schema_id as schema_id,
	s.name as schema_name,
	t.object_id as table_id,
	t.uses_ansi_nulls as is_ansi_nulls_on

from sys.tables t
join sys.schemas s on t.schema_id=s.schema_id 