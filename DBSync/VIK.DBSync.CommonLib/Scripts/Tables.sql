select 
	t1.name as table_name,
	t1.schema_id as schema_id,
	isnull(schema_name(t1.[schema_id]),'') as schema_name,
	t1.object_id as table_id,
	t1.uses_ansi_nulls as is_ansi_nulls_on,
	t1.is_replicated	as is_replicated,
	t1.lock_escalation_desc	 as lock_escalation,
	ISNULL(ds1.name, '') AS data_space_name,
	ISNULL(icm.column_id,-1) AS identity_column_id	
from sys.tables t1
inner join sys.indexes as t2 on
			t1.[object_id] = t2.[object_id]
			and
		t2.[type] between 0 and 1
LEFT JOIN sys.data_spaces ds1 ON ds1.data_space_id = t2.data_space_id
left join sys.identity_columns icm on icm.[object_id] = t1.[object_id]
where t1 .is_filetable = 0