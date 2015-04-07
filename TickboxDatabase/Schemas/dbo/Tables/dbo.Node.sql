CREATE TABLE [dbo].[Node]
(
	NodeId					INT				NOT NULL	IDENTITY(1,1),
	NodeTitle				VARCHAR(150)	NOT NULL,
	NodeDesc				VARCHAR(max)	NOT NULL,
	ChildrenMultiSelect		BIT				NOT NULL
	CONSTRAINT [PK_Node]
		PRIMARY KEY CLUSTERED (NodeId)
)
