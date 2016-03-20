select 	
	o.name as procedure_name,
	o.schema_id as schema_id,
	isnull(schema_name(o.[schema_id]),'') as schema_name,
	o.object_id as prodeure_id,		
	m.definition as procedure_text,
	m.uses_ansi_nulls as is_ansi_nulls_on,
	m.uses_quoted_identifier as is_quoted_identifier
from sys.sql_modules m
join sys.objects o on m.object_id=o.object_id and o.[type]='P'
