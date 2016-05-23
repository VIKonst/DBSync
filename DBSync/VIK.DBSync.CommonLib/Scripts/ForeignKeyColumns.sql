﻿select	t1.constraint_object_id		as foreign_key_id,	t1.constraint_column_id		as foreign_key_column_id,	t1.parent_object_id			as parent_object_id,	COL_NAME(t1.parent_object_id, t1.parent_column_id) as parent_column_name,	t1.referenced_object_id		as referenced_object_id,	COL_NAME(t1.referenced_object_id, t1.referenced_column_id)as referenced_column_namefrom	sys.foreign_key_columns as t1--where t1.parent_object_id={0}order by	t1.parent_object_id, t1.constraint_object_id, t1.constraint_column_id