CREATE TABLE [dbo].[Template]
(
	TemplateId			INT				NOT NULL	IDENTITY(1,1),
	MasterTemplateId	INT				NOT NULL,
	Name				VARCHAR(100)	NOT NULL,
	DocumentLink		VARCHAR(MAX)	NULL,
	
    CONSTRAINT [PK_Template]
		PRIMARY KEY CLUSTERED (TemplateId),
	CONSTRAINT [FK_dboTemplate_MasterTemplate] FOREIGN KEY(MasterTemplateID) REFERENCES [dbo].[MasterTemplate](MasterTemplateId)
)
