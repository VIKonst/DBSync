select
	t1.[object_id]						as foreign_key_id,
	t1.[name]							as foreign_key_name,
	t1.parent_object_id					as referencing_table_id,
	t1.referenced_object_id				as referenced_table_id,	
	t1.key_index_id						as referenced_key_id,
	t1.is_not_for_replication			as is_not_for_replication,
	t1.is_not_trusted					as is_not_trusted,
	t1.delete_referential_action		as delete_referential_action,
	t1.update_referential_action		as update_referential_action,
	t1.is_disabled						as is_disabled,
	t1.is_system_named					as is_system_named
from	sys.foreign_keys as t1
where t1.parent_object_id = {0}
order by t1.[name]