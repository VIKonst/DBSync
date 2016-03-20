select 
	t.name as table_name,
	t.schema_id as schema_id,
	isnull(schema_name(t.[schema_id]),'') as schema_name,
	t.object_id as table_id,
	t.uses_ansi_nulls as is_ansi_nulls_on

from sys.tables t