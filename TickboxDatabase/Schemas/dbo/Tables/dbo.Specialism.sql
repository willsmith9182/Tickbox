CREATE TABLE [dbo].[Specialism]
(
	SpecialismId				INT				NOT NULL	IDENTITY(1,1),
	SpecialismDesc				VARCHAR(100)	NOT NULL,
	CONSTRAINT [PK_Specialism]
		PRIMARY KEY CLUSTERED (SpecialismId)
)
