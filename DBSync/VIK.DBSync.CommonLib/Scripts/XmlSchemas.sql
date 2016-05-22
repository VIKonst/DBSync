select
	t1.xml_collection_id			as xml_collection_id,
	t1.[name]						as xml_collection_name,
	t1.schema_id					as schema_id,
	isnull(t1.principal_id,-1)		as principal_id,
	xml_schema_namespace(schema_name(t1.schema_id), t1.[name])
									as definition,
	t1.create_date					as create_date,

	isnull(schema_name(t1.schema_id), '')	as schema_name,
	isnull(user_name(t1.principal_id), '')	as principal_name
from	sys.xml_schema_collections as t1
where	t1.xml_collection_id > 65535