CREATE TABLE [dbo].[Template]
(
	TemplateId			INT				NOT NULL	IDENTITY(1,1),
	Name				VARCHAR(100)	NOT NULL,
	DocumentLink		VARCHAR(MAX)	NOT NULL,
	IsScaffold			BIT				NOT NULL,
	CONSTRAINT [PK_Template]
		PRIMARY KEY CLUSTERED (TemplateId)
)
