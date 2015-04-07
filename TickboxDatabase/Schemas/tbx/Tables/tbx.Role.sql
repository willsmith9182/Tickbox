CREATE TABLE [tbx].[Role]
(
	[RoleId]			INT				NOT NULL	IDENTITY(1,1),
	[RoleDesc]			VARCHAR(150)	NOT NULL

	CONSTRAINT 
		[tbxRole_PK] 
	PRIMARY KEY(
		RoleId
	)
)
