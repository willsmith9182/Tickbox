CREATE TABLE [tbx].[UserRole]
(
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL,
		
	CONSTRAINT
		[tbxUserRole_PK]
	PRIMARY KEY(
		UserId,
		RoleId
	),

	CONSTRAINT
		[tbxUserRole_tbx_User_FK] 
	FOREIGN KEY(
		UserId
	) 
	REFERENCES [tbx].[User](
		UserId
	),
	
	CONSTRAINT
		[tbxUserRole_tbx_Role_FK]
	FOREIGN KEY(
		RoleId
	) 
	REFERENCES [tbx].[Role](
		RoleId
	)
)
