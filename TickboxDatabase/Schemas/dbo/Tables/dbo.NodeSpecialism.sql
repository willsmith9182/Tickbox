CREATE TABLE [dbo].[NodeSpecialism]
(
	NodeSpecialismId			INT				NOT NULL	IDENTITY(1,1),
	NodeId						INT				NOT NULL,
	SpecialismId				INT				NOT NULL,
	SequenceOrder				INT				NOT NULL,
	Guidelines					VARCHAR(MAX)	NOT NULL,
	DocumentLink				VARCHAR(MAX)	NOT NULL,

	CONSTRAINT [PK_NodeSpecilaism] 
				PRIMARY KEY CLUSTERED (NodeSpecialismId),

	CONSTRAINT [FK_NodeSpecialism_Node] 
				FOREIGN KEY (NodeId) REFERENCES dbo.Node(NodeId),

	CONSTRAINT [FK_NodeSpecialism_Specialism]
				FOREIGN KEY (SpecialismId) REFERENCES dbo.Specialism(SpecialismId)


)
