CREATE TABLE [tbx].[User]
(
	[UserId]				INT					NOT NULL IDENTITY(1,1),
	[FirstName]				VARCHAR(150)		NOT NULL,
	[LastName]				VARCHAR(150)		NOT NULL,
	[EmailAddress]			VARCHAR(200)		NOT NULL,
	[PasswordSHA256B64]		VARCHAR(MAX)		NOT NULL,
	--[ActiveDirectioryGuid]	UNIQUEIDENTIFIER	NULL,
	[IsActive]				BIT					NOT NULL,
	--[IsInternal]			BIT					NOT NULL

	CONSTRAINT
		[tbxUser_PK]
	PRIMARY KEY(
		UserId
	)
)
