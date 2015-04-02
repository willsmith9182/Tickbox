CREATE TABLE [dbo].[Taxonomy]
(
	TaxonomyId				INT				NOT NULL	IDENTITY(1,1),
	TemplateId				INT				NOT NULL,
	Title					VARCHAR(150)	NOT NULL,
	IsScaffold				BIT				NOT NULL

	CONSTRAINT [PK_Taxonomy] 
		PRIMARY KEY CLUSTERED (TaxonomyId),

	CONSTRAINT [FK_Taxonomy_Template]
		FOREIGN KEY (TemplateId) REFERENCES dbo.Template(TemplateId)
)
