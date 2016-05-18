select
	t1.schema_id							as schema_id,
	t1.[name]								as schema_name,
	isnull(t1.principal_id, 0)				as principal_id,
	isnull(user_name(t1.principal_id), '')	as principal_name
from	sys.schemas	as t1
