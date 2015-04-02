CREATE TABLE [dbo].[TaxonomySpecialism]
(
	TaxonomyId				INT				NOT NULL,
	SpecialismId			INT				NOT NULL,

	CONSTRAINT [PK_TaxnonomySpecialism]
		PRIMARY KEY CLUSTERED (TaxonomyId, SpecialismId),

	CONSTRAINT [FK_TaxonomySpecialism_Taxonomy]
		FOREIGN KEY (TaxonomyId) REFERENCES dbo.Taxonomy(TaxonomyID),

	CONSTRAINT [FK_TaxonomySpecialism_Specialism]
		FOREIGN KEY (SpecialismId) REFERENCES dbo.Specialism(SpecialismID)
)
