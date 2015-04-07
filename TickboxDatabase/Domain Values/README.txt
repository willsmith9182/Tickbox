static data. folders to represent schema

use merge syntax:
MERGE [schema].[table] AS TARGET
USING(
	SELECT 
		TABLE COLUMNS
		FROM 
			(VALUES
				(table,data,values),
				(table,data,values)				
			) AS DATA(Each, column, name, in, select)
	) AS SOURCE
	ON (UNIQUE MATCH BETWEEN VALUES DATA AND RTABLE DATA)
	// 
	WHEN MATCHED THEN
	UPDATE SET TARGET.[columnName] = SOURCE.[columnName], TARGET.Cost = SOURCE.Cost
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(Each, column, name, in, values) values (SOURCE.[columnName])
	WHEN NOT MATCHED BY SOURCE THEN DELETE;
