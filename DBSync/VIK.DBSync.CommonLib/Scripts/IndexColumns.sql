select 
	ic.object_id  as object_id, 
	ic.index_id  as index_id, 
	ic.index_column_id  as index_column_id,
	ic.column_id  as column_id,
	ic.is_descending_key as is_descending_key
from sys.index_columns ic
where object_id= {0}