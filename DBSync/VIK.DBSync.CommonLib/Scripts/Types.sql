select
	t1.user_type_id								as type_id,
	t1.[name]									as name_of_type,
	t1.is_user_defined							as is_user_defined,
	t1.[precision]								as type_precision,
	t1.scale									as type_scale,
	t1.is_nullable								as is_nullable,
	t1.system_type_id							as native_type_id,
	isnull(type_name(t1.system_type_id), '')	as native_type_name,
	t1.default_object_id						as bound_default_id,
	case 
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(object_name(t1.default_object_id), '')
		else ''
	end											as bound_default_name,
	case
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.default_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end											as bound_default_owner_name,
	t1.rule_object_id							as bound_rule_id,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(object_name(t1.rule_object_id), '')
		else ''
	end											as bound_rule_name,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.rule_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end											as bound_rule_owner_name,
	t1.max_length								as max_length,
	isnull(t1.collation_name, '')				as collation_name,
	t1.is_assembly_type							as is_assembly_type,
	isnull(t3.assembly_class, '')				as assembly_class,
	isnull(t3.assembly_id, 0)					as assembly_id,
	isnull(t1.schema_id, 0)						as schema_id,
	isnull(t1.principal_id, -1)					as principal_id,
	isnull(t4.[name], '')						as assembly_name,
	t1.is_table_type							as is_table_type,
	isnull(t5.[type_table_object_id], -1)		as type_table_object_id,
	isnull(schema_name(t1.schema_id), '')		as [schema_name],
	isnull(user_name(t1.principal_id),'')		as principal_name
from	sys.types as t1
		left outer join sys.assembly_types as t3 on
			t1.user_type_id = t3.user_type_id
		left join sys.assemblies as t4 on
			t3.assembly_id = t4.assembly_id
		left outer join sys.table_types as t5 on
			t1.user_type_id = t5.user_type_id