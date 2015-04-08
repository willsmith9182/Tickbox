CREATE TABLE [dbo].[TreeNode]
(
	TreeNodeId			INT			NOT NULL	IDENTITY(1,1),
	TaxonomyId			INT			NOT NULL,
	ParentTreeNodeId	INT			NULL,
	NodeId				INT			NOT NULL,

	CONSTRAINT [PK_TreeNode]
		PRIMARY KEY CLUSTERED (TreeNodeId),

	CONSTRAINT [FK_TreeNode_Node] 
		FOREIGN KEY (NodeId) REFERENCES dbo.Node(NodeId),

	CONSTRAINT [FK_TreeNode_TreeNode] 
		FOREIGN KEY (ParentTreeNodeId) REFERENCES dbo.TreeNode(TreeNodeId),

	CONSTRAINT [FK_TreeNode_Taxonomy]
		FOREIGN KEY(TaxonomyId) REFERENCES dbo.Taxonomy(TaxonomyId)

)
