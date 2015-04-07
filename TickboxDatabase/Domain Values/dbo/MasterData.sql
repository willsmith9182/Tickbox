MERGE [dbo].[Template] AS TARGET
USING(
	SELECT 
		TemplateId,
		Name,
		DocumentLink,
		IsScaffold,
		IsMaster
	FROM 
		(VALUES
			(1,'MasterTemplate',null,1,1)					
		) AS DATA(
			TemplateId,
			Name,
			DocumentLink,
			IsScaffold,
			IsMaster
		)
	) AS SOURCE
	ON (TARGET.TemplateId = SOURCE.TemplateId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.[Name] = SOURCE.[Name],
			TARGET.[DocumentLink] = SOURCE.[DocumentLink],
			TARGET.[IsScaffold] = SOURCE.[IsScaffold],
			TARGET.[IsMaster] = SOURCE.[IsMaster]
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			Name,
			DocumentLink,
			IsScaffold,
			IsMaster
		) values (
			SOURCE.Name,
			Source.DocumentLink,
			Source.IsScaffold,
			Source.IsMaster
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;

MERGE [dbo].[Taxonomy] AS TARGET
USING(
	SELECT 
		TaxonomyId,
		TemplateId,
		Title,
		IsScaffold		
	FROM 
		(VALUES
			(1,1,'MasterTaxonomy',1)					
		) AS DATA(
			TaxonomyId,
			TemplateId,
			Title,
			IsScaffold
		)
	) AS SOURCE
	ON (TARGET.TaxonomyId = SOURCE.TaxonomyId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.TemplateId = SOURCE.TemplateId,
			TARGET.Title = SOURCE.Title,
			TARGET.IsScaffold = SOURCE.IsScaffold
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			TemplateId,
			Title,
			IsScaffold
		) values (
			SOURCE.TemplateId,
			SOURCE.Title,
			SOURCE.IsScaffold
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;

MERGE [dbo].[Specialism] AS TARGET
USING(
	SELECT 
		SpecialismId,
		SpecialismDesc,		
		IsScaffold		
	FROM 
		(VALUES
			(1,'MasterSpecialism',1)					
		) AS DATA(
			SpecialismId,
			SpecialismDesc,		
			IsScaffold	
		)
	) AS SOURCE
	ON (TARGET.SpecialismId = SOURCE.SpecialismId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.SpecialismDesc = SOURCE.SpecialismDesc,
			TARGET.IsScaffold = SOURCE.IsScaffold
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			SpecialismDesc,		
			IsScaffold
		) values (
			SOURCE.SpecialismDesc,				
			SOURCE.IsScaffold
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;


MERGE [dbo].[TaxonomySpecialism] AS TARGET
USING(
	SELECT 
		TaxonomyId,
		SpecialismId
	FROM 
		(VALUES
			(1,1)					
		) AS DATA(
			TaxonomyId,
			SpecialismId	
		)
	) AS SOURCE
	ON (TARGET.TaxonomyId = SOURCE.TaxonomyId AND TARGET.SpecialismId = SOURCE.SpecialismId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.TaxonomyId = SOURCE.TaxonomyId,
			TARGET.SpecialismId = SOURCE.SpecialismId
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			TaxonomyId,
			SpecialismId
		) values (
			SOURCE.TaxonomyId,
			SOURCE.SpecialismId
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;

MERGE [dbo].[Node] AS TARGET
USING(
	SELECT 
		NodeId,
		NodeTitle,
		NodeDesc,
		ChildrenMultiSelect
	FROM 
		(VALUES
			(1,'Root','The docuemnt root',1)					
		) AS DATA(
			NodeId,
			NodeTitle,
			NodeDesc,
			ChildrenMultiSelect	
		)
	) AS SOURCE
	ON (TARGET.NodeId= SOURCE.NodeId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.NodeTitle = SOURCE.NodeTitle,
			TARGET.NodeDesc = SOURCE.NodeDesc,
			TARGET.ChildrenMultiSelect = SOURCE.ChildrenMultiSelect
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			NodeTitle,
			NodeDesc,
			ChildrenMultiSelect
		) values (
			SOURCE.NodeTitle,
			SOURCE.NodeDesc,
			SOURCE.ChildrenMultiSelect
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;


MERGE [dbo].[NodeSpecialism] AS TARGET
USING(
	SELECT 
		NodeSpecialismId,
		NodeId,
		SpecialismId,
		SequenceOrder,
		GuideLines,
		DocumentLink,
		IsScaffold
	FROM 
		(VALUES
			(1,1,1,0,'Don''t delete this node definition.','',1)					
		) AS DATA(
			NodeSpecialismId,
			NodeId,
			SpecialismId,
			SequenceOrder,
			GuideLines,
			DocumentLink,
			IsScaffold
		)
	) AS SOURCE
	ON (TARGET.NodeSpecialismId= SOURCE.NodeSpecialismId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.NodeId = SOURCE.NodeId,
			TARGET.SpecialismId = SOURCE.SpecialismId,
			TARGET.SequenceOrder = SOURCE.SequenceOrder,
			TARGET.GuideLines = SOURCE.GuideLines,
			TARGET.DocumentLink = SOURCE.DocumentLink,
			TARGET.IsScaffold = SOURCE.IsScaffold			
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(
			NodeId,
			SpecialismId,
			SequenceOrder,
			GuideLines,
			DocumentLink,
			IsScaffold
		) values (
			SOURCE.NodeId,
			SOURCE.SpecialismId,
			SOURCE.SequenceOrder,
			SOURCE.GuideLines,
			SOURCE.DocumentLink,
			SOURCE.IsScaffold
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;

MERGE [dbo].[TreeNode] AS TARGET
USING(
	SELECT 
		TreeNodeId,
		TaxononmyId,
		ParentTreeNodeId,
		NodeId,		
		IsScaffold
	FROM 
		(VALUES
			(1,1,null,1,1)					
		) AS DATA(
			TreeNodeId,
			TaxononmyId,
			ParentTreeNodeId,
			NodeId,		
			IsScaffold
		)
	) AS SOURCE
	ON (TARGET.TreeNodeId= SOURCE.TreeNodeId)
		
	WHEN MATCHED THEN
		UPDATE SET 
			TARGET.TaxonomyId = SOURCE.TaxononmyId,
			TARGET.ParentTreeNodeId = SOURCE.ParentTreeNodeId,
			TARGET.NodeId = SOURCE.NodeId,			
			TARGET.IsScaffold = SOURCE.IsScaffold			
	WHEN NOT MATCHED BY TARGET THEN
		INSERT(			
			TaxonomyId,
			ParentTreeNodeId,
			NodeId,		
			IsScaffold
		) values (
			SOURCE.TaxononmyId,
			SOURCE.ParentTreeNodeId,
			SOURCE.NodeId,		
			SOURCE.IsScaffold
		)
	WHEN NOT MATCHED BY SOURCE THEN 
		DELETE;
