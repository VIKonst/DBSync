select
	t1.[object_id]													as table_id,
	t1.column_id													as column_id,
	t1.[name]														as column_name,
	t1.user_type_id													as user_type_id,
	isnull(type_name(t1.user_type_id), '')							as user_type_name,
	t1.system_type_id												as native_type_id,
	isnull(type_name(t1.system_type_id), '')						as native_type_name,
	isnull(t1.collation_name, '')									as collation_name,
	t1.[precision]													as column_precision,
	t1.scale														as column_scale,
	t1.is_nullable													as is_nullable,
	t1.is_identity													as is_identity,
	columnproperty(t1.[object_id], t1.[name], 'IsIdentity') 		as is_identity_column,
	columnproperty(t1.[object_id], t1.[name], 'IsIdNotForRepl') 	as is_identity_not_for_replication,
	isnull(t2.seed_value, 0)										as identity_seed,
	isnull(t2.increment_value, 0)									as identity_increment,
	t1.default_object_id											as bound_default_id,
	case
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(object_name(t1.default_object_id), '')
		else ''
	end																as bound_default_name,
	case
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.default_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end																as bound_default_owner_name,
	t1.rule_object_id												as bound_rule_id,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(object_name(t1.rule_object_id), '')
		else ''
	end																as bound_rule_name,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.rule_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end																as bound_rule_owner_name,
	t1.max_length													as max_length,
	t1.is_rowguidcol												as is_rowguidcol,
	t1.is_filestream												as is_filestream,
	t1.is_replicated												as is_replicated,
	t1.is_non_sql_subscribed										as is_non_sql_subscribed,
	t1.is_merge_published											as is_merge_published,
	t1.is_dts_replicated											as is_dts_replicated,
	t1.is_xml_document												as is_xml_document,
	t1.xml_collection_id											as xml_collection_id,
	''																as computed_definition,
	cast(0 as bit)													as uses_database_collation,
	cast(0 as bit)													as is_persisted,
	cast(isnull(t1.is_ansi_padded, 0) as int)						as is_ansi_padding_on,
	t1.is_sparse													as is_sparse,
	t1.is_column_set												as is_column_set,
	
	isnull(schema_name(t3.[schema_id]),'')							as user_type_schema_name,
	isnull(schema_name(xsc.schema_id),'')							as xml_collection_schema_name,
	isnull(xsc.name,'')												as xml_collection_name,
	t1.is_computed													as is_computed
from	sys.columns as t1
		left outer join sys.identity_columns as t2 on 
			t1.object_id = t2.object_id
		LEFT JOIN sys.types t3 ON t3.user_type_id = t1.user_type_id
		left join sys.xml_schema_collections xsc on xsc.xml_collection_id = t1.xml_collection_id
where	
	t1.[object_id]={0}
	and
	t1.is_computed = 0
union all
select
	t1.[object_id]													as table_id,
	t1.column_id													as column_id,
	t1.[name]														as column_name,
	t1.user_type_id													as user_type_id,
	isnull(type_name(t1.user_type_id), '')							as user_type_name,
	t1.system_type_id												as native_type_id,
	isnull(type_name(t1.system_type_id), '')						as native_type_name,
	isnull(t1.collation_name, '')									as collation_name,
	t1.[precision]													as column_precision,
	t1.scale														as column_scale,
	t1.is_nullable													as is_nullable,
	t1.is_identity													as is_identity,
	columnproperty(t1.[object_id], t1.[name], 'IsIdentity') 		as is_identity_column,
	columnproperty(t1.[object_id], t1.[name], 'IsIdNotForRepl') 	as is_identity_not_for_replication,
	isnull(t2.seed_value, 0)										as identity_seed,
	isnull(t2.increment_value, 0)									as identity_increment,
	t1.default_object_id											as bound_default_id,
	case 
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(object_name(t1.default_object_id), '')
		else ''
	end																as bound_default_name,
	case
		when objectpropertyex(t1.default_object_id, 'IsDefault') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.default_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end																as bound_default_owner_name,
	t1.rule_object_id												as bound_rule_id,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(object_name(t1.rule_object_id), '')
		else ''
	end																as bound_rule_name,
	case
		when objectpropertyex(t1.rule_object_id, 'IsRule') = 1
		then isnull(schema_name(cast(isnull(objectpropertyex(t1.rule_object_id, 'SchemaId'), 0) as int)), '')
		else ''
	end																as bound_rule_owner_name,
	t1.max_length													as max_length,
	t1.is_rowguidcol												as is_rowguidcol,
	t1.is_filestream												as is_filestream,
	t1.is_replicated												as is_replicated,
	t1.is_non_sql_subscribed										as is_non_sql_subscribed,
	t1.is_merge_published											as is_merge_published,
	t1.is_dts_replicated											as is_dts_replicated,
	t1.is_xml_document												as is_xml_document,
	t1.xml_collection_id											as xml_collection_id,
	isnull(t1.definition, '')   									as computed_definition,
	t1.uses_database_collation										as uses_database_collation,
	t1.is_persisted													as is_persisted,
	cast(isnull(t1.is_ansi_padded, 0) as int)						as is_ansi_padding_on,
	t1.is_sparse													as is_sparse,
	t1.is_column_set												as is_column_set,
	
	isnull(schema_name(t3.[schema_id]),'')							as user_type_schema_name,
	isnull(schema_name(xsc.schema_id),'')							as xml_collection_schema_name,
	isnull(xsc.name,'')												as xml_collection_name,
	t1.is_computed													as is_computed
from	sys.computed_columns as t1
		left outer join sys.identity_columns as t2 on 
			t1.object_id = t2.object_id
		LEFT JOIN sys.types t3 ON t3.user_type_id = t1.user_type_id
		left join sys.xml_schema_collections xsc on xsc.xml_collection_id = t1.xml_collection_id
where
	t1.[object_id]={0}