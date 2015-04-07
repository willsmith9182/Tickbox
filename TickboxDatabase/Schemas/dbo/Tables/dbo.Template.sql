CREATE TABLE [dbo].[Template]
(
	TemplateId			INT				NOT NULL	IDENTITY(1,1),
	Name				VARCHAR(100)	NOT NULL,
	DocumentLink		VARCHAR(MAX)	NULL,
	IsScaffold			BIT				NOT NULL,
	IsMaster			BIT				NOT NULL	DEFAULT 0, 
    CONSTRAINT [PK_Template]
		PRIMARY KEY CLUSTERED (TemplateId)
)
GO;
CREATE UNIQUE NONCLUSTERED INDEX [IX_MasterSingleton] ON [dbo].[Template] (IsMaster) where IsMaster=1;
GO;