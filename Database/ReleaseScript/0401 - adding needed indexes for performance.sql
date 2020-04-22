--alter table dbo.Project add ProjectDetail_PrimaryKey as ProjectID


CREATE NONCLUSTERED INDEX [IDX_Project_TaxonomyLeaf]
ON [dbo].[Project] ([TaxonomyLeafID])
INCLUDE ([TenantID],[ProjectName],[PrimaryContactPersonID])


CREATE NONCLUSTERED INDEX [IDX_ProjectGeospatialArea_Project]
ON [dbo].[ProjectGeospatialArea] ([ProjectID])
INCLUDE ([TenantID])

CREATE NONCLUSTERED INDEX [IDX_ProjectGeospatialArea_Tenant]
ON [dbo].[ProjectGeospatialArea] ([TenantID])

CREATE NONCLUSTERED INDEX [IDX_ProjectCustomAttributeValue_ProjectCustomAttribute]
ON [dbo].[ProjectCustomAttributeValue] ([ProjectCustomAttributeID])
INCLUDE ([TenantID])


CREATE NONCLUSTERED INDEX [IDX_ProjectCustomAttributeValue_Tenant]
ON [dbo].[ProjectCustomAttributeValue] ([TenantID])

CREATE NONCLUSTERED INDEX [IDX_ProjectCustomAttribute_Tenant]
ON [dbo].[ProjectCustomAttribute] ([TenantID])

