--alter table dbo.Project add ProjectDetail_PrimaryKey as ProjectID


CREATE NONCLUSTERED INDEX [IDX_Project_TaxonomyLeaf]
ON [dbo].[Project] ([TaxonomyLeafID])
INCLUDE ([TenantID],[ProjectName],[PrimaryContactPersonID])
