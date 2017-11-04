select 
	ic.object_id			as object_id, 
	ic.index_id				as index_id, 
	ic.index_column_id		as index_column_id,
	ic.column_id			as column_id,
	ic.is_descending_key	as is_descending_key,
	ic.is_included_column	as is_included
from sys.index_columns ic