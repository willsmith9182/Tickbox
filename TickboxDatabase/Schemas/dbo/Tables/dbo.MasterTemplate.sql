CREATE TABLE [dbo].[MasterTemplate]
(
	MasterTemplateId			INT				NOT NULL	IDENTITY(1,1),	
	LockedTemplate				BIT				NOT NULL,
	CONSTRAINT
		[dboMasterTemplate_PK]
	PRIMARY KEY (
		MasterTemplateId
	)
)
