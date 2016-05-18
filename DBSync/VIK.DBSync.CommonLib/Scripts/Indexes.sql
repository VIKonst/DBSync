select
	t1.[object_id]				as parent_table_id,
	t1.index_id					as index_id,
	t1.[name]					as index_name,
	t1.is_unique				as is_unique,
	t1.[type]					as index_type,
	t1.[type_desc]				as [type_desc],
	t1.fill_factor				as fill_factor,
	t1.is_padded				as is_padded,
	t1.ignore_dup_key			as ignore_dup_key,
	isnull(t2.no_recompute,0)	as no_recompute,
	t1.allow_row_locks			as allow_row_locks,
	t1.allow_page_locks			as allow_page_locks,
	t1.data_space_id			as data_space_id,
	t1.is_disabled				as is_disabled,
	t1.is_primary_key			as is_primary_key,
	indexproperty(t1.[object_id], t1.[name], 'IsClustered')		
								as is_clustered,
	t1.is_unique_constraint		as is_unique_constraint,
	ISNULL(ds.name, '')			as data_space_name,
	ISNULL(xmlt.secondary_type_desc,'')	as xml_secondary_type,
	ISNULL(xmlt.xml_index_type,0)	as xml_type,
	ISNULL(using_xml_index_id,0)	as using_xml_index_id

from	sys.indexes as t1
		left join sys.xml_indexes as xmlt on t1.index_id=xmlt.index_id and t1.object_id = xmlt.object_id
		left join sys.stats as t2 on
		t1.[object_id] = t2.[object_id]
			and
			t1.index_id = t2.stats_id		
		left join sys.data_spaces ds on
			ds.data_space_id = t1.data_space_id
where	t1.[object_id]	= {0} 
	and 	
	t1.is_hypothetical = 0
	and
	t1.[type] between 1 and 3
order by t1.[name]
